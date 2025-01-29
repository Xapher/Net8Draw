using ComputeSharp;

namespace NET8Draw
{
    public partial class Layer
    {
        public float4[] layerPixels, initialLayer;
        public ReadWriteBuffer<float4> textureBuffer;
        public ReadWriteBuffer<int4> asBytes;
            
        [ThreadGroupSize(DefaultThreadGroupSizes.XY)]
        [GeneratedComputeShaderDescriptor]
        public readonly partial struct drawNormalLayer(int width, int height, ReadWriteBuffer<float4> pixels, float2 from, float2 to, int steps, float toolRadius, float4 color, ReadOnlyBuffer<float4> before, int2 region, int blurInner, int blurOuter) : IComputeShader
        {
            public void Execute()
            {
                
                int2 offsetPoint = region + ThreadIds.XY;
                int arrayIndex = getArrayPosFromPoint(offsetPoint);
                if((offsetPoint.X >= 0 && offsetPoint.X <= width) && (offsetPoint.Y >= 0 && offsetPoint.Y <= height))
                {
                    float blurRadius = toolRadius + blurInner;
                    float blurCircum = toolRadius + blurOuter;
                    
                    for (int i = 0; i <= steps; i++)
                    {
                        float dist = Hlsl.Distance(offsetPoint, Hlsl.Lerp(from, to, (float)i / steps));
                        float mod = Hlsl.Clamp(1f - ((dist - blurRadius) / Hlsl.Abs(blurInner)), 0f, 1f);
                        float4 colorToAdd = color;
                        colorToAdd.X *= color.W;
                        colorToAdd.Y *= color.W;
                        colorToAdd.Z *= color.W;

                        float4 previousColor = before[arrayIndex];
                        float maxAlpha = Hlsl.Clamp(previousColor.W + color.W, 0f, 1f);

                        if (previousColor.W + colorToAdd.W > 1.0f)
                        {
                            float delta = (1f - colorToAdd.W) / previousColor.W;
                            //change previous based off of delta
                            //calculate new previous alpha based on delta / previous.W
                            //multiply by previous by the new alpha
                            previousColor *= delta;
                        }

                        colorToAdd = previousColor + colorToAdd;
                        //if it's within the blur distence
                        if (dist <= blurCircum && dist >= blurRadius)
                        {

                            

                            pixels[arrayIndex] += colorToAdd * mod;
                            pixels[arrayIndex].W = Hlsl.Clamp(pixels[arrayIndex].W, 0f, maxAlpha);
                            pixels[arrayIndex].X = Hlsl.Clamp(pixels[arrayIndex].X, 0f, colorToAdd.X);
                            pixels[arrayIndex].Y = Hlsl.Clamp(pixels[arrayIndex].Y, 0f, colorToAdd.Y);
                            pixels[arrayIndex].Z = Hlsl.Clamp(pixels[arrayIndex].Z, 0f, colorToAdd.Z);
                        }

                        //if its withing the actual tool radius
                        if (dist <= blurRadius)
                        {
                            


                            pixels[arrayIndex] = colorToAdd;
                            pixels[arrayIndex].W = Hlsl.Clamp(pixels[arrayIndex].W, 0f, 1f);
                            pixels[arrayIndex].X = Hlsl.Clamp(pixels[arrayIndex].X, 0f, 1f);
                            pixels[arrayIndex].Y = Hlsl.Clamp(pixels[arrayIndex].Y, 0f, 1f);
                            pixels[arrayIndex].Z = Hlsl.Clamp(pixels[arrayIndex].Z, 0f, 1f);
                        }












                        



                    }
                }
            }
            public int getArrayPosFromPoint(int2 p)
            {
                return (p.Y * width) + p.X;
            }

        }


























        [ThreadGroupSize(DefaultThreadGroupSizes.XY)]
        [GeneratedComputeShaderDescriptor]
        public readonly partial struct erase(int width, int height, ReadWriteBuffer<float4> pixels, float2 from, float2 to, int steps, float toolRadius, ReadOnlyBuffer<float4> before, int2 region, int blurInner, int blurOuter) : IComputeShader
        {
            public void Execute()
            {

                int2 offsetPoint = region + ThreadIds.XY;
                int arrayIndex = getArrayPosFromPoint(offsetPoint);
                if ((offsetPoint.X >= 0 && offsetPoint.X <= width) && (offsetPoint.Y >= 0 && offsetPoint.Y <= height))
                {
                    float blurRadius = toolRadius + blurInner;
                    float blurCircum = toolRadius + blurOuter;

                    for (int i = 0; i <= steps; i++)
                    {
                        float dist = Hlsl.Distance(offsetPoint, Hlsl.Lerp(from, to, (float)i / steps));
                        float mod = Hlsl.Clamp(1f - ((dist - blurRadius) / Hlsl.Abs(blurInner)), 0f, 1f);
                        float4 colorToAdd = float4.Zero;

                        float4 previousColor = before[arrayIndex];


                        //if its withing the actual tool radius
                        if (dist <= blurCircum)
                        {



                            pixels[arrayIndex] = colorToAdd;
                            pixels[arrayIndex].W = Hlsl.Clamp(pixels[arrayIndex].W, 0f, 1f);
                            pixels[arrayIndex].X = Hlsl.Clamp(pixels[arrayIndex].X, 0f, 1f);
                            pixels[arrayIndex].Y = Hlsl.Clamp(pixels[arrayIndex].Y, 0f, 1f);
                            pixels[arrayIndex].Z = Hlsl.Clamp(pixels[arrayIndex].Z, 0f, 1f);
                        }
















                    }
                }
            }
            public int getArrayPosFromPoint(int2 p)
            {
                return (p.Y * width) + p.X;
            }

        }





        [ThreadGroupSize(DefaultThreadGroupSizes.X)]
        [GeneratedComputeShaderDescriptor]
        public readonly partial struct drawNormalLayer1D(int width, ReadWriteBuffer<float4> pixels, float2 from, float2 to, int steps, int toolRadius, float4 color, ReadOnlyBuffer<float4> before, float2 minBound, int regWidth, int regHeight) : IComputeShader
        {
            public void Execute()
            {
                pixels[0] = new Float4();   
            }
            public int getArrayPosFromPoint(int2 p)
            {
                return (p.Y * width) + p.X;
            }



            public float noiseAt(int x, int y)
            {
                float tempX = Hlsl.Sin(9f);
                float tempY = Hlsl.Cos(9f);
                return 0.0f;
            }
        }































        public void init(int width, int height)
        {
            layerPixels = new float4[width * height];
            initialLayer = new float4[width * height];
            textureBuffer = GraphicsDevice.GetDefault().AllocateReadWriteBuffer(layerPixels);
            asBytes = GraphicsDevice.GetDefault().AllocateReadWriteBuffer(new int4[width * height]);
        }
    }
}