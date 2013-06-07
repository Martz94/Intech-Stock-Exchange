namespace ISEdesign
{
    partial class TabShareholder
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
            this._tabShareholder = new System.Windows.Forms.TabControl();
            this._tabPortfolio = new System.Windows.Forms.TabPage();
            this.listView1 = new System.Windows.Forms.ListView();
            this.columnHeaderCompany = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderShareCount = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderCurrentSharePrice = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderShareVariation = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this._tabOrderbook = new System.Windows.Forms.TabPage();
            this.listView2 = new System.Windows.Forms.ListView();
            this.columnHeaderOrderSB = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderOrderCompany = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderOrderQuantity = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderOrderPrice = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this._tabStats = new System.Windows.Forms.TabPage();
            this._tabShareholder.SuspendLayout();
            this._tabPortfolio.SuspendLayout();
            this._tabOrderbook.SuspendLayout();
            this.SuspendLayout();
            // 
            // _tabShareholder
            // 
            this._tabShareholder.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._tabShareholder.Controls.Add(this._tabPortfolio);
            this._tabShareholder.Controls.Add(this._tabOrderbook);
            this._tabShareholder.Controls.Add(this._tabStats);
            this._tabShareholder.Location = new System.Drawing.Point(0, 0);
            this._tabShareholder.Name = "_tabShareholder";
            this._tabShareholder.SelectedIndex = 0;
            this._tabShareholder.Size = new System.Drawing.Size(399, 166);
            this._tabShareholder.TabIndex = 0;
            // 
            // _tabPortfolio
            // 
            this._tabPortfolio.Controls.Add(this.listView1);
            this._tabPortfolio.Location = new System.Drawing.Point(4, 22);
            this._tabPortfolio.Name = "_tabPortfolio";
            this._tabPortfolio.Padding = new System.Windows.Forms.Padding(3);
            this._tabPortfolio.Size = new System.Drawing.Size(391, 140);
            this._tabPortfolio.TabIndex = 0;
            this._tabPortfolio.Text = "Portfolio";
            this._tabPortfolio.UseVisualStyleBackColor = true;
            // 
            // listView1
            // 
            this.listView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeaderCompany,
            this.columnHeaderShareCount,
            this.columnHeaderCurrentSharePrice,
            this.columnHeaderShareVariation});
            this.listView1.GridLines = true;
            this.listView1.Location = new System.Drawing.Point(-4, 0);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(395, 142);
            this.listView1.TabIndex = 0;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            // 
            // columnHeaderCompany
            // 
            this.columnHeaderCompany.Text = "Company";
            this.columnHeaderCompany.Width = 98;
            // 
            // columnHeaderShareCount
            // 
            this.columnHeaderShareCount.Text = "Share Count";
            this.columnHeaderShareCount.Width = 87;
            // 
            // columnHeaderCurrentSharePrice
            // 
            this.columnHeaderCurrentSharePrice.Text = "Current Price";
            this.columnHeaderCurrentSharePrice.Width = 89;
            // 
            // columnHeaderShareVariation
            // 
            this.columnHeaderShareVariation.Text = "Variation";
            // 
            // _tabOrderbook
            // 
            this._tabOrderbook.Controls.Add(this.listView2);
            this._tabOrderbook.Location = new System.Drawing.Point(4, 22);
            this._tabOrderbook.Name = "_tabOrderbook";
            this._tabOrderbook.Padding = new System.Windows.Forms.Padding(3);
            this._tabOrderbook.Size = new System.Drawing.Size(391, 92);
            this._tabOrderbook.TabIndex = 1;
            this._tabOrderbook.Text = "Orderbook";
            this._tabOrderbook.UseVisualStyleBackColor = true;
            // 
            // listView2
            // 
            this.listView2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listView2.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeaderOrderSB,
            this.columnHeaderOrderCompany,
            this.columnHeaderOrderQuantity,
            this.columnHeaderOrderPrice});
            this.listView2.GridLines = true;
            this.listView2.Location = new System.Drawing.Point(0, 0);
            this.listView2.Name = "listView2";
            this.listView2.Size = new System.Drawing.Size(389, 97);
            this.listView2.TabIndex = 0;
            this.listView2.UseCompatibleStateImageBehavior = false;
            this.listView2.View = System.Windows.Forms.View.Details;
            // 
            // columnHeaderOrderSB
            // 
            this.columnHeaderOrderSB.Text = "Sell / Buy";
            // 
            // columnHeaderOrderCompany
            // 
            this.columnHeaderOrderCompany.Text = "Company";
            this.columnHeaderOrderCompany.Width = 85;
            // 
            // columnHeaderOrderQuantity
            // 
            this.columnHeaderOrderQuantity.Text = "Quantity";
            this.columnHeaderOrderQuantity.Width = 80;
            // 
            // columnHeaderOrderPrice
            // 
            this.columnHeaderOrderPrice.Text = "Price";
            // 
            // _tabStats
            // 
            this._tabStats.Location = new System.Drawing.Point(4, 22);
            this._tabStats.Name = "_tabStats";
            this._tabStats.Size = new System.Drawing.Size(391, 92);
            this._tabStats.TabIndex = 2;
            this._tabStats.Text = "Statistics";
            this._tabStats.UseVisualStyleBackColor = true;
            // 
            // TabShareholder
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this._tabShareholder);
            this.Name = "TabShareholder";
            this.Size = new System.Drawing.Size(396, 167);
            this._tabShareholder.ResumeLayout(false);
            this._tabPortfolio.ResumeLayout(false);
            this._tabOrderbook.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl _tabShareholder;
        private System.Windows.Forms.TabPage _tabPortfolio;
        private System.Windows.Forms.TabPage _tabOrderbook;
        private System.Windows.Forms.TabPage _tabStats;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ColumnHeader columnHeaderCompany;
        private System.Windows.Forms.ColumnHeader columnHeaderShareCount;
        private System.Windows.Forms.ColumnHeader columnHeaderCurrentSharePrice;
        private System.Windows.Forms.ColumnHeader columnHeaderShareVariation;
        private System.Windows.Forms.ListView listView2;
        private System.Windows.Forms.ColumnHeader columnHeaderOrderSB;
        private System.Windows.Forms.ColumnHeader columnHeaderOrderCompany;
        private System.Windows.Forms.ColumnHeader columnHeaderOrderQuantity;
        private System.Windows.Forms.ColumnHeader columnHeaderOrderPrice;
    }
}
