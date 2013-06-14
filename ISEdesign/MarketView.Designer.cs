namespace ISEdesign
{
    partial class MarketView
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
            this._label = new System.Windows.Forms.Label();
            this._listView = new System.Windows.Forms.ListView();
            this._columnHeaderName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this._columnHeaderValue = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderVolume = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderVariation = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SuspendLayout();
            // 
            // _label
            // 
            this._label.AutoSize = true;
            this._label.Location = new System.Drawing.Point(3, 0);
            this._label.Name = "_label";
            this._label.Size = new System.Drawing.Size(59, 13);
            this._label.TabIndex = 0;
            this._label.Text = "Companies";
            // 
            // _listView
            // 
            this._listView.Alignment = System.Windows.Forms.ListViewAlignment.SnapToGrid;
            this._listView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this._columnHeaderName,
            this._columnHeaderValue,
            this.columnHeaderVolume,
            this.columnHeaderVariation});
            this._listView.Dock = System.Windows.Forms.DockStyle.Fill;
            this._listView.ForeColor = System.Drawing.SystemColors.WindowText;
            this._listView.FullRowSelect = true;
            this._listView.GridLines = true;
            this._listView.HideSelection = false;
            this._listView.Location = new System.Drawing.Point(0, 0);
            this._listView.Name = "_listView";
            this._listView.Size = new System.Drawing.Size(321, 279);
            this._listView.TabIndex = 0;
            this._listView.UseCompatibleStateImageBehavior = false;
            this._listView.View = System.Windows.Forms.View.Details;
            this._listView.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this._listView_ColumnClick);
            this._listView.Click += new System.EventHandler(this._listView_Click);
            this._listView.DoubleClick += new System.EventHandler(this._listView_DoubleClick);
            // 
            // _columnHeaderName
            // 
            this._columnHeaderName.Text = "Name";
            this._columnHeaderName.Width = 67;
            // 
            // _columnHeaderValue
            // 
            this._columnHeaderValue.Text = "Share Value";
            this._columnHeaderValue.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this._columnHeaderValue.Width = 82;
            // 
            // columnHeaderVolume
            // 
            this.columnHeaderVolume.Text = "Volume";
            this.columnHeaderVolume.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // columnHeaderVariation
            // 
            this.columnHeaderVariation.Text = "Variation";
            this.columnHeaderVariation.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // MarketView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this._listView);
            this.Controls.Add(this._label);
            this.Name = "MarketView";
            this.Size = new System.Drawing.Size(321, 279);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private void _listView_SelectedIndexChanged( object sender, System.EventArgs e )
        {
            throw new System.NotImplementedException();
        }

        #endregion

        private System.Windows.Forms.Label _label;
        private System.Windows.Forms.ListView _listView;
        private System.Windows.Forms.ColumnHeader _columnHeaderName;
        private System.Windows.Forms.ColumnHeader _columnHeaderValue;
        private System.Windows.Forms.ColumnHeader columnHeaderVolume;
        private System.Windows.Forms.ColumnHeader columnHeaderVariation;
    }
}
