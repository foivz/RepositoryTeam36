namespace DrivingSchool
{
    partial class UcUserStatusAndActivity
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
            this.korisnikstatusBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.aktivnostBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.customGridViewLeft)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.customGridViewRight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.korisnikstatusBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.aktivnostBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonDeleteLeft
            // 
            this.buttonDeleteLeft.Click += new System.EventHandler(this.buttonDeleteLeft_Click);
            // 
            // buttonSaveLeft
            // 
            this.buttonSaveLeft.Click += new System.EventHandler(this.buttonSaveLeft_Click);
            // 
            // buttonDeleteRight
            // 
            this.buttonDeleteRight.Click += new System.EventHandler(this.buttonDeleteRight_Click);
            // 
            // buttonSaveRight
            // 
            this.buttonSaveRight.Click += new System.EventHandler(this.buttonSaveRight_Click);
            // 
            // customGridViewLeft
            // 
            this.customGridViewLeft.AutoGenerateColumns = false;
            this.customGridViewLeft.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn3});
            this.customGridViewLeft.DataSource = this.korisnikstatusBindingSource;
            // 
            // customGridViewRight
            // 
            this.customGridViewRight.AutoGenerateColumns = false;
            this.customGridViewRight.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn5,
            this.dataGridViewTextBoxColumn6,
            this.dataGridViewTextBoxColumn7,
            this.dataGridViewTextBoxColumn4,
            this.dataGridViewTextBoxColumn8});
            this.customGridViewRight.DataSource = this.aktivnostBindingSource;
            // 
            // labelLeft
            // 
            this.labelLeft.Size = new System.Drawing.Size(85, 13);
            this.labelLeft.Text = "Status korisnika:";
            // 
            // labelRight
            // 
            this.labelRight.Size = new System.Drawing.Size(56, 13);
            this.labelRight.Text = "Aktivnosti:";
            // 
            // korisnikstatusBindingSource
            // 
            this.korisnikstatusBindingSource.DataSource = typeof(Model.korisnik_status);
            // 
            // aktivnostBindingSource
            // 
            this.aktivnostBindingSource.DataSource = typeof(Model.aktivnost);
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "naziv";
            this.dataGridViewTextBoxColumn2.HeaderText = "naziv";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "status_id";
            this.dataGridViewTextBoxColumn1.HeaderText = "status_id";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.Visible = false;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.DataPropertyName = "korisnik";
            this.dataGridViewTextBoxColumn3.HeaderText = "korisnik";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.Visible = false;
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.DataPropertyName = "naziv";
            this.dataGridViewTextBoxColumn5.HeaderText = "naziv";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.DataPropertyName = "opis";
            this.dataGridViewTextBoxColumn6.HeaderText = "opis";
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            // 
            // dataGridViewTextBoxColumn7
            // 
            this.dataGridViewTextBoxColumn7.DataPropertyName = "trajanje_sati";
            this.dataGridViewTextBoxColumn7.HeaderText = "broj sati";
            this.dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.DataPropertyName = "aktivnost_id";
            this.dataGridViewTextBoxColumn4.HeaderText = "aktivnost_id";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.Visible = false;
            // 
            // dataGridViewTextBoxColumn8
            // 
            this.dataGridViewTextBoxColumn8.DataPropertyName = "korisnik_aktivnost";
            this.dataGridViewTextBoxColumn8.HeaderText = "korisnik_aktivnost";
            this.dataGridViewTextBoxColumn8.Name = "dataGridViewTextBoxColumn8";
            this.dataGridViewTextBoxColumn8.Visible = false;
            // 
            // UcUserStatusAndActivity
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.Name = "UcUserStatusAndActivity";
            ((System.ComponentModel.ISupportInitialize)(this.customGridViewLeft)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.customGridViewRight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.korisnikstatusBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.aktivnostBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.BindingSource korisnikstatusBindingSource;
        private System.Windows.Forms.BindingSource aktivnostBindingSource;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn7;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn8;
    }
}
