namespace DrivingSchool
{
    partial class UcInsertEmployee
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
            this.labelType = new System.Windows.Forms.Label();
            this.comboBoxType = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // comboBoxTown
            // 
            this.comboBoxTown.Size = new System.Drawing.Size(483, 21);
            this.comboBoxTown.TabIndex = 6;
            // 
            // textBoxAddres
            // 
            this.textBoxAddres.Size = new System.Drawing.Size(483, 20);
            this.textBoxAddres.TabIndex = 5;
            // 
            // textBoxOib
            // 
            this.textBoxOib.Size = new System.Drawing.Size(483, 20);
            this.textBoxOib.TabIndex = 2;
            // 
            // labelTown
            // 
            this.labelTown.TabIndex = 16;
            // 
            // labelAddres
            // 
            this.labelAddres.TabIndex = 15;
            // 
            // labelSex
            // 
            this.labelSex.TabIndex = 14;
            // 
            // labelOib
            // 
            this.labelOib.TabIndex = 12;
            // 
            // buttonCancel
            // 
            this.buttonCancel.Location = new System.Drawing.Point(513, 421);
            this.buttonCancel.TabIndex = 9;
            // 
            // buttonSave
            // 
            this.buttonSave.Location = new System.Drawing.Point(426, 421);
            this.buttonSave.TabIndex = 8;
            // 
            // textBoxLastName
            // 
            this.textBoxLastName.Size = new System.Drawing.Size(483, 20);
            this.textBoxLastName.TabIndex = 1;
            // 
            // textBoxDateOfBirth
            // 
            this.textBoxDateOfBirth.Size = new System.Drawing.Size(483, 20);
            this.textBoxDateOfBirth.TabIndex = 3;
            // 
            // textBoxName
            // 
            this.textBoxName.Size = new System.Drawing.Size(483, 20);
            this.textBoxName.TabIndex = 0;
            // 
            // labelName
            // 
            this.labelName.TabIndex = 10;
            // 
            // labelLastName
            // 
            this.labelLastName.TabIndex = 11;
            // 
            // labelDateOfBirth
            // 
            this.labelDateOfBirth.TabIndex = 13;
            // 
            // comboBoxSex
            // 
            this.comboBoxSex.Size = new System.Drawing.Size(483, 21);
            this.comboBoxSex.TabIndex = 4;
            // 
            // labelType
            // 
            this.labelType.AutoSize = true;
            this.labelType.Location = new System.Drawing.Point(6, 207);
            this.labelType.Name = "labelType";
            this.labelType.Size = new System.Drawing.Size(34, 13);
            this.labelType.TabIndex = 17;
            this.labelType.Text = "Vrsta:";
            // 
            // comboBoxType
            // 
            this.comboBoxType.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBoxType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxType.FormattingEnabled = true;
            this.comboBoxType.Location = new System.Drawing.Point(111, 204);
            this.comboBoxType.Name = "comboBoxType";
            this.comboBoxType.Size = new System.Drawing.Size(483, 21);
            this.comboBoxType.TabIndex = 7;
            // 
            // UcInsertEmployee
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.Controls.Add(this.comboBoxType);
            this.Controls.Add(this.labelType);
            this.Name = "UcInsertEmployee";
            this.Size = new System.Drawing.Size(601, 456);
            this.Controls.SetChildIndex(this.comboBoxSex, 0);
            this.Controls.SetChildIndex(this.labelDateOfBirth, 0);
            this.Controls.SetChildIndex(this.labelLastName, 0);
            this.Controls.SetChildIndex(this.labelName, 0);
            this.Controls.SetChildIndex(this.textBoxName, 0);
            this.Controls.SetChildIndex(this.textBoxDateOfBirth, 0);
            this.Controls.SetChildIndex(this.textBoxLastName, 0);
            this.Controls.SetChildIndex(this.buttonSave, 0);
            this.Controls.SetChildIndex(this.buttonCancel, 0);
            this.Controls.SetChildIndex(this.labelOib, 0);
            this.Controls.SetChildIndex(this.labelSex, 0);
            this.Controls.SetChildIndex(this.labelAddres, 0);
            this.Controls.SetChildIndex(this.labelTown, 0);
            this.Controls.SetChildIndex(this.textBoxOib, 0);
            this.Controls.SetChildIndex(this.textBoxAddres, 0);
            this.Controls.SetChildIndex(this.comboBoxTown, 0);
            this.Controls.SetChildIndex(this.labelType, 0);
            this.Controls.SetChildIndex(this.comboBoxType, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelType;
        private System.Windows.Forms.ComboBox comboBoxType;
    }
}
