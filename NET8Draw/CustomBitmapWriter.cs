using System.Drawing.Imaging;
using System.Runtime.InteropServices;
namespace NET8Draw
{
    public static class CustomBitmapWriter
    {
        static Dictionary<int, BitmapData> b;



        static BitmapData bmpd;
        static IntPtr memStart;
        static Rectangle rect = new Rectangle(0, 0, 10, 10);
        static int stridePerPixel = 4;
        static int linescanStride = 0;

        static int imagePixelIndex = 0;


        static BitmapData fromBit, toBit;
        static IntPtr fromMem, toMem;


        public static void initUnlock(int layer, Bitmap b, Rectangle rect)
        {

        }





        public static void initUnlock(Bitmap from, Bitmap to, Rectangle region)
        {
            fromBit = from.LockBits(region, ImageLockMode.ReadOnly, from.PixelFormat);
            toBit = to.LockBits(region, ImageLockMode.WriteOnly, to.PixelFormat);

            fromMem = fromBit.Scan0;
            toMem = toBit.Scan0;
            
            linescanStride = stridePerPixel * region.Width;
        }


        public static void updateBitmapRegion(int y)
        {
            //copy from fromMem to toMem
        }

        public static int getStrideLength()
        {
            return linescanStride;
        }




        public static void initUnlock(Bitmap bmp, Rectangle r)
        {
            linescanStride = stridePerPixel * r.Width;
            bmpd = bmp.LockBits(r, ImageLockMode.WriteOnly, bmp.PixelFormat);
            memStart = bmpd.Scan0;
        }



        public static void writeColorToBitmap(int x, int y, float4 color)
        {
            imagePixelIndex = (x + (bmpd.Width * y)) * 4;
            unsafe
            {
                ((byte*)memStart)[imagePixelIndex] = (byte)(color.Z * 255);
                ((byte*)memStart)[imagePixelIndex + 1] = (byte)(color.Y * 255);
                ((byte*)memStart)[imagePixelIndex + 2] = (byte)(color.X * 255);
                ((byte*)memStart)[imagePixelIndex + 3] = (byte)(color.W * 255);
            }
            //Marshal.Copy(pixels, 0, memStart + (bmpd.Stride * y), linescanStride);
        }




        public static void copyBytesToWholeBitmap(int y, byte[] pixels)
        {
            //sMarshal.Copy(pixels, 0, memStart + (bmpd.Stride * y), pixels.Length);
        }

        public static  void modifyColor(int x, int y, float4 color)
        {
            //bitmapMemSpans[y].modifyColor(x, color.X, color.Y, color.Z, color.W);
        }


        public static void release(Bitmap b)
        {
            b.UnlockBits(bmpd);
        }
    }
}