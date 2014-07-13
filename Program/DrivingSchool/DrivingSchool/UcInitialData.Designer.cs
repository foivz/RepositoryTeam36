namespace DrivingSchool
{
    partial class UcInitialData
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
            this.tabControlInitial = new System.Windows.Forms.TabControl();
            this.tabPageCountryAndTown = new System.Windows.Forms.TabPage();
            this.tabPageVehicleTypeAndCategory = new System.Windows.Forms.TabPage();
            this.tabPageGearAndEmployeeType = new System.Windows.Forms.TabPage();
            this.tabPageUserStatusAndActivity = new System.Windows.Forms.TabPage();
            this.ucTownAndCountry1 = new DrivingSchool.UcTownAndCountry();
            this.ucVenicleTypeAndCategory1 = new DrivingSchool.UcVehicleTypeAndCategory();
            this.ucGearAndEmployeeType1 = new DrivingSchool.UcGearAndEmployeeType();
            this.ucUserStatusAndActivity1 = new DrivingSchool.UcUserStatusAndActivity();
            this.tabControlInitial.SuspendLayout();
            this.tabPageCountryAndTown.SuspendLayout();
            this.tabPageVehicleTypeAndCategory.SuspendLayout();
            this.tabPageGearAndEmployeeType.SuspendLayout();
            this.tabPageUserStatusAndActivity.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControlInitial
            // 
            this.tabControlInitial.Alignment = System.Windows.Forms.TabAlignment.Bottom;
            this.tabControlInitial.Controls.Add(this.tabPageCountryAndTown);
            this.tabControlInitial.Controls.Add(this.tabPageVehicleTypeAndCategory);
            this.tabControlInitial.Controls.Add(this.tabPageGearAndEmployeeType);
            this.tabControlInitial.Controls.Add(this.tabPageUserStatusAndActivity);
            this.tabControlInitial.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlInitial.Location = new System.Drawing.Point(0, 0);
            this.tabControlInitial.Multiline = true;
            this.tabControlInitial.Name = "tabControlInitial";
            this.tabControlInitial.SelectedIndex = 0;
            this.tabControlInitial.Size = new System.Drawing.Size(819, 397);
            this.tabControlInitial.TabIndex = 0;
            // 
            // tabPageCountryAndTown
            // 
            this.tabPageCountryAndTown.Controls.Add(this.ucTownAndCountry1);
            this.tabPageCountryAndTown.Location = new System.Drawing.Point(4, 4);
            this.tabPageCountryAndTown.Name = "tabPageCountryAndTown";
            this.tabPageCountryAndTown.Size = new System.Drawing.Size(811, 371);
            this.tabPageCountryAndTown.TabIndex = 0;
            this.tabPageCountryAndTown.Text = "Država i grad";
            this.tabPageCountryAndTown.UseVisualStyleBackColor = true;
            // 
            // tabPageVehicleTypeAndCategory
            // 
            this.tabPageVehicleTypeAndCategory.Controls.Add(this.ucVenicleTypeAndCategory1);
            this.tabPageVehicleTypeAndCategory.Location = new System.Drawing.Point(4, 4);
            this.tabPageVehicleTypeAndCategory.Name = "tabPageVehicleTypeAndCategory";
            this.tabPageVehicleTypeAndCategory.Size = new System.Drawing.Size(811, 371);
            this.tabPageVehicleTypeAndCategory.TabIndex = 1;
            this.tabPageVehicleTypeAndCategory.Text = "Vrste vozila i kategorije";
            this.tabPageVehicleTypeAndCategory.UseVisualStyleBackColor = true;
            // 
            // tabPageGearAndEmployeeType
            // 
            this.tabPageGearAndEmployeeType.Controls.Add(this.ucGearAndEmployeeType1);
            this.tabPageGearAndEmployeeType.Location = new System.Drawing.Point(4, 4);
            this.tabPageGearAndEmployeeType.Name = "tabPageGearAndEmployeeType";
            this.tabPageGearAndEmployeeType.Size = new System.Drawing.Size(811, 371);
            this.tabPageGearAndEmployeeType.TabIndex = 2;
            this.tabPageGearAndEmployeeType.Text = "Oprema i vrste zaposlenika";
            this.tabPageGearAndEmployeeType.UseVisualStyleBackColor = true;
            // 
            // tabPageUserStatusAndActivity
            // 
            this.tabPageUserStatusAndActivity.Controls.Add(this.ucUserStatusAndActivity1);
            this.tabPageUserStatusAndActivity.Location = new System.Drawing.Point(4, 4);
            this.tabPageUserStatusAndActivity.Name = "tabPageUserStatusAndActivity";
            this.tabPageUserStatusAndActivity.Size = new System.Drawing.Size(811, 371);
            this.tabPageUserStatusAndActivity.TabIndex = 3;
            this.tabPageUserStatusAndActivity.Text = "Statusi korisnika i aktivnosti";
            this.tabPageUserStatusAndActivity.UseVisualStyleBackColor = true;
            // 
            // ucTownAndCountry1
            // 
            this.ucTownAndCountry1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ucTownAndCountry1.Location = new System.Drawing.Point(0, 0);
            this.ucTownAndCountry1.Name = "ucTownAndCountry1";
            this.ucTownAndCountry1.Size = new System.Drawing.Size(811, 371);
            this.ucTownAndCountry1.TabIndex = 0;
            // 
            // ucVenicleTypeAndCategory1
            // 
            this.ucVenicleTypeAndCategory1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ucVenicleTypeAndCategory1.Location = new System.Drawing.Point(0, 0);
            this.ucVenicleTypeAndCategory1.Name = "ucVenicleTypeAndCategory1";
            this.ucVenicleTypeAndCategory1.Size = new System.Drawing.Size(811, 371);
            this.ucVenicleTypeAndCategory1.TabIndex = 0;
            // 
            // ucGearAndEmployeeType1
            // 
            this.ucGearAndEmployeeType1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ucGearAndEmployeeType1.Location = new System.Drawing.Point(0, 0);
            this.ucGearAndEmployeeType1.Name = "ucGearAndEmployeeType1";
            this.ucGearAndEmployeeType1.Size = new System.Drawing.Size(811, 371);
            this.ucGearAndEmployeeType1.TabIndex = 0;
            // 
            // ucUserStatusAndActivity1
            // 
            this.ucUserStatusAndActivity1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ucUserStatusAndActivity1.Location = new System.Drawing.Point(0, 0);
            this.ucUserStatusAndActivity1.Name = "ucUserStatusAndActivity1";
            this.ucUserStatusAndActivity1.Size = new System.Drawing.Size(811, 371);
            this.ucUserStatusAndActivity1.TabIndex = 0;
            // 
            // UcInitialData
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tabControlInitial);
            this.Name = "UcInitialData";
            this.Size = new System.Drawing.Size(819, 397);
            this.tabControlInitial.ResumeLayout(false);
            this.tabPageCountryAndTown.ResumeLayout(false);
            this.tabPageVehicleTypeAndCategory.ResumeLayout(false);
            this.tabPageGearAndEmployeeType.ResumeLayout(false);
            this.tabPageUserStatusAndActivity.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControlInitial;
        private System.Windows.Forms.TabPage tabPageCountryAndTown;
        private System.Windows.Forms.TabPage tabPageVehicleTypeAndCategory;
        private System.Windows.Forms.TabPage tabPageGearAndEmployeeType;
        private System.Windows.Forms.TabPage tabPageUserStatusAndActivity;
        private UcVehicleTypeAndCategory ucVenicleTypeAndCategory1;
        private UcGearAndEmployeeType ucGearAndEmployeeType1;
        private UcUserStatusAndActivity ucUserStatusAndActivity1;
        private UcTownAndCountry ucTownAndCountry1;
    }
}
