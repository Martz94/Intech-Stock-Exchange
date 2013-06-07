namespace ISEdesign
{
    public partial class AppDesign
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
            this._marketView = new ISEdesign.MarketView();
            this.tabShareholder1 = new ISEdesign.TabShareholder();
            this._actionBar = new ISEdesign.Actionbar();
            this.SuspendLayout();
            // 
            // _marketView
            // 
            this._marketView.Dock = System.Windows.Forms.DockStyle.Fill;
            this._marketView.Location = new System.Drawing.Point(0, 53);
            this._marketView.Name = "_marketView";
            this._marketView.Size = new System.Drawing.Size(569, 159);
            this._marketView.TabIndex = 1;
            // 
            // tabShareholder1
            // 
            this.tabShareholder1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.tabShareholder1.Location = new System.Drawing.Point(0, 212);
            this.tabShareholder1.Name = "tabShareholder1";
            this.tabShareholder1.Size = new System.Drawing.Size(569, 163);
            this.tabShareholder1.TabIndex = 4;
            // 
            // _actionBar
            // 
            this._actionBar.BackColor = System.Drawing.Color.SkyBlue;
            this._actionBar.Dock = System.Windows.Forms.DockStyle.Top;
            this._actionBar.Location = new System.Drawing.Point( 0, 0 );
            this._actionBar.MarketView = null;
            this._actionBar.Name = "_actionBar";
            this._actionBar.Size = new System.Drawing.Size( 569, 53 );
            this._actionBar.TabIndex = 3;
            this._actionBar.TabShareholder = null;
            // 
            // AppDesign
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(569, 375);
            this.Controls.Add(this._marketView);
            this.Controls.Add(this._actionBar);
            this.Controls.Add(this.tabShareholder1);
            this.Name = "AppDesign";
            this.Text = "Intech Stock Exchange";
            this.ResumeLayout(false);

        }

        #endregion

        private MarketView _marketView;
        private TabShareholder tabShareholder1;
        private Actionbar _actionBar;
    }
}

