
using ComputeSharp;
using ComputeSharp.Resources;
using Newtonsoft.Json.Linq;
using System.IO;

namespace NET8Draw
{
    public partial class Form1 : Form
    {
        NETDrawingHandler drawingAppHandler = new NETDrawingHandler();
        CustomMouseEventHandler mouseEvents;
        NewCanvasForm newCanvasF;
        private LayerButton b;
        int currentValue = 12;

        string defualtApplicationSettings = "{\"CanvasData\": {\"Width\":512,\"Height\":512,\"Hue\": 255},\"BrushData\":{\"LastBrush\":\"pen\",\"Size\":5,\"Opacity\":1.0,\"Color\": [0.0, 0.0, 0.0, 1.0]},\"ApplicationData\":{}}";
        JObject lastSettings;

        string baseAppDir = Path.GetFullPath(Application.ExecutablePath).Replace(Path.GetFileName(Application.ExecutablePath), "");
        string resourceDir = @"Resources\";
        string baseDataDir = @"UserData\";
        string customBrushesDir = @"CustomBrush\";
        string lastLaunchOptions = @"LastLaunch.json";

        public Form1()
        {
            InitializeComponent();



            baseDataDir = baseAppDir + baseDataDir;
            customBrushesDir = baseDataDir + customBrushesDir;
            lastLaunchOptions = baseDataDir + lastLaunchOptions;
            resourceDir = baseAppDir + resourceDir;

            PencilToolButton.Click += changeToPencil;
            PenToolButton.Click += changeToPen;
            EraserToolButton.Click += changeToEraser;
            CustomToolButton.Click += changeToCustom;

            c.MouseEnter += CanvasMouseEnter;
            c.MouseLeave += CanvasMouseLeave;

            
            if (!Directory.Exists(baseDataDir))
            {
                Directory.CreateDirectory(baseDataDir);
            }
            if (!Directory.Exists(customBrushesDir))
            {
                Directory.CreateDirectory(customBrushesDir);
            }

            if (!File.Exists(lastLaunchOptions))
            {
                File.Create(lastLaunchOptions).Close();
                //write default settings
                lastSettings = JObject.Parse(defualtApplicationSettings);
                lastSettings["ApplicationData"]["Width"] = this.Width;
                lastSettings["ApplicationData"]["Height"] = this.Height;

                File.WriteAllText(lastLaunchOptions, lastSettings.ToString());
            }
            else
            {
                //load
                lastSettings = JObject.Parse(File.ReadAllText(lastLaunchOptions));
                this.Width = ((int)lastSettings["ApplicationData"]["Width"]);
                this.Height = (int)lastSettings["ApplicationData"]["Height"];
                this.Location = new Point((int)lastSettings["ApplicationData"]["PositionX"], (int)lastSettings["ApplicationData"]["PositionY"]);
                switch(((int)lastSettings["ApplicationData"]["WindowMode"]))
                {
                    case 0:
                        this.WindowState = FormWindowState.Normal;
                        break;
                    case 1:
                        this.WindowState = FormWindowState.Minimized;
                        break;
                    case 2:
                        this.WindowState = FormWindowState.Maximized;
                        break;
                    default:
                        this.WindowState = FormWindowState.Maximized;
                        break;
                }
            }   


            foreach (Control c in ToolsQuickSizesSplit.Panel1.Controls)
            {
                c.Width = ToolsQuickSizesSplit.Panel1.Width;
                c.Height = ToolsQuickSizesSplit.Panel1.Width;
            }

            for (int i = 1; i <= 10; i++)
            {
                int t = i;
                Button b = new Button();
                b.Text = i.ToString();
                b.Width = ToolListToolSizeSplitter.Panel2.Width;
                b.Height = ToolListToolSizeSplitter.Panel2.Width;
                b.Dock = DockStyle.Top;
                b.Click += (object? sender, EventArgs e) => {
                    //change Pixel size
                    drawingAppHandler.changeToolSize(t);
                };
                ToolListToolSizeSplitter.Panel2.Controls.Add(b);
                ToolListToolSizeSplitter.Panel2.Controls.SetChildIndex(b, 0);
            }

            for (int i = 1; i < 40; i++)
            {
                int t = currentValue;
                Button b = new Button();
                b.Text = currentValue.ToString();
                b.Width = ToolListToolSizeSplitter.Panel2.Width;
                b.Height = ToolListToolSizeSplitter.Panel2.Width;
                b.Dock = DockStyle.Top;
                b.Click += (object? sender, EventArgs e) => {
                    //change Pixel size
                    drawingAppHandler.changeToolSize(t);
                };
                ToolListToolSizeSplitter.Panel2.Controls.Add(b);
                ToolListToolSizeSplitter.Panel2.Controls.SetChildIndex(b, 0);
                currentValue += 4;
                if(i % 2 == 0)
                {
                    currentValue += 2;
                }
            }


            canvasQuickToolsSplit.Panel2.Controls.Add(drawingCanvas);
            drawingCanvas.Child = c;
            this.FormClosing += startClosing;
            colorPicker1.setHandler(drawingAppHandler);
            colorPicker1.calculateHue(1);
            //quickLayerColorPickerSPlitter.Panel1//Color picker
            //drawingCanvas.Bounds
        }

        private void CanvasMouseLeave(object? sender, EventArgs e)
        {
            Cursor.Current = Cursors.Default;
        }

        private void CanvasMouseEnter(object? sender, EventArgs e)
        {
            Cursor.Current = Cursors.Cross;
        }

        private void changeToCustom(object? sender, EventArgs e)
        {
            loadToolType(ToolType.Custom);
        }

        private void changeToEraser(object? sender, EventArgs e)
        {
            loadToolType(ToolType.Eraser);
        }

        private void changeToPen(object? sender, EventArgs e)
        {
            loadToolType(ToolType.Pen);
        }

        private void changeToPencil(object? sender, EventArgs e)
        {
            loadToolType(ToolType.Pencil);
        }
        internal void initNewCanvas(int width, int height)
        {
            initCanvas(width, height);
            lastSettings["CanvasData"]["Width"] = width;
            lastSettings["CanvasData"]["Height"] = height;
            
            mouseEvents.enable();
        }

        JObject tempBrushObject;
        public void loadToolType(ToolType t)
        {
            try
            {
                ToolListToolSizeSplitter.Panel1.Controls.Clear();
                foreach (string item in Directory.GetFiles(baseDataDir + t))
                {
                    Button b = new Button();
                    b.Dock = DockStyle.Top;
                    tempBrushObject = JObject.Parse(File.ReadAllText(item));
                    b.Text = tempBrushObject["Name"].ToString();
                    b.Width = ToolListToolSizeSplitter.Panel1.Width;
                    b.Height = ToolListToolSizeSplitter.Panel1.Width;
                    ToolListToolSizeSplitter.Panel1.Controls.Add(b);
                    b.Name = item;
                    b.Click += changeToolTo;
                }
            }
            catch
            {

            }
            
        }

        private void changeToolTo(object? sender, EventArgs e)
        {
            tempBrushObject = JObject.Parse(File.ReadAllText(((Control)sender).Name));
            //???? How should i handle different brushes, right now i can only really do it based on color
            //drawingAppHandler.changeToolSize();
            drawingAppHandler.changeToolType((ToolType)((int)tempBrushObject["StrokeMethod"]));
        }

        private void NewCanvas_Click(object sender, EventArgs e)
        {
            openForm();
            newCanvasF = new NewCanvasForm(this, int.Parse(lastSettings["CanvasData"]["Width"].ToString()), int.Parse(lastSettings["CanvasData"]["Height"].ToString()));
        }




        public void initCanvas(int w, int h)
        {
            c.changeCanvasSize(w, h);
            drawingAppHandler.newCanvas(w, h, c);
            mouseEvents = new CustomMouseEventHandler(drawingAppHandler, this, drawingCanvas);
            newLayer();
        }

        public void newLayer()
        {
            LayersColorPickerSplitter.Panel2.Controls.Add(b = new LayerButton(drawingAppHandler, drawingAppHandler.creteNewLayer()));
            drawingAppHandler.addNewLayerPreview(b.getID(), b);
        }


        private void startClosing(object? sender, FormClosingEventArgs e)
        {
            updatePreviousSettings();
            if (mouseEvents != null)
            {
                mouseEvents.close();
            }
        }

        private void updatePreviousSettings()
        {
            lastSettings["ApplicationData"]["Width"] = this.Width;
            lastSettings["ApplicationData"]["Height"] = this.Height;
            lastSettings["ApplicationData"]["PositionX"] = this.Location.X;
            lastSettings["ApplicationData"]["PositionY"] = this.Location.Y;
            lastSettings["ApplicationData"]["WindowMode"] = ((int)this.WindowState);

            File.WriteAllText(lastLaunchOptions, lastSettings.ToString());
        }



        internal void enableMouse()
        {
            mouseEvents.enable();
        }

        private void changeToolSize(object sender, EventArgs e)
        {
            drawingAppHandler.changeToolSize(((NumericUpDown)sender).Value);
        }


        public void openForm()
        {
            formsOpen++;
        }

        public void closeForm()
        {
            formsOpen--;
            Console.WriteLine("FOrm Closed");
        }



        int formsOpen = 0;
        internal bool isFocused()
        {
            if (formsOpen == 0 && Form.ActiveForm != null)
            {
                return true;
            }
            return false;
        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog dialogue = new SaveFileDialog() { DefaultExt = ".png", Filter = "PNG (*.png)|*.png|JPEG (*.jpg)|*.jpg|All Files (*.*)|*.*" })
            {
                if (dialogue.ShowDialog() == DialogResult.OK)
                {
                    Console.WriteLine(dialogue.FileName);
                    drawingAppHandler.saveCanvas(dialogue.FileName);
                }
            }
        }

        private void newLayerButton_Click(object sender, EventArgs e)
        {
            newLayer();
        }

        internal bool isInsideCanvas(Point p)
        {
            return canvasQuickToolsSplit.Panel2.Bounds.Contains(p);
        }

        System.Windows.Point tempP = new System.Windows.Point();
        internal void updateCirclePos(Point currentMouse)
        {
            tempP.X = currentMouse.X;
            tempP.Y = currentMouse.Y;
            c.updateRadPos(tempP);
        }
    }
}
