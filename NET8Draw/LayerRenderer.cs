using ComputeSharp;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace NET8Draw
{
    public static partial class LayerRenderer
    {

        static int2 regionStart = new Int2();
        public static void renderLayer(CanvasLayer nextLayer, ReadWriteBuffer<float4> preview, int width, int height, Rectangle region)
        {
            regionStart.X = region.X;
            regionStart.Y = region.Y;
            GraphicsDevice.GetDefault().For(region.Width, region.Height, new renderNormal(nextLayer.getPixelBuffer(), preview, width, regionStart));
        }


        public static void renderFirstLayer(CanvasLayer l, ReadWriteBuffer<float4> preview, int width, int height, Rectangle region)
        {
            regionStart.X = region.X;
            regionStart.Y = region.Y;
            GraphicsDevice.GetDefault().For(region.Width, region.Height, new renderFirst(l.getPixelBuffer(), preview, width, regionStart));
        }

        internal static void clearRegionF(ReadWriteBuffer<float4> previewBuffer, int width, Rectangle drawingRegion)
        {
            regionStart.X = drawingRegion.X;
            regionStart.Y = drawingRegion.Y;
            GraphicsDevice.GetDefault().For(drawingRegion.Width, drawingRegion.Height, new clearRegion(previewBuffer, width, regionStart));
        }

        [ThreadGroupSize(DefaultThreadGroupSizes.XY)]
        [GeneratedComputeShaderDescriptor]
        public partial struct renderFirst(ReadWriteBuffer<float4> layer, ReadWriteBuffer<float4> final, int width, int2 regionStart) : IComputeShader
        {
            public void Execute()
            {
                int2 offset = regionStart + ThreadIds.XY;
                int offsetPos = getArrayPosFromPoint(offset);
                final[offsetPos] = float4.Zero;

                //previous layer is the final layer before change
                float4 previousColor = final[offsetPos];
                float4 colorToAdd = layer[offsetPos];

                final[offsetPos] = previousColor + colorToAdd;
            }

            public int getArrayPosFromPoint(int2 p)
            {
                return (p.Y * width) + p.X;
            }
        }






        [ThreadGroupSize(DefaultThreadGroupSizes.XY)]
        [GeneratedComputeShaderDescriptor]
        public partial struct renderNormal(ReadWriteBuffer<float4> currentLayer, ReadWriteBuffer<float4> final, int width, int2 regionStart) : IComputeShader
        {
            public void Execute()
            {
                int2 offset = regionStart + ThreadIds.XY;
                int offsetPos = getArrayPosFromPoint(offset);

                

                if (currentLayer[offsetPos].W > 0)
                {
                    float4 previousColor = final[offsetPos];
                    float4 colorToAdd = currentLayer[offsetPos];

                    if (previousColor.W + currentLayer[offsetPos].W > 1)
                    {
                        final[offsetPos] *= (1.0f - currentLayer[offsetPos].W);
                    }
                    final[offsetPos] += colorToAdd;
                }
            }

            public int getArrayPosFromPoint(int2 p)
            {
                return (p.Y * width) + p.X;
            }
        }




        [ThreadGroupSize(DefaultThreadGroupSizes.XY)]
        [GeneratedComputeShaderDescriptor]
        public partial struct clearRegion(ReadWriteBuffer<float4> final, int width, int2 regionStart) : IComputeShader
        {
            public void Execute()
            {
                int2 offset = regionStart + ThreadIds.XY;
                int offsetPos = getArrayPosFromPoint(offset);
                final[offsetPos].X = 0; 
                final[offsetPos].Y = 0;
                final[offsetPos].Z = 0;
                final[offsetPos].W = 0;
            }

            public int getArrayPosFromPoint(int2 p)
            {
                return (p.Y * width) + p.X;
            }
        }







        /*
         * public void Execute()
            {
                int2 offsetPoint = region + ThreadIds.XY;
                int arrayIndex = getArrayPosFromPoint(offsetPoint);

                for (int i = 0; i <= steps; i++)
                {
                    if (Hlsl.Distance(offsetPoint, Hlsl.Lerp(from, to, (float)i / steps)) < toolRadius)
                    {
                        float4 colorToAdd = color;
                        float4 previousColor = before[arrayIndex];
                        colorToAdd.X *= color.W;
                        colorToAdd.Y *= color.W;
                        colorToAdd.Z *= color.W;

                        if (previousColor.W + colorToAdd.W > 1.0f)
                        {
                            float delta = (1f - colorToAdd.W) / previousColor.W;
                            //change previous based off of delta
                            //calculate new previous alpha based on delta / previous.W
                            //multiply by previous by the new alpha
                            previousColor.X *= delta;
                            previousColor.Y *= delta;
                            previousColor.Z *= delta;
                        }


                        pixels[arrayIndex] = previousColor + colorToAdd;
                        pixels[arrayIndex].W = Hlsl.Clamp(pixels[arrayIndex].W, 0f, 1f);
                        pixels[arrayIndex].X = Hlsl.Clamp(pixels[arrayIndex].X, 0f, 1f);
                        pixels[arrayIndex].Y = Hlsl.Clamp(pixels[arrayIndex].Y, 0f, 1f);
                        pixels[arrayIndex].Z = Hlsl.Clamp(pixels[arrayIndex].Z, 0f, 1f);
                    }
                }

            }
         */

    }
}
