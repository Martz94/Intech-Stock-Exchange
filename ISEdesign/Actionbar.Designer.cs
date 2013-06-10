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
            this._goButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // _initialize
            // 
            this._initialize.Location = new System.Drawing.Point(32, 6);
            this._initialize.Name = "_initialize";
            this._initialize.Size = new System.Drawing.Size(75, 37);
            this._initialize.TabIndex = 0;
            this._initialize.Text = "Initialize...";
            this._initialize.UseVisualStyleBackColor = true;
            this._initialize.Click += new System.EventHandler(this._initialize_Click);
            // 
            // _stepByStep
            // 
            this._stepByStep.Location = new System.Drawing.Point(166, 7);
            this._stepByStep.Name = "_stepByStep";
            this._stepByStep.Size = new System.Drawing.Size(75, 37);
            this._stepByStep.TabIndex = 1;
            this._stepByStep.Text = "Step by Step";
            this._stepByStep.UseVisualStyleBackColor = true;
            this._stepByStep.Click += new System.EventHandler(this._stepByStep_Click);
            // 
            // _round
            // 
            this._round.AutoSize = true;
            this._round.Location = new System.Drawing.Point(285, 7);
            this._round.Name = "_round";
            this._round.Size = new System.Drawing.Size(45, 13);
            this._round.TabIndex = 2;
            this._round.Text = "Round :";
            // 
            // _roundNumber
            // 
            this._roundNumber.Location = new System.Drawing.Point(291, 23);
            this._roundNumber.Name = "_roundNumber";
            this._roundNumber.ScrollBars = System.Windows.Forms.ScrollBars.Horizontal;
            this._roundNumber.Size = new System.Drawing.Size(39, 20);
            this._roundNumber.TabIndex = 3;
            // 
            // _goButton
            // 
            this._goButton.Location = new System.Drawing.Point(351, 6);
            this._goButton.Name = "_goButton";
            this._goButton.Size = new System.Drawing.Size(43, 37);
            this._goButton.TabIndex = 6;
            this._goButton.Text = "Go";
            this._goButton.UseVisualStyleBackColor = true;
            this._goButton.Click += new System.EventHandler(this._goButtonClick);
            // 
            // Actionbar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.SkyBlue;
            this.Controls.Add(this._goButton);
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
        private System.Windows.Forms.Button _goButton;
    }
}
