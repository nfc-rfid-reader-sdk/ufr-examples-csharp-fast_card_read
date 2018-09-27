namespace C_sharp_Fast_Card_Read
{
    partial class FastCardForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FastCardForm));
            this.bOpenReader = new System.Windows.Forms.Button();
            this.bCardInfo = new System.Windows.Forms.Button();
            this.bReadCard = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.saveTXT = new System.Windows.Forms.CheckBox();
            this.saveMFD = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tCardInfo = new System.Windows.Forms.RichTextBox();
            this.tReaderInfo = new System.Windows.Forms.RichTextBox();
            this.tInfo = new System.Windows.Forms.RichTextBox();
            this.ASCIIBox = new System.Windows.Forms.RichTextBox();
            this.LogoURL = new System.Windows.Forms.PictureBox();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.LogoURL)).BeginInit();
            this.SuspendLayout();
            // 
            // bOpenReader
            // 
            this.bOpenReader.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bOpenReader.Location = new System.Drawing.Point(181, 24);
            this.bOpenReader.Name = "bOpenReader";
            this.bOpenReader.Size = new System.Drawing.Size(116, 96);
            this.bOpenReader.TabIndex = 0;
            this.bOpenReader.Text = "OPEN READER";
            this.bOpenReader.UseVisualStyleBackColor = true;
            this.bOpenReader.Click += new System.EventHandler(this.bOpenReader_Click);
            // 
            // bCardInfo
            // 
            this.bCardInfo.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bCardInfo.Location = new System.Drawing.Point(743, 24);
            this.bCardInfo.Name = "bCardInfo";
            this.bCardInfo.Size = new System.Drawing.Size(124, 50);
            this.bCardInfo.TabIndex = 1;
            this.bCardInfo.Text = "CARD INFO";
            this.bCardInfo.UseVisualStyleBackColor = true;
            this.bCardInfo.Click += new System.EventHandler(this.bCardInfo_Click);
            // 
            // bReadCard
            // 
            this.bReadCard.Enabled = false;
            this.bReadCard.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bReadCard.Location = new System.Drawing.Point(743, 80);
            this.bReadCard.Name = "bReadCard";
            this.bReadCard.Size = new System.Drawing.Size(124, 40);
            this.bReadCard.TabIndex = 2;
            this.bReadCard.Text = "Read card";
            this.bReadCard.UseVisualStyleBackColor = true;
            this.bReadCard.Click += new System.EventHandler(this.bReadCard_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.saveTXT);
            this.groupBox1.Controls.Add(this.saveMFD);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(22, 129);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(904, 47);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(749, 19);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(42, 19);
            this.label2.TabIndex = 7;
            this.label2.Text = "ASCII";
            // 
            // saveTXT
            // 
            this.saveTXT.AutoSize = true;
            this.saveTXT.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.saveTXT.Location = new System.Drawing.Point(438, 18);
            this.saveTXT.Name = "saveTXT";
            this.saveTXT.Size = new System.Drawing.Size(165, 23);
            this.saveTXT.TabIndex = 6;
            this.saveTXT.Text = "Save as text file (.txt)";
            this.saveTXT.UseVisualStyleBackColor = true;
            // 
            // saveMFD
            // 
            this.saveMFD.AutoSize = true;
            this.saveMFD.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.saveMFD.Location = new System.Drawing.Point(176, 18);
            this.saveMFD.Name = "saveMFD";
            this.saveMFD.Size = new System.Drawing.Size(181, 23);
            this.saveMFD.TabIndex = 5;
            this.saveMFD.Text = "Save as raw data (.mfd)";
            this.saveMFD.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(6, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(110, 19);
            this.label1.TabIndex = 4;
            this.label1.Text = "Output options:";
            // 
            // tCardInfo
            // 
            this.tCardInfo.BackColor = System.Drawing.SystemColors.Info;
            this.tCardInfo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tCardInfo.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tCardInfo.Location = new System.Drawing.Point(322, 24);
            this.tCardInfo.Name = "tCardInfo";
            this.tCardInfo.Size = new System.Drawing.Size(402, 96);
            this.tCardInfo.TabIndex = 4;
            this.tCardInfo.Text = "";
            // 
            // tReaderInfo
            // 
            this.tReaderInfo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tReaderInfo.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tReaderInfo.Location = new System.Drawing.Point(22, 451);
            this.tReaderInfo.Name = "tReaderInfo";
            this.tReaderInfo.Size = new System.Drawing.Size(904, 85);
            this.tReaderInfo.TabIndex = 6;
            this.tReaderInfo.Text = "";
            // 
            // tInfo
            // 
            this.tInfo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tInfo.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tInfo.Location = new System.Drawing.Point(22, 179);
            this.tInfo.Name = "tInfo";
            this.tInfo.Size = new System.Drawing.Size(603, 266);
            this.tInfo.TabIndex = 7;
            this.tInfo.Text = resources.GetString("tInfo.Text");
            // 
            // ASCIIBox
            // 
            this.ASCIIBox.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ASCIIBox.Location = new System.Drawing.Point(631, 179);
            this.ASCIIBox.Name = "ASCIIBox";
            this.ASCIIBox.Size = new System.Drawing.Size(295, 266);
            this.ASCIIBox.TabIndex = 8;
            this.ASCIIBox.Text = "";
            // 
            // LogoURL
            // 
            this.LogoURL.Image = global::C_sharp_Fast_Card_Read.Properties.Resources.map_logo;
            this.LogoURL.Location = new System.Drawing.Point(22, 12);
            this.LogoURL.Name = "LogoURL";
            this.LogoURL.Size = new System.Drawing.Size(131, 108);
            this.LogoURL.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.LogoURL.TabIndex = 9;
            this.LogoURL.TabStop = false;
            this.LogoURL.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // FastCardForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(938, 544);
            this.Controls.Add(this.LogoURL);
            this.Controls.Add(this.ASCIIBox);
            this.Controls.Add(this.tInfo);
            this.Controls.Add(this.tReaderInfo);
            this.Controls.Add(this.tCardInfo);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.bReadCard);
            this.Controls.Add(this.bCardInfo);
            this.Controls.Add(this.bOpenReader);
            this.Name = "FastCardForm";
            this.Text = "C#-Fast-Card-Reader";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.LogoURL)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button bOpenReader;
        private System.Windows.Forms.Button bCardInfo;
        private System.Windows.Forms.Button bReadCard;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox saveTXT;
        private System.Windows.Forms.CheckBox saveMFD;
        private System.Windows.Forms.RichTextBox tCardInfo;
        private System.Windows.Forms.RichTextBox tReaderInfo;
        private System.Windows.Forms.RichTextBox tInfo;
        private System.Windows.Forms.RichTextBox ASCIIBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox LogoURL;
    }
}

