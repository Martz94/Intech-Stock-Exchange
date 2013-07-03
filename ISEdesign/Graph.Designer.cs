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
            this._chartCompany = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabMarketGraph = new System.Windows.Forms.TabPage();
            this.tabCompanyGraph = new System.Windows.Forms.TabPage();
            this._chartMarket = new System.Windows.Forms.DataVisualization.Charting.Chart();
            ((System.ComponentModel.ISupportInitialize)(this._chartCompany)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabMarketGraph.SuspendLayout();
            this.tabCompanyGraph.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._chartMarket)).BeginInit();
            this.SuspendLayout();
            // 
            // _chartCompany
            // 
            chartArea1.Name = "ChartArea1";
            this._chartCompany.ChartAreas.Add(chartArea1);
            this._chartCompany.Dock = System.Windows.Forms.DockStyle.Fill;
            legend1.Name = "Legend1";
            this._chartCompany.Legends.Add(legend1);
            this._chartCompany.Location = new System.Drawing.Point(3, 3);
            this._chartCompany.Name = "_chartCompany";
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this._chartCompany.Series.Add(series1);
            this._chartCompany.Size = new System.Drawing.Size(501, 404);
            this._chartCompany.TabIndex = 0;
            this._chartCompany.Text = "chart1";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabMarketGraph);
            this.tabControl1.Controls.Add(this.tabCompanyGraph);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(515, 436);
            this.tabControl1.TabIndex = 1;
            // 
            // tabMarketGraph
            // 
            this.tabMarketGraph.Controls.Add(this._chartMarket);
            this.tabMarketGraph.Location = new System.Drawing.Point(4, 22);
            this.tabMarketGraph.Name = "tabMarketGraph";
            this.tabMarketGraph.Padding = new System.Windows.Forms.Padding(3);
            this.tabMarketGraph.Size = new System.Drawing.Size(507, 410);
            this.tabMarketGraph.TabIndex = 0;
            this.tabMarketGraph.Text = "Market Graph";
            this.tabMarketGraph.UseVisualStyleBackColor = true;
            // 
            // tabCompanyGraph
            // 
            this.tabCompanyGraph.Controls.Add(this._chartCompany);
            this.tabCompanyGraph.Location = new System.Drawing.Point(4, 22);
            this.tabCompanyGraph.Name = "tabCompanyGraph";
            this.tabCompanyGraph.Padding = new System.Windows.Forms.Padding(3);
            this.tabCompanyGraph.Size = new System.Drawing.Size(507, 410);
            this.tabCompanyGraph.TabIndex = 1;
            this.tabCompanyGraph.Text = "Company Graph";
            this.tabCompanyGraph.UseVisualStyleBackColor = true;
            // 
            // _chartMarket
            // 
            chartArea2.Name = "ChartArea1";
            this._chartMarket.ChartAreas.Add(chartArea2);
            this._chartMarket.Dock = System.Windows.Forms.DockStyle.Fill;
            legend2.Name = "Legend1";
            this._chartMarket.Legends.Add(legend2);
            this._chartMarket.Location = new System.Drawing.Point(3, 3);
            this._chartMarket.Name = "_chartMarket";
            series2.ChartArea = "ChartArea1";
            series2.Legend = "Legend1";
            series2.Name = "Series1";
            this._chartMarket.Series.Add(series2);
            this._chartMarket.Size = new System.Drawing.Size(501, 404);
            this._chartMarket.TabIndex = 0;
            this._chartMarket.Text = "chart1";
            // 
            // Graph
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tabControl1);
            this.Name = "Graph";
            this.Size = new System.Drawing.Size(515, 436);
            ((System.ComponentModel.ISupportInitialize)(this._chartCompany)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tabMarketGraph.ResumeLayout(false);
            this.tabCompanyGraph.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this._chartMarket)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart _chartCompany;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabMarketGraph;
        private System.Windows.Forms.TabPage tabCompanyGraph;
        private System.Windows.Forms.DataVisualization.Charting.Chart _chartMarket;


    }
}
