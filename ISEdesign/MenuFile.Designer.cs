namespace ISEdesign
{
    partial class MenuFile
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this._fileMenu = new System.Windows.Forms.ToolStripMenuItem();
            this._loadMenu = new System.Windows.Forms.ToolStripMenuItem();
            this._saveMenu = new System.Windows.Forms.ToolStripMenuItem();
            this._initializeMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.menuStrip1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._fileMenu});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(47, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // _fileMenu
            // 
            this._fileMenu.BackColor = System.Drawing.Color.LightSteelBlue;
            this._fileMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._initializeMenu,
            this._loadMenu,
            this._saveMenu});
            this._fileMenu.Name = "_fileMenu";
            this._fileMenu.Size = new System.Drawing.Size(37, 20);
            this._fileMenu.Text = "File";
            // 
            // _loadMenu
            // 
            this._loadMenu.Name = "_loadMenu";
            this._loadMenu.Size = new System.Drawing.Size(152, 22);
            this._loadMenu.Text = "Open...";
            this._loadMenu.Click += new System.EventHandler(this._loadMenu_Click);
            // 
            // _saveMenu
            // 
            this._saveMenu.Name = "_saveMenu";
            this._saveMenu.Size = new System.Drawing.Size(152, 22);
            this._saveMenu.Text = "Save...";
            this._saveMenu.Click += new System.EventHandler(this._saveMenu_Click);
            // 
            // _initializeMenu
            // 
            this._initializeMenu.Name = "_initializeMenu";
            this._initializeMenu.Size = new System.Drawing.Size(152, 22);
            this._initializeMenu.Text = "Initialize...";
            this._initializeMenu.Click += new System.EventHandler(this._initializeMenu_Click);
            // 
            // MenuFile
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.menuStrip1);
            this.Name = "MenuFile";
            this.Size = new System.Drawing.Size(47, 24);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem _fileMenu;
        private System.Windows.Forms.ToolStripMenuItem _loadMenu;
        private System.Windows.Forms.ToolStripMenuItem _saveMenu;
        private System.Windows.Forms.ToolStripMenuItem _initializeMenu;
    }
}
