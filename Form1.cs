using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CutImage
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private string filePath;

        private void button1_Click(object sender, EventArgs e)
        {
            if(openFileDialog1.ShowDialog() != DialogResult.OK)
            {
                return;
            }


            filePath = openFileDialog1.FileName;
            var ext = Path.GetExtension(filePath);

            switch (ext.ToLower())
            {
                case ".jpg":
                case ".png":
                case ".jpeg":
                    ShowImage();
                    break;
                default:
                    return;
            }
        }


        private Bitmap source;

        private void ShowImage()
        {
            source = new Bitmap(filePath);
            pictureBox1.Image = source;
            this.Text = $"width:{source.Width} height:{source.Height}";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var sx = Convert.ToInt32(inpStartX.Text);
            var sy = Convert.ToInt32(inpStartY.Text);


            var cx = Convert.ToInt32(inpCutX.Text);
            var cy = Convert.ToInt32(inpCutY.Text);

            RectangleF rectangleF = new RectangleF(sx, sy, cx, cy);
            var newBitmap = source.Clone(rectangleF, System.Drawing.Imaging.PixelFormat.Format32bppRgb);

            pictureBox2.Image = newBitmap;
        }
    }
}
