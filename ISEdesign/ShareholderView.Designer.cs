namespace ISEdesign
{
    partial class ShareholderView
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
            this._listViewSh = new System.Windows.Forms.ListView();
            this.columnNameSh = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnCashSh = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnTotalPortfolio = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnCapital = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnStrategy = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SuspendLayout();
            // 
            // _listViewSh
            // 
            this._listViewSh.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnNameSh,
            this.columnCashSh,
            this.columnTotalPortfolio,
            this.columnCapital,
            this.columnStrategy});
            this._listViewSh.Dock = System.Windows.Forms.DockStyle.Fill;
            this._listViewSh.FullRowSelect = true;
            this._listViewSh.GridLines = true;
            this._listViewSh.HideSelection = false;
            this._listViewSh.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this._listViewSh.Location = new System.Drawing.Point(0, 0);
            this._listViewSh.Name = "_listViewSh";
            this._listViewSh.Size = new System.Drawing.Size(350, 294);
            this._listViewSh.TabIndex = 0;
            this._listViewSh.UseCompatibleStateImageBehavior = false;
            this._listViewSh.View = System.Windows.Forms.View.Details;
            this._listViewSh.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this._listViewSh_ColumnClick);
            this._listViewSh.Click += new System.EventHandler(this._listViewSh_Click);
            // 
            // columnNameSh
            // 
            this.columnNameSh.Text = "Name";
            this.columnNameSh.Width = 130;
            // 
            // columnCashSh
            // 
            this.columnCashSh.Text = "Cash (€)";
            this.columnCashSh.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.columnCashSh.Width = 130;
            // 
            // columnTotalPortfolio
            // 
            this.columnTotalPortfolio.Text = "Portfolio Value (€)";
            this.columnTotalPortfolio.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.columnTotalPortfolio.Width = 130;
            // 
            // columnCapital
            // 
            this.columnCapital.Text = "Capital (€)";
            this.columnCapital.Width = 130;
            // 
            // columnStrategy
            // 
            this.columnStrategy.Text = "Strategy";
            this.columnStrategy.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnStrategy.Width = 130;
            // 
            // ShareholderView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this._listViewSh);
            this.Name = "ShareholderView";
            this.Size = new System.Drawing.Size(350, 294);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView _listViewSh;
        private System.Windows.Forms.ColumnHeader columnNameSh;
        private System.Windows.Forms.ColumnHeader columnCashSh;
        private System.Windows.Forms.ColumnHeader columnTotalPortfolio;
        private System.Windows.Forms.ColumnHeader columnStrategy;
        private System.Windows.Forms.ColumnHeader columnCapital;
    }
}
