namespace DrivingSchool
{
    partial class UcTownAndCountry
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
            this.drzavaBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.gradBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.customGridViewLeft)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.customGridViewRight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.drzavaBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gradBindingSource)).BeginInit();
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
            this.customGridViewLeft.DataSource = this.drzavaBindingSource;
            this.customGridViewLeft.RowHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.customGridViewLeft_RowHeaderMouseClick);
            this.customGridViewLeft.SelectionChanged += new System.EventHandler(this.customGridViewLeft_SelectionChanged);
            // 
            // customGridViewRight
            // 
            this.customGridViewRight.AutoGenerateColumns = false;
            this.customGridViewRight.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn5,
            this.dataGridViewTextBoxColumn4,
            this.dataGridViewTextBoxColumn6,
            this.dataGridViewTextBoxColumn7,
            this.dataGridViewTextBoxColumn8});
            this.customGridViewRight.DataSource = this.gradBindingSource;
            this.customGridViewRight.UserAddedRow += new System.Windows.Forms.DataGridViewRowEventHandler(this.customGridViewRight_UserAddedRow);
            // 
            // labelLeft
            // 
            this.labelLeft.Size = new System.Drawing.Size(44, 13);
            this.labelLeft.Text = "Država:";
            // 
            // labelRight
            // 
            this.labelRight.Size = new System.Drawing.Size(33, 13);
            this.labelRight.Text = "Grad:";
            // 
            // drzavaBindingSource
            // 
            this.drzavaBindingSource.DataSource = typeof(Model.drzava);
            // 
            // gradBindingSource
            // 
            this.gradBindingSource.DataSource = typeof(Model.grad);
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "naziv";
            this.dataGridViewTextBoxColumn2.HeaderText = "naziv";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "drzava_id";
            this.dataGridViewTextBoxColumn1.HeaderText = "drzava_id";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.Visible = false;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.DataPropertyName = "grad";
            this.dataGridViewTextBoxColumn3.HeaderText = "grad";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.Visible = false;
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.DataPropertyName = "naziv";
            this.dataGridViewTextBoxColumn5.HeaderText = "naziv";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.DataPropertyName = "grad_id";
            this.dataGridViewTextBoxColumn4.HeaderText = "grad_id";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.Visible = false;
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.DataPropertyName = "drzava_id";
            this.dataGridViewTextBoxColumn6.HeaderText = "drzava_id";
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            this.dataGridViewTextBoxColumn6.Visible = false;
            // 
            // dataGridViewTextBoxColumn7
            // 
            this.dataGridViewTextBoxColumn7.DataPropertyName = "drzava";
            this.dataGridViewTextBoxColumn7.HeaderText = "drzava";
            this.dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
            this.dataGridViewTextBoxColumn7.Visible = false;
            // 
            // dataGridViewTextBoxColumn8
            // 
            this.dataGridViewTextBoxColumn8.DataPropertyName = "osoba";
            this.dataGridViewTextBoxColumn8.HeaderText = "osoba";
            this.dataGridViewTextBoxColumn8.Name = "dataGridViewTextBoxColumn8";
            this.dataGridViewTextBoxColumn8.Visible = false;
            // 
            // UcTownAndCountry
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.Name = "UcTownAndCountry";
            ((System.ComponentModel.ISupportInitialize)(this.customGridViewLeft)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.customGridViewRight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.drzavaBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gradBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.BindingSource drzavaBindingSource;
        private System.Windows.Forms.BindingSource gradBindingSource;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn7;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn8;
    }
}
