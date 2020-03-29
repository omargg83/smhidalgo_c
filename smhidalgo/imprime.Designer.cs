namespace smhidalgo
{
    partial class imprime
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(imprime));
            this.label1 = new System.Windows.Forms.Label();
            this.cmb_oficios = new System.Windows.Forms.ComboBox();
            this.button2 = new System.Windows.Forms.Button();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.grid_buscar = new System.Windows.Forms.DataGridView();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.printDocument1 = new System.Drawing.Printing.PrintDocument();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.abrirToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.salirToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grid_buscar)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 75);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 17);
            this.label1.TabIndex = 78;
            this.label1.Text = "Tienda:";
            // 
            // cmb_oficios
            // 
            this.cmb_oficios.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmb_oficios.FormattingEnabled = true;
            this.cmb_oficios.Location = new System.Drawing.Point(77, 75);
            this.cmb_oficios.Margin = new System.Windows.Forms.Padding(4);
            this.cmb_oficios.Name = "cmb_oficios";
            this.cmb_oficios.Size = new System.Drawing.Size(250, 28);
            this.cmb_oficios.TabIndex = 77;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(335, 75);
            this.button2.Margin = new System.Windows.Forms.Padding(4);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(100, 28);
            this.button2.TabIndex = 79;
            this.button2.Text = "Seleccionar";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 231);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(448, 26);
            this.statusStrip1.TabIndex = 80;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(151, 20);
            this.toolStripStatusLabel1.Text = "toolStripStatusLabel1";
            // 
            // grid_buscar
            // 
            this.grid_buscar.AllowUserToAddRows = false;
            this.grid_buscar.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grid_buscar.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.grid_buscar.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grid_buscar.Location = new System.Drawing.Point(13, 111);
            this.grid_buscar.Margin = new System.Windows.Forms.Padding(4);
            this.grid_buscar.Name = "grid_buscar";
            this.grid_buscar.ReadOnly = true;
            this.grid_buscar.RowHeadersWidth = 51;
            this.grid_buscar.Size = new System.Drawing.Size(422, 113);
            this.grid_buscar.TabIndex = 81;
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 5000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // printDocument1
            // 
            this.printDocument1.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.printDocument1_PrintPage);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.abrirToolStripMenuItem,
            this.salirToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(112, 52);
            // 
            // abrirToolStripMenuItem
            // 
            this.abrirToolStripMenuItem.Name = "abrirToolStripMenuItem";
            this.abrirToolStripMenuItem.Size = new System.Drawing.Size(111, 24);
            this.abrirToolStripMenuItem.Text = "Abrir";
            this.abrirToolStripMenuItem.Click += new System.EventHandler(this.abrirToolStripMenuItem_Click);
            // 
            // salirToolStripMenuItem
            // 
            this.salirToolStripMenuItem.Name = "salirToolStripMenuItem";
            this.salirToolStripMenuItem.Size = new System.Drawing.Size(111, 24);
            this.salirToolStripMenuItem.Text = "Salir";
            this.salirToolStripMenuItem.Click += new System.EventHandler(this.salirToolStripMenuItem_Click);
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.BalloonTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.notifyIcon1.BalloonTipText = "Hola";
            this.notifyIcon1.BalloonTipTitle = "mundo";
            this.notifyIcon1.ContextMenuStrip = this.contextMenuStrip1;
            this.notifyIcon1.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon1.Icon")));
            this.notifyIcon1.Text = "SMHIDALGO";
            this.notifyIcon1.Visible = true;
            this.notifyIcon1.DoubleClick += new System.EventHandler(this.notifyIcon1_DoubleClick);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 9);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(390, 17);
            this.label2.TabIndex = 82;
            this.label2.Text = "Aplicación para imprimir tickets directamente en la impresora";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(184, 35);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(68, 17);
            this.label3.TabIndex = 83;
            this.label3.Text = "No cerrar";
            // 
            // imprime
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(448, 257);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.grid_buscar);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmb_oficios);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.Name = "imprime";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SM - Hidalgo";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.imprime_FormClosed);
            this.Load += new System.EventHandler(this.imprime_Load);
            this.Resize += new System.EventHandler(this.Form1_Resize);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grid_buscar)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmb_oficios;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.DataGridView grid_buscar;
        private System.Windows.Forms.Timer timer1;
        private System.Drawing.Printing.PrintDocument printDocument1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem abrirToolStripMenuItem;
        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private System.Windows.Forms.ToolStripMenuItem salirToolStripMenuItem;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
    }
}

