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
            this.SuspendLayout();
            // 
            // _companyNumber
            // 
            this._companyNumber.AutoSize = true;
            this._companyNumber.Location = new System.Drawing.Point(21, 26);
            this._companyNumber.Name = "_companyNumber";
            this._companyNumber.Size = new System.Drawing.Size(99, 13);
            this._companyNumber.TabIndex = 0;
            this._companyNumber.Text = "Companies Number";
            // 
            // _nbCompanyTextBox
            // 
            this._nbCompanyTextBox.Location = new System.Drawing.Point(126, 23);
            this._nbCompanyTextBox.Name = "_nbCompanyTextBox";
            this._nbCompanyTextBox.Size = new System.Drawing.Size(38, 20);
            this._nbCompanyTextBox.TabIndex = 1;
            // 
            // _shareholderNumber
            // 
            this._shareholderNumber.AutoSize = true;
            this._shareholderNumber.Location = new System.Drawing.Point(224, 26);
            this._shareholderNumber.Name = "_shareholderNumber";
            this._shareholderNumber.Size = new System.Drawing.Size(109, 13);
            this._shareholderNumber.TabIndex = 2;
            this._shareholderNumber.Text = "Shareholders Number";
            // 
            // _nbShareholderTextBox
            // 
            this._nbShareholderTextBox.Location = new System.Drawing.Point(339, 23);
            this._nbShareholderTextBox.Name = "_nbShareholderTextBox";
            this._nbShareholderTextBox.Size = new System.Drawing.Size(38, 20);
            this._nbShareholderTextBox.TabIndex = 3;
            // 
            // _okButton
            // 
            this._okButton.Location = new System.Drawing.Point(105, 66);
            this._okButton.Name = "_okButton";
            this._okButton.Size = new System.Drawing.Size(75, 23);
            this._okButton.TabIndex = 4;
            this._okButton.Text = "OK";
            this._okButton.UseVisualStyleBackColor = true;
            this._okButton.Click += new System.EventHandler(this._okButton_Click);
            // 
            // _cancelButton
            // 
            this._cancelButton.Location = new System.Drawing.Point(227, 66);
            this._cancelButton.Name = "_cancelButton";
            this._cancelButton.Size = new System.Drawing.Size(75, 23);
            this._cancelButton.TabIndex = 5;
            this._cancelButton.Text = "Cancel";
            this._cancelButton.UseVisualStyleBackColor = true;
            this._cancelButton.Click += new System.EventHandler(this._cancelButton_Click);
            // 
            // CreateNewWorld
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(428, 101);
            this.Controls.Add(this._cancelButton);
            this.Controls.Add(this._okButton);
            this.Controls.Add(this._nbShareholderTextBox);
            this.Controls.Add(this._shareholderNumber);
            this.Controls.Add(this._nbCompanyTextBox);
            this.Controls.Add(this._companyNumber);
            this.Name = "CreateNewWorld";
            this.Text = "CreateNewWorld";
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
    }
}