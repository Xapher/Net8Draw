using ComputeSharp;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;
using System.Windows.Documents;

namespace NET8Draw
{
    internal class DigitalCanvas
    {
        List<CanvasLayer> layers = new List<CanvasLayer>();
        private int width;
        private int height;
        int currentLayer = 0;
        int thumbWidth = 0, thumbHeight = 0;
        int thumbSize = 5;


        Dictionary<int, LayerThumbnail> layerThumbs = new Dictionary<int, LayerThumbnail>();


        Point imageOffset = new Point();

        Rectangle drawingRegion = new Rectangle(), imageRegion = new Rectangle();
        Bitmap preview;



        int strideClampMax = 0;
        int regionEndIndex = 0;
        byte pixelSize = 4;//default to 4 cause 32bbp
        float4[] previewPixels;
        int2 regionStart = new Int2();
        ReadWriteBuffer<float4> previewBuffer;

        int scanLineStride = 0;

        ReadOnlyBuffer<float4> beforeChange, previuosPreview;
        byte[] rgbValues;
        GCHandle previewMem;

        PixelFormat previewFormat;


        public DigitalCanvas(int width, int height, PixelFormat previewFormat)
        {
            this.width = width;
            this.height = height;

            thumbWidth = width / thumbSize;
            thumbHeight = height / thumbSize;

            switch(previewFormat)
            {
                case PixelFormat.Format32bppArgb:
                    pixelSize = 4;
                    break;
                case PixelFormat.Format64bppArgb:
                    pixelSize = 8;//????? Will this work?
                    break;
                case PixelFormat.Format16bppRgb565:
                    break;
            }

            scanLineStride = width * pixelSize;

            rgbValues = new byte[scanLineStride * height];

            previewMem = GCHandle.Alloc(rgbValues, GCHandleType.Pinned);

            preview = new Bitmap(width, height, scanLineStride, PixelFormat.Format32bppArgb, previewMem.AddrOfPinnedObject());

            previewPixels = new float4[width * height];
            
            previewBuffer = GraphicsDevice.GetDefault().AllocateReadWriteBuffer(previewPixels);

            imageRegion = new Rectangle(0, 0, width, height);

            this.previewFormat = previewFormat;

            strideClampMax = width * height;

            //Console.WriteLine(imageRegion);

            //Console.WriteLine(strideClampMax);
        }



        Rectangle previousRegion = new Rectangle(-1,-1, -1,-1);
        float2 mousePoint = new Float2(), previousPoint = new Float2();
        float2 tempLerp;
        int steps = 0;
        float stepFloat = 0f;



        public void floatMouse(Point mouse)
        {
            mousePoint.X = mouse.X - imageOffset.X;
            mousePoint.Y = mouse.Y - imageOffset.Y;
            stepFloat = (Distance(mousePoint, previousPoint) + 1);
            steps = (int)stepFloat;
        }

        public void endDraw()
        {
            previousPoint = mousePoint;
        }
        
        internal void draw(float toolRadius, float4 color)
        {
            calculateDrawingRegion(mousePoint, (int)Math.Round(toolRadius, MidpointRounding.ToPositiveInfinity));//calculates full bounds from prev to curr
            if (drawingRegion.Width > 0 && drawingRegion.Height > 0)
            {
                layers[currentLayer].draw(mousePoint, previousPoint, toolRadius, color, beforeChange, drawingRegion, ref regionStart, steps, strideClampMax);
                //LayerRenderer.clearRegionF(previewBuffer, width, drawingRegion);
                LayerRenderer.renderFirstLayer(layers[0], previewBuffer, width, height, drawingRegion);
                for (int i = 1; i < layers.Count; i++)
                {
                    LayerRenderer.renderLayer(layers[i], previewBuffer, width, height, drawingRegion);
                }

                //convert this from to starting region end region instead of each y
                imagePixelIndex = drawingRegion.X + (width * drawingRegion.Y);
                regionEndIndex = drawingRegion.Right + (width * drawingRegion.Bottom);

                previewBuffer.CopyTo(previewPixels, imagePixelIndex, imagePixelIndex, Math.Clamp(regionEndIndex, 0, strideClampMax) - imagePixelIndex);
            }
        }





        public float2 lerp(float2 a, float2 b, float t)
        {
            tempLerp.X = ((b.X - a.X) * t) + a.X;
            tempLerp.Y = ((b.Y - a.Y) * t) + a.Y;
            return tempLerp;
        }



        public Rectangle getBounds()
        {
            return drawingRegion;
        }

        float2 minBounds = new float2(0, 0), maxBounds = new float2(0, 0);
        void calculateDrawingRegion(float2 m, int rad)
        {   
            minBounds.X = Math.Min(previousPoint.X, m.X) - (rad);
            minBounds.Y = Math.Min(previousPoint.Y, m.Y) - (rad);
            maxBounds.X = Math.Max(previousPoint.X, m.X) + (rad);
            maxBounds.Y = Math.Max(previousPoint.Y, m.Y) + (rad);



            if (minBounds.X < 0)
            {
                minBounds.X = 0;
            }
            if (minBounds.Y < 0)
            {
                minBounds.Y = 0;
            }
            if (maxBounds.X > width)
            {
                maxBounds.X = width;
            }
            if (maxBounds.Y > height)
            {
                maxBounds.Y = height;
            }


            drawingRegion.X = (int)minBounds.X;
            drawingRegion.Y = (int)minBounds.Y;
            drawingRegion.Width = (int)(maxBounds.X - minBounds.X);
            drawingRegion.Height = (int)(maxBounds.Y - minBounds.Y);

            regionStart.X = drawingRegion.X;
            regionStart.Y = drawingRegion.Y;
        }





        float2 a = new Float2(), b = new Float2();
        public void calculateDrawingRegionBetween(int i, int rad)
        {
            a = lerp(previousPoint, mousePoint, (i / stepFloat));
            b = lerp(previousPoint, mousePoint, ((i + 1) / stepFloat));

            minBounds.X = Math.Min(a.X, b.X) - (rad);
            minBounds.Y = Math.Min(a.Y, b.Y) - (rad);
            maxBounds.X = Math.Max(a.X, b.X) + (rad);
            maxBounds.Y = Math.Max(a.Y, b.Y) + (rad);

            

            if (minBounds.X < 0)
            {
                minBounds.X = 0;
            }
            if (minBounds.Y < 0)
            {
                minBounds.Y = 0;
            }
            if (maxBounds.X > width)
            {
                maxBounds.X = width;
            }
            if (maxBounds.Y > height)
            {
                maxBounds.Y = height;
            }


            drawingRegion.X = (int)minBounds.X;
            drawingRegion.Y = (int)minBounds.Y;
            drawingRegion.Width = (int)(maxBounds.X - minBounds.X);
            drawingRegion.Height = (int)(maxBounds.Y - minBounds.Y);

            regionStart.X = drawingRegion.X;
            regionStart.Y = drawingRegion.Y;
        }






        internal float2 getMousePoint()
        {
            return mousePoint;
        }


        internal float2 getPreviousPoint()
        {
            return previousPoint;
        }



        int startingIndex = 0;

        private void renderPreview()
        {


            /*
             * for (int i = 0; i < drawingRegion.Height; i++)
            {
                startingIndex = drawingRegion.X + (width * (drawingRegion.Y + i));
                previewBuffer.CopyTo(previewPixels, startingIndex, startingIndex, drawingRegion.Width);
            }
             */
            previewBuffer.CopyTo(previewPixels);




            for (int x = drawingRegion.Left; x < drawingRegion.Right; x++)
            {
                for (int y = drawingRegion.Top; y < drawingRegion.Bottom; y++)
                {
                    startingIndex = (x * 4) + (scanLineStride * y);
                    imagePixelIndex = x + (width * y);

                    rgbValues[startingIndex] = (byte)(previewPixels[imagePixelIndex].Z * 255);
                    rgbValues[startingIndex + 1] = (byte)(previewPixels[imagePixelIndex].Y * 255);
                    rgbValues[startingIndex + 2] = (byte)(previewPixels[imagePixelIndex].X * 255);
                    rgbValues[startingIndex + 3] = (byte)(previewPixels[imagePixelIndex].W * 255);
                }
            }
        }










        Point tempP = new Point();
        public void renderRegionPreview()
        {


            for (int x = drawingRegion.Left; x < drawingRegion.Right; x++)
            {
                for (int y = drawingRegion.Top; y < drawingRegion.Bottom; y++)
                {
                    tempP.X = x;
                    tempP.Y = y;
                    if(!previousRegion.Contains(tempP))
                    {
                        startingIndex = (x * 4) + (scanLineStride * y);
                        imagePixelIndex = x + (width * y);

                        rgbValues[startingIndex] = (byte)(previewPixels[imagePixelIndex].Z * 255);
                        rgbValues[startingIndex + 1] = (byte)(previewPixels[imagePixelIndex].Y * 255);
                        rgbValues[startingIndex + 2] = (byte)(previewPixels[imagePixelIndex].X * 255);
                        rgbValues[startingIndex + 3] = (byte)(previewPixels[imagePixelIndex].W * 255);
                    }
                }
            }
        }













        internal void firstPoint(Point mouseDown)
        {
            previousPoint.X = mouseDown.X - imageOffset.X;
            previousPoint.Y = mouseDown.Y - imageOffset.Y;
            if(beforeChange == null)
            {
                beforeChange = GraphicsDevice.GetDefault().AllocateReadOnlyBuffer<float4>(layers[currentLayer].getPixelArray());
            }
            else
            {
                beforeChange.CopyFrom(layers[currentLayer].getPixelArray());
            }



            if (previuosPreview == null)
            {
                previuosPreview = GraphicsDevice.GetDefault().AllocateReadOnlyBuffer<float4>(previewBuffer);
            }
            else
            {
                previuosPreview.CopyFrom(previewBuffer);
            }

            //ReadOnlyBuffer
        }

        internal Bitmap getBitmap()
        {
            return preview;
        }

        public void setLayer(int id)
        {
            currentLayer = id;
        }
        CanvasLayer temp;
        public int newLayer()
        {
            temp = new CanvasLayer(width, height, thumbWidth, thumbHeight);
            layers.Add(temp);
            return layers.Count - 1;
        }

        internal int getCurrentLayer()
        {
            return currentLayer;
        }

        internal void updateImageOffset(Point point)
        {
            this.imageOffset = point;
        }


        int imagePixelIndex = 0;
        byte[] regionBuffer = new byte[10];
        int stride = 0;
        internal byte[] getRegionBuffer(int y)
        {
            stride = drawingRegion.Width * 4;
            if (regionBuffer.Length < stride)
            {
                regionBuffer = new byte[stride];
            }

            for (int i = 0; i < stride; i +=4)
            {
                imagePixelIndex = ((drawingRegion.X + (i / 4)) * 4) + (scanLineStride * (drawingRegion.Y + y));
                regionBuffer[i] = rgbValues[imagePixelIndex];
                regionBuffer[i + 1] = rgbValues[imagePixelIndex + 1];
                regionBuffer[i + 2] = rgbValues[imagePixelIndex + 2];
                regionBuffer[i + 3] = rgbValues[imagePixelIndex + 3];
            }

            return regionBuffer;
        }

        internal Bitmap getLayerThumb()
        {
            layers[currentLayer].calculateThumbnail();
            return layers[currentLayer].getThumbnail();
        }

        internal Rectangle getCanvasBounds()
        {
            return imageRegion;
        }

        internal float4 getColor(int x, int y)
        {
            return previewPixels[x + (width * y)];
        }

        byte[] c = new byte[4];
        internal byte[] getColorAsByte(int x, int y)
        {

            imagePixelIndex = x + (width * y);

            c[0] = (byte)(previewPixels[imagePixelIndex].Z * 255);//B
            c[1] = (byte)(previewPixels[imagePixelIndex].Y * 255);//B
            c[2] = (byte)(previewPixels[imagePixelIndex].X * 255);//B
            c[3] = (byte)(previewPixels[imagePixelIndex].W * 255);//B

            return c;
        }


        float tempA = 0f, tempB = 0f;
        public float Distance(float2 v1, float2 v2)
        {
            tempA = MathF.Pow(v1.X - v2.X, 2);
            tempB = MathF.Pow(v1.Y - v2.Y, 2);
            return (float)Math.Sqrt(tempA + tempB);
        }

        internal int getSteps()
        {
            return steps;
        }

        internal float getFloatSteps()
        {
            return stepFloat;
        }

        internal bool positiveBounds()
        {
            if(drawingRegion.Width > 0 && drawingRegion.Height > 0)
            {
                return true;
            }
            return false;
        }

        internal byte[] getRGBValues()
        {
            return rgbValues;
        }

        internal Bitmap getFinalPreview()
        {
            return preview;
        }

        internal void Erase(float toolRadius)
        {
            calculateDrawingRegion(mousePoint, (int)Math.Round(toolRadius, MidpointRounding.ToPositiveInfinity));//calculates full bounds from prev to curr
            if (drawingRegion.Width > 0 && drawingRegion.Height > 0)
            {
                layers[currentLayer].Erase(mousePoint, previousPoint, toolRadius, beforeChange, drawingRegion, ref regionStart, steps, strideClampMax);
                //LayerRenderer.clearRegionF(previewBuffer, width, drawingRegion);
                LayerRenderer.renderFirstLayer(layers[0], previewBuffer, width, height, drawingRegion);
                for (int i = 1; i < layers.Count; i++)
                {
                    LayerRenderer.renderLayer(layers[i], previewBuffer, width, height, drawingRegion);
                }

                //convert this from to starting region end region instead of each y
                imagePixelIndex = drawingRegion.X + (width * drawingRegion.Y);
                regionEndIndex = drawingRegion.Right + (width * drawingRegion.Bottom);

                previewBuffer.CopyTo(previewPixels, imagePixelIndex, imagePixelIndex, Math.Clamp(regionEndIndex, 0, strideClampMax) - imagePixelIndex);
            }
        }
    }
}