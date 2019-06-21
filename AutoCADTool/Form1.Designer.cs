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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.diameter = new System.Windows.Forms.NumericUpDown();
            this.zCoordinate = new System.Windows.Forms.NumericUpDown();
            this.speeValue = new System.Windows.Forms.NumericUpDown();
            this.speed = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.diameter)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.zCoordinate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.speeValue)).BeginInit();
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
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(648, 139);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(69, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Durchmesser";
            this.label1.Click += new System.EventHandler(this.Label1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(648, 216);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Z Abstand ";
            this.label2.Click += new System.EventHandler(this.Label2_Click);
            // 
            // diameter
            // 
            this.diameter.Location = new System.Drawing.Point(651, 156);
            this.diameter.Name = "diameter";
            this.diameter.Size = new System.Drawing.Size(100, 20);
            this.diameter.TabIndex = 6;
            this.diameter.ValueChanged += new System.EventHandler(this.Diameter_ValueChanged);
            // 
            // zCoordinate
            // 
            this.zCoordinate.Location = new System.Drawing.Point(650, 233);
            this.zCoordinate.Name = "zCoordinate";
            this.zCoordinate.Size = new System.Drawing.Size(101, 20);
            this.zCoordinate.TabIndex = 7;
            this.zCoordinate.ValueChanged += new System.EventHandler(this.ZCoordinate_ValueChanged);
            // 
            // speeValue
            // 
            this.speeValue.Location = new System.Drawing.Point(651, 301);
            this.speeValue.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.speeValue.Minimum = new decimal(new int[] {
            500,
            0,
            0,
            0});
            this.speeValue.Name = "speeValue";
            this.speeValue.Size = new System.Drawing.Size(100, 20);
            this.speeValue.TabIndex = 8;
            this.speeValue.Value = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.speeValue.ValueChanged += new System.EventHandler(this.NumericUpDown1_ValueChanged);
            // 
            // speed
            // 
            this.speed.AutoSize = true;
            this.speed.Location = new System.Drawing.Point(651, 285);
            this.speed.Name = "speed";
            this.speed.Size = new System.Drawing.Size(85, 13);
            this.speed.TabIndex = 9;
            this.speed.Text = "Geschwindigkeit";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(780, 433);
            this.Controls.Add(this.speed);
            this.Controls.Add(this.speeValue);
            this.Controls.Add(this.zCoordinate);
            this.Controls.Add(this.diameter);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.GCodeFrame);
            this.Controls.Add(this.Cancel);
            this.Controls.Add(this.Save);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.diameter)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.zCoordinate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.speeValue)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button Save;
        private System.Windows.Forms.Button Cancel;
        private System.Windows.Forms.RichTextBox GCodeFrame;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown diameter;
        private System.Windows.Forms.NumericUpDown zCoordinate;
        private System.Windows.Forms.NumericUpDown speeValue;
        private System.Windows.Forms.Label speed;
    }
}