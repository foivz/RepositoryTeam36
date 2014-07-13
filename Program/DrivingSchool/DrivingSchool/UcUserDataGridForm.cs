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
    public partial class UcUserDataGridForm : DrivingSchool.UcDataGridForm
    {
        List<korisnik> usersList = new List<korisnik>();
        List<korisnik> changedUsers = new List<korisnik>();

        public UcUserDataGridForm()
        {
            InitializeComponent();
        }

        public UcUserDataGridForm(string name, ClickedEvent.ClickedButtonEventHandler eventHandler, bool allowInserting, bool allowPrinting)
            : base(name, eventHandler, allowInserting, allowPrinting)
        {
            InitializeComponent();
            FillGrid();
        }

        protected override void buttonCancel_Click(object sender, EventArgs e)
        {
            base.buttonCancel_Click(this, null);
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
            korisnikBindingSource.DataSource = l.GetUsersList();
            gradBindingSource.DataSource = l.GetTownsList();
            korisnikstatusBindingSource.DataSource = l.GetUserStatusList();
            maxOldRowIndex = korisnikBindingSource.Count - 1;
        }

        bool Save()
        {
            Logic l = new Logic();
            List<int> list = GetOrderedListOfChangedRows();
            StringBuilder sb = new StringBuilder();
            foreach (int i in list)
            {
                changedUsers.Add((korisnik)korisnikBindingSource[i]);
            }
            KeyValuePair<int, List<string>> errors = l.CheckPersonsUpdate<korisnik>(changedUsers);
            if (errors.Value != null)
            {
                int index = errors.Key;
                foreach (string err in errors.Value)
                {
                    sb.Append(err + ",");
                }
                customGridView.ClearSelection();
                customGridView.Rows[list[index]].Selected = true;
                changedUsers.Clear();
                MessageBox.Show(sb.ToString(0, sb.Length - 1));
                return false;
            }
            if (l.SaveUsers(changedUsers))
            {
                changedUsers.Clear();
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
            if (customGridView.SelectedRows[0].Index < korisnikBindingSource.Count)
            {
                if (!MessageBox.Show(this, "Želite li obrisati odabrani red?", "Pozor", MessageBoxButtons.YesNo).Equals(DialogResult.Yes))
                    return false;
                //novi dodani red
                if (customGridView.SelectedRows[0].Index > maxOldRowIndex)
                    return true;
                List<osoba> persons = new List<osoba>();
                korisnik user = (korisnik)korisnikBindingSource.Current;
                if (user == null)
                    return false;
                persons.Add(user);
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
