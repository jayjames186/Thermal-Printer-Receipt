using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Hayes_Material_Request
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        // Method to load and display an image
        public void LoadImage(string filePath)
        {
            if (System.IO.File.Exists(filePath))
            {
                pictureBoxPreview.Image = new Bitmap(filePath); // Load the image into PictureBox
            }
            else
            {
                MessageBox.Show("Image file not found: " + filePath);
            }
        }
    }
}
