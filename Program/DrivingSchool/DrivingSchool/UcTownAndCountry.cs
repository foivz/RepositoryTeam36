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
    public partial class UcTownAndCountry : DrivingSchool.UcCommonFormWithSplit
    {
        int currentCountryId = 0;
        List<drzava> changedCountries = new List<drzava>();
        List<grad> changedTowns = new List<grad>();

        public UcTownAndCountry()
        {
            InitializeComponent();
        }

        private void customGridViewLeft_SelectionChanged(object sender, EventArgs e)
        {
            FillTownGridForCountry((int)customGridViewLeft.CurrentRow.Cells[1].Value);
        }

        private void customGridViewLeft_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            FillTownGridForCountry((int)customGridViewLeft.CurrentRow.Cells[1].Value);
        }

        private void buttonSaveLeft_Click(object sender, EventArgs e)
        {
            SaveCountries();
        }

        private void buttonDeleteLeft_Click(object sender, EventArgs e)
        {
            DeleteCounty();
        }

        private void customGridViewRight_UserAddedRow(object sender, DataGridViewRowEventArgs e)
        {
            AddCountryId(customGridViewRight.CurrentRow);
        }

        private void buttonSaveRight_Click(object sender, EventArgs e)
        {
            SaveTowns();
        }
        
        private void buttonDeleteRight_Click(object sender, EventArgs e)
        {
            DeleteTown();
        }

        public void FillInitial()
        {
            FillCountryGrid();
        }

        void FillCountryGrid()
        {
            Logic l = new Logic();
            drzavaBindingSource.DataSource = l.GetCountriesList();
            maxOldRowIndexGridLeft = drzavaBindingSource.Count - 1;
            if (drzavaBindingSource.Count.Equals(0))
                return;
            FillTownGridForCountry((drzavaBindingSource.Current as drzava).drzava_id);
        }

        void FillTownGridForCountry(int countryId)
        {
            currentCountryId = countryId;
            gradBindingSource.DataSource = new Logic().GetTownsForCountry(countryId);
            maxOldRowIndexGridRight = gradBindingSource.Count - 1;
            customGridViewRight.ResetChangedRows();
        }

        private void AddCountryId(DataGridViewRow row)
        {
            customGridViewRight.CurrentRow.Cells[2].Value = currentCountryId;
        }

        private void SaveCountries()
        {
            Logic l = new Logic();
            List<int> list = customGridViewLeft.GetOrderedListOfChangedRows();
            StringBuilder sb = new StringBuilder();
            foreach (int i in list)
            {
                changedCountries.Add((drzava)drzavaBindingSource[i]);
            }
            KeyValuePair<int, List<string>> errors = l.CheckCountriesUpdate(changedCountries);
            if (errors.Value != null)
            {
                int index = errors.Key;
                foreach (string err in errors.Value)
                {
                    sb.Append(err + ",");
                }
                customGridViewLeft.ClearSelection();
                customGridViewLeft.Rows[list[index]].Selected = true;
                changedCountries.Clear();
                MessageBox.Show(sb.ToString(0, sb.Length - 1));
                return;
            }
            if (l.SaveCountries(changedCountries))
            {
                changedCountries.Clear();
                customGridViewLeft.ResetChangedRows();
                FillCountryGrid();
            }
        }

        private void SaveTowns()
        {
            Logic l = new Logic();
            List<int> list = customGridViewRight.GetOrderedListOfChangedRows();
            StringBuilder sb = new StringBuilder();
            foreach (int i in list)
            {
                changedTowns.Add((grad)gradBindingSource[i]);
            }
            KeyValuePair<int, List<string>> errors = l.CheckTownsUpdate(changedTowns);
            if (errors.Value != null)
            {
                int index = errors.Key;
                foreach (string err in errors.Value)
                {
                    sb.Append(err + ",");
                }
                customGridViewRight.ClearSelection();
                customGridViewRight.Rows[list[index]].Selected = true;
                changedTowns.Clear();
                MessageBox.Show(sb.ToString(0, sb.Length - 1));
                return;
            }
            if (l.SaveTowns(changedTowns))
            {
                changedTowns.Clear();
                customGridViewRight.ResetChangedRows();
                FillTownGridForCountry((drzavaBindingSource.Current as drzava).drzava_id);
            }
        }

        void DeleteCounty()
        {
            if (customGridViewLeft.SelectedRows.Count != 1)
            {
                return;
            }
            if (customGridViewLeft.SelectedRows[0].Index < drzavaBindingSource.Count)
            {
                if (!MessageBox.Show(this, "Želite li obrisati odabrani red?", "Pozor", MessageBoxButtons.YesNo).Equals(DialogResult.Yes))
                    return;
                //novi dodani red
                if (customGridViewLeft.SelectedRows[0].Index > maxOldRowIndexGridLeft)
                {
                    customGridViewLeft.DeleteRow();
                    return;
                }
                List<drzava> countries = new List<drzava>();
                drzava country = (drzava)drzavaBindingSource.Current;
                if (country == null)
                    return;
                countries.Add(country);
                if (new Logic().DeleteCountriesList(countries))
                {
                    customGridViewLeft.DeleteRow();
                    --maxOldRowIndexGridLeft;
                }
            }
        }

        void DeleteTown()
        {
            if (customGridViewRight.SelectedRows.Count != 1)
            {
                return;
            }
            if (customGridViewRight.SelectedRows[0].Index < gradBindingSource.Count)
            {
                if (!MessageBox.Show(this, "Želite li obrisati odabrani red?", "Pozor", MessageBoxButtons.YesNo).Equals(DialogResult.Yes))
                    return;
                //novi dodani red
                if (customGridViewRight.SelectedRows[0].Index > maxOldRowIndexGridRight)
                {
                    customGridViewRight.DeleteRow();
                    return;
                }
                List<grad> towns = new List<grad>();
                grad town = (grad)gradBindingSource.Current;
                if (town == null)
                    return;
                towns.Add(town);
                if (new Logic().DeleteTownsList(towns))
                {
                    customGridViewRight.DeleteRow();
                    --maxOldRowIndexGridRight;
                }
            }
        }

    }
}
