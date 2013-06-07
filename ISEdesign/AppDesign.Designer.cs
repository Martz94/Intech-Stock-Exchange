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
            this.marketView1 = new ISEdesign.MarketView();
            this.actionbar1 = new ISEdesign.Actionbar();
            this.tabShareholder1 = new ISEdesign.TabShareholder();
            this.SuspendLayout();
            // 
            // marketView1
            // 
            this.marketView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.marketView1.Location = new System.Drawing.Point(0, 53);
            this.marketView1.Name = "marketView1";
            this.marketView1.Size = new System.Drawing.Size(553, 170);
            this.marketView1.TabIndex = 1;
            // 
            // actionbar1
            // 
            this.actionbar1.BackColor = System.Drawing.Color.DeepPink;
            this.actionbar1.Dock = System.Windows.Forms.DockStyle.Top;
            this.actionbar1.Location = new System.Drawing.Point(0, 0);
            this.actionbar1.MarketView = null;
            this.actionbar1.Name = "actionbar1";
            this.actionbar1.Size = new System.Drawing.Size(553, 53);
            this.actionbar1.TabIndex = 3;
            this.actionbar1.TabShareholder = null;
            // 
            // tabShareholder1
            // 
            this.tabShareholder1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.tabShareholder1.Location = new System.Drawing.Point(0, 223);
            this.tabShareholder1.Name = "tabShareholder1";
            this.tabShareholder1.Size = new System.Drawing.Size(553, 119);
            this.tabShareholder1.TabIndex = 2;
            // 
            // AppDesign
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(553, 342);
            this.Controls.Add(this.marketView1);
            this.Controls.Add(this.actionbar1);
            this.Controls.Add(this.tabShareholder1);
            this.Name = "AppDesign";
            this.Text = "Intech Stock Exchange";
            this.ResumeLayout(false);

        }

        #endregion

        private MarketView marketView1;
        private TabShareholder tabShareholder1;
        private Actionbar actionbar1;
    }
}

