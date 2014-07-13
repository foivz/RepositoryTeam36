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
    public partial class UcVenicleTypeAndCategory : DrivingSchool.UcCommonFormWithSplit
    {
        List<vozilo_vrsta> changedVehicleTypes = new List<vozilo_vrsta>();
        List<kategorija> changedCategories = new List<kategorija>();

        public UcVenicleTypeAndCategory()
        {
            InitializeComponent();
        }

        private void buttonSaveLeft_Click(object sender, EventArgs e)
        {
            SaveVehicleTypes();
        }

        private void buttonDeleteLeft_Click(object sender, EventArgs e)
        {
            DeleteVehicleType();
        }

        private void buttonSaveRight_Click(object sender, EventArgs e)
        {
            SaveCategories();
        }

        private void buttonDeleteRight_Click(object sender, EventArgs e)
        {
            DeleteCategory();
        }

        public void FillInitial()
        {
            Logic l = new Logic();
            FillVehicleTypeGrid(l);
            FillCategoryGrid(l);
        }

        void FillVehicleTypeGrid(Logic l)
        {
            vozilovrstaBindingSource.DataSource = l.GetVehiclesTypesList();
            maxOldRowIndexGridLeft = vozilovrstaBindingSource.Count - 1;
        }

        void FillCategoryGrid(Logic l)
        {
            kategorijaBindingSource.DataSource = l.GetCategoriesList();
            maxOldRowIndexGridRight = kategorijaBindingSource.Count - 1;
        }

        private void SaveVehicleTypes()
        {
            Logic l = new Logic();
            List<int> list = customGridViewLeft.GetOrderedListOfChangedRows();
            StringBuilder sb = new StringBuilder();
            foreach (int i in list)
            {
                changedVehicleTypes.Add((vozilo_vrsta)vozilovrstaBindingSource[i]);
            }
            KeyValuePair<int, List<string>> errors = l.CheckVehicleTypesUpdate(changedVehicleTypes);
            if (errors.Value != null)
            {
                int index = errors.Key;
                foreach (string err in errors.Value)
                {
                    sb.Append(err + ",");
                }
                customGridViewLeft.ClearSelection();
                customGridViewLeft.Rows[list[index]].Selected = true;
                changedVehicleTypes.Clear();
                MessageBox.Show(sb.ToString(0, sb.Length - 1));
                return;
            }
            if (l.SaveVehicleTypes(changedVehicleTypes))
            {
                changedVehicleTypes.Clear();
                customGridViewLeft.ResetChangedRows();
                FillVehicleTypeGrid(l);
            }
        }

        private void SaveCategories()
        {
            Logic l = new Logic();
            List<int> list = customGridViewRight.GetOrderedListOfChangedRows();
            StringBuilder sb = new StringBuilder();
            foreach (int i in list)
            {
                changedCategories.Add((kategorija)kategorijaBindingSource[i]);
            }
            KeyValuePair<int, List<string>> errors = l.CheckCategoriesUpdate(changedCategories);
            if (errors.Value != null)
            {
                int index = errors.Key;
                foreach (string err in errors.Value)
                {
                    sb.Append(err + ",");
                }
                customGridViewRight.ClearSelection();
                customGridViewRight.Rows[list[index]].Selected = true;
                changedCategories.Clear();
                MessageBox.Show(sb.ToString(0, sb.Length - 1));
                return;
            }
            if (l.SaveCategories(changedCategories))
            {
                changedCategories.Clear();
                customGridViewRight.ResetChangedRows();
                FillCategoryGrid(l);
            }
        }

        void DeleteVehicleType()
        {
            if (customGridViewLeft.SelectedRows.Count != 1)
            {
                return;
            }
            if (customGridViewLeft.SelectedRows[0].Index < vozilovrstaBindingSource.Count)
            {
                if (!MessageBox.Show(this, "Želite li obrisati odabrani red?", "Pozor", MessageBoxButtons.YesNo).Equals(DialogResult.Yes))
                    return;
                //novi dodani red
                if (customGridViewLeft.SelectedRows[0].Index > maxOldRowIndexGridLeft)
                {
                    customGridViewLeft.DeleteRow();
                    return;
                }
                List<vozilo_vrsta> vehicleTypes = new List<vozilo_vrsta>();
                vozilo_vrsta vehicleType = (vozilo_vrsta)vozilovrstaBindingSource.Current;
                if (vehicleType == null)
                    return;
                vehicleTypes.Add(vehicleType);
                if (new Logic().DeleteVehicleTypesList(vehicleTypes))
                {
                    customGridViewLeft.DeleteRow();
                    --maxOldRowIndexGridLeft;
                }
            }
        }

        void DeleteCategory()
        {
            if (customGridViewRight.SelectedRows.Count != 1)
            {
                return;
            }
            if (customGridViewRight.SelectedRows[0].Index < kategorijaBindingSource.Count)
            {
                if (!MessageBox.Show(this, "Želite li obrisati odabrani red?", "Pozor", MessageBoxButtons.YesNo).Equals(DialogResult.Yes))
                    return;
                //novi dodani red
                if (customGridViewRight.SelectedRows[0].Index > maxOldRowIndexGridRight)
                {
                    customGridViewRight.DeleteRow();
                    return;
                }
                List<kategorija> categories = new List<kategorija>();
                kategorija category = (kategorija)kategorijaBindingSource.Current;
                if (category == null)
                    return;
                categories.Add(category);
                if (new Logic().DeleteCategoriesList(categories))
                {
                    customGridViewRight.DeleteRow();
                    --maxOldRowIndexGridRight;
                }
            }
        }

    }
}
