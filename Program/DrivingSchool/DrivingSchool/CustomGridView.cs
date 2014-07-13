using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Design;

namespace DrivingSchool
{
    
    [Designer(typeof (System.Windows.Forms.Design.ControlDesigner))]
    public partial class CustomGridView : DataGridView
    {
        Color oldRowHeaderColor;
        Color changedRowsHeaderColor;
        HashSet<int> changedRows = new HashSet<int>();

        public bool HasChanges
        {
            get
            { 
                return changedRows.Count > 0 ? true : false;
            }
        }

        /// <summary>
        /// Postavlja ili vraća boju koja označava red u kojem je bilo promjena
        /// </summary>
        public Color ChangedRowsHeaderColor 
        {
            get 
            {
                return changedRowsHeaderColor;
            }
            set 
            {
                changedRowsHeaderColor = value;
            }
        }

        public CustomGridView()
        {
            //InitializeComponent();
            this.EnableHeadersVisualStyles = false;
            this.CellEndEdit += CustomGridView_CellEndEdit;
            this.EditMode = DataGridViewEditMode.EditOnKeystroke;
            this.oldRowHeaderColor = this.RowsDefaultCellStyle.BackColor;
            this.ChangedRowsHeaderColor = Color.FromArgb(255, 0, 0);
            this.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            this.MultiSelect = false;
        }

        void CustomGridView_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (!changedRows.Contains(CurrentRow.Index))
            {
                if (CurrentRow.Index < this.Rows.Count - 1 && this.AllowUserToAddRows)
                {
                    CurrentRow.HeaderCell.Style.BackColor = changedRowsHeaderColor;
                    changedRows.Add(CurrentRow.Index);
                }
            }
            //changedRows.Add(CurrentRow.Index);
        }

        /// <summary>
        /// Briše označeni red iz MyDataGridView kontrole.
        /// </summary>
        public void DeleteRow()
        {
            int index = SelectedRows[0].Index;
            if (index > -1)
            {
                try
                {
                    Rows.RemoveAt(index);
                }
                catch (InvalidOperationException)
                { }
                changedRows.RemoveWhere(r => r == index);
                List<int> temp = changedRows.ToList();
                foreach (int i in temp)
                {
                    if (i > index) {
                        changedRows.RemoveWhere(r => r == i);
                        changedRows.Add(i - 1);
                    }
                }
            }
        }

        /// <summary>
        /// Vraća sortiranu listu indeksa redova u kojima je bilo promjena.
        /// </summary>
        /// <returns></returns>
        public List<int> GetOrderedListOfChangedRows()
        {
            return changedRows.OrderBy(a => a).ToList();
        }

        /// <summary>
        /// Poništava zapamćene informacije o promijenjenim redovima.
        /// </summary>
        public void ResetChangedRows()
        {
            foreach (int row in GetOrderedListOfChangedRows()) 
            {
                this.Rows[row].HeaderCell.Style.BackColor = oldRowHeaderColor;
            }
            changedRows.Clear();
        }

    }
}
