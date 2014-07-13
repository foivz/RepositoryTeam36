namespace DrivingSchool
{
    partial class UcVehicleGear
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
            this.comboBoxVehicle = new System.Windows.Forms.ComboBox();
            this.labelVehicle = new System.Windows.Forms.Label();
            this.vozilododatnaopremaBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dodatnaopremaBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.oprema = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.customGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.vozilododatnaopremaBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dodatnaopremaBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // customGridView
            // 
            this.customGridView.AutoGenerateColumns = false;
            this.customGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.oprema,
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn3,
            this.dataGridViewTextBoxColumn4});
            this.customGridView.DataSource = this.vozilododatnaopremaBindingSource;
            this.customGridView.Location = new System.Drawing.Point(3, 39);
            this.customGridView.Size = new System.Drawing.Size(559, 252);
            this.customGridView.RowEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.customGridView_RowEnter);
            // 
            // comboBoxVehicle
            // 
            this.comboBoxVehicle.FormattingEnabled = true;
            this.comboBoxVehicle.Location = new System.Drawing.Point(56, 12);
            this.comboBoxVehicle.Name = "comboBoxVehicle";
            this.comboBoxVehicle.Size = new System.Drawing.Size(221, 21);
            this.comboBoxVehicle.TabIndex = 11;
            this.comboBoxVehicle.SelectedIndexChanged += new System.EventHandler(this.comboBoxVehicle_SelectedIndexChanged);
            // 
            // labelVehicle
            // 
            this.labelVehicle.AutoSize = true;
            this.labelVehicle.Location = new System.Drawing.Point(3, 15);
            this.labelVehicle.Name = "labelVehicle";
            this.labelVehicle.Size = new System.Drawing.Size(38, 13);
            this.labelVehicle.TabIndex = 12;
            this.labelVehicle.Text = "Vozilo:";
            // 
            // vozilododatnaopremaBindingSource
            // 
            this.vozilododatnaopremaBindingSource.DataSource = typeof(Model.vozilo_dodatna_oprema);
            // 
            // dodatnaopremaBindingSource
            // 
            this.dodatnaopremaBindingSource.DataSource = typeof(Model.dodatna_oprema);
            // 
            // oprema
            // 
            this.oprema.DataPropertyName = "oprema_id";
            this.oprema.DataSource = this.dodatnaopremaBindingSource;
            this.oprema.DisplayMember = "naziv";
            this.oprema.HeaderText = "oprema";
            this.oprema.Name = "oprema";
            this.oprema.ValueMember = "oprema_id";
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "oprema_id";
            this.dataGridViewTextBoxColumn2.HeaderText = "oprema_id";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.Visible = false;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "vozilo_id";
            this.dataGridViewTextBoxColumn1.HeaderText = "vozilo_id";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.Visible = false;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.DataPropertyName = "dodatna_oprema";
            this.dataGridViewTextBoxColumn3.HeaderText = "dodatna_oprema";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.Visible = false;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.DataPropertyName = "vozilo";
            this.dataGridViewTextBoxColumn4.HeaderText = "vozilo";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.Visible = false;
            // 
            // UcVehicleGear
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.Controls.Add(this.labelVehicle);
            this.Controls.Add(this.comboBoxVehicle);
            this.Name = "UcVehicleGear";
            this.Controls.SetChildIndex(this.customGridView, 0);
            this.Controls.SetChildIndex(this.buttonSave, 0);
            this.Controls.SetChildIndex(this.buttonDelete, 0);
            this.Controls.SetChildIndex(this.buttonPrint, 0);
            this.Controls.SetChildIndex(this.buttonCancel, 0);
            this.Controls.SetChildIndex(this.comboBoxVehicle, 0);
            this.Controls.SetChildIndex(this.labelVehicle, 0);
            ((System.ComponentModel.ISupportInitialize)(this.customGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.vozilododatnaopremaBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dodatnaopremaBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBoxVehicle;
        private System.Windows.Forms.Label labelVehicle;
        private System.Windows.Forms.BindingSource dodatnaopremaBindingSource;
        private System.Windows.Forms.BindingSource vozilododatnaopremaBindingSource;
        private System.Windows.Forms.DataGridViewComboBoxColumn oprema;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
    }
}
