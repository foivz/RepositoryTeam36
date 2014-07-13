using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using LogicLayer;

namespace DrivingSchool
{
    public partial class UcReportVehicle : DrivingSchool.UcReport
    {
        public UcReportVehicle()
        {
            InitializeComponent();
        }

        public UcReportVehicle(string name, ClickedEvent.ClickedButtonEventHandler eventHandler)
            : base(name, eventHandler)
        {
            InitializeComponent();
            FillGrid();
        }

        void FillGrid()
        {
            v_voziloBindingSource.DataSource = new Logic().GetReportVehicles();
            this.reportViewer1.RefreshReport();
        }
    }
}
