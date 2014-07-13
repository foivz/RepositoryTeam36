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
    /// Bazna klasa za forme koje prikazuju izvješća
    /// </summary>
    public partial class UcReport : UserControl
    {
        ClickedEvent ce = new ClickedEvent();
        protected string MyName { get; private set; }

        public UcReport()
        {
            InitializeComponent();
        }

        public UcReport(string name, ClickedEvent.ClickedButtonEventHandler eventHandler)
        {
            this.Dock = DockStyle.Fill;
            InitializeComponent();
            Initialize(name, eventHandler);
        }

        void Initialize(string name, ClickedEvent.ClickedButtonEventHandler eventHandler)
        {
            this.MyName = name;
            this.ce.ButtonClicked += eventHandler;
        }

        /// <summary>
        /// Pokrene događaj ClickedEvent. Vrijednost ClickedEvent.ClickedButton označava pritisnutu tipku.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected virtual void buttonCancel_Click(object sender, EventArgs e)
        {
            ce.RaiseEvent(ClickedEvent.ClickedButton.Cancel, this.MyName);
        }

    }
}
