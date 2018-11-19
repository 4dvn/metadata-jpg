using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MetaData_jpg
{
    public partial class Form1 : Form
    {
        private PictureBox pictureBox1;
        String lokasyon;
        public Form1()
        {
            InitializeComponent();
            button1.Dock = DockStyle.Bottom;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                lokasyon = openFileDialog1.FileName;
            }
            button1.Text = lokasyon;
            //MessageBox.Show(lokasyon);
            if (pictureBox1 !=null)
            {
                pictureBox1.Dispose();
            }
            pictureBox1 = new PictureBox();
            pictureBox1.Dock = DockStyle.Fill;
            pictureBox1.BackColor = Color.GreenYellow;
            pictureBox1.Paint += new System.Windows.Forms.PaintEventHandler(this.Form1_Paint);

            this.Controls.Add(pictureBox1);

        }

        private void Form1_Paint(object sender, System.Windows.Forms.PaintEventArgs e)
        {
            // Create an Image object. 
            Image image = new Bitmap(lokasyon);

            // Get the PropertyItems property from image.
            PropertyItem[] propItems = image.PropertyItems;

            // Set up the display.
            Font font = new Font("Arial", 12);
            SolidBrush blackBrush = new SolidBrush(Color.Black);
            int X = 0;
            int Y = 0;

            // For each PropertyItem in the array, display the ID, type, and 
            // length.
            int count = 0;
            foreach (PropertyItem propItem in propItems)
            {
                e.Graphics.DrawString(
                "Property Item " + count.ToString(),
                font,
                blackBrush,
                X, Y);

                Y += font.Height;

                e.Graphics.DrawString(
                   "   iD: 0x" + propItem.Id.ToString("x"),
                   font,
                   blackBrush,
                   X, Y);

                Y += font.Height;

                e.Graphics.DrawString(
                   "   type: " + propItem.Type.ToString(),
                   font,
                   blackBrush,
                   X, Y);

                Y += font.Height;

                e.Graphics.DrawString(
                   "   length: " + propItem.Len.ToString() + " bytes",
                   font,
                   blackBrush,
                   X, Y);

                Y += font.Height;

                count++;
            }
            // Convert the value of the second property to a string, and display 
            // it.
            System.Text.ASCIIEncoding encoding = new System.Text.ASCIIEncoding();
            string manufacturer = encoding.GetString(propItems[1].Value);

            e.Graphics.DrawString(
               "The equipment make is " + manufacturer + ".",
               font,
               blackBrush,
               X, Y);
        }        
    }
}
