using ComputeSharp;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.Numerics;
using System.Runtime.InteropServices;

namespace NET8Draw
{
    public class CanvasLayer : Layer
    {
        int width = 0, height = 0;

        Bitmap thumb;
        Rectangle thumbRect;
        byte thumbSize = 5;

        byte[] thumbValues = new byte[] { };
        GCHandle thumbAdd;


        public CanvasLayer(int width, int height, int tW, int tH)
        {
            thumbValues = new byte[(tW * 4) * tH];
            thumbAdd = GCHandle.Alloc(thumbValues, GCHandleType.Pinned);
            thumb = new Bitmap(tW, tH, tW * 4, PixelFormat.Format32bppArgb, thumbAdd.AddrOfPinnedObject());
            init(width, height);
            this.width = width;
            this.height = height;
            
            thumbRect = new Rectangle(0, 0, thumb.Width, thumb.Height);
        }

        int steps = 0;





        int pixelEnd = 0;
        internal void draw(float2 mouse, float2 previousMouseInput, float toolRadius, float4 color, ReadOnlyBuffer<float4> before, Rectangle r, ref int2 regionStart, int steps, int maxRegionLen)
        {
            GraphicsDevice.GetDefault().For(r.Width, r.Height, new drawNormalLayer(width, height, textureBuffer, previousMouseInput, mouse, steps, toolRadius, color, before, regionStart, -3, 1));


            imagePixelIndex = r.X + (width * r.Y);
            pixelEnd = r.Right + (width * r.Bottom);

            textureBuffer.CopyTo(layerPixels, imagePixelIndex, imagePixelIndex, Math.Clamp(pixelEnd, 0, maxRegionLen) - imagePixelIndex);
            textureBuffer.CopyTo(layerPixels);
        }




        int thumbIndex = 0;
        public void calculateThumbnail()
        {
            for (int x = 0; x < thumb.Width; x++)
            {
                for (int y = 0; y < thumb.Height; y++)
                {
                    imagePixelIndex = (x * thumbSize) + (width * (y * thumbSize));
                    thumbIndex = (x * 4) + (thumb.Width * (y * 4));

                    thumbValues[thumbIndex] = (byte)(layerPixels[imagePixelIndex].Z * 255);//B
                    thumbValues[thumbIndex + 1] = (byte)(layerPixels[imagePixelIndex].Y * 255);//G
                    thumbValues[thumbIndex + 2] = (byte)(layerPixels[imagePixelIndex].X * 255);//R
                    thumbValues[thumbIndex + 3] = (byte)(layerPixels[imagePixelIndex].W * 255);//A
                }
            }
        }

        List<Point> needUpdate = new List<Point>();
        Point tempPoint = new Point();
        float2 tempLerpA, tempLerpB;


        BitmapData bmpData, bmpData2;
        byte[] rgbValues;
        int bytes;
        IntPtr ptr;



        int imagePixelIndex = 0;

        float tempA = 0f, tempB = 0f;

        


        float2 tempLerp = new Float2();
        public float2 lerp(Point a, Point b, float t)
        {

            tempLerp.X = ((b.X - a.X) * t) + tempA;
            tempLerp.Y = ((b.Y - a.Y) * t) + tempA;
            //Console.WriteLine("Is: " + t + " correct? " + a + "/" + b + "    " + tempLerp);
            return tempLerp;
        }




        public float2 lerp(float2 a, float2 b, float t)
        {
            tempLerp.X = ((b.X - a.X) * t) + a.X;
            tempLerp.Y = ((b.Y - b.Y) * t) + a.Y;
            //Console.WriteLine("Is: " + t + " correct? " + a + "/" + b + "    " + tempLerp);
            return tempLerp;
        }

        internal float4[] getPixelArray()
        {
            return layerPixels;
        }


        public Bitmap getThumbnail()
        {
            return thumb;
        }

        internal ReadWriteBuffer<float4> getPixelBuffer()
        {
            return textureBuffer;
        }

        internal void Erase(float2 mousePoint, float2 previousPoint, float toolRadius, ReadOnlyBuffer<float4> beforeChange, Rectangle r, ref int2 regionStart, int steps, int strideClampMax)
        {
            GraphicsDevice.GetDefault().For(r.Width, r.Height, new erase(width, height, textureBuffer, previousPoint, mousePoint, steps, toolRadius, beforeChange, regionStart, -3, 1));


            imagePixelIndex = r.X + (width * r.Y);
            pixelEnd = r.Right + (width * r.Bottom);

            textureBuffer.CopyTo(layerPixels, imagePixelIndex, imagePixelIndex, Math.Clamp(pixelEnd, 0, strideClampMax) - imagePixelIndex);
            textureBuffer.CopyTo(layerPixels);
        }
    }
}