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
    public partial class UcUserStatusAndActivity : DrivingSchool.UcCommonFormWithSplit
    {
        List<korisnik_status> changedStatuses = new List<korisnik_status>();
        List<aktivnost> changedActivities = new List<aktivnost>();

        public UcUserStatusAndActivity()
        {
            InitializeComponent();
        }

        private void buttonSaveLeft_Click(object sender, EventArgs e)
        {
            SaveUserStatus();
        }

        private void buttonDeleteLeft_Click(object sender, EventArgs e)
        {
            DeleteStatuses();
        }

        private void buttonSaveRight_Click(object sender, EventArgs e)
        {
            SaveActivities();
        }

        private void buttonDeleteRight_Click(object sender, EventArgs e)
        {
            DeleteActivities();
        }

        public void FillInitial()
        {
            Logic l = new Logic();
            FillUserStatusGrid(l);
            FillActivityGrid(l);
        }

        void FillUserStatusGrid(Logic l)
        {
            korisnikstatusBindingSource.DataSource = l.GetUserStatusList();
            maxOldRowIndexGridLeft = korisnikstatusBindingSource.Count - 1;
        }

        void FillActivityGrid(Logic l)
        {
            aktivnostBindingSource.DataSource = l.GetActivitiesList();
            maxOldRowIndexGridRight = aktivnostBindingSource.Count - 1;
        }

        private void SaveUserStatus()
        {
            Logic l = new Logic();
            List<int> list = customGridViewLeft.GetOrderedListOfChangedRows();
            StringBuilder sb = new StringBuilder();
            foreach (int i in list)
            {
                changedStatuses.Add((korisnik_status)korisnikstatusBindingSource[i]);
            }
            KeyValuePair<int, List<string>> errors = l.CheckUserStatusesUpdate(changedStatuses);
            if (errors.Value != null)
            {
                int index = errors.Key;
                foreach (string err in errors.Value)
                {
                    sb.Append(err + ",");
                }
                customGridViewLeft.ClearSelection();
                customGridViewLeft.Rows[list[index]].Selected = true;
                changedStatuses.Clear();
                MessageBox.Show(sb.ToString(0, sb.Length - 1));
                return;
            }
            if (l.SaveUserStatus(changedStatuses))
            {
                changedStatuses.Clear();
                customGridViewLeft.ResetChangedRows();
                FillUserStatusGrid(l);
            }
        }

        private void SaveActivities()
        {
            Logic l = new Logic();
            List<int> list = customGridViewRight.GetOrderedListOfChangedRows();
            StringBuilder sb = new StringBuilder();
            foreach (int i in list)
            {
                changedActivities.Add((aktivnost)aktivnostBindingSource[i]);
            }
            KeyValuePair<int, List<string>> errors = l.CheckActivitiesUpdate(changedActivities);
            if (errors.Value != null)
            {
                int index = errors.Key;
                foreach (string err in errors.Value)
                {
                    sb.Append(err + ",");
                }
                customGridViewRight.ClearSelection();
                customGridViewRight.Rows[list[index]].Selected = true;
                changedActivities.Clear();
                MessageBox.Show(sb.ToString(0, sb.Length - 1));
                return;
            }
            if (l.SaveActivities(changedActivities))
            {
                changedActivities.Clear();
                customGridViewRight.ResetChangedRows();
                FillActivityGrid(l);
            }
        }

        void DeleteStatuses()
        {
            if (customGridViewLeft.SelectedRows.Count != 1)
            {
                return;
            }
            if (customGridViewLeft.SelectedRows[0].Index < korisnikstatusBindingSource.Count)
            {
                if (!MessageBox.Show(this, "Želite li obrisati odabrani red?", "Pozor", MessageBoxButtons.YesNo).Equals(DialogResult.Yes))
                    return;
                //novi dodani red
                if (customGridViewLeft.SelectedRows[0].Index > maxOldRowIndexGridLeft)
                {
                    customGridViewLeft.DeleteRow();
                    return;
                }
                List<korisnik_status> statuses = new List<korisnik_status>();
                korisnik_status userStatus = (korisnik_status)korisnikstatusBindingSource.Current;
                statuses.Add(userStatus);
                if (userStatus == null)
                    return;
                if (new Logic().DeleteStatusesList(statuses))
                {
                    customGridViewLeft.DeleteRow();
                    --maxOldRowIndexGridLeft;
                }
            }
        }

        void DeleteActivities()
        {
            if (customGridViewRight.SelectedRows.Count != 1)
            {
                return;
            }
            if (customGridViewRight.SelectedRows[0].Index < aktivnostBindingSource.Count)
            {
                if (!MessageBox.Show(this, "Želite li obrisati odabrani red?", "Pozor", MessageBoxButtons.YesNo).Equals(DialogResult.Yes))
                    return;
                //novi dodani red
                if (customGridViewRight.SelectedRows[0].Index > maxOldRowIndexGridRight)
                {
                    customGridViewRight.DeleteRow();
                    return;
                }
                List<aktivnost> activities = new List<aktivnost>();
                aktivnost activity = (aktivnost)aktivnostBindingSource.Current;
                if (activity == null)
                    return;
                activities.Add(activity);
                if (new Logic().DeleteActivitiesList(activities))
                {
                    customGridViewRight.DeleteRow();
                    --maxOldRowIndexGridRight;
                }
            }
        }

    }
}
