namespace LangtonsAnt
{
    partial class FrmMain
    {
        /// <summary>
        /// Variabile di progettazione necessaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Pulire le risorse in uso.
        /// </summary>
        /// <param name="disposing">ha valore true se le risorse gestite devono essere eliminate, false in caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Codice generato da Progettazione Windows Form

        /// <summary>
        /// Metodo necessario per il supporto della finestra di progettazione. Non modificare
        /// il contenuto del metodo con l'editor di codice.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMain));
            this.TlpMain = new System.Windows.Forms.TableLayoutPanel();
            this.BtnStart = new System.Windows.Forms.Button();
            this.BtnExit = new System.Windows.Forms.Button();
            this.PbxGrid = new System.Windows.Forms.PictureBox();
            this.BtnStopReset = new System.Windows.Forms.Button();
            this.LblSteps = new System.Windows.Forms.Label();
            this.TlpMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PbxGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // TlpMain
            // 
            this.TlpMain.ColumnCount = 6;
            this.TlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 200F));
            this.TlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 200F));
            this.TlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 200F));
            this.TlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 200F));
            this.TlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.TlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 200F));
            this.TlpMain.Controls.Add(this.BtnStart, 0, 1);
            this.TlpMain.Controls.Add(this.BtnExit, 5, 1);
            this.TlpMain.Controls.Add(this.PbxGrid, 0, 0);
            this.TlpMain.Controls.Add(this.BtnStopReset, 1, 1);
            this.TlpMain.Controls.Add(this.LblSteps, 2, 1);
            this.TlpMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TlpMain.Location = new System.Drawing.Point(0, 0);
            this.TlpMain.Name = "TlpMain";
            this.TlpMain.RowCount = 2;
            this.TlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.TlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 66F));
            this.TlpMain.Size = new System.Drawing.Size(1014, 618);
            this.TlpMain.TabIndex = 1;
            // 
            // BtnStart
            // 
            this.BtnStart.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BtnStart.Location = new System.Drawing.Point(3, 555);
            this.BtnStart.Name = "BtnStart";
            this.BtnStart.Size = new System.Drawing.Size(194, 60);
            this.BtnStart.TabIndex = 1;
            this.BtnStart.Text = "Start";
            this.BtnStart.UseVisualStyleBackColor = true;
            this.BtnStart.Click += new System.EventHandler(this.BtnStart_Click);
            // 
            // BtnExit
            // 
            this.BtnExit.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BtnExit.Location = new System.Drawing.Point(817, 555);
            this.BtnExit.Name = "BtnExit";
            this.BtnExit.Size = new System.Drawing.Size(194, 60);
            this.BtnExit.TabIndex = 2;
            this.BtnExit.Text = "Exit";
            this.BtnExit.UseVisualStyleBackColor = true;
            this.BtnExit.Click += new System.EventHandler(this.BtnExit_Click);
            // 
            // PbxGrid
            // 
            this.TlpMain.SetColumnSpan(this.PbxGrid, 10);
            this.PbxGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PbxGrid.Location = new System.Drawing.Point(3, 3);
            this.PbxGrid.Name = "PbxGrid";
            this.PbxGrid.Size = new System.Drawing.Size(1008, 546);
            this.PbxGrid.TabIndex = 3;
            this.PbxGrid.TabStop = false;
            this.PbxGrid.Paint += new System.Windows.Forms.PaintEventHandler(this.PbxGrid_Paint);
            // 
            // BtnStopReset
            // 
            this.BtnStopReset.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BtnStopReset.Location = new System.Drawing.Point(203, 555);
            this.BtnStopReset.Name = "BtnStopReset";
            this.BtnStopReset.Size = new System.Drawing.Size(194, 60);
            this.BtnStopReset.TabIndex = 4;
            this.BtnStopReset.Text = "Stop/Reset";
            this.BtnStopReset.UseVisualStyleBackColor = true;
            this.BtnStopReset.Click += new System.EventHandler(this.BtnStopReset_Click);
            // 
            // LblSteps
            // 
            this.LblSteps.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.LblSteps.AutoSize = true;
            this.LblSteps.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblSteps.Location = new System.Drawing.Point(465, 576);
            this.LblSteps.Name = "LblSteps";
            this.LblSteps.Size = new System.Drawing.Size(70, 18);
            this.LblSteps.TabIndex = 5;
            this.LblSteps.Text = "Steps: 0";
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1014, 618);
            this.Controls.Add(this.TlpMain);
            this.DoubleBuffered = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmMain";
            this.Text = "Langton\'s Ant";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FrmMain_Load);
            this.TlpMain.ResumeLayout(false);
            this.TlpMain.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PbxGrid)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TableLayoutPanel TlpMain;
        private System.Windows.Forms.Button BtnStart;
        private System.Windows.Forms.Button BtnExit;
        private System.Windows.Forms.PictureBox PbxGrid;
        private System.Windows.Forms.Button BtnStopReset;
        private System.Windows.Forms.Label LblSteps;
    }
}

