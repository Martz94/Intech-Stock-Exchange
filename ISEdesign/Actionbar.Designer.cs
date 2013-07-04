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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Actionbar));
            this._stepByStep = new System.Windows.Forms.Button();
            this._round = new System.Windows.Forms.Label();
            this._roundNumber = new System.Windows.Forms.TextBox();
            this._goButton = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this._autoRefresh = new System.Windows.Forms.CheckBox();
            this._buttonInitialize = new System.Windows.Forms.Button();
            this._openMarket = new System.Windows.Forms.PictureBox();
            this._saveMarket = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this._openMarket)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._saveMarket)).BeginInit();
            this.SuspendLayout();
            // 
            // _stepByStep
            // 
            this._stepByStep.Location = new System.Drawing.Point(275, 6);
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
            this._round.Location = new System.Drawing.Point(408, 6);
            this._round.Name = "_round";
            this._round.Size = new System.Drawing.Size(45, 13);
            this._round.TabIndex = 2;
            this._round.Text = "Round :";
            // 
            // _roundNumber
            // 
            this._roundNumber.Location = new System.Drawing.Point(414, 23);
            this._roundNumber.Name = "_roundNumber";
            this._roundNumber.ScrollBars = System.Windows.Forms.ScrollBars.Horizontal;
            this._roundNumber.Size = new System.Drawing.Size(39, 20);
            this._roundNumber.TabIndex = 3;
            // 
            // _goButton
            // 
            this._goButton.Location = new System.Drawing.Point(459, 6);
            this._goButton.Name = "_goButton";
            this._goButton.Size = new System.Drawing.Size(43, 37);
            this._goButton.TabIndex = 6;
            this._goButton.Text = "Go";
            this._goButton.UseVisualStyleBackColor = true;
            this._goButton.Click += new System.EventHandler(this._goButtonClick);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(677, 6);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(43, 37);
            this.button1.TabIndex = 7;
            this.button1.Text = "Stop";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // _autoRefresh
            // 
            this._autoRefresh.AutoSize = true;
            this._autoRefresh.Location = new System.Drawing.Point(522, 25);
            this._autoRefresh.Name = "_autoRefresh";
            this._autoRefresh.Size = new System.Drawing.Size(83, 17);
            this._autoRefresh.TabIndex = 8;
            this._autoRefresh.Text = "Auto refresh";
            this._autoRefresh.UseVisualStyleBackColor = true;
            // 
            // _buttonInitialize
            // 
            this._buttonInitialize.Location = new System.Drawing.Point(137, 6);
            this._buttonInitialize.Name = "_buttonInitialize";
            this._buttonInitialize.Size = new System.Drawing.Size(75, 37);
            this._buttonInitialize.TabIndex = 9;
            this._buttonInitialize.Text = "Initialize...";
            this._buttonInitialize.UseVisualStyleBackColor = true;
            this._buttonInitialize.Click += new System.EventHandler(this._buttonInitialize_Click);
            // 
            // _openMarket
            // 
            this._openMarket.Image = ((System.Drawing.Image)(resources.GetObject("_openMarket.Image")));
            this._openMarket.Location = new System.Drawing.Point(3, 15);
            this._openMarket.Name = "_openMarket";
            this._openMarket.Size = new System.Drawing.Size(29, 27);
            this._openMarket.TabIndex = 10;
            this._openMarket.TabStop = false;
            this._openMarket.Click += new System.EventHandler(this.openMarket_Click);
            // 
            // _saveMarket
            // 
            this._saveMarket.Image = ((System.Drawing.Image)(resources.GetObject("_saveMarket.Image")));
            this._saveMarket.Location = new System.Drawing.Point(49, 18);
            this._saveMarket.Name = "_saveMarket";
            this._saveMarket.Size = new System.Drawing.Size(23, 24);
            this._saveMarket.TabIndex = 11;
            this._saveMarket.TabStop = false;
            this._saveMarket.Click += new System.EventHandler(this.saveMarket_Click);
            // 
            // Actionbar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.SkyBlue;
            this.Controls.Add(this._saveMarket);
            this.Controls.Add(this._openMarket);
            this.Controls.Add(this._buttonInitialize);
            this.Controls.Add(this._autoRefresh);
            this.Controls.Add(this.button1);
            this.Controls.Add(this._goButton);
            this.Controls.Add(this._roundNumber);
            this.Controls.Add(this._round);
            this.Controls.Add(this._stepByStep);
            this.Name = "Actionbar";
            this.Size = new System.Drawing.Size(792, 53);
            ((System.ComponentModel.ISupportInitialize)(this._openMarket)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._saveMarket)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button _stepByStep;
        private System.Windows.Forms.Label _round;
        private System.Windows.Forms.TextBox _roundNumber;
        private System.Windows.Forms.Button _goButton;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.CheckBox _autoRefresh;
        private System.Windows.Forms.Button _buttonInitialize;
        private System.Windows.Forms.PictureBox _openMarket;
        private System.Windows.Forms.PictureBox _saveMarket;
    }
}
