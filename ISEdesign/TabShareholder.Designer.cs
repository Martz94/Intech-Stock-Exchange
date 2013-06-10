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
            this._nbBuyOrders = new System.Windows.Forms.Label();
            this._nbSellOrders = new System.Windows.Forms.Label();
            this._totalShareValue = new System.Windows.Forms.Label();
            this._cash = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this._tabShareholder.SuspendLayout();
            this._tabPortfolio.SuspendLayout();
            this._tabOrderbook.SuspendLayout();
            this._tabStats.SuspendLayout();
            this.SuspendLayout();
            // 
            // _tabShareholder
            // 
            this._tabShareholder.Controls.Add(this._tabPortfolio);
            this._tabShareholder.Controls.Add(this._tabOrderbook);
            this._tabShareholder.Controls.Add(this._tabStats);
            this._tabShareholder.Dock = System.Windows.Forms.DockStyle.Fill;
            this._tabShareholder.Location = new System.Drawing.Point(0, 0);
            this._tabShareholder.Name = "_tabShareholder";
            this._tabShareholder.SelectedIndex = 0;
            this._tabShareholder.Size = new System.Drawing.Size(396, 162);
            this._tabShareholder.TabIndex = 0;
            // 
            // _tabPortfolio
            // 
            this._tabPortfolio.Controls.Add(this.listView1);
            this._tabPortfolio.Location = new System.Drawing.Point(4, 22);
            this._tabPortfolio.Name = "_tabPortfolio";
            this._tabPortfolio.Padding = new System.Windows.Forms.Padding(3);
            this._tabPortfolio.Size = new System.Drawing.Size(388, 93);
            this._tabPortfolio.TabIndex = 0;
            this._tabPortfolio.Text = "Portfolio";
            this._tabPortfolio.UseVisualStyleBackColor = true;
            // 
            // listView1
            // 
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeaderCompany,
            this.columnHeaderShareCount,
            this.columnHeaderCurrentSharePrice,
            this.columnHeaderShareVariation});
            this.listView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listView1.GridLines = true;
            this.listView1.Location = new System.Drawing.Point(3, 3);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(382, 87);
            this.listView1.TabIndex = 0;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            // 
            // columnHeaderCompany
            // 
            this.columnHeaderCompany.Text = "Company";
            this.columnHeaderCompany.Width = 120;
            // 
            // columnHeaderShareCount
            // 
            this.columnHeaderShareCount.Text = "Share Count";
            this.columnHeaderShareCount.Width = 101;
            // 
            // columnHeaderCurrentSharePrice
            // 
            this.columnHeaderCurrentSharePrice.Text = "Current Price";
            this.columnHeaderCurrentSharePrice.Width = 94;
            // 
            // columnHeaderShareVariation
            // 
            this.columnHeaderShareVariation.Text = "Variation";
            this.columnHeaderShareVariation.Width = 68;
            // 
            // _tabOrderbook
            // 
            this._tabOrderbook.Controls.Add(this.listView2);
            this._tabOrderbook.Location = new System.Drawing.Point(4, 22);
            this._tabOrderbook.Name = "_tabOrderbook";
            this._tabOrderbook.Padding = new System.Windows.Forms.Padding(3);
            this._tabOrderbook.Size = new System.Drawing.Size(388, 93);
            this._tabOrderbook.TabIndex = 1;
            this._tabOrderbook.Text = "Orderbook";
            this._tabOrderbook.UseVisualStyleBackColor = true;
            // 
            // listView2
            // 
            this.listView2.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeaderOrderSB,
            this.columnHeaderOrderCompany,
            this.columnHeaderOrderQuantity,
            this.columnHeaderOrderPrice});
            this.listView2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listView2.GridLines = true;
            this.listView2.Location = new System.Drawing.Point(3, 3);
            this.listView2.Name = "listView2";
            this.listView2.Size = new System.Drawing.Size(382, 87);
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
            this._tabStats.Controls.Add(this._nbBuyOrders);
            this._tabStats.Controls.Add(this._nbSellOrders);
            this._tabStats.Controls.Add(this._totalShareValue);
            this._tabStats.Controls.Add(this._cash);
            this._tabStats.Controls.Add(this.label4);
            this._tabStats.Controls.Add(this.label3);
            this._tabStats.Controls.Add(this.label2);
            this._tabStats.Controls.Add(this.label1);
            this._tabStats.Location = new System.Drawing.Point(4, 22);
            this._tabStats.Name = "_tabStats";
            this._tabStats.Size = new System.Drawing.Size(388, 136);
            this._tabStats.TabIndex = 2;
            this._tabStats.Text = "Statistics";
            this._tabStats.UseVisualStyleBackColor = true;
            // 
            // _nbBuyOrders
            // 
            this._nbBuyOrders.AutoSize = true;
            this._nbBuyOrders.Location = new System.Drawing.Point(126, 67);
            this._nbBuyOrders.Name = "_nbBuyOrders";
            this._nbBuyOrders.Size = new System.Drawing.Size(0, 13);
            this._nbBuyOrders.TabIndex = 7;
            // 
            // _nbSellOrders
            // 
            this._nbSellOrders.AutoSize = true;
            this._nbSellOrders.Location = new System.Drawing.Point(126, 100);
            this._nbSellOrders.Name = "_nbSellOrders";
            this._nbSellOrders.Size = new System.Drawing.Size(0, 13);
            this._nbSellOrders.TabIndex = 6;
            // 
            // _totalShareValue
            // 
            this._totalShareValue.AutoSize = true;
            this._totalShareValue.Location = new System.Drawing.Point(126, 36);
            this._totalShareValue.Name = "_totalShareValue";
            this._totalShareValue.Size = new System.Drawing.Size(0, 13);
            this._totalShareValue.TabIndex = 5;
            // 
            // _cash
            // 
            this._cash.AutoSize = true;
            this._cash.Location = new System.Drawing.Point(126, 8);
            this._cash.Name = "_cash";
            this._cash.Size = new System.Drawing.Size(0, 13);
            this._cash.TabIndex = 4;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(8, 67);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(114, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Number of buy orders :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(8, 100);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(112, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Number of sell orders :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 36);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(95, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Total share value :";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(37, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Cash :";
            // 
            // TabShareholder
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this._tabShareholder);
            this.Name = "TabShareholder";
            this.Size = new System.Drawing.Size(396, 162);
            this._tabShareholder.ResumeLayout(false);
            this._tabPortfolio.ResumeLayout(false);
            this._tabOrderbook.ResumeLayout(false);
            this._tabStats.ResumeLayout(false);
            this._tabStats.PerformLayout();
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
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label _nbBuyOrders;
        private System.Windows.Forms.Label _nbSellOrders;
        private System.Windows.Forms.Label _totalShareValue;
        private System.Windows.Forms.Label _cash;
    }
}
