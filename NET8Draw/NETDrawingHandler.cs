

using ComputeSharp;
using DrawingCanvas;
using System.Runtime.InteropServices;

namespace NET8Draw
{
    internal class NETDrawingHandler
    {
        

        Canvas canvasPreview;//The image on the app, using this to offset drawing into local coordinates

        DigitalCanvas c;

        bool drawing = false;
        float4 color = new float4(0f,0f,0f, 1f);
        float toolRadius = 4;

        ToolType currentType = ToolType.Pen;//default
        
        Dictionary<int, LayerButton> layerPreviewButtons = new Dictionary<int, LayerButton>();

        


        public void newCanvas(int width, int height, Canvas can)
        {
            c = new DigitalCanvas(width, height, System.Drawing.Imaging.PixelFormat.Format32bppArgb);
            canvasPreview = can;
        }

        public void addNewLayerPreview(int id, LayerButton b)
        {
            layerPreviewButtons.Add(id, b);
        }

        public int creteNewLayer()
        {
            return c.newLayer();
        }


        public void setLayer(int layer)
        {
            c.setLayer(layer);
        }  

        public void startDrawing(Point mouseDown)
        {
            //backup current layer as float4[] to compare to new layer
            drawing = true;

            c.updateImageOffset(canvasPreview.getImagePosition());
            c.firstPoint(mouseDown);
        }


        public void draw(Point MousePos)
        {
            //setup mouse point
            c.floatMouse(MousePos);
            //draw

            //c.clearRegion(toolRadius);
            if (currentType == ToolType.Eraser)
            {
                c.Erase(toolRadius);
            }
            else
            {
                c.draw(toolRadius, color);//Add some other stuff for noise and suchs
            }
            
            //update regions on image
            //????

            if(c.positiveBounds())
            {
                c.renderRegionPreview();
                canvasPreview.updateImage(c.getBounds(), c.getRGBValues());
            }

            /*
             * 
             * 
            OLD AND SLOW


            for (int i = 0; i < c.getSteps(); i++)
            {
                //??????
                c.calculateDrawingRegionBetween(i, toolRadius);
                if (c.positiveBounds())
                {
                    c.renderRegionPreview();
                    canvasPreview.updateImage(c.getBounds(), c.getRGBValues());
                }
            }
             */



            //set previous point
            c.endDraw();
            canvasPreview.refreshImage();
        }

        public void updatePreviews()
        {
            layerPreviewButtons[c.getCurrentLayer()].updatePreview(c.getLayerThumb());
            layerPreviewButtons[c.getCurrentLayer()].Refresh();
        }



        public void checkMouse()
        {
        }

        internal void changeToolSize(int value)
        {
            toolRadius = value;
        }

        internal void changeToolSize(decimal value)
        {
            toolRadius = (float)value;
        }

        internal void changeColor(int3 hueValue)
        {
            color.X = hueValue.X / 255f;
            color.Y = hueValue.Y / 255f;
            color.Z = hueValue.Z / 255f;
        }

        internal void changeOpacity(decimal value)
        {
            color.W = ((float)value / 255f);
        }

        internal void saveCanvas(string fileName)
        {
            c.getFinalPreview().Save(fileName);
        }

        internal void changeToolType(ToolType toolType)
        {
            currentType = toolType;
        }
    }
}