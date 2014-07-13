using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DrivingSchool
{
    /// <summary>
    /// Predstavlja kontrolu sa 4 tabPage kontrole koja služi za unos početnih podataka
    /// </summary>
    public partial class UcInitialData : UserControl
    {
        ClickedEvent ce = new ClickedEvent();
        protected string MyName { get; private set; }

        public UcInitialData()
        {
            InitializeComponent();
        }

        public UcInitialData(string name, ClickedEvent.ClickedButtonEventHandler eventHandler)
        {
            this.Dock = DockStyle.Fill;
            this.MyName = name;
            this.ce.ButtonClicked += eventHandler;
            InitializeComponent();
            tabControlInitial.TabPages[0].Select();
            ucTownAndCountry1.ClickedEventHandler = button_Click;
            ucTownAndCountry1.FillInitial();
            ucVenicleTypeAndCategory1.ClickedEventHandler = button_Click;
            ucVenicleTypeAndCategory1.FillInitial();
            ucGearAndEmployeeType1.ClickedEventHandler = button_Click;
            ucGearAndEmployeeType1.FillInitial();
            ucUserStatusAndActivity1.ClickedEventHandler = button_Click;
            ucUserStatusAndActivity1.FillInitial();
        }

        public void button_Click(object sender, ClickedEvent.ClickedButtonEventArgs e)
        {
            switch (e.ClickedButton)
            {
                case ClickedEvent.ClickedButton.Cancel:
                    ce.RaiseEvent(ClickedEvent.ClickedButton.Cancel, this.MyName);
                    break;
            }

        }

    }
}
