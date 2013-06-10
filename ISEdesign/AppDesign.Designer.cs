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
            this.splitter1 = new System.Windows.Forms.Splitter();
            this._marketView = new ISEdesign.MarketView();
            this._actionBar = new ISEdesign.Actionbar();
            this.tabShareholder1 = new ISEdesign.TabShareholder();
            this.graph1 = new ISEdesign.Graph();
            this.SuspendLayout();
            // 
            // splitter1
            // 
            this.splitter1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.splitter1.Location = new System.Drawing.Point(0, 317);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(739, 3);
            this.splitter1.TabIndex = 6;
            this.splitter1.TabStop = false;
            // 
            // _marketView
            // 
            this._marketView.Dock = System.Windows.Forms.DockStyle.Left;
            this._marketView.Location = new System.Drawing.Point(0, 53);
            this._marketView.Name = "_marketView";
            this._marketView.Size = new System.Drawing.Size(316, 264);
            this._marketView.TabIndex = 1;
            // 
            // _actionBar
            // 
            this._actionBar.BackColor = System.Drawing.Color.SkyBlue;
            this._actionBar.Dock = System.Windows.Forms.DockStyle.Top;
            this._actionBar.Location = new System.Drawing.Point(0, 0);
            this._actionBar.MarketView = null;
            this._actionBar.Name = "_actionBar";
            this._actionBar.Size = new System.Drawing.Size(739, 53);
            this._actionBar.TabIndex = 3;
            this._actionBar.TabShareholder = null;
            // 
            // tabShareholder1
            // 
            this.tabShareholder1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabShareholder1.Location = new System.Drawing.Point(316, 53);
            this.tabShareholder1.Name = "tabShareholder1";
            this.tabShareholder1.Size = new System.Drawing.Size(423, 264);
            this.tabShareholder1.TabIndex = 4;
            // 
            // graph1
            // 
            this.graph1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.graph1.Location = new System.Drawing.Point(0, 320);
            this.graph1.Name = "graph1";
            this.graph1.Size = new System.Drawing.Size(739, 160);
            this.graph1.TabIndex = 5;
            // 
            // AppDesign
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(739, 480);
            this.Controls.Add(this.tabShareholder1);
            this.Controls.Add(this._marketView);
            this.Controls.Add(this._actionBar);
            this.Controls.Add(this.splitter1);
            this.Controls.Add(this.graph1);
            this.Name = "AppDesign";
            this.Text = "Intech Stock Exchange";
            this.ResumeLayout(false);

        }

        #endregion

        private MarketView _marketView;
        private TabShareholder tabShareholder1;
        private Actionbar _actionBar;
        private Graph graph1;
        private System.Windows.Forms.Splitter splitter1;
    }
}

