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
    public partial class UcDataGridForm : UserControl
    {
        ClickedEvent ce = new ClickedEvent();
        protected const int INITIAL_INDEX = -1;
        /// <summary>
        /// Indeks zadnjeg reda nakon punjenja BindingSource
        /// </summary>
        protected int maxOldRowIndex = INITIAL_INDEX;
        protected string MyName { get; private set; }

        public UcDataGridForm()
        {
            InitializeComponent();
        }

        public UcDataGridForm(string name, ClickedEvent.ClickedButtonEventHandler eventHandler, bool allowInserting)
        {
            Initialize(name, eventHandler);
            buttonPrint.Visible = false;
            if (!allowInserting)
            {
                customGridView.AllowUserToAddRows = false;
            }
        }

        public UcDataGridForm(string name, ClickedEvent.ClickedButtonEventHandler eventHandler, bool allowInserting, bool allowPrinting)
        {
            Initialize(name, eventHandler);
            if (!allowInserting)
            {
                customGridView.AllowUserToAddRows = false;
            }
            if (!allowPrinting)
            {
                buttonPrint.Visible = false;
            }
        }

        void Initialize(string name, ClickedEvent.ClickedButtonEventHandler eventHandler)
        {
            this.Dock = DockStyle.Fill;
            this.MyName = name;
            this.ce.ButtonClicked += eventHandler;
            InitializeComponent();
        }

        /// <summary>
        /// Pokrene događaj ClickedEvent. Vrijednost ClickedEvent.ClickedButton označava pritisnutu tipku.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected virtual void buttonSave_Click(object sender, EventArgs e)
        {
            ce.RaiseEvent(ClickedEvent.ClickedButton.Save, this.MyName);
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

        /// <summary>
        /// Poziva metodu za brisanje reda iz DataGridView kontrole.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected virtual void buttonDelete_Click(object sender, EventArgs e)
        {
            DeleteRow();
        }

        /// <summary>
        /// Pokrene događaj ClickedEvent. Vrijednost ClickedEvent.ClickedButton označava pritisnutu tipku.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected virtual void buttonPrint_Click(object sender, EventArgs e)
        {
            ce.RaiseEvent(ClickedEvent.ClickedButton.Print, this.MyName);
        }

        /// <summary>
        /// Vraća sortiranu listu indeksa redova iz DataGridView kontrole u kojima je bilo izmjena.
        /// </summary>
        /// <returns></returns>
        protected List<int> GetOrderedListOfChangedRows()
        {
            return customGridView.GetOrderedListOfChangedRows();
        }

        /// <summary>
        /// Poništava podatke o redovima u kojima je u DataGridView kontroli bilo promjena.
        /// </summary>
        protected void ResetChangedRows()
        {
            customGridView.ResetChangedRows();
        }

        /// <summary>
        /// Briše označeni red iz DataGridView kontrole.
        /// </summary>
        protected virtual void DeleteRow()
        {
            customGridView.DeleteRow();
        }

        private void customGridView_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            e.ThrowException = false;
        }

    }
}
