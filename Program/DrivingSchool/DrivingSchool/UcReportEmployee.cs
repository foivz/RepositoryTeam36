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
    public partial class UcReportEmployee : DrivingSchool.UcReport
    {
        public UcReportEmployee()
        {
            InitializeComponent();
        }

        public UcReportEmployee(string name, ClickedEvent.ClickedButtonEventHandler eventHandler)
            : base(name, eventHandler)
        {
            InitializeComponent();
            FillGrid();
        }

        void FillGrid()
        {
            v_zaposlenikBindingSource.DataSource = new Logic().GetReportEmployees();
            this.reportViewer1.RefreshReport();
        }
    }
}
