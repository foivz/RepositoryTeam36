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
    public partial class UcReportUser : DrivingSchool.UcReport
    {
        public UcReportUser()
        {
            InitializeComponent();
        }

        public UcReportUser(string name, ClickedEvent.ClickedButtonEventHandler eventHandler)
            : base(name, eventHandler)
        {
            InitializeComponent();
            FillGrid();
        }

        void FillGrid()
        {
            v_korisnikBindingSource.DataSource = new Logic().GetReportUsers();
            this.reportViewer1.RefreshReport();
        }

    }
}
