namespace DrivingSchool
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.menuStripTop = new System.Windows.Forms.MenuStrip();
            this.programToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.izlazToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.noviToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.korisnikToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.zaposlenikToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.menuStripLeft = new System.Windows.Forms.MenuStrip();
            this.korisniciToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.zaposleniciToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.vozilaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.korisničkeAktivnostiToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.voziloOpremaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.unosPodatakaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.menuStripTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.menuStripLeft.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStripTop
            // 
            this.menuStripTop.BackColor = System.Drawing.SystemColors.Info;
            this.menuStripTop.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.programToolStripMenuItem,
            this.noviToolStripMenuItem});
            this.menuStripTop.Location = new System.Drawing.Point(0, 0);
            this.menuStripTop.Name = "menuStripTop";
            this.menuStripTop.Size = new System.Drawing.Size(855, 24);
            this.menuStripTop.TabIndex = 0;
            this.menuStripTop.Text = "menuStrip1";
            // 
            // programToolStripMenuItem
            // 
            this.programToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.izlazToolStripMenuItem});
            this.programToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("programToolStripMenuItem.Image")));
            this.programToolStripMenuItem.Name = "programToolStripMenuItem";
            this.programToolStripMenuItem.Size = new System.Drawing.Size(81, 20);
            this.programToolStripMenuItem.Text = "Program";
            // 
            // izlazToolStripMenuItem
            // 
            this.izlazToolStripMenuItem.Name = "izlazToolStripMenuItem";
            this.izlazToolStripMenuItem.Size = new System.Drawing.Size(96, 22);
            this.izlazToolStripMenuItem.Text = "Izlaz";
            // 
            // noviToolStripMenuItem
            // 
            this.noviToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.korisnikToolStripMenuItem,
            this.zaposlenikToolStripMenuItem});
            this.noviToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("noviToolStripMenuItem.Image")));
            this.noviToolStripMenuItem.Name = "noviToolStripMenuItem";
            this.noviToolStripMenuItem.Size = new System.Drawing.Size(60, 20);
            this.noviToolStripMenuItem.Text = "Novi";
            // 
            // korisnikToolStripMenuItem
            // 
            this.korisnikToolStripMenuItem.Name = "korisnikToolStripMenuItem";
            this.korisnikToolStripMenuItem.Size = new System.Drawing.Size(131, 22);
            this.korisnikToolStripMenuItem.Text = "Korisnik";
            this.korisnikToolStripMenuItem.Click += new System.EventHandler(this.korisnikToolStripMenuItem_Click);
            // 
            // zaposlenikToolStripMenuItem
            // 
            this.zaposlenikToolStripMenuItem.Name = "zaposlenikToolStripMenuItem";
            this.zaposlenikToolStripMenuItem.Size = new System.Drawing.Size(131, 22);
            this.zaposlenikToolStripMenuItem.Text = "Zaposlenik";
            this.zaposlenikToolStripMenuItem.Click += new System.EventHandler(this.zaposlenikToolStripMenuItem_Click);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer1.Location = new System.Drawing.Point(0, 24);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.menuStripLeft);
            this.splitContainer1.Panel1MinSize = 200;
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.tabControl1);
            this.splitContainer1.Size = new System.Drawing.Size(855, 356);
            this.splitContainer1.SplitterDistance = 200;
            this.splitContainer1.TabIndex = 1;
            // 
            // menuStripLeft
            // 
            this.menuStripLeft.BackColor = System.Drawing.SystemColors.MenuBar;
            this.menuStripLeft.Dock = System.Windows.Forms.DockStyle.None;
            this.menuStripLeft.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold);
            this.menuStripLeft.GripStyle = System.Windows.Forms.ToolStripGripStyle.Visible;
            this.menuStripLeft.ImageScalingSize = new System.Drawing.Size(28, 28);
            this.menuStripLeft.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.korisniciToolStripMenuItem,
            this.zaposleniciToolStripMenuItem,
            this.vozilaToolStripMenuItem,
            this.korisničkeAktivnostiToolStripMenuItem,
            this.voziloOpremaToolStripMenuItem,
            this.unosPodatakaToolStripMenuItem});
            this.menuStripLeft.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.VerticalStackWithOverflow;
            this.menuStripLeft.Location = new System.Drawing.Point(9, 9);
            this.menuStripLeft.Name = "menuStripLeft";
            this.menuStripLeft.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.menuStripLeft.Size = new System.Drawing.Size(182, 207);
            this.menuStripLeft.TabIndex = 0;
            this.menuStripLeft.Text = "menuStripLeft";
            this.menuStripLeft.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.menuStripLeft_ItemClicked);
            // 
            // korisniciToolStripMenuItem
            // 
            this.korisniciToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("korisniciToolStripMenuItem.Image")));
            this.korisniciToolStripMenuItem.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.korisniciToolStripMenuItem.Name = "korisniciToolStripMenuItem";
            this.korisniciToolStripMenuItem.Size = new System.Drawing.Size(178, 32);
            this.korisniciToolStripMenuItem.Text = "Korisnici";
            // 
            // zaposleniciToolStripMenuItem
            // 
            this.zaposleniciToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("zaposleniciToolStripMenuItem.Image")));
            this.zaposleniciToolStripMenuItem.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.zaposleniciToolStripMenuItem.Name = "zaposleniciToolStripMenuItem";
            this.zaposleniciToolStripMenuItem.Size = new System.Drawing.Size(178, 32);
            this.zaposleniciToolStripMenuItem.Text = "Zaposlenici";
            // 
            // vozilaToolStripMenuItem
            // 
            this.vozilaToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("vozilaToolStripMenuItem.Image")));
            this.vozilaToolStripMenuItem.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.vozilaToolStripMenuItem.Name = "vozilaToolStripMenuItem";
            this.vozilaToolStripMenuItem.Size = new System.Drawing.Size(178, 32);
            this.vozilaToolStripMenuItem.Text = "Vozila";
            // 
            // korisničkeAktivnostiToolStripMenuItem
            // 
            this.korisničkeAktivnostiToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("korisničkeAktivnostiToolStripMenuItem.Image")));
            this.korisničkeAktivnostiToolStripMenuItem.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.korisničkeAktivnostiToolStripMenuItem.Name = "korisničkeAktivnostiToolStripMenuItem";
            this.korisničkeAktivnostiToolStripMenuItem.Size = new System.Drawing.Size(178, 32);
            this.korisničkeAktivnostiToolStripMenuItem.Text = "Korisničke aktivnosti";
            // 
            // voziloOpremaToolStripMenuItem
            // 
            this.voziloOpremaToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("voziloOpremaToolStripMenuItem.Image")));
            this.voziloOpremaToolStripMenuItem.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.voziloOpremaToolStripMenuItem.Name = "voziloOpremaToolStripMenuItem";
            this.voziloOpremaToolStripMenuItem.Size = new System.Drawing.Size(178, 32);
            this.voziloOpremaToolStripMenuItem.Text = "Vozilo oprema";
            // 
            // unosPodatakaToolStripMenuItem
            // 
            this.unosPodatakaToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("unosPodatakaToolStripMenuItem.Image")));
            this.unosPodatakaToolStripMenuItem.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.unosPodatakaToolStripMenuItem.Name = "unosPodatakaToolStripMenuItem";
            this.unosPodatakaToolStripMenuItem.Size = new System.Drawing.Size(178, 32);
            this.unosPodatakaToolStripMenuItem.Text = "Unos podataka";
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Location = new System.Drawing.Point(3, 3);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(645, 350);
            this.tabControl1.TabIndex = 0;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(855, 380);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.menuStripTop);
            this.MainMenuStrip = this.menuStripTop;
            this.Name = "MainForm";
            this.Text = "Autoškola";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.menuStripTop.ResumeLayout(false);
            this.menuStripTop.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.menuStripLeft.ResumeLayout(false);
            this.menuStripLeft.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStripTop;
        private System.Windows.Forms.ToolStripMenuItem programToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem izlazToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem noviToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem korisnikToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem zaposlenikToolStripMenuItem;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.MenuStrip menuStripLeft;
        private System.Windows.Forms.ToolStripMenuItem korisniciToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem zaposleniciToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem vozilaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem korisničkeAktivnostiToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem voziloOpremaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem unosPodatakaToolStripMenuItem;
        private System.Windows.Forms.TabControl tabControl1;
    }
}