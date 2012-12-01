using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace WindowsFormsApplication4
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void encodeButton_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                var memoryStream = new System.IO.MemoryStream();

                openFileDialog1.OpenFile().CopyTo(memoryStream);

                byte[] data = memoryStream.ToArray();

                encodeTextView.Text = Convert.ToBase64String(data);

                Clipboard.SetText(encodeTextView.Text);
            }
            else
            {
                return;
            }
        }

        private void encodeTextView_TextChanged(object sender, EventArgs e)
        {

        }

        private void decodeButton_Click(object sender, EventArgs e)
        {
            char[] data = decodeTextView.Text.ToCharArray();

            byte[] temp = System.Convert.FromBase64CharArray(data, 0, data.Length);
            
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                System.IO.File.WriteAllBytes(saveFileDialog1.FileName, temp);

            }
        }

        private void decodeTextView_TextChanged(object sender, EventArgs e)
        {

        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {

        }

        private void saveFileDialog1_FileOk(object sender, CancelEventArgs e)
        {

        }

        private void resetToolStripMenuItem_Click(object sender, EventArgs e)
        {
            encodeTextView.ResetText();
            decodeTextView.ResetText();
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutBox1 box = new AboutBox1();
            box.ShowDialog(); 
        }
    }
}




