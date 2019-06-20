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

namespace AutoCADTool
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Title = "Save GCode";
           
            if (sfd.ShowDialog() == DialogResult.OK && sfd.FileName != "")
            {

                StreamWriter wr = new StreamWriter(sfd.FileName);
                wr.Write(GCodeFrame.Text);
                wr.Close();
                MessageBox.Show("Geschafft");
            }
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            GCodeFrame.Text = "";
            this.Close();
            
        }

        private void GCodeFrame_TextChanged(object sender, EventArgs e)
        {

        }

        public void SetTextGCode(string str)
        {
            GCodeFrame.Text = str;
        }

    }
}
