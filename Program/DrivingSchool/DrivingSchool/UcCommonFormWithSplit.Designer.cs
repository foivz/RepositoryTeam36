namespace DrivingSchool
{
    partial class UcCommonFormWithSplit
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UcCommonFormWithSplit));
            this.buttonCancel = new System.Windows.Forms.Button();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.buttonDeleteLeft = new System.Windows.Forms.Button();
            this.buttonSaveLeft = new System.Windows.Forms.Button();
            this.labelLeft = new System.Windows.Forms.Label();
            this.customGridViewLeft = new DrivingSchool.CustomGridView();
            this.buttonDeleteRight = new System.Windows.Forms.Button();
            this.labelRight = new System.Windows.Forms.Label();
            this.buttonSaveRight = new System.Windows.Forms.Button();
            this.customGridViewRight = new DrivingSchool.CustomGridView();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.customGridViewLeft)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.customGridViewRight)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonCancel
            // 
            this.buttonCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonCancel.Location = new System.Drawing.Point(698, 323);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(81, 32);
            this.buttonCancel.TabIndex = 10;
            this.buttonCancel.Text = "Odustani";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer1.IsSplitterFixed = true;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.buttonDeleteLeft);
            this.splitContainer1.Panel1.Controls.Add(this.buttonSaveLeft);
            this.splitContainer1.Panel1.Controls.Add(this.labelLeft);
            this.splitContainer1.Panel1.Controls.Add(this.customGridViewLeft);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.buttonDeleteRight);
            this.splitContainer1.Panel2.Controls.Add(this.labelRight);
            this.splitContainer1.Panel2.Controls.Add(this.buttonSaveRight);
            this.splitContainer1.Panel2.Controls.Add(this.customGridViewRight);
            this.splitContainer1.Size = new System.Drawing.Size(691, 358);
            this.splitContainer1.SplitterDistance = 345;
            this.splitContainer1.SplitterWidth = 1;
            this.splitContainer1.TabIndex = 11;
            // 
            // buttonDeleteLeft
            // 
            this.buttonDeleteLeft.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonDeleteLeft.Image = ((System.Drawing.Image)(resources.GetObject("buttonDeleteLeft.Image")));
            this.buttonDeleteLeft.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonDeleteLeft.Location = new System.Drawing.Point(114, 310);
            this.buttonDeleteLeft.Name = "buttonDeleteLeft";
            this.buttonDeleteLeft.Size = new System.Drawing.Size(103, 45);
            this.buttonDeleteLeft.TabIndex = 11;
            this.buttonDeleteLeft.Text = "Briši";
            this.buttonDeleteLeft.UseVisualStyleBackColor = true;
            // 
            // buttonSaveLeft
            // 
            this.buttonSaveLeft.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonSaveLeft.Image = ((System.Drawing.Image)(resources.GetObject("buttonSaveLeft.Image")));
            this.buttonSaveLeft.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonSaveLeft.Location = new System.Drawing.Point(5, 310);
            this.buttonSaveLeft.Name = "buttonSaveLeft";
            this.buttonSaveLeft.Size = new System.Drawing.Size(103, 45);
            this.buttonSaveLeft.TabIndex = 10;
            this.buttonSaveLeft.Text = "Spremi";
            this.buttonSaveLeft.UseVisualStyleBackColor = true;
            // 
            // labelLeft
            // 
            this.labelLeft.AutoSize = true;
            this.labelLeft.Location = new System.Drawing.Point(14, 9);
            this.labelLeft.Name = "labelLeft";
            this.labelLeft.Size = new System.Drawing.Size(35, 13);
            this.labelLeft.TabIndex = 2;
            this.labelLeft.Text = "label1";
            // 
            // customGridViewLeft
            // 
            this.customGridViewLeft.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.customGridViewLeft.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.customGridViewLeft.ChangedRowsHeaderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.customGridViewLeft.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnKeystroke;
            this.customGridViewLeft.EnableHeadersVisualStyles = false;
            this.customGridViewLeft.Location = new System.Drawing.Point(5, 25);
            this.customGridViewLeft.MultiSelect = false;
            this.customGridViewLeft.Name = "customGridViewLeft";
            this.customGridViewLeft.Size = new System.Drawing.Size(334, 280);
            this.customGridViewLeft.TabIndex = 0;
            this.customGridViewLeft.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.customGridViewLeft_DataError);
            // 
            // buttonDeleteRight
            // 
            this.buttonDeleteRight.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonDeleteRight.Image = ((System.Drawing.Image)(resources.GetObject("buttonDeleteRight.Image")));
            this.buttonDeleteRight.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonDeleteRight.Location = new System.Drawing.Point(114, 310);
            this.buttonDeleteRight.Name = "buttonDeleteRight";
            this.buttonDeleteRight.Size = new System.Drawing.Size(103, 45);
            this.buttonDeleteRight.TabIndex = 13;
            this.buttonDeleteRight.Text = "Briši";
            this.buttonDeleteRight.UseVisualStyleBackColor = true;
            // 
            // labelRight
            // 
            this.labelRight.AutoSize = true;
            this.labelRight.Location = new System.Drawing.Point(12, 9);
            this.labelRight.Name = "labelRight";
            this.labelRight.Size = new System.Drawing.Size(35, 13);
            this.labelRight.TabIndex = 3;
            this.labelRight.Text = "label1";
            // 
            // buttonSaveRight
            // 
            this.buttonSaveRight.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonSaveRight.Image = ((System.Drawing.Image)(resources.GetObject("buttonSaveRight.Image")));
            this.buttonSaveRight.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonSaveRight.Location = new System.Drawing.Point(5, 310);
            this.buttonSaveRight.Name = "buttonSaveRight";
            this.buttonSaveRight.Size = new System.Drawing.Size(103, 45);
            this.buttonSaveRight.TabIndex = 12;
            this.buttonSaveRight.Text = "Spremi";
            this.buttonSaveRight.UseVisualStyleBackColor = true;
            // 
            // customGridViewRight
            // 
            this.customGridViewRight.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.customGridViewRight.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.customGridViewRight.ChangedRowsHeaderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.customGridViewRight.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnKeystroke;
            this.customGridViewRight.EnableHeadersVisualStyles = false;
            this.customGridViewRight.Location = new System.Drawing.Point(5, 25);
            this.customGridViewRight.MultiSelect = false;
            this.customGridViewRight.Name = "customGridViewRight";
            this.customGridViewRight.Size = new System.Drawing.Size(334, 280);
            this.customGridViewRight.TabIndex = 1;
            this.customGridViewRight.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.customGridViewRight_DataError);
            // 
            // UcCommonFormWithSplit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.buttonCancel);
            this.Name = "UcCommonFormWithSplit";
            this.Size = new System.Drawing.Size(782, 358);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.customGridViewLeft)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.customGridViewRight)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        protected System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.SplitContainer splitContainer1;
        protected System.Windows.Forms.Button buttonDeleteLeft;
        protected System.Windows.Forms.Button buttonSaveLeft;
        protected System.Windows.Forms.Button buttonDeleteRight;
        protected System.Windows.Forms.Button buttonSaveRight;
        protected CustomGridView customGridViewLeft;
        protected CustomGridView customGridViewRight;
        protected System.Windows.Forms.Label labelLeft;
        protected System.Windows.Forms.Label labelRight;
    }
}
