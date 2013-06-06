namespace ISEdesign
{
    partial class Actionbar
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this._initialize = new System.Windows.Forms.Button();
            this._stepByStep = new System.Windows.Forms.Button();
            this._round = new System.Windows.Forms.Label();
            this._roundNumber = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this._listShareholder = new System.Windows.Forms.ComboBox();
            this._goButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // _initialize
            // 
            this._initialize.Location = new System.Drawing.Point(3, 6);
            this._initialize.Name = "_initialize";
            this._initialize.Size = new System.Drawing.Size(75, 37);
            this._initialize.TabIndex = 0;
            this._initialize.Text = "Initialize...";
            this._initialize.UseVisualStyleBackColor = true;
            this._initialize.Click += new System.EventHandler(this._initialize_Click);
            // 
            // _stepByStep
            // 
            this._stepByStep.Location = new System.Drawing.Point(104, 6);
            this._stepByStep.Name = "_stepByStep";
            this._stepByStep.Size = new System.Drawing.Size(75, 37);
            this._stepByStep.TabIndex = 1;
            this._stepByStep.Text = "Step by Step";
            this._stepByStep.UseVisualStyleBackColor = true;
            // 
            // _round
            // 
            this._round.AutoSize = true;
            this._round.Location = new System.Drawing.Point(206, 6);
            this._round.Name = "_round";
            this._round.Size = new System.Drawing.Size(45, 13);
            this._round.TabIndex = 2;
            this._round.Text = "Round :";
            // 
            // _roundNumber
            // 
            this._roundNumber.Location = new System.Drawing.Point(209, 23);
            this._roundNumber.Name = "_roundNumber";
            this._roundNumber.Size = new System.Drawing.Size(39, 20);
            this._roundNumber.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(330, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(116, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Choose a shareholder :";
            // 
            // _listShareholder
            // 
            this._listShareholder.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._listShareholder.FormattingEnabled = true;
            this._listShareholder.Location = new System.Drawing.Point(333, 22);
            this._listShareholder.Name = "_listShareholder";
            this._listShareholder.Size = new System.Drawing.Size(113, 21);
            this._listShareholder.TabIndex = 5;
            this._listShareholder.SelectedIndexChanged += new System.EventHandler(this._listShareholder_SelectedIndexChanged);
            // 
            // _goButton
            // 
            this._goButton.Location = new System.Drawing.Point(257, 6);
            this._goButton.Name = "_goButton";
            this._goButton.Size = new System.Drawing.Size(43, 37);
            this._goButton.TabIndex = 6;
            this._goButton.Text = "Go";
            this._goButton.UseVisualStyleBackColor = true;
            // 
            // Actionbar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DeepPink;
            this.Controls.Add(this._goButton);
            this.Controls.Add(this._listShareholder);
            this.Controls.Add(this.label1);
            this.Controls.Add(this._roundNumber);
            this.Controls.Add(this._round);
            this.Controls.Add(this._stepByStep);
            this.Controls.Add(this._initialize);
            this.Name = "Actionbar";
            this.Size = new System.Drawing.Size(453, 53);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button _initialize;
        private System.Windows.Forms.Button _stepByStep;
        private System.Windows.Forms.Label _round;
        private System.Windows.Forms.TextBox _roundNumber;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox _listShareholder;
        private System.Windows.Forms.Button _goButton;
    }
}
