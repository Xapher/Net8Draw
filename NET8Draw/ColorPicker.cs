using ComputeSharp;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;

namespace NET8Draw
{
    internal partial class ColorPicker : PictureBox
    {
        Bitmap colorRepresentation;


        Int3 hueValue = new Int3(255, 0, 0);

        float3 colorValue = new Float3(1f, 0f, 0f);

        float2 colorPosition = new float2(0f, 0f);

        byte[] rgbValues = new byte[4];
        GCHandle colorAdd;

        [ThreadGroupSize(DefaultThreadGroupSizes.XY)]
        [GeneratedComputeShaderDescriptor]
        public partial struct computeColorPicker(int width, int height, ReadWriteBuffer<int3> color, int3 hue) : IComputeShader
        {
            public void Execute()
            {
                //X IS HUE
                //Y IS SATURATION

                float hueSat = (ThreadIds.X / (float)width);
                float satValue = 1f - (ThreadIds.Y / (float)height);
                int3 white = new int3((int)(255 * (satValue * (1f - hueSat))), (int)(255 * (satValue * (1f - hueSat))), (int)(255 * (satValue * (1f - hueSat))));
                int3 pixelHue = new Int3((int)(hue.X * (hueSat * satValue)), (int)(hue.Y * (hueSat * satValue)), (int)(hue.Z * (hueSat * satValue)));

                

                color[getArrayPosFromPoint(ThreadIds.XY)] = white + pixelHue;
            }



            public int getArrayPosFromPoint(int2 p)
            {
                return (p.Y * width) + p.X;
            }
        }















        int3[] pixels;
        ReadWriteBuffer<int3> pixelBuffer;






        public ColorPicker()
        {
            this.SizeChanged += updateColorPickerSize;
            this.Click += changeColor;
            this.Dock = DockStyle.Fill;

        }


        int3 white = new Int3(255, 255, 255);
        float whiteMod = 0f, hueMod = 0f;
        private void changeColor(object? sender, EventArgs e)
        {
            colorPosition.X = ((MouseEventArgs)e).Location.X / (float)this.Width;//hue
            colorPosition.Y = 1f - (((MouseEventArgs)e).Location.Y / (float)this.Height);//saturation

            //hueValue * colorposition.x
            //

            whiteMod = (colorPosition.Y * (1f - colorPosition.X));
            hueMod = (colorPosition.X * colorPosition.Y);


            tempColor.X = (int)(white.X * whiteMod);
            tempColor.Y = (int)(white.Y * whiteMod);
            tempColor.Z = (int)(white.Z * whiteMod);

            tempColor.X += (int)(hueValue.X * hueMod);
            tempColor.Y += (int)(hueValue.Y * hueMod);
            tempColor.Z += (int)(hueValue.Z * hueMod);

            h.changeColor(tempColor);
        }

        void initColorPicker()
        {
            if(colorAdd != null && colorAdd.IsAllocated)
            {
                colorAdd.Free();
            }

            rgbValues = new byte[(this.Size.Width * 4) * this.Size.Height];

            colorAdd = GCHandle.Alloc(rgbValues, GCHandleType.Pinned);

            colorRepresentation = new Bitmap(this.Size.Width, this.Size.Height, this.Size.Width * 4, PixelFormat.Format32bppArgb, colorAdd.AddrOfPinnedObject());
            pixels = new int3[colorRepresentation.Width * colorRepresentation.Height];

            pixelBuffer = GraphicsDevice.GetDefault().AllocateReadWriteBuffer(pixels);


            GraphicsDevice.GetDefault().For(colorRepresentation.Width, colorRepresentation.Height, new computeColorPicker(colorRepresentation.Width, colorRepresentation.Height, pixelBuffer, hueValue));

            pixelBuffer.CopyTo(pixels);

              

            updateColorPickerBitmap();
        }


        int imagePixelIndex = 0;
        int byteIndex = 0;
        void updateColorPickerBitmap()//Change later to lockbits and unlock bits
        {
            
            for (int x = 0; x < colorRepresentation.Width; x++)
            {
                for (int y = 0; y < colorRepresentation.Height; y++)
                {
                    byteIndex = ((x * 4) + ((colorRepresentation.Width * 4) * y));
                    imagePixelIndex = (x + (colorRepresentation.Width * y));
                    rgbValues[byteIndex] = (byte)(pixels[imagePixelIndex].Z);
                    rgbValues[byteIndex + 1] = (byte)(pixels[imagePixelIndex].Y);
                    rgbValues[byteIndex + 2] = (byte)(pixels[imagePixelIndex].X);
                    rgbValues[byteIndex + 3] = 255;

                }
            }
            this.Refresh();
        }

        float angle = 0;
        byte colorIndex = 0;
        Color[] rgb = new Color[] {Color.Red, Color.Green, Color.Blue};
        public void calculateHue(int value)
        {
            //circle, 0 - 120 red lerped to green, 120 - 240 green lerped to blue, 240 - 360 blue lerped to red
            //x / width * 360.0 is blah
            //((PictureBox)sender).Location;

            if(value == 360)
            {
                colorIndex = 2;
            }
            else
            {
                colorIndex = (byte)(value / 120f);
                angle = (value % 120);
            }

            if(colorIndex < 2)
            {
                hueValue = lerpColor(rgb[colorIndex], rgb[colorIndex + 1], (angle / 120f));
                //Console.WriteLine("Betwee: " +  + " and " + rgb[colorIndex + 1] + " With: " + (angle / 120f));
            }
            else
            {
                hueValue = lerpColor(rgb[colorIndex], rgb[0], (angle / 120f));
                //Console.WriteLine("Betwee: " + rgb[colorIndex] + " and " + rgb[0] + " With: " + (angle / 120f));
            }


            updateColorPickerColor();
            
            updateColorPickerBitmap();
            
        }


        int3 tempColor = new Int3();
        byte max = 0;

        int3  lerpColor(Color a, Color b, float t)
        {
            max = 0;
            tempColor.X = (int)(((b.R - a.R) * t) + a.R);
            tempColor.Y = (int)(((b.G - a.G) * t) + a.G);
            tempColor.Z = (int)(((b.B - a.B) * t) + a.B);

            if(tempColor.X > max)
            {
                max = (byte)tempColor.X;
            }

            if (tempColor.Y > max)
            {
                max = (byte)tempColor.Y;
            }

            if (tempColor.Z > max)
            {
                max = (byte)tempColor.Z;
            }

            tempColor.X = (int)(tempColor.X * (255f / max));
            tempColor.Y = (int)(tempColor.Y * (255f / max));
            tempColor.Z = (int)(tempColor.Z * (255f / max));
            return tempColor;
        }



        void updateColorPickerColor()
        {
            GraphicsDevice.GetDefault().For(colorRepresentation.Width, colorRepresentation.Height, new computeColorPicker(colorRepresentation.Width, colorRepresentation.Height, pixelBuffer, hueValue));

            pixelBuffer.CopyTo(pixels);
        }


        private void updateColorPickerSize(object? sender, EventArgs e)
        {
            initColorPicker();
            this.Image = colorRepresentation;
            this.Refresh();
        }


        NETDrawingHandler h;
        internal void setHandler(NETDrawingHandler drawingAppHandler)
        {
            h = drawingAppHandler;
        }
    }
}