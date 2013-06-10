namespace ISEdesign
{
    partial class Graph
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabCompanyStockPrice = new System.Windows.Forms.TabPage();
            this._chartStockPrice = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.tabCompany = new System.Windows.Forms.TabPage();
            this._chartCompany = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.tabControl1.SuspendLayout();
            this.tabCompanyStockPrice.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._chartStockPrice)).BeginInit();
            this.tabCompany.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._chartCompany)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabCompanyStockPrice);
            this.tabControl1.Controls.Add(this.tabCompany);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(515, 436);
            this.tabControl1.TabIndex = 0;
            // 
            // tabCompanyStockPrice
            // 
            this.tabCompanyStockPrice.Controls.Add(this._chartStockPrice);
            this.tabCompanyStockPrice.Location = new System.Drawing.Point(4, 22);
            this.tabCompanyStockPrice.Name = "tabCompanyStockPrice";
            this.tabCompanyStockPrice.Padding = new System.Windows.Forms.Padding(3);
            this.tabCompanyStockPrice.Size = new System.Drawing.Size(507, 410);
            this.tabCompanyStockPrice.TabIndex = 1;
            this.tabCompanyStockPrice.Text = "Stock Price";
            this.tabCompanyStockPrice.UseVisualStyleBackColor = true;
            // 
            // _chartStockPrice
            // 
            chartArea1.Name = "ChartArea1";
            this._chartStockPrice.ChartAreas.Add(chartArea1);
            this._chartStockPrice.Dock = System.Windows.Forms.DockStyle.Fill;
            legend1.Name = "Legend1";
            this._chartStockPrice.Legends.Add(legend1);
            this._chartStockPrice.Location = new System.Drawing.Point(3, 3);
            this._chartStockPrice.Name = "_chartStockPrice";
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this._chartStockPrice.Series.Add(series1);
            this._chartStockPrice.Size = new System.Drawing.Size(501, 404);
            this._chartStockPrice.TabIndex = 0;
            this._chartStockPrice.Text = "chart1";
            // 
            // tabCompany
            // 
            this.tabCompany.Controls.Add(this._chartCompany);
            this.tabCompany.Location = new System.Drawing.Point(4, 22);
            this.tabCompany.Name = "tabCompany";
            this.tabCompany.Padding = new System.Windows.Forms.Padding(3);
            this.tabCompany.Size = new System.Drawing.Size(507, 410);
            this.tabCompany.TabIndex = 0;
            this.tabCompany.Text = "Volume";
            this.tabCompany.UseVisualStyleBackColor = true;
            // 
            // _chartCompany
            // 
            chartArea2.Name = "ChartArea1";
            this._chartCompany.ChartAreas.Add(chartArea2);
            this._chartCompany.Dock = System.Windows.Forms.DockStyle.Fill;
            legend2.Name = "Legend1";
            this._chartCompany.Legends.Add(legend2);
            this._chartCompany.Location = new System.Drawing.Point(3, 3);
            this._chartCompany.Name = "_chartCompany";
            series2.ChartArea = "ChartArea1";
            series2.Legend = "Legend1";
            series2.Name = "Series1";
            this._chartCompany.Series.Add(series2);
            this._chartCompany.Size = new System.Drawing.Size(501, 404);
            this._chartCompany.TabIndex = 0;
            this._chartCompany.Text = "chart1";
            // 
            // Graph
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tabControl1);
            this.Name = "Graph";
            this.Size = new System.Drawing.Size(515, 436);
            this.tabControl1.ResumeLayout(false);
            this.tabCompanyStockPrice.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this._chartStockPrice)).EndInit();
            this.tabCompany.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this._chartCompany)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabCompany;
        private System.Windows.Forms.DataVisualization.Charting.Chart _chartCompany;
        private System.Windows.Forms.TabPage tabCompanyStockPrice;
        private System.Windows.Forms.DataVisualization.Charting.Chart _chartStockPrice;

    }
}
