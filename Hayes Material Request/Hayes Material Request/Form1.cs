using System;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.Drawing.Printing;
using System.IO;
using System.Reflection;
using System.Windows.Forms;

namespace Hayes_Material_Request
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Call the method to create the PNG file
            CreatePngFromText();

            // Open the custom print preview form
            Form2 previewForm = new Form2();
            string filePath = "C:\\Users\\jjames\\source\\repos\\Hayes Material Request\\Hayes Material Request\\bin\\Debug\\Request.png";
            previewForm.LoadImage(filePath); // Load the generated image
            previewForm.ShowDialog(); // Open as a modal dialog
        }

        private void CreatePngFromText()
        {
            // Set the filename and path
            string folderPath = "C:\\Users\\jjames\\source\\repos\\Hayes Material Request\\Hayes Material Request\\bin\\Debug";

            // Ensure the folder exists
            if (!Directory.Exists(folderPath))
            {
                Directory.CreateDirectory(folderPath);
            }

            string filePath = Path.Combine(folderPath, "Request.png");

            // Delete the file if it already exists
            if (File.Exists(filePath))
            {
                File.Delete(filePath);
            }

            // Create a bitmap for the PNG file
            using (Bitmap bmp = new Bitmap(574, 1000)) // 574px wide to match 72mm at 203 DPI, height can be adjusted
            {
                using (Graphics graphics = Graphics.FromImage(bmp))
                {
                    // Fill the background with white
                    graphics.Clear(Color.White);

                    // Create a font for the header
                    using (Font headerFont = new Font("Arial", 24, FontStyle.Bold))
                    {
                        // Draw the header
                        string headerText = "Hayes Material Request";
                        PointF headerPosition = new PointF(10, 10);
                        graphics.DrawString(headerText, headerFont, Brushes.Black, headerPosition);

                        // Draw an underline for the header
                        SizeF headerSize = graphics.MeasureString(headerText, headerFont);
                        graphics.DrawLine(Pens.Black, headerPosition.X, headerPosition.Y + headerSize.Height,
                                          headerPosition.X + headerSize.Width, headerPosition.Y + headerSize.Height);
                    }

                    // Create a font to use for drawing the text
                    using (Font font = new Font("Arial", 20))
                    {
                        // Define a starting position for drawing the text
                        float yPos = 50; // Adjust to leave space for the header
                        float lineHeight = font.GetHeight() + 5; // Line height with some padding

                        // Draw the text from the text boxes onto the bitmap
                        graphics.DrawString("Employee: " + EmployeeBox1.Text.Trim(), font, Brushes.Black, new PointF(10, yPos));
                        yPos += lineHeight;

                        graphics.DrawString("Work Center: " + WorkCentertextBox5.Text.Trim(), font, Brushes.Black, new PointF(10, yPos));
                        yPos += lineHeight;

                        graphics.DrawString("Part Number: " + PartNumtextBox4.Text.Trim(), font, Brushes.Black, new PointF(10, yPos));
                        yPos += lineHeight;

                        graphics.DrawString("Time Needed By: " + TimeNeededBytextBox3.Text.Trim(), font, Brushes.Black, new PointF(10, yPos));
                        yPos += lineHeight;

                        graphics.DrawString("Notes: " + NotestextBox2.Text.Trim(), font, Brushes.Black, new PointF(10, yPos));
                        yPos += lineHeight;

                        graphics.DrawString("Quantity: " + numericUpDown1.Value.ToString(), font, Brushes.Black, new PointF(10, yPos));
                    }
                }

                // Save the bitmap as a PNG file
                bmp.Save(filePath, ImageFormat.Png);
            }
        

        //    //old code that open the document in receipt.png
        //    // Automatically open the PNG file with the default image viewer
        //    try
        //    {
        //        Process.Start(new ProcessStartInfo(filePath) { UseShellExecute = true });
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show("Failed to open image: " + ex.Message);
        //    }
        }


        public void button2_Click(object sender, EventArgs e) //for the cancel button
        {
            // Clear all input fields
            EmployeeBox1.Text = " ";
            WorkCentertextBox5.Text = "";
            PartNumtextBox4.Text = "";
            numericUpDown1.Value = 0;
            TimeNeededBytextBox3.Text = "";
            NotestextBox2.Text = "";
        }



        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            // Your code to handle text change event for textBox1
        }


        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox9_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox11_TextChanged(object sender, EventArgs e)
        {

        }
    }
}

