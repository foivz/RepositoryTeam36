using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Model;

namespace DrivingSchool
{
    public partial class UcInsertPerson : UserControl
    {
        private ClickedEvent ce = new ClickedEvent();
        protected string MyName { get; set; }
        protected List<grad> towns = new List<grad>();

        protected UcInsertPerson()
        {
            this.Dock = DockStyle.Fill;
            InitializeComponent();
        }

        public UcInsertPerson(string name, ClickedEvent.ClickedButtonEventHandler eventHandler)
        {
            this.Dock = DockStyle.Fill;
            this.MyName = name;
            this.ce.ButtonClicked += eventHandler;
            InitializeComponent();
            comboBoxSex.SelectedIndex = 0;
        }

        protected virtual void buttonSave_Click(object sender, EventArgs e)
        {
            ce.RaiseEvent(ClickedEvent.ClickedButton.Save, this.MyName);
        }

        protected virtual void buttonCancel_Click(object sender, EventArgs e)
        {
            ce.RaiseEvent(ClickedEvent.ClickedButton.Cancel, this.MyName);
        }

    }
}
