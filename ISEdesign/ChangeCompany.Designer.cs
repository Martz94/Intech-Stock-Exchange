namespace ISEdesign
{
    partial class ChangeCompany
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this._buttonOk = new System.Windows.Forms.Button();
            this._buttonCancel = new System.Windows.Forms.Button();
            this._companyNameTextBox = new System.Windows.Forms.TextBox();
            this._shareValueTextBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Company Name";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(279, 19);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Share value";
            // 
            // _buttonOk
            // 
            this._buttonOk.Location = new System.Drawing.Point(102, 54);
            this._buttonOk.Name = "_buttonOk";
            this._buttonOk.Size = new System.Drawing.Size(75, 23);
            this._buttonOk.TabIndex = 2;
            this._buttonOk.Text = "OK";
            this._buttonOk.UseVisualStyleBackColor = true;
            this._buttonOk.Click += new System.EventHandler(this._buttonOk_Click);
            // 
            // _buttonCancel
            // 
            this._buttonCancel.Location = new System.Drawing.Point(239, 54);
            this._buttonCancel.Name = "_buttonCancel";
            this._buttonCancel.Size = new System.Drawing.Size(75, 23);
            this._buttonCancel.TabIndex = 3;
            this._buttonCancel.Text = "Cancel";
            this._buttonCancel.UseVisualStyleBackColor = true;
            this._buttonCancel.Click += new System.EventHandler(this._buttonCancel_Click);
            // 
            // _companyNameTextBox
            // 
            this._companyNameTextBox.Location = new System.Drawing.Point(102, 16);
            this._companyNameTextBox.Name = "_companyNameTextBox";
            this._companyNameTextBox.Size = new System.Drawing.Size(114, 20);
            this._companyNameTextBox.TabIndex = 0;
            // 
            // _shareValueTextBox
            // 
            this._shareValueTextBox.Location = new System.Drawing.Point(349, 16);
            this._shareValueTextBox.Name = "_shareValueTextBox";
            this._shareValueTextBox.Size = new System.Drawing.Size(45, 20);
            this._shareValueTextBox.TabIndex = 5;
            this._shareValueTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this._okButton_KeyDown);
            // 
            // ChangeCompany
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(417, 98);
            this.Controls.Add(this._shareValueTextBox);
            this.Controls.Add(this._companyNameTextBox);
            this.Controls.Add(this._buttonCancel);
            this.Controls.Add(this._buttonOk);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "ChangeCompany";
            this.Text = "ChangeCompany";
            this.Enter += new System.EventHandler(this.ChangeCompany_Enter);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button _buttonOk;
        private System.Windows.Forms.Button _buttonCancel;
        private System.Windows.Forms.TextBox _companyNameTextBox;
        private System.Windows.Forms.TextBox _shareValueTextBox;
    }
}