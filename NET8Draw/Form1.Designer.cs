using System.Windows.Forms.Integration;
using System.Windows.Input;
using DrawingCanvas;
namespace NET8Draw
{
    partial class Form1
    {
        

        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            MenuCanvasSplitter = new SplitContainer();
            menuStrip1 = new MenuStrip();
            fileToolStripMenuItem = new ToolStripMenuItem();
            newToolStripMenuItem = new ToolStripMenuItem();
            newCanvas = new ToolStripMenuItem();
            openToolStripMenuItem = new ToolStripMenuItem();
            saveToolStripMenuItem = new ToolStripMenuItem();
            saveAsToolStripMenuItem = new ToolStripMenuItem();
            editToolStripMenuItem = new ToolStripMenuItem();
            insertToolStripMenuItem = new ToolStripMenuItem();
            canvasToolStripMenuItem = new ToolStripMenuItem();
            ToolCanvasSplitter = new SplitContainer();
            ToolsQuickSizesSplit = new SplitContainer();
            CustomToolButton = new PictureBox();
            EraserToolButton = new PictureBox();
            PencilToolButton = new PictureBox();
            PenToolButton = new PictureBox();
            ToolListToolSizeSplitter = new SplitContainer();
            CanvasLayersSplitter = new SplitContainer();
            canvasQuickToolsSplit = new SplitContainer();
            numericUpDown1 = new NumericUpDown();
            label4 = new Label();
            AAModes = new ComboBox();
            label3 = new Label();
            AlphaBrush = new CheckBox();
            opacitySlider = new NumericUpDown();
            label2 = new Label();
            ToolSizeSlider = new NumericUpDown();
            label1 = new Label();
            drawingCanvas = new ElementHost();
            LayersColorPickerSplitter = new SplitContainer();
            quickLayerColorPickerSPlitter = new SplitContainer();
            HueColorpickerSplitter = new SplitContainer();
            colorPicker1 = new ColorPicker();
            Hue = new TrackBar();
            splitContainer1 = new SplitContainer();
            LayerOpacity = new TrackBar();
            comboBox1 = new ComboBox();
            newFolderButton = new Button();
            newLayerButton = new Button();
            ((System.ComponentModel.ISupportInitialize)MenuCanvasSplitter).BeginInit();
            MenuCanvasSplitter.Panel1.SuspendLayout();
            MenuCanvasSplitter.Panel2.SuspendLayout();
            MenuCanvasSplitter.SuspendLayout();
            menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)ToolCanvasSplitter).BeginInit();
            ToolCanvasSplitter.Panel1.SuspendLayout();
            ToolCanvasSplitter.Panel2.SuspendLayout();
            ToolCanvasSplitter.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)ToolsQuickSizesSplit).BeginInit();
            ToolsQuickSizesSplit.Panel1.SuspendLayout();
            ToolsQuickSizesSplit.Panel2.SuspendLayout();
            ToolsQuickSizesSplit.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)CustomToolButton).BeginInit();
            ((System.ComponentModel.ISupportInitialize)EraserToolButton).BeginInit();
            ((System.ComponentModel.ISupportInitialize)PencilToolButton).BeginInit();
            ((System.ComponentModel.ISupportInitialize)PenToolButton).BeginInit();
            ((System.ComponentModel.ISupportInitialize)ToolListToolSizeSplitter).BeginInit();
            ToolListToolSizeSplitter.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)CanvasLayersSplitter).BeginInit();
            CanvasLayersSplitter.Panel1.SuspendLayout();
            CanvasLayersSplitter.Panel2.SuspendLayout();
            CanvasLayersSplitter.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)canvasQuickToolsSplit).BeginInit();
            canvasQuickToolsSplit.Panel1.SuspendLayout();
            canvasQuickToolsSplit.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numericUpDown1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)opacitySlider).BeginInit();
            ((System.ComponentModel.ISupportInitialize)ToolSizeSlider).BeginInit();
            ((System.ComponentModel.ISupportInitialize)LayersColorPickerSplitter).BeginInit();
            LayersColorPickerSplitter.Panel1.SuspendLayout();
            LayersColorPickerSplitter.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)quickLayerColorPickerSPlitter).BeginInit();
            quickLayerColorPickerSPlitter.Panel1.SuspendLayout();
            quickLayerColorPickerSPlitter.Panel2.SuspendLayout();
            quickLayerColorPickerSPlitter.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)HueColorpickerSplitter).BeginInit();
            HueColorpickerSplitter.Panel1.SuspendLayout();
            HueColorpickerSplitter.Panel2.SuspendLayout();
            HueColorpickerSplitter.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)colorPicker1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)Hue).BeginInit();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)LayerOpacity).BeginInit();
            SuspendLayout();
            // 
            // MenuCanvasSplitter
            // 
            MenuCanvasSplitter.Dock = DockStyle.Fill;
            MenuCanvasSplitter.FixedPanel = FixedPanel.Panel1;
            MenuCanvasSplitter.IsSplitterFixed = true;
            MenuCanvasSplitter.Location = new Point(0, 0);
            MenuCanvasSplitter.Name = "MenuCanvasSplitter";
            MenuCanvasSplitter.Orientation = Orientation.Horizontal;
            // 
            // MenuCanvasSplitter.Panel1
            // 
            MenuCanvasSplitter.Panel1.AccessibleName = "MenuPanel";
            MenuCanvasSplitter.Panel1.Controls.Add(menuStrip1);
            // 
            // MenuCanvasSplitter.Panel2
            // 
            MenuCanvasSplitter.Panel2.AccessibleDescription = "The container seperate from the menu strip. Contains the tools, layers, color pickrer, etc.";
            MenuCanvasSplitter.Panel2.AccessibleName = "AppContainer";
            MenuCanvasSplitter.Panel2.Controls.Add(ToolCanvasSplitter);
            MenuCanvasSplitter.Size = new Size(1904, 1041);
            MenuCanvasSplitter.SplitterDistance = 25;
            MenuCanvasSplitter.TabIndex = 0;
            // 
            // menuStrip1
            // 
            menuStrip1.Dock = DockStyle.Fill;
            menuStrip1.Items.AddRange(new ToolStripItem[] { fileToolStripMenuItem, editToolStripMenuItem, insertToolStripMenuItem, canvasToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(1904, 25);
            menuStrip1.TabIndex = 0;
            menuStrip1.Text = "FileMenuStrip";
            // 
            // fileToolStripMenuItem
            // 
            fileToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { newToolStripMenuItem, openToolStripMenuItem, saveToolStripMenuItem, saveAsToolStripMenuItem });
            fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            fileToolStripMenuItem.Size = new Size(37, 21);
            fileToolStripMenuItem.Text = "File";
            // 
            // newToolStripMenuItem
            // 
            newToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { newCanvas });
            newToolStripMenuItem.Name = "newToolStripMenuItem";
            newToolStripMenuItem.Size = new Size(123, 22);
            newToolStripMenuItem.Text = "New";
            // 
            // newCanvas
            // 
            newCanvas.Name = "newCanvas";
            newCanvas.Size = new Size(112, 22);
            newCanvas.Text = "Canvas";
            newCanvas.Click += NewCanvas_Click;
            // 
            // openToolStripMenuItem
            // 
            openToolStripMenuItem.Name = "openToolStripMenuItem";
            openToolStripMenuItem.Size = new Size(123, 22);
            openToolStripMenuItem.Text = "Open";
            // 
            // saveToolStripMenuItem
            // 
            saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            saveToolStripMenuItem.Size = new Size(123, 22);
            saveToolStripMenuItem.Text = "Save";
            // 
            // saveAsToolStripMenuItem
            // 
            saveAsToolStripMenuItem.Name = "saveAsToolStripMenuItem";
            saveAsToolStripMenuItem.Size = new Size(123, 22);
            saveAsToolStripMenuItem.Text = "Save As...";
            saveAsToolStripMenuItem.Click += saveAsToolStripMenuItem_Click;
            // 
            // editToolStripMenuItem
            // 
            editToolStripMenuItem.Name = "editToolStripMenuItem";
            editToolStripMenuItem.Size = new Size(39, 21);
            editToolStripMenuItem.Text = "Edit";
            // 
            // insertToolStripMenuItem
            // 
            insertToolStripMenuItem.Name = "insertToolStripMenuItem";
            insertToolStripMenuItem.Size = new Size(48, 21);
            insertToolStripMenuItem.Text = "Insert";
            // 
            // canvasToolStripMenuItem
            // 
            canvasToolStripMenuItem.Name = "canvasToolStripMenuItem";
            canvasToolStripMenuItem.Size = new Size(57, 21);
            canvasToolStripMenuItem.Text = "Canvas";
            // 
            // ToolCanvasSplitter
            // 
            ToolCanvasSplitter.AccessibleDescription = "Beginning of a standard naming from LR. Tools on the left, canvas on the right";
            ToolCanvasSplitter.BorderStyle = BorderStyle.Fixed3D;
            ToolCanvasSplitter.Dock = DockStyle.Fill;
            ToolCanvasSplitter.IsSplitterFixed = true;
            ToolCanvasSplitter.Location = new Point(0, 0);
            ToolCanvasSplitter.Name = "ToolCanvasSplitter";
            // 
            // ToolCanvasSplitter.Panel1
            // 
            ToolCanvasSplitter.Panel1.AccessibleName = "Tools";
            ToolCanvasSplitter.Panel1.Controls.Add(ToolsQuickSizesSplit);
            // 
            // ToolCanvasSplitter.Panel2
            // 
            ToolCanvasSplitter.Panel2.AccessibleName = "Canvas";
            ToolCanvasSplitter.Panel2.Controls.Add(CanvasLayersSplitter);
            ToolCanvasSplitter.Size = new Size(1904, 1012);
            ToolCanvasSplitter.SplitterDistance = 250;
            ToolCanvasSplitter.TabIndex = 0;
            // 
            // ToolsQuickSizesSplit
            // 
            ToolsQuickSizesSplit.BorderStyle = BorderStyle.Fixed3D;
            ToolsQuickSizesSplit.Dock = DockStyle.Fill;
            ToolsQuickSizesSplit.FixedPanel = FixedPanel.Panel2;
            ToolsQuickSizesSplit.Location = new Point(0, 0);
            ToolsQuickSizesSplit.Name = "ToolsQuickSizesSplit";
            // 
            // ToolsQuickSizesSplit.Panel1
            // 
            ToolsQuickSizesSplit.Panel1.Controls.Add(CustomToolButton);
            ToolsQuickSizesSplit.Panel1.Controls.Add(EraserToolButton);
            ToolsQuickSizesSplit.Panel1.Controls.Add(PencilToolButton);
            ToolsQuickSizesSplit.Panel1.Controls.Add(PenToolButton);
            // 
            // ToolsQuickSizesSplit.Panel2
            // 
            ToolsQuickSizesSplit.Panel2.AutoScroll = true;
            ToolsQuickSizesSplit.Panel2.Controls.Add(ToolListToolSizeSplitter);
            ToolsQuickSizesSplit.Size = new Size(250, 1012);
            ToolsQuickSizesSplit.SplitterDistance = 68;
            ToolsQuickSizesSplit.TabIndex = 0;
            // 
            // CustomToolButton
            // 
            CustomToolButton.BackgroundImage = Properties.Resources.Border;
            CustomToolButton.BackgroundImageLayout = ImageLayout.Zoom;
            CustomToolButton.Dock = DockStyle.Top;
            CustomToolButton.Location = new Point(0, 150);
            CustomToolButton.Name = "CustomToolButton";
            CustomToolButton.Size = new Size(64, 50);
            CustomToolButton.TabIndex = 7;
            CustomToolButton.TabStop = false;
            // 
            // EraserToolButton
            // 
            EraserToolButton.BackColor = SystemColors.Window;
            EraserToolButton.BackgroundImage = Properties.Resources.Border;
            EraserToolButton.BackgroundImageLayout = ImageLayout.Zoom;
            EraserToolButton.Dock = DockStyle.Top;
            EraserToolButton.Location = new Point(0, 100);
            EraserToolButton.Name = "EraserToolButton";
            EraserToolButton.Size = new Size(64, 50);
            EraserToolButton.TabIndex = 6;
            EraserToolButton.TabStop = false;
            // 
            // PencilToolButton
            // 
            PencilToolButton.BackColor = SystemColors.Window;
            PencilToolButton.BackgroundImage = Properties.Resources.Border;
            PencilToolButton.BackgroundImageLayout = ImageLayout.Zoom;
            PencilToolButton.Dock = DockStyle.Top;
            PencilToolButton.Image = Properties.Resources.Pencil;
            PencilToolButton.Location = new Point(0, 50);
            PencilToolButton.Name = "PencilToolButton";
            PencilToolButton.Size = new Size(64, 50);
            PencilToolButton.SizeMode = PictureBoxSizeMode.Zoom;
            PencilToolButton.TabIndex = 5;
            PencilToolButton.TabStop = false;
            // 
            // PenToolButton
            // 
            PenToolButton.BackColor = SystemColors.Window;
            PenToolButton.BackgroundImage = Properties.Resources.Border;
            PenToolButton.BackgroundImageLayout = ImageLayout.Zoom;
            PenToolButton.Dock = DockStyle.Top;
            PenToolButton.Image = Properties.Resources.Pen;
            PenToolButton.Location = new Point(0, 0);
            PenToolButton.Name = "PenToolButton";
            PenToolButton.Size = new Size(64, 50);
            PenToolButton.SizeMode = PictureBoxSizeMode.Zoom;
            PenToolButton.TabIndex = 4;
            PenToolButton.TabStop = false;
            // 
            // ToolListToolSizeSplitter
            // 
            ToolListToolSizeSplitter.BorderStyle = BorderStyle.Fixed3D;
            ToolListToolSizeSplitter.Dock = DockStyle.Fill;
            ToolListToolSizeSplitter.Location = new Point(0, 0);
            ToolListToolSizeSplitter.Name = "ToolListToolSizeSplitter";
            // 
            // ToolListToolSizeSplitter.Panel2
            // 
            ToolListToolSizeSplitter.Panel2.AutoScroll = true;
            ToolListToolSizeSplitter.Size = new Size(178, 1012);
            ToolListToolSizeSplitter.SplitterDistance = 103;
            ToolListToolSizeSplitter.TabIndex = 0;
            // 
            // CanvasLayersSplitter
            // 
            CanvasLayersSplitter.BorderStyle = BorderStyle.Fixed3D;
            CanvasLayersSplitter.Dock = DockStyle.Fill;
            CanvasLayersSplitter.Location = new Point(0, 0);
            CanvasLayersSplitter.Name = "CanvasLayersSplitter";
            // 
            // CanvasLayersSplitter.Panel1
            // 
            CanvasLayersSplitter.Panel1.Controls.Add(canvasQuickToolsSplit);
            CanvasLayersSplitter.Panel1.Controls.Add(drawingCanvas);
            // 
            // CanvasLayersSplitter.Panel2
            // 
            CanvasLayersSplitter.Panel2.Controls.Add(LayersColorPickerSplitter);
            CanvasLayersSplitter.Size = new Size(1650, 1012);
            CanvasLayersSplitter.SplitterDistance = 1319;
            CanvasLayersSplitter.TabIndex = 0;
            // 
            // canvasQuickToolsSplit
            // 
            canvasQuickToolsSplit.BorderStyle = BorderStyle.Fixed3D;
            canvasQuickToolsSplit.Dock = DockStyle.Fill;
            canvasQuickToolsSplit.FixedPanel = FixedPanel.Panel1;
            canvasQuickToolsSplit.IsSplitterFixed = true;
            canvasQuickToolsSplit.Location = new Point(0, 0);
            canvasQuickToolsSplit.Name = "canvasQuickToolsSplit";
            canvasQuickToolsSplit.Orientation = Orientation.Horizontal;
            // 
            // canvasQuickToolsSplit.Panel1
            // 
            canvasQuickToolsSplit.Panel1.Controls.Add(numericUpDown1);
            canvasQuickToolsSplit.Panel1.Controls.Add(label4);
            canvasQuickToolsSplit.Panel1.Controls.Add(AAModes);
            canvasQuickToolsSplit.Panel1.Controls.Add(label3);
            canvasQuickToolsSplit.Panel1.Controls.Add(AlphaBrush);
            canvasQuickToolsSplit.Panel1.Controls.Add(opacitySlider);
            canvasQuickToolsSplit.Panel1.Controls.Add(label2);
            canvasQuickToolsSplit.Panel1.Controls.Add(ToolSizeSlider);
            canvasQuickToolsSplit.Panel1.Controls.Add(label1);
            canvasQuickToolsSplit.Size = new Size(1319, 1012);
            canvasQuickToolsSplit.SplitterDistance = 25;
            canvasQuickToolsSplit.TabIndex = 1;
            // 
            // numericUpDown1
            // 
            numericUpDown1.Dock = DockStyle.Left;
            numericUpDown1.Location = new Point(792, 0);
            numericUpDown1.Name = "numericUpDown1";
            numericUpDown1.Size = new Size(120, 23);
            numericUpDown1.TabIndex = 10;
            // 
            // label4
            // 
            label4.Dock = DockStyle.Left;
            label4.Location = new Point(723, 0);
            label4.Name = "label4";
            label4.Padding = new Padding(20, 0, 0, 0);
            label4.Size = new Size(69, 21);
            label4.TabIndex = 9;
            label4.Text = "AA Size:";
            label4.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // AAModes
            // 
            AAModes.Dock = DockStyle.Left;
            AAModes.FormattingEnabled = true;
            AAModes.Items.AddRange(new object[] { "Interior (Same Effective Radius, Max AA: Radius)", "Middle (Radius + half AA)", "Exterior(Radius + AA Amount)" });
            AAModes.Location = new Point(461, 0);
            AAModes.Name = "AAModes";
            AAModes.Size = new Size(262, 23);
            AAModes.TabIndex = 8;
            // 
            // label3
            // 
            label3.Dock = DockStyle.Left;
            label3.Location = new Point(400, 0);
            label3.Name = "label3";
            label3.Size = new Size(61, 21);
            label3.TabIndex = 7;
            label3.Text = "AA Mode:";
            label3.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // AlphaBrush
            // 
            AlphaBrush.AccessibleDescription = "This will make the brush only affect the alpha value on the image";
            AlphaBrush.Dock = DockStyle.Left;
            AlphaBrush.Location = new Point(296, 0);
            AlphaBrush.Name = "AlphaBrush";
            AlphaBrush.Padding = new Padding(10, 0, 0, 0);
            AlphaBrush.Size = new Size(104, 21);
            AlphaBrush.TabIndex = 6;
            AlphaBrush.Text = "Alpha Brush";
            AlphaBrush.UseVisualStyleBackColor = true;
            // 
            // opacitySlider
            // 
            opacitySlider.DecimalPlaces = 2;
            opacitySlider.Dock = DockStyle.Left;
            opacitySlider.Increment = new decimal(new int[] { 1, 0, 0, 65536 });
            opacitySlider.Location = new Point(214, 0);
            opacitySlider.Maximum = new decimal(new int[] { 255, 0, 0, 0 });
            opacitySlider.Name = "opacitySlider";
            opacitySlider.Size = new Size(82, 23);
            opacitySlider.TabIndex = 5;
            opacitySlider.Value = new decimal(new int[] { 255, 0, 0, 0 });
            opacitySlider.ValueChanged += changeOpacity;
            // 
            // label2
            // 
            label2.Dock = DockStyle.Left;
            label2.Location = new Point(166, 0);
            label2.Name = "label2";
            label2.Size = new Size(48, 21);
            label2.TabIndex = 4;
            label2.Text = "Opacity";
            // 
            // ToolSizeSlider
            // 
            ToolSizeSlider.DecimalPlaces = 2;
            ToolSizeSlider.Dock = DockStyle.Left;
            ToolSizeSlider.Increment = new decimal(new int[] { 2, 0, 0, 65536 });
            ToolSizeSlider.Location = new Point(66, 0);
            ToolSizeSlider.Maximum = new decimal(new int[] { 2500, 0, 0, 0 });
            ToolSizeSlider.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            ToolSizeSlider.Name = "ToolSizeSlider";
            ToolSizeSlider.Size = new Size(100, 23);
            ToolSizeSlider.TabIndex = 3;
            ToolSizeSlider.Value = new decimal(new int[] { 1, 0, 0, 0 });
            ToolSizeSlider.ValueChanged += changeToolSize;
            // 
            // label1
            // 
            label1.Dock = DockStyle.Left;
            label1.Location = new Point(0, 0);
            label1.Name = "label1";
            label1.Size = new Size(66, 21);
            label1.TabIndex = 2;
            label1.Text = "Brush Size";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // drawingCanvas
            // 
            drawingCanvas.Dock = DockStyle.Fill;
            drawingCanvas.Location = new Point(0, 0);
            drawingCanvas.Name = "ImageCanvas";
            drawingCanvas.Size = new Size(1319, 1012);
            drawingCanvas.TabIndex = 0;
            // 
            // LayersColorPickerSplitter
            // 
            LayersColorPickerSplitter.BorderStyle = BorderStyle.Fixed3D;
            LayersColorPickerSplitter.Dock = DockStyle.Fill;
            LayersColorPickerSplitter.Location = new Point(0, 0);
            LayersColorPickerSplitter.Name = "LayersColorPickerSplitter";
            LayersColorPickerSplitter.Orientation = Orientation.Horizontal;
            // 
            // LayersColorPickerSplitter.Panel1
            // 
            LayersColorPickerSplitter.Panel1.Controls.Add(quickLayerColorPickerSPlitter);
            // 
            // LayersColorPickerSplitter.Panel2
            // 
            LayersColorPickerSplitter.Panel2.AutoScroll = true;
            LayersColorPickerSplitter.Size = new Size(327, 1012);
            LayersColorPickerSplitter.SplitterDistance = 336;
            LayersColorPickerSplitter.TabIndex = 0;
            // 
            // quickLayerColorPickerSPlitter
            // 
            quickLayerColorPickerSPlitter.BorderStyle = BorderStyle.Fixed3D;
            quickLayerColorPickerSPlitter.Dock = DockStyle.Fill;
            quickLayerColorPickerSPlitter.Location = new Point(0, 0);
            quickLayerColorPickerSPlitter.Name = "quickLayerColorPickerSPlitter";
            quickLayerColorPickerSPlitter.Orientation = Orientation.Horizontal;
            // 
            // quickLayerColorPickerSPlitter.Panel1
            // 
            quickLayerColorPickerSPlitter.Panel1.Controls.Add(HueColorpickerSplitter);
            // 
            // quickLayerColorPickerSPlitter.Panel2
            // 
            quickLayerColorPickerSPlitter.Panel2.Controls.Add(splitContainer1);
            quickLayerColorPickerSPlitter.Size = new Size(327, 336);
            quickLayerColorPickerSPlitter.SplitterDistance = 266;
            quickLayerColorPickerSPlitter.TabIndex = 0;
            // 
            // HueColorpickerSplitter
            // 
            HueColorpickerSplitter.BorderStyle = BorderStyle.Fixed3D;
            HueColorpickerSplitter.Dock = DockStyle.Fill;
            HueColorpickerSplitter.FixedPanel = FixedPanel.Panel2;
            HueColorpickerSplitter.IsSplitterFixed = true;
            HueColorpickerSplitter.Location = new Point(0, 0);
            HueColorpickerSplitter.Name = "HueColorpickerSplitter";
            HueColorpickerSplitter.Orientation = Orientation.Horizontal;
            // 
            // HueColorpickerSplitter.Panel1
            // 
            HueColorpickerSplitter.Panel1.Controls.Add(colorPicker1);
            // 
            // HueColorpickerSplitter.Panel2
            // 
            HueColorpickerSplitter.Panel2.Controls.Add(Hue);
            HueColorpickerSplitter.Size = new Size(327, 266);
            HueColorpickerSplitter.SplitterDistance = 233;
            HueColorpickerSplitter.TabIndex = 0;
            // 
            // colorPicker1
            // 
            colorPicker1.Dock = DockStyle.Fill;
            colorPicker1.Image = (Image)resources.GetObject("colorPicker1.Image");
            colorPicker1.Location = new Point(0, 0);
            colorPicker1.Name = "colorPicker1";
            colorPicker1.Size = new Size(323, 229);
            colorPicker1.TabIndex = 0;
            colorPicker1.TabStop = false;
            // 
            // Hue
            // 
            Hue.Dock = DockStyle.Fill;
            Hue.Location = new Point(0, 0);
            Hue.Maximum = 360;
            Hue.Name = "Hue";
            Hue.Size = new Size(323, 25);
            Hue.TabIndex = 0;
            Hue.ValueChanged += Hue_ValueChanged;
            // 
            // splitContainer1
            // 
            splitContainer1.Dock = DockStyle.Fill;
            splitContainer1.FixedPanel = FixedPanel.Panel1;
            splitContainer1.IsSplitterFixed = true;
            splitContainer1.Location = new Point(0, 0);
            splitContainer1.Name = "splitContainer1";
            splitContainer1.Orientation = Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            splitContainer1.Panel1.Controls.Add(LayerOpacity);
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.Controls.Add(comboBox1);
            splitContainer1.Panel2.Controls.Add(newFolderButton);
            splitContainer1.Panel2.Controls.Add(newLayerButton);
            splitContainer1.Size = new Size(323, 62);
            splitContainer1.SplitterDistance = 31;
            splitContainer1.TabIndex = 0;
            // 
            // LayerOpacity
            // 
            LayerOpacity.Dock = DockStyle.Fill;
            LayerOpacity.Location = new Point(0, 0);
            LayerOpacity.Maximum = 255;
            LayerOpacity.Name = "LayerOpacity";
            LayerOpacity.Size = new Size(323, 31);
            LayerOpacity.TabIndex = 0;
            LayerOpacity.Value = 255;
            // 
            // comboBox1
            // 
            comboBox1.Dock = DockStyle.Left;
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(129, 0);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(121, 23);
            comboBox1.TabIndex = 2;
            // 
            // newFolderButton
            // 
            newFolderButton.Dock = DockStyle.Left;
            newFolderButton.Location = new Point(54, 0);
            newFolderButton.Name = "newFolderButton";
            newFolderButton.Size = new Size(75, 27);
            newFolderButton.TabIndex = 1;
            newFolderButton.Text = "+Folder";
            newFolderButton.UseVisualStyleBackColor = true;
            // 
            // newLayerButton
            // 
            newLayerButton.Dock = DockStyle.Left;
            newLayerButton.Location = new Point(0, 0);
            newLayerButton.Name = "newLayerButton";
            newLayerButton.Size = new Size(54, 27);
            newLayerButton.TabIndex = 0;
            newLayerButton.Text = "+Layer";
            newLayerButton.UseVisualStyleBackColor = true;
            newLayerButton.Click += newLayerButton_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1904, 1041);
            Controls.Add(MenuCanvasSplitter);
            MainMenuStrip = menuStrip1;
            Name = "Form1";
            Text = "Form1";
            WindowState = FormWindowState.Maximized;
            MenuCanvasSplitter.Panel1.ResumeLayout(false);
            MenuCanvasSplitter.Panel1.PerformLayout();
            MenuCanvasSplitter.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)MenuCanvasSplitter).EndInit();
            MenuCanvasSplitter.ResumeLayout(false);
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ToolCanvasSplitter.Panel1.ResumeLayout(false);
            ToolCanvasSplitter.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)ToolCanvasSplitter).EndInit();
            ToolCanvasSplitter.ResumeLayout(false);
            ToolsQuickSizesSplit.Panel1.ResumeLayout(false);
            ToolsQuickSizesSplit.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)ToolsQuickSizesSplit).EndInit();
            ToolsQuickSizesSplit.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)CustomToolButton).EndInit();
            ((System.ComponentModel.ISupportInitialize)EraserToolButton).EndInit();
            ((System.ComponentModel.ISupportInitialize)PencilToolButton).EndInit();
            ((System.ComponentModel.ISupportInitialize)PenToolButton).EndInit();
            ((System.ComponentModel.ISupportInitialize)ToolListToolSizeSplitter).EndInit();
            ToolListToolSizeSplitter.ResumeLayout(false);
            CanvasLayersSplitter.Panel1.ResumeLayout(false);
            CanvasLayersSplitter.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)CanvasLayersSplitter).EndInit();
            CanvasLayersSplitter.ResumeLayout(false);
            canvasQuickToolsSplit.Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)canvasQuickToolsSplit).EndInit();
            canvasQuickToolsSplit.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)numericUpDown1).EndInit();
            ((System.ComponentModel.ISupportInitialize)opacitySlider).EndInit();
            ((System.ComponentModel.ISupportInitialize)ToolSizeSlider).EndInit();
            LayersColorPickerSplitter.Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)LayersColorPickerSplitter).EndInit();
            LayersColorPickerSplitter.ResumeLayout(false);
            quickLayerColorPickerSPlitter.Panel1.ResumeLayout(false);
            quickLayerColorPickerSPlitter.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)quickLayerColorPickerSPlitter).EndInit();
            quickLayerColorPickerSPlitter.ResumeLayout(false);
            HueColorpickerSplitter.Panel1.ResumeLayout(false);
            HueColorpickerSplitter.Panel2.ResumeLayout(false);
            HueColorpickerSplitter.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)HueColorpickerSplitter).EndInit();
            HueColorpickerSplitter.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)colorPicker1).EndInit();
            ((System.ComponentModel.ISupportInitialize)Hue).EndInit();
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel1.PerformLayout();
            splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)LayerOpacity).EndInit();
            ResumeLayout(false);
        }

        private void changeOpacity(object sender, EventArgs e)
        {
            drawingAppHandler.changeOpacity(((NumericUpDown)sender).Value);
        }

        private void Hue_ValueChanged(object sender, EventArgs e)
        {
            colorPicker1.calculateHue(((TrackBar)sender).Value);
        }





        #endregion


        ElementHost drawingCanvas;
        Canvas c = new Canvas();
        private SplitContainer MenuCanvasSplitter;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem fileToolStripMenuItem;
        private ToolStripMenuItem newToolStripMenuItem;
        private ToolStripMenuItem openToolStripMenuItem;
        private ToolStripMenuItem saveToolStripMenuItem;
        private ToolStripMenuItem saveAsToolStripMenuItem;
        private ToolStripMenuItem editToolStripMenuItem;
        private ToolStripMenuItem insertToolStripMenuItem;
        private SplitContainer ToolCanvasSplitter;
        private SplitContainer CanvasLayersSplitter;
        private ToolStripMenuItem newCanvas, newTool, changeImageSize, changeCanvasSize, importImage, importImageAsNewCanvas;
        private SplitContainer canvasQuickToolsSplit;//canvasQuickToolsSplit THIS IS THE CANVAS CONTAINER, HOLDING THE WPF IMAGE
        private SplitContainer LayersColorPickerSplitter;
        private SplitContainer quickLayerColorPickerSPlitter;
        private ToolStripMenuItem canvasToolStripMenuItem;
        private Label label1;
        private NumericUpDown ToolSizeSlider;
        private NumericUpDown opacitySlider;
        private Label label2;
        private CheckBox AlphaBrush;
        private SplitContainer HueColorpickerSplitter;
        private TrackBar Hue;
        private ColorPicker colorPicker1;
        private ComboBox AAModes;
        private Label label3;
        private SplitContainer splitContainer1;
        private Button newFolderButton;
        private Button newLayerButton;
        private TrackBar LayerOpacity;
        private ComboBox comboBox1;
        private NumericUpDown numericUpDown1;
        private Label label4;
        private SplitContainer ToolsQuickSizesSplit;
        private SplitContainer ToolListToolSizeSplitter;
        private PictureBox PenToolButton;
        private PictureBox PencilToolButton;
        private PictureBox EraserToolButton;
        private PictureBox CustomToolButton;
    }
}
