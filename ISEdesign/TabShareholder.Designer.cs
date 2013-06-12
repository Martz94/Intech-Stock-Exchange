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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
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
            this._chartShareholder = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this._tabShareholder.SuspendLayout();
            this._tabPortfolio.SuspendLayout();
            this._tabOrderbook.SuspendLayout();
            this._tabStats.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._chartShareholder)).BeginInit();
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
            this._tabPortfolio.Size = new System.Drawing.Size(388, 136);
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
            this.listView1.Size = new System.Drawing.Size(382, 130);
            this.listView1.TabIndex = 0;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            this.listView1.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.listView1_ColumnClick);
            // 
            // columnHeaderCompany
            // 
            this.columnHeaderCompany.Text = "Company";
            this.columnHeaderCompany.Width = 120;
            // 
            // columnHeaderShareCount
            // 
            this.columnHeaderShareCount.Text = "Share Count";
            this.columnHeaderShareCount.Width = 77;
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
            this._tabOrderbook.Size = new System.Drawing.Size(388, 136);
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
            this.listView2.Size = new System.Drawing.Size(382, 130);
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
            this._tabStats.Controls.Add(this._chartShareholder);
            this._tabStats.Location = new System.Drawing.Point(4, 22);
            this._tabStats.Name = "_tabStats";
            this._tabStats.Size = new System.Drawing.Size(388, 136);
            this._tabStats.TabIndex = 2;
            this._tabStats.Text = "Graph";
            this._tabStats.UseVisualStyleBackColor = true;
            // 
            // _chartShareholder
            // 
            chartArea1.Name = "ChartArea1";
            this._chartShareholder.ChartAreas.Add(chartArea1);
            this._chartShareholder.Dock = System.Windows.Forms.DockStyle.Fill;
            legend1.Name = "Legend1";
            this._chartShareholder.Legends.Add(legend1);
            this._chartShareholder.Location = new System.Drawing.Point(0, 0);
            this._chartShareholder.Name = "_chartShareholder";
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this._chartShareholder.Series.Add(series1);
            this._chartShareholder.Size = new System.Drawing.Size(388, 136);
            this._chartShareholder.TabIndex = 0;
            this._chartShareholder.Text = "chart1";
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
            ((System.ComponentModel.ISupportInitialize)(this._chartShareholder)).EndInit();
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
        private System.Windows.Forms.DataVisualization.Charting.Chart _chartShareholder;
    }
}
