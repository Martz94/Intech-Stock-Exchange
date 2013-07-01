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
            this._companyNumber = new System.Windows.Forms.Label();
            this._nbCompanyTextBox = new System.Windows.Forms.TextBox();
            this._shareholderNumber = new System.Windows.Forms.Label();
            this._nbShareholderTextBox = new System.Windows.Forms.TextBox();
            this._okButton = new System.Windows.Forms.Button();
            this._cancelButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.RandomTrackBar = new System.Windows.Forms.TrackBar();
            this.Regular = new System.Windows.Forms.CheckedListBox();
            this.StupidTrackBar = new System.Windows.Forms.TrackBar();
            this.SmartTrackBar = new System.Windows.Forms.TrackBar();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.RandomTrackBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.StupidTrackBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SmartTrackBar)).BeginInit();
            this.SuspendLayout();
            // 
            // _companyNumber
            // 
            this._companyNumber.AutoSize = true;
            this._companyNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._companyNumber.Location = new System.Drawing.Point(12, 99);
            this._companyNumber.Name = "_companyNumber";
            this._companyNumber.Size = new System.Drawing.Size(130, 13);
            this._companyNumber.TabIndex = 0;
            this._companyNumber.Text = "Number of Companies";
            // 
            // _nbCompanyTextBox
            // 
            this._nbCompanyTextBox.Location = new System.Drawing.Point(168, 96);
            this._nbCompanyTextBox.Name = "_nbCompanyTextBox";
            this._nbCompanyTextBox.Size = new System.Drawing.Size(38, 20);
            this._nbCompanyTextBox.TabIndex = 1;
            this._nbCompanyTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this._Button_KeyDown);
            // 
            // _shareholderNumber
            // 
            this._shareholderNumber.AutoSize = true;
            this._shareholderNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._shareholderNumber.Location = new System.Drawing.Point(12, 232);
            this._shareholderNumber.Name = "_shareholderNumber";
            this._shareholderNumber.Size = new System.Drawing.Size(143, 13);
            this._shareholderNumber.TabIndex = 2;
            this._shareholderNumber.Text = "Number of Shareholders";
            // 
            // _nbShareholderTextBox
            // 
            this._nbShareholderTextBox.Location = new System.Drawing.Point(168, 229);
            this._nbShareholderTextBox.Name = "_nbShareholderTextBox";
            this._nbShareholderTextBox.Size = new System.Drawing.Size(38, 20);
            this._nbShareholderTextBox.TabIndex = 3;
            this._nbShareholderTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this._Button_KeyDown);
            // 
            // _okButton
            // 
            this._okButton.Location = new System.Drawing.Point(246, 374);
            this._okButton.Name = "_okButton";
            this._okButton.Size = new System.Drawing.Size(75, 23);
            this._okButton.TabIndex = 4;
            this._okButton.Text = "OK, GO!";
            this._okButton.UseVisualStyleBackColor = true;
            this._okButton.TabStopChanged += new System.EventHandler(this._okButton_Click);
            this._okButton.Click += new System.EventHandler(this._okButton_Click);
            this._okButton.Enter += new System.EventHandler(this._okButton_Click);
            this._okButton.KeyDown += new System.Windows.Forms.KeyEventHandler(this._Button_KeyDown);
            this._okButton.Validated += new System.EventHandler(this._okButton_Click);
            // 
            // _cancelButton
            // 
            this._cancelButton.Location = new System.Drawing.Point(42, 374);
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
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.label1.Location = new System.Drawing.Point(242, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(166, 20);
            this.label1.TabIndex = 7;
            this.label1.Text = "Create Your Market";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(310, 99);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(111, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "Market overall stability";
            // 
            // RandomTrackBar
            // 
            this.RandomTrackBar.Location = new System.Drawing.Point(458, 224);
            this.RandomTrackBar.Name = "RandomTrackBar";
            this.RandomTrackBar.Size = new System.Drawing.Size(135, 45);
            this.RandomTrackBar.TabIndex = 9;
            // 
            // Regular
            // 
            this.Regular.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.Regular.FormattingEnabled = true;
            this.Regular.Items.AddRange(new object[] {
            "Regular",
            "Quite stable",
            "Very stable",
            "Very unstable"});
            this.Regular.Location = new System.Drawing.Point(447, 78);
            this.Regular.Name = "Regular";
            this.Regular.Size = new System.Drawing.Size(166, 64);
            this.Regular.TabIndex = 10;
            // 
            // StupidTrackBar
            // 
            this.StupidTrackBar.Location = new System.Drawing.Point(458, 288);
            this.StupidTrackBar.Name = "StupidTrackBar";
            this.StupidTrackBar.Size = new System.Drawing.Size(135, 45);
            this.StupidTrackBar.TabIndex = 11;
            // 
            // SmartTrackBar
            // 
            this.SmartTrackBar.Location = new System.Drawing.Point(458, 352);
            this.SmartTrackBar.Name = "SmartTrackBar";
            this.SmartTrackBar.Size = new System.Drawing.Size(135, 45);
            this.SmartTrackBar.TabIndex = 12;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(505, 336);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(39, 13);
            this.label3.TabIndex = 13;
            this.label3.Text = "Smart";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(501, 272);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(43, 13);
            this.label4.TabIndex = 14;
            this.label4.Text = "Stupid";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(501, 208);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 13);
            this.label5.TabIndex = 15;
            this.label5.Text = "Random";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(310, 243);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(84, 13);
            this.label6.TabIndex = 16;
            this.label6.Text = "Strategy Factory";
            // 
            // CreateNewWorld
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLight;
            this.ClientSize = new System.Drawing.Size(616, 434);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.SmartTrackBar);
            this.Controls.Add(this.StupidTrackBar);
            this.Controls.Add(this.Regular);
            this.Controls.Add(this.RandomTrackBar);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this._cancelButton);
            this.Controls.Add(this._okButton);
            this.Controls.Add(this._nbShareholderTextBox);
            this.Controls.Add(this._shareholderNumber);
            this.Controls.Add(this._nbCompanyTextBox);
            this.Controls.Add(this._companyNumber);
            this.Name = "CreateNewWorld";
            this.Text = "CreateNewWorld";
            ((System.ComponentModel.ISupportInitialize)(this.RandomTrackBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.StupidTrackBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SmartTrackBar)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label _companyNumber;
        private System.Windows.Forms.TextBox _nbCompanyTextBox;
        private System.Windows.Forms.Label _shareholderNumber;
        private System.Windows.Forms.TextBox _nbShareholderTextBox;
        private System.Windows.Forms.Button _okButton;
        private System.Windows.Forms.Button _cancelButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TrackBar RandomTrackBar;
        private System.Windows.Forms.CheckedListBox Regular;
        private System.Windows.Forms.TrackBar StupidTrackBar;
        private System.Windows.Forms.TrackBar SmartTrackBar;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
    }
}