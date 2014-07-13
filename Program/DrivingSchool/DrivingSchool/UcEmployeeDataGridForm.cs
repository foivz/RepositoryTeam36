using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Model;
using LogicLayer;

namespace DrivingSchool
{
    public partial class UcEmployeeDataGridForm : DrivingSchool.UcDataGridForm
    {
        List<zaposlenik> changedEmployees = new List<zaposlenik>();

        public UcEmployeeDataGridForm()
        {
            InitializeComponent();
        }

        public UcEmployeeDataGridForm(string name, ClickedEvent.ClickedButtonEventHandler eventHandler, bool allowInserting, bool allowPrinting)
            : base(name, eventHandler, allowInserting, allowPrinting)
        {
            InitializeComponent();
            FillGrid();
        }

        protected override void buttonSave_Click(object sender, EventArgs e)
        {
            if (Save())
            {
                FillGrid();
            }
        }

        protected override void buttonDelete_Click(object sender, EventArgs e)
        {
            if (Delete())
            {
                base.buttonDelete_Click(this, null);
            }
        }

        void FillGrid()
        {
            Logic l = new Logic();
            zaposlenikBindingSource.DataSource = l.GetEmployeesList();
            gradBindingSource.DataSource = l.GetTownsList();
            zaposlenikvrstaBindingSource.DataSource = l.GetEmployeeTypesList();
            maxOldRowIndex = zaposlenikBindingSource.Count - 1;
        }

        bool Save()
        {
            Logic l = new Logic();
            List<int> list = GetOrderedListOfChangedRows();
            StringBuilder sb = new StringBuilder();
            foreach (int i in list)
            {
                changedEmployees.Add((zaposlenik)zaposlenikBindingSource[i]);
            }
            KeyValuePair<int, List<string>> errors = l.CheckPersonsUpdate<zaposlenik>(changedEmployees);
            if (errors.Value != null)
            {
                int index = errors.Key;
                foreach (string err in errors.Value)
                {
                    sb.Append(err + ",");
                }
                customGridView.ClearSelection();
                customGridView.Rows[list[index]].Selected = true;
                changedEmployees.Clear();
                MessageBox.Show(sb.ToString(0, sb.Length - 1));
                return false;
            }
            if (l.SaveEmployees(changedEmployees))
            {
                changedEmployees.Clear();
                ResetChangedRows();
                FillGrid();
            }
            return true;
        }

        bool Delete()
        {
            if (customGridView.SelectedRows.Count != 1)
            {
                return false;
            }
            if (customGridView.SelectedRows[0].Index < zaposlenikBindingSource.Count)
            {
                if (!MessageBox.Show(this, "Želite li obrisati odabrani red?", "Pozor", MessageBoxButtons.YesNo).Equals(DialogResult.Yes))
                    return false;
                //novi dodani red
                if (customGridView.SelectedRows[0].Index > maxOldRowIndex)
                    return true;
                List<osoba> persons = new List<osoba>();
                zaposlenik employee = (zaposlenik)zaposlenikBindingSource.Current;
                if (employee == null)
                    return false;
                persons.Add(employee);
                bool ret = new Logic().DeletePersonsList(persons);
                if (ret)
                {
                    --maxOldRowIndex;
                }
                return ret;
            }
            return false;
        }
    }
}
