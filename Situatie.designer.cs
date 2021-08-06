namespace ProiectContabilitate
{
    partial class Situatie
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Situatie));
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.refreshToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.salvareInFisierToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.formatBitmapToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.formatBinarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.restaurareDinFisierToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.formatBinarToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.viewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.vizualizareBazăDeDateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.printToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ajutorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pnl = new System.Windows.Forms.Panel();
            this.listView1 = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader7 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader8 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.contextMenuStrip2 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.ștergeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editeazăToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lblTotalSFC = new System.Windows.Forms.Label();
            this.lblTotalSFD = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.button3 = new System.Windows.Forms.Button();
            this.lblRezultat = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.printDocument1 = new System.Drawing.Printing.PrintDocument();
            this.printPreviewDialog1 = new System.Windows.Forms.PrintPreviewDialog();
            this.button4 = new System.Windows.Forms.Button();
            this.închidereAplicațieToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStrip1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.pnl.SuspendLayout();
            this.contextMenuStrip2.SuspendLayout();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(112, 45);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(291, 39);
            this.button1.TabIndex = 1;
            this.button1.Text = "&Afișare grafic";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.button2.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.Location = new System.Drawing.Point(112, 133);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(291, 36);
            this.button2.TabIndex = 9;
            this.button2.Text = "Ștergere situație";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.refreshToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(114, 26);
            // 
            // refreshToolStripMenuItem
            // 
            this.refreshToolStripMenuItem.Name = "refreshToolStripMenuItem";
            this.refreshToolStripMenuItem.Size = new System.Drawing.Size(113, 22);
            this.refreshToolStripMenuItem.Text = "Refresh";
            this.refreshToolStripMenuItem.Click += new System.EventHandler(this.refreshToolStripMenuItem_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.menuStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Visible;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem1,
            this.viewToolStripMenuItem,
            this.printToolStripMenuItem,
            this.ajutorToolStripMenuItem,
            this.închidereAplicațieToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.ShowItemToolTips = true;
            this.menuStrip1.Size = new System.Drawing.Size(902, 24);
            this.menuStrip1.TabIndex = 19;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem1
            // 
            this.fileToolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.salvareInFisierToolStripMenuItem,
            this.restaurareDinFisierToolStripMenuItem});
            this.fileToolStripMenuItem1.Name = "fileToolStripMenuItem1";
            this.fileToolStripMenuItem1.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem1.Text = "&File";
            // 
            // salvareInFisierToolStripMenuItem
            // 
            this.salvareInFisierToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.formatBitmapToolStripMenuItem,
            this.formatBinarToolStripMenuItem});
            this.salvareInFisierToolStripMenuItem.Name = "salvareInFisierToolStripMenuItem";
            this.salvareInFisierToolStripMenuItem.Size = new System.Drawing.Size(177, 22);
            this.salvareInFisierToolStripMenuItem.Text = "Salvare in fisier";
            // 
            // formatBitmapToolStripMenuItem
            // 
            this.formatBitmapToolStripMenuItem.Name = "formatBitmapToolStripMenuItem";
            this.formatBitmapToolStripMenuItem.Size = new System.Drawing.Size(153, 22);
            this.formatBitmapToolStripMenuItem.Text = "Format bitmap";
            this.formatBitmapToolStripMenuItem.Click += new System.EventHandler(this.formatBitmapToolStripMenuItem_Click);
            // 
            // formatBinarToolStripMenuItem
            // 
            this.formatBinarToolStripMenuItem.Name = "formatBinarToolStripMenuItem";
            this.formatBinarToolStripMenuItem.Size = new System.Drawing.Size(153, 22);
            this.formatBinarToolStripMenuItem.Text = "Format binar";
            this.formatBinarToolStripMenuItem.Click += new System.EventHandler(this.formatBinarToolStripMenuItem_Click);
            // 
            // restaurareDinFisierToolStripMenuItem
            // 
            this.restaurareDinFisierToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.formatBinarToolStripMenuItem1});
            this.restaurareDinFisierToolStripMenuItem.Name = "restaurareDinFisierToolStripMenuItem";
            this.restaurareDinFisierToolStripMenuItem.Size = new System.Drawing.Size(177, 22);
            this.restaurareDinFisierToolStripMenuItem.Text = "Restaurare din fisier";
            // 
            // formatBinarToolStripMenuItem1
            // 
            this.formatBinarToolStripMenuItem1.Name = "formatBinarToolStripMenuItem1";
            this.formatBinarToolStripMenuItem1.Size = new System.Drawing.Size(142, 22);
            this.formatBinarToolStripMenuItem1.Text = "Format binar";
            this.formatBinarToolStripMenuItem1.Click += new System.EventHandler(this.formatBinarToolStripMenuItem1_Click);
            // 
            // viewToolStripMenuItem
            // 
            this.viewToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.vizualizareBazăDeDateToolStripMenuItem});
            this.viewToolStripMenuItem.Name = "viewToolStripMenuItem";
            this.viewToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.viewToolStripMenuItem.Text = "View";
            // 
            // vizualizareBazăDeDateToolStripMenuItem
            // 
            this.vizualizareBazăDeDateToolStripMenuItem.Name = "vizualizareBazăDeDateToolStripMenuItem";
            this.vizualizareBazăDeDateToolStripMenuItem.Size = new System.Drawing.Size(198, 22);
            this.vizualizareBazăDeDateToolStripMenuItem.Text = "Vizualizare bază de date";
            this.vizualizareBazăDeDateToolStripMenuItem.Click += new System.EventHandler(this.vizualizareBazăDeDateToolStripMenuItem_Click);
            // 
            // printToolStripMenuItem
            // 
            this.printToolStripMenuItem.Name = "printToolStripMenuItem";
            this.printToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.printToolStripMenuItem.Text = "Print";
            this.printToolStripMenuItem.Click += new System.EventHandler(this.printToolStripMenuItem_Click);
            // 
            // ajutorToolStripMenuItem
            // 
            this.ajutorToolStripMenuItem.Name = "ajutorToolStripMenuItem";
            this.ajutorToolStripMenuItem.Size = new System.Drawing.Size(52, 20);
            this.ajutorToolStripMenuItem.Text = "&Ajutor";
            this.ajutorToolStripMenuItem.Click += new System.EventHandler(this.ajutorToolStripMenuItem_Click);
            // 
            // pnl
            // 
            this.pnl.Controls.Add(this.listView1);
            this.pnl.Controls.Add(this.lblTotalSFC);
            this.pnl.Controls.Add(this.lblTotalSFD);
            this.pnl.Controls.Add(this.label9);
            this.pnl.Location = new System.Drawing.Point(39, 280);
            this.pnl.Name = "pnl";
            this.pnl.Size = new System.Drawing.Size(823, 255);
            this.pnl.TabIndex = 20;
            // 
            // listView1
            // 
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4,
            this.columnHeader5,
            this.columnHeader6,
            this.columnHeader7,
            this.columnHeader8});
            this.listView1.ContextMenuStrip = this.contextMenuStrip2;
            this.listView1.FullRowSelect = true;
            this.listView1.GridLines = true;
            this.listView1.HideSelection = false;
            this.listView1.Location = new System.Drawing.Point(3, 3);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(813, 219);
            this.listView1.TabIndex = 22;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            this.listView1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.listView1_MouseDown);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Nr. cont";
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Tip cont";
            this.columnHeader2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader2.Width = 94;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Perioada";
            this.columnHeader3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader3.Width = 102;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Sold initial";
            this.columnHeader4.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader4.Width = 114;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "Rulaj debitor";
            this.columnHeader5.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader5.Width = 112;
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "Rulaj creditor";
            this.columnHeader6.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader6.Width = 104;
            // 
            // columnHeader7
            // 
            this.columnHeader7.Text = "Sold final debitor";
            this.columnHeader7.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader7.Width = 112;
            // 
            // columnHeader8
            // 
            this.columnHeader8.Text = "Sold final creditor";
            this.columnHeader8.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader8.Width = 111;
            // 
            // contextMenuStrip2
            // 
            this.contextMenuStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ștergeToolStripMenuItem,
            this.editeazăToolStripMenuItem});
            this.contextMenuStrip2.Name = "contextMenuStrip2";
            this.contextMenuStrip2.Size = new System.Drawing.Size(118, 48);
            // 
            // ștergeToolStripMenuItem
            // 
            this.ștergeToolStripMenuItem.Name = "ștergeToolStripMenuItem";
            this.ștergeToolStripMenuItem.Size = new System.Drawing.Size(117, 22);
            this.ștergeToolStripMenuItem.Text = "Șterge";
            this.ștergeToolStripMenuItem.Click += new System.EventHandler(this.ștergeToolStripMenuItem_Click);
            // 
            // editeazăToolStripMenuItem
            // 
            this.editeazăToolStripMenuItem.Name = "editeazăToolStripMenuItem";
            this.editeazăToolStripMenuItem.Size = new System.Drawing.Size(117, 22);
            this.editeazăToolStripMenuItem.Text = "Editează";
            this.editeazăToolStripMenuItem.Click += new System.EventHandler(this.editeazăToolStripMenuItem_Click);
            // 
            // lblTotalSFC
            // 
            this.lblTotalSFC.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lblTotalSFC.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblTotalSFC.Location = new System.Drawing.Point(706, 225);
            this.lblTotalSFC.Name = "lblTotalSFC";
            this.lblTotalSFC.Size = new System.Drawing.Size(110, 23);
            this.lblTotalSFC.TabIndex = 20;
            this.lblTotalSFC.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lblTotalSFD
            // 
            this.lblTotalSFD.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lblTotalSFD.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblTotalSFD.Location = new System.Drawing.Point(592, 225);
            this.lblTotalSFD.Name = "lblTotalSFD";
            this.lblTotalSFD.Size = new System.Drawing.Size(108, 23);
            this.lblTotalSFD.TabIndex = 19;
            this.lblTotalSFD.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label9
            // 
            this.label9.BackColor = System.Drawing.SystemColors.Info;
            this.label9.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(490, 225);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(96, 23);
            this.label9.TabIndex = 18;
            this.label9.Text = "Total";
            this.label9.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.button3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button3.Location = new System.Drawing.Point(112, 90);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(291, 37);
            this.button3.TabIndex = 21;
            this.button3.Text = "&Sortare conturi";
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // lblRezultat
            // 
            this.lblRezultat.BackColor = System.Drawing.SystemColors.Info;
            this.lblRezultat.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblRezultat.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRezultat.Location = new System.Drawing.Point(39, 551);
            this.lblRezultat.Name = "lblRezultat";
            this.lblRezultat.Size = new System.Drawing.Size(816, 50);
            this.lblRezultat.TabIndex = 21;
            this.lblRezultat.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // textBox1
            // 
            this.textBox1.AllowDrop = true;
            this.textBox1.Location = new System.Drawing.Point(566, 85);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox1.Size = new System.Drawing.Size(224, 144);
            this.textBox1.TabIndex = 22;
            this.textBox1.DragDrop += new System.Windows.Forms.DragEventHandler(this.textBox1_DragDrop);
            this.textBox1.DragEnter += new System.Windows.Forms.DragEventHandler(this.textBox1_DragEnter);
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.SystemColors.Info;
            this.label2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(566, 45);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(224, 23);
            this.label2.TabIndex = 24;
            this.label2.Text = "Detalii tranzacție";
            this.label2.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // printDocument1
            // 
            this.printDocument1.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.printDocument1_PrintPage);
            // 
            // printPreviewDialog1
            // 
            this.printPreviewDialog1.AutoScrollMargin = new System.Drawing.Size(0, 0);
            this.printPreviewDialog1.AutoScrollMinSize = new System.Drawing.Size(0, 0);
            this.printPreviewDialog1.ClientSize = new System.Drawing.Size(400, 300);
            this.printPreviewDialog1.Enabled = true;
            this.printPreviewDialog1.Icon = ((System.Drawing.Icon)(resources.GetObject("printPreviewDialog1.Icon")));
            this.printPreviewDialog1.Name = "printPreviewDialog1";
            this.printPreviewDialog1.Visible = false;
            // 
            // button4
            // 
            this.button4.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.button4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button4.Location = new System.Drawing.Point(112, 175);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(291, 37);
            this.button4.TabIndex = 26;
            this.button4.Text = "&Încarcă lista în baza de date";
            this.button4.UseVisualStyleBackColor = false;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // închidereAplicațieToolStripMenuItem
            // 
            this.închidereAplicațieToolStripMenuItem.Name = "închidereAplicațieToolStripMenuItem";
            this.închidereAplicațieToolStripMenuItem.Size = new System.Drawing.Size(115, 20);
            this.închidereAplicațieToolStripMenuItem.Text = "Închidere aplicație";
            this.închidereAplicațieToolStripMenuItem.Click += new System.EventHandler(this.închidereAplicațieToolStripMenuItem_Click);
            // 
            // Situatie
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(902, 613);
            this.ContextMenuStrip = this.contextMenuStrip1;
            this.Controls.Add(this.button4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.lblRezultat);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.pnl);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Situatie";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Situatie";
            this.Load += new System.EventHandler(this.Situatie_Load);
            this.contextMenuStrip1.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.pnl.ResumeLayout(false);
            this.contextMenuStrip2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem refreshToolStripMenuItem;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.Panel pnl;
        private System.Windows.Forms.Label lblTotalSFC;
        private System.Windows.Forms.Label lblTotalSFD;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ToolStripMenuItem ajutorToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem salvareInFisierToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem restaurareDinFisierToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem formatBitmapToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem formatBinarToolStripMenuItem;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.ToolStripMenuItem formatBinarToolStripMenuItem1;
        private System.Windows.Forms.Label lblRezultat;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ColumnHeader columnHeader6;
        private System.Windows.Forms.ColumnHeader columnHeader7;
        private System.Windows.Forms.ColumnHeader columnHeader8;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ToolStripMenuItem printToolStripMenuItem;
        private System.Drawing.Printing.PrintDocument printDocument1;
        private System.Windows.Forms.PrintPreviewDialog printPreviewDialog1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip2;
        private System.Windows.Forms.ToolStripMenuItem ștergeToolStripMenuItem;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.ToolStripMenuItem editeazăToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem viewToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem vizualizareBazăDeDateToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem închidereAplicațieToolStripMenuItem;
    }
}