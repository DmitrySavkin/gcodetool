namespace AutoCADTool
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.Save = new System.Windows.Forms.Button();
            this.Cancel = new System.Windows.Forms.Button();
            this.GCodeFrame = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // Save
            // 
            this.Save.Location = new System.Drawing.Point(650, 27);
            this.Save.Name = "Save";
            this.Save.Size = new System.Drawing.Size(101, 33);
            this.Save.TabIndex = 0;
            this.Save.Text = "Speichern";
            this.Save.UseVisualStyleBackColor = true;
            this.Save.Click += new System.EventHandler(this.Button1_Click);
            // 
            // Cancel
            // 
            this.Cancel.Location = new System.Drawing.Point(650, 80);
            this.Cancel.Name = "Cancel";
            this.Cancel.Size = new System.Drawing.Size(101, 32);
            this.Cancel.TabIndex = 1;
            this.Cancel.Text = "Abbrechnen";
            this.Cancel.UseVisualStyleBackColor = true;
            this.Cancel.Click += new System.EventHandler(this.Button2_Click);
            // 
            // GCodeFrame
            // 
            this.GCodeFrame.Location = new System.Drawing.Point(12, 27);
            this.GCodeFrame.Name = "GCodeFrame";
            this.GCodeFrame.Size = new System.Drawing.Size(632, 394);
            this.GCodeFrame.TabIndex = 2;
            this.GCodeFrame.Text = "";
            this.GCodeFrame.TextChanged += new System.EventHandler(this.GCodeFrame_TextChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(780, 433);
            this.Controls.Add(this.GCodeFrame);
            this.Controls.Add(this.Cancel);
            this.Controls.Add(this.Save);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button Save;
        private System.Windows.Forms.Button Cancel;
        private System.Windows.Forms.RichTextBox GCodeFrame;
    }
}