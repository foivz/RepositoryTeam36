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
    public partial class UcUserActivitiesDataGridForm : DrivingSchool.UcDataGridForm
    {
        int curUserId = 0;
        SortedList<int, korisnik> users = new SortedList<int, korisnik>();
        List<korisnik_aktivnost> changedActivities = new List<korisnik_aktivnost>();
        /// <summary>
        /// Popis aktivnosti koje treba maknuti jer su zamijenjene s drugim aktivnostima
        /// </summary>
        Dictionary<int, korisnik_aktivnost> activitiesToDelete = new Dictionary<int, korisnik_aktivnost>();

        public UcUserActivitiesDataGridForm()
        {
            InitializeComponent();
        }

        public UcUserActivitiesDataGridForm(string name, ClickedEvent.ClickedButtonEventHandler eventHandler, bool allowInserting)
            : base(name, eventHandler, allowInserting)
        {
            InitializeComponent();
            FillInitial();
        }

        protected override void buttonSave_Click(object sender, EventArgs e)
        {
            if (Save())
            {
                ShowGrid(curUserId);
            }
        }

        protected override void buttonDelete_Click(object sender, EventArgs e)
        {
            if (Delete())
            {
                base.buttonDelete_Click(this, null);
            }
        }

        private void comboBoxUser_SelectedIndexChanged(object sender, EventArgs e)
        {
            SetCurrentUserId();
            ShowGrid(GetUserId());
        }

        private void customGridView_UserAddedRow(object sender, DataGridViewRowEventArgs e)
        {
            AddUserId(customGridView.CurrentRow);
        }

        private void customGridView_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            if (e.RowIndex <= maxOldRowIndex && !activitiesToDelete.ContainsKey(customGridView.CurrentRow.Index))
            {
                korisnik_aktivnost curActivity = (korisnik_aktivnost)korisnikaktivnostBindingSource.Current;
                korisnik_aktivnost ua = new korisnik_aktivnost() { korisnik_id = curActivity.korisnik_id, aktivnost_id = curActivity.aktivnost_id, od = curActivity.od, @do = curActivity.@do, polozeno = curActivity.polozeno };
                activitiesToDelete.Add(customGridView.CurrentRow.Index, ua);
            }
        }

        void FillInitial()
        {
            foreach (korisnik k in new Logic().GetUsersList())
            {
                comboBoxUser.Items.Add(k.ime + " " + k.prezime);
                users.Add(comboBoxUser.Items.Count - 1, k);
            }
            CheckUsersCombo();
        }

        void CheckUsersCombo()
        {
            if (comboBoxUser.SelectedIndex < 0)
            {
                customGridView.Enabled = false;
            }
            else
            {
                customGridView.Enabled = true;
            }
        }

        void SetCurrentUserId()
        {
            curUserId = users[comboBoxUser.SelectedIndex].osoba_id;
        }

        int GetUserId()
        {
            return users[comboBoxUser.SelectedIndex].osoba_id;
        }

        void ShowGrid(int userId)
        {
            Logic l = new Logic();
            korisnikaktivnostBindingSource.DataSource = l.GetActivitiesForUser(userId);
            aktivnostBindingSource.DataSource = l.GetActivitiesList();
            maxOldRowIndex = korisnikaktivnostBindingSource.Count - 1;
            CheckUsersCombo();
        }

        void AddUserId(DataGridViewRow row)
        {
            customGridView.CurrentRow.Cells[4].Value = GetUserId();
        }

        bool Save()
        {
            List<int> list = GetOrderedListOfChangedRows();
            List<korisnik_aktivnost> deleteActivities = new List<korisnik_aktivnost>();
            foreach (int i in list)
            {
                changedActivities.Add((korisnik_aktivnost)korisnikaktivnostBindingSource[i]);
                if (activitiesToDelete.ContainsKey(i))
                    deleteActivities.Add(activitiesToDelete[i]);
            }
            Logic l = new Logic();
            StringBuilder sb = new StringBuilder();
            KeyValuePair<int, List<string>> errors = l.CheckActivitiesForUserUpdate(deleteActivities, changedActivities);
            if (errors.Value != null)
            {
                int index = errors.Key;
                foreach (string err in errors.Value)
                {
                    sb.Append(err + ",");
                }
                customGridView.ClearSelection();
                customGridView.Rows[list[index]].Selected = true;
                deleteActivities.Clear();
                changedActivities.Clear();
                MessageBox.Show(sb.ToString(0, sb.Length - 1));
                return false;
            }
            if (new Logic().SaveUserActivities(deleteActivities, changedActivities))
            {
                changedActivities.Clear();
                deleteActivities.Clear();
                activitiesToDelete.Clear();
                ResetChangedRows();
            }
            return true;
        }

        bool Delete()
        {
            if (customGridView.SelectedRows.Count != 1)
            {
                return false;
            }
            if (customGridView.SelectedRows[0].Index < korisnikaktivnostBindingSource.Count)
            {
                if (!MessageBox.Show(this, "Želite li obrisati odabrani red?", "Pozor", MessageBoxButtons.YesNo).Equals(DialogResult.Yes))
                    return false;
                //novi dodani red
                if (customGridView.SelectedRows[0].Index > maxOldRowIndex)
                    return true;
                List<korisnik_aktivnost> userActivities = new List<korisnik_aktivnost>();
                korisnik_aktivnost activity = (korisnik_aktivnost)korisnikaktivnostBindingSource.Current;
                int index = korisnikaktivnostBindingSource.IndexOf(activity);
                if (activitiesToDelete.ContainsKey(index))
                    userActivities.Add(activitiesToDelete[index]);
                else
                    userActivities.Add(activity);
                bool ret = new Logic().DeleteUserActivitiesList(userActivities);
                if (ret)
                {
                    activitiesToDelete.Remove(index);
                    --maxOldRowIndex;
                }
                return ret;
            }
            return false;
        }

    }
}
