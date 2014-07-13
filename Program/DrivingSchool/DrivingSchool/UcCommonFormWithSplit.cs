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
    public partial class UcCommonFormWithSplit : UserControl
    {
        ClickedEvent ce = new ClickedEvent();
        protected const int INITIAL_INDEX = -1;
        /// <summary>
        /// Indeks zadnjeg reda nakon punjenja BindingSource
        /// </summary>
        protected int maxOldRowIndexGridLeft = INITIAL_INDEX;
        protected int maxOldRowIndexGridRight = INITIAL_INDEX;
        protected string MyName { get; private set; }

        public UcCommonFormWithSplit()
        {
            InitializeComponent();
        }
        public ClickedEvent.ClickedButtonEventHandler ClickedEventHandler
        {
            set
            {
                this.ce.ButtonClicked += value;
            }
        }

        protected virtual void buttonCancel_Click(object sender, EventArgs e)
        {
            ce.RaiseEvent(ClickedEvent.ClickedButton.Cancel, this.MyName);
        }

        private void customGridViewLeft_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            e.ThrowException = false;
        }

        private void customGridViewRight_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            e.ThrowException = false;
        }

    }
}
