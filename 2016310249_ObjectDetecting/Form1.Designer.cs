namespace _2016310249_ObjectDetecting
{
    partial class Form1
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.cbBlur = new System.Windows.Forms.CheckBox();
            this.sbThreshold = new System.Windows.Forms.HScrollBar();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rbGreen = new System.Windows.Forms.RadioButton();
            this.label2 = new System.Windows.Forms.Label();
            this.rbBlue = new System.Windows.Forms.RadioButton();
            this.sbGreenColor = new System.Windows.Forms.HScrollBar();
            this.rbRed = new System.Windows.Forms.RadioButton();
            this.sbRedColor = new System.Windows.Forms.HScrollBar();
            this.sbBlueColor = new System.Windows.Forms.HScrollBar();
            this.sbRadius = new System.Windows.Forms.HScrollBar();
            this.textBox1 = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(12, 12);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(220, 20);
            this.comboBox1.TabIndex = 0;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox1.Location = new System.Drawing.Point(238, 36);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(320, 240);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 11;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // listBox1
            // 
            this.listBox1.BackColor = System.Drawing.Color.Black;
            this.listBox1.Font = new System.Drawing.Font("돋움체", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.listBox1.ForeColor = System.Drawing.Color.Lime;
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Location = new System.Drawing.Point(12, 38);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(220, 238);
            this.listBox1.TabIndex = 12;
            // 
            // pictureBox2
            // 
            this.pictureBox2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox2.Location = new System.Drawing.Point(564, 38);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(320, 240);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 13;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox3
            // 
            this.pictureBox3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox3.Location = new System.Drawing.Point(238, 282);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(320, 240);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox3.TabIndex = 14;
            this.pictureBox3.TabStop = false;
            // 
            // pictureBox4
            // 
            this.pictureBox4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox4.Location = new System.Drawing.Point(564, 282);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(320, 240);
            this.pictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox4.TabIndex = 15;
            this.pictureBox4.TabStop = false;
            // 
            // cbBlur
            // 
            this.cbBlur.AutoSize = true;
            this.cbBlur.Location = new System.Drawing.Point(250, 14);
            this.cbBlur.Name = "cbBlur";
            this.cbBlur.Size = new System.Drawing.Size(81, 16);
            this.cbBlur.TabIndex = 16;
            this.cbBlur.Text = "Blur apply";
            this.cbBlur.UseVisualStyleBackColor = true;
            this.cbBlur.CheckedChanged += new System.EventHandler(this.cbBlur_CheckedChanged);
            // 
            // sbThreshold
            // 
            this.sbThreshold.Location = new System.Drawing.Point(71, 17);
            this.sbThreshold.Maximum = 255;
            this.sbThreshold.Name = "sbThreshold";
            this.sbThreshold.Size = new System.Drawing.Size(146, 22);
            this.sbThreshold.TabIndex = 17;
            this.sbThreshold.Value = 40;
            this.sbThreshold.Scroll += new System.Windows.Forms.ScrollEventHandler(this.sbThreshold_Scroll);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 12);
            this.label1.TabIndex = 18;
            this.label1.Text = "Threshold";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rbGreen);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.rbBlue);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.sbGreenColor);
            this.groupBox1.Controls.Add(this.rbRed);
            this.groupBox1.Controls.Add(this.sbRedColor);
            this.groupBox1.Controls.Add(this.sbBlueColor);
            this.groupBox1.Controls.Add(this.sbRadius);
            this.groupBox1.Controls.Add(this.sbThreshold);
            this.groupBox1.Location = new System.Drawing.Point(12, 282);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(220, 176);
            this.groupBox1.TabIndex = 19;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Option";
            // 
            // rbGreen
            // 
            this.rbGreen.AutoSize = true;
            this.rbGreen.Location = new System.Drawing.Point(6, 151);
            this.rbGreen.Name = "rbGreen";
            this.rbGreen.Size = new System.Drawing.Size(57, 16);
            this.rbGreen.TabIndex = 20;
            this.rbGreen.TabStop = true;
            this.rbGreen.Text = "Green";
            this.rbGreen.UseVisualStyleBackColor = true;
            this.rbGreen.CheckedChanged += new System.EventHandler(this.rbGreen_CheckedChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 51);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 12);
            this.label2.TabIndex = 18;
            this.label2.Text = "Raudis";
            // 
            // rbBlue
            // 
            this.rbBlue.AutoSize = true;
            this.rbBlue.Location = new System.Drawing.Point(6, 115);
            this.rbBlue.Name = "rbBlue";
            this.rbBlue.Size = new System.Drawing.Size(48, 16);
            this.rbBlue.TabIndex = 20;
            this.rbBlue.TabStop = true;
            this.rbBlue.Text = "Blue";
            this.rbBlue.UseVisualStyleBackColor = true;
            this.rbBlue.CheckedChanged += new System.EventHandler(this.rbBlue_CheckedChanged);
            // 
            // sbGreenColor
            // 
            this.sbGreenColor.Location = new System.Drawing.Point(71, 145);
            this.sbGreenColor.Maximum = 255;
            this.sbGreenColor.Name = "sbGreenColor";
            this.sbGreenColor.Size = new System.Drawing.Size(146, 22);
            this.sbGreenColor.TabIndex = 17;
            this.sbGreenColor.Value = 30;
            this.sbGreenColor.Scroll += new System.Windows.Forms.ScrollEventHandler(this.sbGreenColor_Scroll);
            // 
            // rbRed
            // 
            this.rbRed.AutoSize = true;
            this.rbRed.Checked = true;
            this.rbRed.Location = new System.Drawing.Point(6, 81);
            this.rbRed.Name = "rbRed";
            this.rbRed.Size = new System.Drawing.Size(45, 16);
            this.rbRed.TabIndex = 19;
            this.rbRed.TabStop = true;
            this.rbRed.Text = "Red";
            this.rbRed.UseVisualStyleBackColor = true;
            this.rbRed.CheckedChanged += new System.EventHandler(this.rbRed_CheckedChanged);
            // 
            // sbRedColor
            // 
            this.sbRedColor.Location = new System.Drawing.Point(71, 81);
            this.sbRedColor.Maximum = 255;
            this.sbRedColor.Name = "sbRedColor";
            this.sbRedColor.Size = new System.Drawing.Size(146, 22);
            this.sbRedColor.TabIndex = 17;
            this.sbRedColor.Value = 220;
            this.sbRedColor.Scroll += new System.Windows.Forms.ScrollEventHandler(this.sbRedColor_Scroll);
            // 
            // sbBlueColor
            // 
            this.sbBlueColor.Location = new System.Drawing.Point(71, 115);
            this.sbBlueColor.Maximum = 255;
            this.sbBlueColor.Name = "sbBlueColor";
            this.sbBlueColor.Size = new System.Drawing.Size(146, 22);
            this.sbBlueColor.TabIndex = 17;
            this.sbBlueColor.Value = 30;
            this.sbBlueColor.Scroll += new System.Windows.Forms.ScrollEventHandler(this.sbBlueColor_Scroll);
            // 
            // sbRadius
            // 
            this.sbRadius.Location = new System.Drawing.Point(71, 48);
            this.sbRadius.Maximum = 450;
            this.sbRadius.Name = "sbRadius";
            this.sbRadius.Size = new System.Drawing.Size(146, 22);
            this.sbRadius.TabIndex = 17;
            this.sbRadius.Value = 100;
            this.sbRadius.Scroll += new System.Windows.Forms.ScrollEventHandler(this.sbRadius_Scroll);
            // 
            // textBox1
            // 
            this.textBox1.Enabled = false;
            this.textBox1.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.textBox1.Location = new System.Drawing.Point(238, 252);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(178, 26);
            this.textBox1.TabIndex = 20;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(892, 570);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.cbBlur);
            this.Controls.Add(this.pictureBox4);
            this.Controls.Add(this.pictureBox3);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.comboBox1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.PictureBox pictureBox4;
        private System.Windows.Forms.CheckBox cbBlur;
        private System.Windows.Forms.HScrollBar sbThreshold;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rbGreen;
        private System.Windows.Forms.RadioButton rbBlue;
        private System.Windows.Forms.RadioButton rbRed;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.HScrollBar sbRadius;
        private System.Windows.Forms.HScrollBar sbGreenColor;
        private System.Windows.Forms.HScrollBar sbBlueColor;
        private System.Windows.Forms.HScrollBar sbRedColor;
        private System.Windows.Forms.TextBox textBox1;
    }
}

