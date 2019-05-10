
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            controlBtn.Visible = false;
            convertBtn.Visible = false;
            saveBtn.Visible = false;
        }

        private void ToolStripButton1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("AutoCad has started");
            MessageBox.Show("Gaometries were loaded");
            controlBtn.Visible = true;
            convertBtn.Visible = true;
            saveBtn.Visible = true;

        }

        private void ToolStripButton2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("The draw was converted");
            infoTextBox.TextAlign = HorizontalAlignment.Left;
            infoTextBox.Text = GCodeGenerator.GCodeGenerator.GetGCode().ToString();
        }

        private void ToolStripButton3_Click(object sender, EventArgs e)
        {
            MessageBox.Show("The draw was controled");
        }

        private void Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Label1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void SaveBtn_Click(object sender, EventArgs e)
        {
           string currentDir =  System.IO.Path.GetDirectoryName(Application.ExecutablePath);
            SaveFileDialog saveDialog = new SaveFileDialog();
            saveDialog.InitialDirectory = currentDir;
          //  saveDialog.Filter = "gcode files (*.gcode)";ERROR
          //want to show the extension .gcode for the file.
            saveDialog.CheckFileExists = true;
            saveDialog.CheckPathExists = true;
            saveDialog.DefaultExt = "gcode";
            saveDialog.ShowDialog();
        }

        private void Label2_Click(object sender, EventArgs e)
        {

        }
    }
}
