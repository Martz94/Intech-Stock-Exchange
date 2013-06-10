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
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.splitContainer3 = new System.Windows.Forms.SplitContainer();
            this._marketView = new ISEdesign.MarketView();
            this.graph1 = new ISEdesign.Graph();
            this.shareholderView1 = new ISEdesign.ShareholderView();
            this.tabShareholder1 = new ISEdesign.TabShareholder();
            this._actionBar = new ISEdesign.Actionbar();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).BeginInit();
            this.splitContainer3.Panel1.SuspendLayout();
            this.splitContainer3.Panel2.SuspendLayout();
            this.splitContainer3.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 53);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.splitContainer2);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.splitContainer3);
            this.splitContainer1.Size = new System.Drawing.Size(739, 427);
            this.splitContainer1.SplitterDistance = 320;
            this.splitContainer1.TabIndex = 8;
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this._marketView);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.graph1);
            this.splitContainer2.Size = new System.Drawing.Size(320, 427);
            this.splitContainer2.SplitterDistance = 210;
            this.splitContainer2.TabIndex = 0;
            // 
            // splitContainer3
            // 
            this.splitContainer3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer3.Location = new System.Drawing.Point(0, 0);
            this.splitContainer3.Name = "splitContainer3";
            this.splitContainer3.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer3.Panel1
            // 
            this.splitContainer3.Panel1.Controls.Add(this.shareholderView1);
            // 
            // splitContainer3.Panel2
            // 
            this.splitContainer3.Panel2.Controls.Add(this.tabShareholder1);
            this.splitContainer3.Size = new System.Drawing.Size(415, 427);
            this.splitContainer3.SplitterDistance = 209;
            this.splitContainer3.TabIndex = 0;
            // 
            // _marketView
            // 
            this._marketView.Dock = System.Windows.Forms.DockStyle.Fill;
            this._marketView.Location = new System.Drawing.Point(0, 0);
            this._marketView.Name = "_marketView";
            this._marketView.Size = new System.Drawing.Size(320, 210);
            this._marketView.TabIndex = 1;
            // 
            // graph1
            // 
            this.graph1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.graph1.Location = new System.Drawing.Point(0, 0);
            this.graph1.Name = "graph1";
            this.graph1.Size = new System.Drawing.Size(320, 213);
            this.graph1.TabIndex = 5;
            // 
            // shareholderView1
            // 
            this.shareholderView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.shareholderView1.Location = new System.Drawing.Point(0, 0);
            this.shareholderView1.Name = "shareholderView1";
            this.shareholderView1.Size = new System.Drawing.Size(415, 209);
            this.shareholderView1.TabIndex = 7;
            this.shareholderView1.TabShareholder = null;
            // 
            // tabShareholder1
            // 
            this.tabShareholder1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabShareholder1.Location = new System.Drawing.Point(0, 0);
            this.tabShareholder1.Name = "tabShareholder1";
            this.tabShareholder1.Size = new System.Drawing.Size(415, 214);
            this.tabShareholder1.TabIndex = 4;
            // 
            // _actionBar
            // 
            this._actionBar.BackColor = System.Drawing.Color.SkyBlue;
            this._actionBar.Dock = System.Windows.Forms.DockStyle.Top;
            this._actionBar.Location = new System.Drawing.Point(0, 0);
            this._actionBar.MarketView = null;
            this._actionBar.Name = "_actionBar";
            this._actionBar.ShareholderView = null;
            this._actionBar.Size = new System.Drawing.Size(739, 53);
            this._actionBar.TabIndex = 3;
            this._actionBar.TabShareholder = null;
            // 
            // AppDesign
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(739, 480);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this._actionBar);
            this.Name = "AppDesign";
            this.Text = "Intech Stock Exchange";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.splitContainer3.Panel1.ResumeLayout(false);
            this.splitContainer3.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).EndInit();
            this.splitContainer3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private MarketView _marketView;
        private TabShareholder tabShareholder1;
        private Actionbar _actionBar;
        private Graph graph1;
        private ShareholderView shareholderView1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.SplitContainer splitContainer3;
    }
}

