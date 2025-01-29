using System.Runtime.InteropServices;

namespace NET8Draw
{
    internal class LayerThumbnail
    {
        byte[] thumbValues;
        GCHandle arrayAdd;
        Bitmap thumbPreview;

        public LayerThumbnail(int w, int h, int BPP)
        {
            thumbValues = new byte[(w * BPP) * h];
            arrayAdd = GCHandle.Alloc(thumbPreview, GCHandleType.Pinned);
            thumbPreview = new Bitmap(w,h, w * BPP, System.Drawing.Imaging.PixelFormat.Format32bppArgb, arrayAdd.AddrOfPinnedObject());
        }
    }
}