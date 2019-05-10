namespace WindowsFormsApp1
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.autoCadBtn = new System.Windows.Forms.ToolStripButton();
            this.convertBtn = new System.Windows.Forms.ToolStripButton();
            this.controlBtn = new System.Windows.Forms.ToolStripButton();
            this.saveBtn = new System.Windows.Forms.ToolStripButton();
            this.panel = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.infoTextBox = new System.Windows.Forms.TextBox();
            this.toolStrip1.SuspendLayout();
            this.panel.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(18, 18);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.autoCadBtn,
            this.convertBtn,
            this.controlBtn,
            this.saveBtn});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(800, 26);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // autoCadBtn
            // 
            this.autoCadBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.autoCadBtn.Image = ((System.Drawing.Image)(resources.GetObject("autoCadBtn.Image")));
            this.autoCadBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.autoCadBtn.Name = "autoCadBtn";
            this.autoCadBtn.Size = new System.Drawing.Size(71, 23);
            this.autoCadBtn.Text = "AutoCAD";
            this.autoCadBtn.TextImageRelation = System.Windows.Forms.TextImageRelation.Overlay;
            this.autoCadBtn.Click += new System.EventHandler(this.ToolStripButton1_Click);
            // 
            // convertBtn
            // 
            this.convertBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.convertBtn.Image = ((System.Drawing.Image)(resources.GetObject("convertBtn.Image")));
            this.convertBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.convertBtn.Name = "convertBtn";
            this.convertBtn.Size = new System.Drawing.Size(61, 23);
            this.convertBtn.Text = "Konvert";
            this.convertBtn.Click += new System.EventHandler(this.ToolStripButton2_Click);
            // 
            // controlBtn
            // 
            this.controlBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.controlBtn.Image = ((System.Drawing.Image)(resources.GetObject("controlBtn.Image")));
            this.controlBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.controlBtn.Name = "controlBtn";
            this.controlBtn.Size = new System.Drawing.Size(59, 23);
            this.controlBtn.Text = "Control";
            this.controlBtn.Click += new System.EventHandler(this.ToolStripButton3_Click);
            // 
            // saveBtn
            // 
            this.saveBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.saveBtn.Image = ((System.Drawing.Image)(resources.GetObject("saveBtn.Image")));
            this.saveBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.saveBtn.Name = "saveBtn";
            this.saveBtn.Size = new System.Drawing.Size(41, 23);
            this.saveBtn.Text = "Save";
            this.saveBtn.Click += new System.EventHandler(this.SaveBtn_Click);
            // 
            // panel
            // 
            this.panel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel.Controls.Add(this.infoTextBox);
            this.panel.Controls.Add(this.label2);
            this.panel.Controls.Add(this.label1);
            this.panel.Location = new System.Drawing.Point(0, 29);
            this.panel.Name = "panel";
            this.panel.Size = new System.Drawing.Size(800, 421);
            this.panel.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(86, 38);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 15);
            this.label1.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(460, 116);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(0, 15);
            this.label2.TabIndex = 1;
            this.label2.Click += new System.EventHandler(this.Label2_Click);
            // 
            // infoTextBox
            // 
            this.infoTextBox.Location = new System.Drawing.Point(11, 15);
            this.infoTextBox.Multiline = true;
            this.infoTextBox.Name = "infoTextBox";
            this.infoTextBox.Size = new System.Drawing.Size(414, 349);
            this.infoTextBox.TabIndex = 2;
            this.infoTextBox.Text = "Some information";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.panel);
            this.Controls.Add(this.toolStrip1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.panel.ResumeLayout(false);
            this.panel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton autoCadBtn;
        private System.Windows.Forms.ToolStripButton convertBtn;
        private System.Windows.Forms.ToolStripButton controlBtn;
        private System.Windows.Forms.ToolStripButton saveBtn;
        private System.Windows.Forms.Panel panel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox infoTextBox;
    }
}

