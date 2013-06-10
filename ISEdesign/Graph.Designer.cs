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
            this.tabCompany = new System.Windows.Forms.TabPage();
            this.tabShareholder = new System.Windows.Forms.TabPage();
            this._chartCompany = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this._chartShareholder = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.tabControl1.SuspendLayout();
            this.tabCompany.SuspendLayout();
            this.tabShareholder.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._chartCompany)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._chartShareholder)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabCompany);
            this.tabControl1.Controls.Add(this.tabShareholder);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(515, 436);
            this.tabControl1.TabIndex = 0;
            // 
            // tabCompany
            // 
            this.tabCompany.Controls.Add(this._chartCompany);
            this.tabCompany.Location = new System.Drawing.Point(4, 22);
            this.tabCompany.Name = "tabCompany";
            this.tabCompany.Padding = new System.Windows.Forms.Padding(3);
            this.tabCompany.Size = new System.Drawing.Size(507, 410);
            this.tabCompany.TabIndex = 0;
            this.tabCompany.Text = "Company";
            this.tabCompany.UseVisualStyleBackColor = true;
            // 
            // tabShareholder
            // 
            this.tabShareholder.Controls.Add(this._chartShareholder);
            this.tabShareholder.Location = new System.Drawing.Point(4, 22);
            this.tabShareholder.Name = "tabShareholder";
            this.tabShareholder.Padding = new System.Windows.Forms.Padding(3);
            this.tabShareholder.Size = new System.Drawing.Size(507, 410);
            this.tabShareholder.TabIndex = 1;
            this.tabShareholder.Text = "Shareholder";
            this.tabShareholder.UseVisualStyleBackColor = true;
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
            // _chartShareholder
            // 
            chartArea2.Name = "ChartArea1";
            this._chartShareholder.ChartAreas.Add(chartArea2);
            this._chartShareholder.Dock = System.Windows.Forms.DockStyle.Fill;
            legend2.Name = "Legend1";
            this._chartShareholder.Legends.Add(legend2);
            this._chartShareholder.Location = new System.Drawing.Point(3, 3);
            this._chartShareholder.Name = "_chartShareholder";
            series2.ChartArea = "ChartArea1";
            series2.Legend = "Legend1";
            series2.Name = "Series1";
            this._chartShareholder.Series.Add(series2);
            this._chartShareholder.Size = new System.Drawing.Size(501, 404);
            this._chartShareholder.TabIndex = 0;
            this._chartShareholder.Text = "chart1";
            // 
            // Graph
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tabControl1);
            this.Name = "Graph";
            this.Size = new System.Drawing.Size(515, 436);
            this.tabControl1.ResumeLayout(false);
            this.tabCompany.ResumeLayout(false);
            this.tabShareholder.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this._chartCompany)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._chartShareholder)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabCompany;
        private System.Windows.Forms.DataVisualization.Charting.Chart _chartCompany;
        private System.Windows.Forms.TabPage tabShareholder;
        private System.Windows.Forms.DataVisualization.Charting.Chart _chartShareholder;

    }
}
