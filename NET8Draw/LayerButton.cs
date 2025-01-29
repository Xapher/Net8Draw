namespace NET8Draw
{
    internal class LayerButton : Button
    {
        NETDrawingHandler host;
        PictureBox preview;
        int layerID = 0;//defualt
        Button visibility = new Button();
        Label l = new Label();
        public LayerButton(NETDrawingHandler canvas, int layer)
        {
            visibility.Dock = DockStyle.Left;
            visibility.Width = 25;
            visibility.Text = "V";

            l.Text = "Layer: " + layer + "";
            l.Dock = DockStyle.Left;
            l.AutoSize = false;
            l.BackColor = Color.Transparent;
            l.Padding = new Padding(0, 10, 0, 0);

            this.Dock = DockStyle.Top;
            this.Height = 125;
            this.Click += changeLayer;
            host = canvas;
            this.layerID = layer;
            
            preview = new PictureBox();
            preview.Dock = DockStyle.Left;
            preview.BorderStyle = BorderStyle.FixedSingle;
            preview.Size = new Size(this.Height - 5, this.Height - 5);

            this.Controls.Add(l);
            this.Controls.Add(preview);
            this.Controls.Add(visibility);
        }

        internal int getID()
        {
            return layerID;
        }

        internal void updatePreview(Bitmap b)
        {
            preview.Image = b;
            preview.SizeMode = PictureBoxSizeMode.Zoom;
            preview.Refresh();
        }

        private void changeLayer(object? sender, EventArgs e)
        {
            host.setLayer(layerID);
        }
    }
}