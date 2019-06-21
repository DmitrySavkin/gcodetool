using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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

        private void DomainUpDown1_SelectedItemChanged(object sender, EventArgs e)
        {
       

        }

        private void Label1_Click(object sender, EventArgs e)
        {

        }

        private void Label2_Click(object sender, EventArgs e)
        {

        }

        private void DomainUpDown1_SelectedItemChanged_1(object sender, EventArgs e)
        {
           
        }
        private void NumericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            decimal z = this.zCoordinate.Value;
            string pattern = @"S[0-9]{3,4}";
            Regex r = new Regex(pattern);
            string cpy = GCodeFrame.Text;
            string nd = r.Replace(cpy, "S" + z);
            GCodeFrame.Text = nd;
            //   MessageBox.Show(nd);
        }

        private void Diameter_ValueChanged(object sender, EventArgs e)
        {
            
        }

        private void ZCoordinate_ValueChanged(object sender, EventArgs e)
        {
             decimal z = this.zCoordinate.Value;
             string pattern = @"Z[0-9]{1,2}";
             Regex r = new Regex(pattern);
             string cpy = GCodeFrame.Text;
             string nd = r.Replace(cpy, "Z" + z);
             GCodeFrame.Text = nd;
             pattern = @"Z-[0-9]{1,2}";
             r = new Regex(pattern);
             cpy = GCodeFrame.Text;
             nd = r.Replace(cpy, "Z-" + z);
             GCodeFrame.Text = nd;
         //   MessageBox.Show(nd);
        }
    }
}
