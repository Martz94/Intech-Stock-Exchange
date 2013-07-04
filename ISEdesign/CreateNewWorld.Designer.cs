namespace ISEdesign
{
    partial class CreateNewWorld
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose( bool disposing )
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose( disposing );
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CreateNewWorld));
            this._companyNumber = new System.Windows.Forms.Label();
            this._nbCompanyTextBox = new System.Windows.Forms.TextBox();
            this._shareholderNumber = new System.Windows.Forms.Label();
            this._okButton = new System.Windows.Forms.Button();
            this._cancelButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.RandomTrackBar = new System.Windows.Forms.TrackBar();
            this.StupidTrackBar = new System.Windows.Forms.TrackBar();
            this.SmartTrackBar = new System.Windows.Forms.TrackBar();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.nbRandom = new System.Windows.Forms.Label();
            this.nbStupid = new System.Windows.Forms.Label();
            this.nbSmart = new System.Windows.Forms.Label();
            this._labelNbSh = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.label2 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label7 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.RandomTrackBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.StupidTrackBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SmartTrackBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // _companyNumber
            // 
            this._companyNumber.AutoSize = true;
            this._companyNumber.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._companyNumber.Location = new System.Drawing.Point(260, 98);
            this._companyNumber.Name = "_companyNumber";
            this._companyNumber.Size = new System.Drawing.Size(128, 15);
            this._companyNumber.TabIndex = 0;
            this._companyNumber.Text = "Number of Companies";
            // 
            // _nbCompanyTextBox
            // 
            this._nbCompanyTextBox.Location = new System.Drawing.Point(417, 96);
            this._nbCompanyTextBox.Name = "_nbCompanyTextBox";
            this._nbCompanyTextBox.Size = new System.Drawing.Size(38, 20);
            this._nbCompanyTextBox.TabIndex = 1;
            this._nbCompanyTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this._Button_KeyDown);
            // 
            // _shareholderNumber
            // 
            this._shareholderNumber.AutoSize = true;
            this._shareholderNumber.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._shareholderNumber.Location = new System.Drawing.Point(25, 264);
            this._shareholderNumber.Name = "_shareholderNumber";
            this._shareholderNumber.Size = new System.Drawing.Size(140, 15);
            this._shareholderNumber.TabIndex = 2;
            this._shareholderNumber.Text = "Number of Shareholders";
            // 
            // _okButton
            // 
            this._okButton.Location = new System.Drawing.Point(327, 419);
            this._okButton.Name = "_okButton";
            this._okButton.Size = new System.Drawing.Size(75, 23);
            this._okButton.TabIndex = 4;
            this._okButton.Text = "OK";
            this._okButton.UseVisualStyleBackColor = true;
            this._okButton.TabStopChanged += new System.EventHandler(this._okButton_Click);
            this._okButton.Click += new System.EventHandler(this._okButton_Click);
            this._okButton.Enter += new System.EventHandler(this._okButton_Click);
            this._okButton.KeyDown += new System.Windows.Forms.KeyEventHandler(this._Button_KeyDown);
            this._okButton.Validated += new System.EventHandler(this._okButton_Click);
            // 
            // _cancelButton
            // 
            this._cancelButton.Location = new System.Drawing.Point(173, 419);
            this._cancelButton.Name = "_cancelButton";
            this._cancelButton.Size = new System.Drawing.Size(75, 23);
            this._cancelButton.TabIndex = 5;
            this._cancelButton.Text = "Cancel";
            this._cancelButton.UseVisualStyleBackColor = true;
            this._cancelButton.Click += new System.EventHandler(this._cancelButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Calibri", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.label1.Location = new System.Drawing.Point(223, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(179, 26);
            this.label1.TabIndex = 7;
            this.label1.Text = "Create Your Market";
            // 
            // RandomTrackBar
            // 
            this.RandomTrackBar.Location = new System.Drawing.Point(19, 344);
            this.RandomTrackBar.Maximum = 100;
            this.RandomTrackBar.Name = "RandomTrackBar";
            this.RandomTrackBar.Size = new System.Drawing.Size(135, 45);
            this.RandomTrackBar.TabIndex = 9;
            this.RandomTrackBar.TickFrequency = 10;
            this.RandomTrackBar.ValueChanged += new System.EventHandler(this.RandomTrackBar_ValueChanged);
            // 
            // StupidTrackBar
            // 
            this.StupidTrackBar.Location = new System.Drawing.Point(228, 344);
            this.StupidTrackBar.Maximum = 100;
            this.StupidTrackBar.Name = "StupidTrackBar";
            this.StupidTrackBar.Size = new System.Drawing.Size(135, 45);
            this.StupidTrackBar.TabIndex = 11;
            this.StupidTrackBar.TickFrequency = 10;
            this.StupidTrackBar.ValueChanged += new System.EventHandler(this.StupidTrackBar_ValueChanged);
            // 
            // SmartTrackBar
            // 
            this.SmartTrackBar.Location = new System.Drawing.Point(441, 344);
            this.SmartTrackBar.Maximum = 100;
            this.SmartTrackBar.Name = "SmartTrackBar";
            this.SmartTrackBar.Size = new System.Drawing.Size(135, 45);
            this.SmartTrackBar.TabIndex = 12;
            this.SmartTrackBar.TickFrequency = 10;
            this.SmartTrackBar.ValueChanged += new System.EventHandler(this.SmartTrackBar_ValueChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Blue;
            this.label3.Location = new System.Drawing.Point(491, 326);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(40, 15);
            this.label3.TabIndex = 13;
            this.label3.Text = "Smart";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Green;
            this.label4.Location = new System.Drawing.Point(276, 326);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(42, 15);
            this.label4.TabIndex = 14;
            this.label4.Text = "Stupid";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Red;
            this.label5.Location = new System.Drawing.Point(65, 326);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(52, 15);
            this.label5.TabIndex = 15;
            this.label5.Text = "Random";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(82, 204);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(99, 19);
            this.label6.TabIndex = 16;
            this.label6.Text = "Shareholders";
            // 
            // nbRandom
            // 
            this.nbRandom.AutoSize = true;
            this.nbRandom.Location = new System.Drawing.Point(83, 376);
            this.nbRandom.Name = "nbRandom";
            this.nbRandom.Size = new System.Drawing.Size(13, 13);
            this.nbRandom.TabIndex = 17;
            this.nbRandom.Text = "0";
            // 
            // nbStupid
            // 
            this.nbStupid.AutoSize = true;
            this.nbStupid.Location = new System.Drawing.Point(290, 376);
            this.nbStupid.Name = "nbStupid";
            this.nbStupid.Size = new System.Drawing.Size(13, 13);
            this.nbStupid.TabIndex = 18;
            this.nbStupid.Text = "0";
            // 
            // nbSmart
            // 
            this.nbSmart.AutoSize = true;
            this.nbSmart.Location = new System.Drawing.Point(505, 376);
            this.nbSmart.Name = "nbSmart";
            this.nbSmart.Size = new System.Drawing.Size(13, 13);
            this.nbSmart.TabIndex = 19;
            this.nbSmart.Text = "0";
            // 
            // _labelNbSh
            // 
            this._labelNbSh.AutoSize = true;
            this._labelNbSh.Location = new System.Drawing.Point(181, 266);
            this._labelNbSh.Name = "_labelNbSh";
            this._labelNbSh.Size = new System.Drawing.Size(0, 13);
            this._labelNbSh.TabIndex = 20;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(39, 88);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(37, 39);
            this.pictureBox1.TabIndex = 21;
            this.pictureBox1.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(36, 188);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(40, 35);
            this.pictureBox2.TabIndex = 22;
            this.pictureBox2.TabStop = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(82, 98);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(83, 19);
            this.label2.TabIndex = 23;
            this.label2.Text = "Companies";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.Window;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Location = new System.Drawing.Point(12, 169);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(577, 1);
            this.panel1.TabIndex = 24;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(260, 210);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(295, 13);
            this.label7.TabIndex = 25;
            this.label7.Text = "Scroll the trackbars to determine the number of shareholders";
            // 
            // CreateNewWorld
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLight;
            this.ClientSize = new System.Drawing.Size(601, 464);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this._labelNbSh);
            this.Controls.Add(this.nbSmart);
            this.Controls.Add(this.nbStupid);
            this.Controls.Add(this.nbRandom);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.SmartTrackBar);
            this.Controls.Add(this.StupidTrackBar);
            this.Controls.Add(this.RandomTrackBar);
            this.Controls.Add(this.label1);
            this.Controls.Add(this._cancelButton);
            this.Controls.Add(this._okButton);
            this.Controls.Add(this._shareholderNumber);
            this.Controls.Add(this._nbCompanyTextBox);
            this.Controls.Add(this._companyNumber);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "CreateNewWorld";
            this.Text = "CreateNewWorld";
            ((System.ComponentModel.ISupportInitialize)(this.RandomTrackBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.StupidTrackBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SmartTrackBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label _companyNumber;
        private System.Windows.Forms.TextBox _nbCompanyTextBox;
        private System.Windows.Forms.Label _shareholderNumber;
        private System.Windows.Forms.Button _okButton;
        private System.Windows.Forms.Button _cancelButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TrackBar RandomTrackBar;
        private System.Windows.Forms.TrackBar StupidTrackBar;
        private System.Windows.Forms.TrackBar SmartTrackBar;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label nbRandom;
        private System.Windows.Forms.Label nbStupid;
        private System.Windows.Forms.Label nbSmart;
        private System.Windows.Forms.Label _labelNbSh;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label7;
    }
}