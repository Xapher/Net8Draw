using System.Drawing.Imaging;
using System.Runtime.InteropServices;
using System.Windows.Documents;
using System.Windows.Media.Imaging;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;
using System.Windows.Media.Media3D;
using System.Drawing;

namespace DrawingCanvas
{
    /// <summary>
    /// Interaction logic for UserControl1.xaml
    /// </summary>
    public partial class Canvas : System.Windows.Controls.UserControl
    {

        GCHandle memLoc;





        Bitmap bitmap;
        BitmapData bmpd;
        IntPtr memAdd;

        int memLength = 0;
        int stride = 0;
        byte[] rgbValues;

        public Canvas()
        {
            InitializeComponent();
            //graphicsTest.Source = imagesou;
        }
        public void changeCanvasSize(int w, int h)
        {
            if (!CanvasImage.Visible)
            {
                CanvasImage.Visible = true;
            }

            rgbValues = new byte[(w * h) * 4];

            memLoc = GCHandle.Alloc(rgbValues, GCHandleType.Pinned);

            bitmap = new Bitmap(w, h, w * 4, PixelFormat.Format32bppArgb, memLoc.AddrOfPinnedObject());

            stride = w * 4;


            CanvasContainer.Width = w;
            CanvasContainer.Height = h;
            CanvasImage.Size = new Size(w, h);
            CanvasImage.Image = bitmap;
            //imageSize = new Rectangle(0,0, w, h);
            //imageGraphics = CanvasImage.CreateGraphics();
        }

        public Point getImagePosition()
        {
            return CanvasImage.PointToScreen(CanvasImage.Location);
        }

        int pixelIndex = 0;


        public void updateImage(Rectangle reg, byte[] rgb)
        {
            for (int x = reg.Left; x < reg.Right; x++)
            {
                for (int y = reg.Top; y < reg.Bottom; y++)
                {
                    pixelIndex = (x * 4) + (stride * y);

                    rgbValues[pixelIndex] = rgb[pixelIndex];
                    rgbValues[pixelIndex + 1] = rgb[pixelIndex + 1];
                    rgbValues[pixelIndex + 2] = rgb[pixelIndex + 2];
                    rgbValues[pixelIndex + 3] = rgb[pixelIndex + 3];
                }
            }
        }



        public void updateImage(Rectangle region, int y, byte[] buffer)
        {

            pixelIndex = (region.X * 4) + (stride * (region.Y + y));

            for (int i = 0; i < region.Width * 4; i+= 4)
            {
                rgbValues[pixelIndex + i] = buffer[i];
                rgbValues[pixelIndex + (i + 1)] = buffer[i + 1];
                rgbValues[pixelIndex + (i + 2)] = buffer[i + 2];
                rgbValues[pixelIndex + (i + 3)] = buffer[i + 3];
            }
        }

        public void updateRadPos(System.Windows.Point p)
        {
            RadiusDisplay.RenderTransform.Transform(p);
        }
        public void refreshImage()
        {
            CanvasImage.Refresh();
        }
    }

}
