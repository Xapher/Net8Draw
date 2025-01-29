using System.ComponentModel;
using System.Runtime.InteropServices;
using System.Windows.Input;
namespace NET8Draw
{
    internal class CustomMouseEventHandler
    {

        CanvasState t;

        [DllImport("user32.dll")]
        public static extern bool GetCursorPos(out Point lpPoint);
        [DllImport("user32.dll")]
        public static extern short GetAsyncKeyState(UInt16 virtualKeyCode);


        UInt16 mouseLeft = 0x01, mouseRight = 0x02, shift = 0x10, alt = 0x12, spacebar = 0x20, R = 0x52, Z = 0x5A;
        bool appRunning = false;

        public short getMouseDown()
        {
            return GetAsyncKeyState(mouseLeft);
        }

        public short getVirtualKeyDown(UInt16 virtualKeyCode)
        {
            return GetAsyncKeyState(virtualKeyCode);
        }

        public Point GetCursorScreenPosition()
        {
            Point lpPoint;
            GetCursorPos(out lpPoint);
            return lpPoint;
        }

        bool mouseDown = false, enabled = false; 


        NETDrawingHandler parent;
        BackgroundWorker mouseThread;
        Form1 form;
        Control bounds;
        Rectangle screenBounds = new Rectangle();   
        public CustomMouseEventHandler(NETDrawingHandler caller, Form1 form, Control canvasBounds)
        {
            this.bounds = canvasBounds;
            screenBounds = bounds.RectangleToScreen(canvasBounds.Bounds);
            //Console.WriteLine(screenBounds);
            bounds.SizeChanged += Bounds_SizeChanged;
            this.form = form;
            parent = caller;
            appRunning = true;
            mouseThread = new BackgroundWorker();
            mouseThread.WorkerSupportsCancellation = true;
            mouseThread.DoWork += checkMouse;
            mouseThread.WorkerReportsProgress = true;
            mouseThread.ProgressChanged += checkProgress;
            //Console.WriteLine("Tablet:" + Tablet.CurrentTabletDevice);
            
            if(Tablet.CurrentTabletDevice != null)
            {
                if ((Tablet.CurrentTabletDevice.TabletHardwareCapabilities & TabletHardwareCapabilities.SupportsPressure) == TabletHardwareCapabilities.SupportsPressure)
                {
                    Console.WriteLine("Supports Pressure");
                }
            }
        }

        private void Bounds_SizeChanged(object? sender, EventArgs e)
        {
            screenBounds = bounds.RectangleToScreen(this.bounds.Bounds);
        }

        bool inProgress = false;
        private void checkProgress(object? sender, ProgressChangedEventArgs e)
        {
            inProgress  = true;

            if (e.ProgressPercentage == 4)
            {
                parent.updatePreviews();
            }
            else if (e.ProgressPercentage == 2)
            {
                parent.startDrawing(currentMouse);
                canDraw = true;
            }
            else if (e.ProgressPercentage == 0 && canDraw && form.isFocused())
            {
                parent.draw(currentMouse);
            }
            else if (e.ProgressPercentage == 5)
            {
                form.updateCirclePos(currentMouse);
            }
            inProgress = false;
        }
        bool canDraw = false;
        short tempMouse = 0;
        Point prevMouse, currentMouse;
        private void checkMouse(object? sender, DoWorkEventArgs h)
        {
            while(appRunning)
            {
                tempMouse = getVirtualKeyDown(mouseLeft);
                currentMouse = GetCursorScreenPosition();
                

                if (!inProgress)
                {
                    //get modifier keys first
                    //then get mouse
                    //somehow make sure mouse is over canvas


                    //check modifier keys, pan/rotate/zoom/etc



                    //check mouse

                    //if no modifier keys are active draw
                    

                    if (tempMouse != 0 && !mouseDown && tempMouse != 1)
                    {
                        if (form.isFocused() && form.isInsideCanvas(currentMouse) && !mouseDown)
                        {
                            ((BackgroundWorker)sender).ReportProgress(2);
                        }
                        mouseDown = true;
                    }

                    if (mouseDown && tempMouse == 0)
                    {
                        mouseDown = false;
                        canDraw = false;
                        ((BackgroundWorker)sender).ReportProgress(4);
                    }

                    if (canDraw)
                    {
                        currentMouse = GetCursorScreenPosition();
                        //Console.WriteLine(GetCursorScreenPosition());
                        //drawing?
                        if (prevMouse != currentMouse)
                        {
                            ((BackgroundWorker)sender).ReportProgress(0);
                            
                        }
                        prevMouse = currentMouse;
                    }
                }
                else
                {
                    if (tempMouse == 0 && mouseDown)
                    {
                        mouseDown = false;
                        canDraw = false;
                        ((BackgroundWorker)sender).ReportProgress(4);
                    }
                }
            }
        }

        byte modKeysDown = 0;
        bool checkModifiers() {
            modKeysDown = 0;

            if(getVirtualKeyDown(spacebar) != 0)
            {
                modKeysDown++;
            }


            if (getVirtualKeyDown(R) != 0)
            {
                modKeysDown++;
            }


            if (getVirtualKeyDown(Z) != 0)
            {
                modKeysDown++;
            }

            if (modKeysDown > 1)
            {
                return false;
            }
            return true;
        }

        public void enable()
        {
            mouseThread.RunWorkerAsync();
        }

        internal void close()
        {
            appRunning = false;
        }
    }
}