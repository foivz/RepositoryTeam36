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
    public partial class UcGearAndEmployeeType : DrivingSchool.UcCommonFormWithSplit
    {
        List<dodatna_oprema> changedGear = new List<dodatna_oprema>();
        List<zaposlenik_vrsta> changedEmployeeTypes = new List<zaposlenik_vrsta>();

        public UcGearAndEmployeeType()
        {
            InitializeComponent();
        }

        private void buttonSaveLeft_Click(object sender, EventArgs e)
        {
            SaveGear();
        }

        private void buttonDeleteLeft_Click(object sender, EventArgs e)
        {
            DeleteGear();
        }

        private void buttonSaveRight_Click(object sender, EventArgs e)
        {
            SaveEmployeeTypes();
        }

        private void buttonDeleteRight_Click(object sender, EventArgs e)
        {
            DeleteEmployeeTypes();
        }

        public void FillInitial()
        {
            Logic l = new Logic();
            FillGearGrid(l);
            FillEmployeeTypeGrid(l);
        }

        void FillGearGrid(Logic l)
        {
            dodatnaopremaBindingSource.DataSource = l.GetGearList();
            maxOldRowIndexGridLeft = dodatnaopremaBindingSource.Count - 1;
        }

        void FillEmployeeTypeGrid(Logic l)
        {
            zaposlenikvrstaBindingSource.DataSource = l.GetEmployeeTypesList();
            maxOldRowIndexGridRight = zaposlenikvrstaBindingSource.Count - 1;
        }

        private void SaveGear()
        {
            Logic l = new Logic();
            List<int> list = customGridViewLeft.GetOrderedListOfChangedRows();
            StringBuilder sb = new StringBuilder();
            foreach (int i in list)
            {
                changedGear.Add((dodatna_oprema)dodatnaopremaBindingSource[i]);
            }
            KeyValuePair<int, List<string>> errors = l.CheckGearUpdate(changedGear);
            if (errors.Value != null)
            {
                int index = errors.Key;
                foreach (string err in errors.Value)
                {
                    sb.Append(err + ",");
                }
                customGridViewLeft.ClearSelection();
                customGridViewLeft.Rows[list[index]].Selected = true;
                changedGear.Clear();
                MessageBox.Show(sb.ToString(0, sb.Length - 1));
                return;
            }
            if (l.SaveGear(changedGear))
            {
                changedGear.Clear();
                customGridViewLeft.ResetChangedRows();
                FillGearGrid(l);
            }
        }

        private void SaveEmployeeTypes()
        {
            Logic l = new Logic();
            List<int> list = customGridViewRight.GetOrderedListOfChangedRows();
            StringBuilder sb = new StringBuilder();
            foreach (int i in list)
            {
                changedEmployeeTypes.Add((zaposlenik_vrsta)zaposlenikvrstaBindingSource[i]);
            }
            KeyValuePair<int, List<string>> errors = l.CheckEmployeeTypesUpdate(changedEmployeeTypes);
            if (errors.Value != null)
            {
                int index = errors.Key;
                foreach (string err in errors.Value)
                {
                    sb.Append(err + ",");
                }
                customGridViewRight.ClearSelection();
                customGridViewRight.Rows[list[index]].Selected = true;
                changedEmployeeTypes.Clear();
                MessageBox.Show(sb.ToString(0, sb.Length - 1));
                return;
            }
            if (l.SaveEmployeeTypes(changedEmployeeTypes))
            {
                changedEmployeeTypes.Clear();
                customGridViewRight.ResetChangedRows();
                FillEmployeeTypeGrid(l);
            }
        }

        void DeleteGear()
        {
            if (customGridViewLeft.SelectedRows.Count != 1)
            {
                return;
            }
            if (customGridViewLeft.SelectedRows[0].Index < dodatnaopremaBindingSource.Count)
            {
                if (!MessageBox.Show(this, "Želite li obrisati odabrani red?", "Pozor", MessageBoxButtons.YesNo).Equals(DialogResult.Yes))
                    return;
                //novi dodani red
                if (customGridViewLeft.SelectedRows[0].Index > maxOldRowIndexGridLeft)
                {
                    customGridViewLeft.DeleteRow();
                    return;
                }
                List<dodatna_oprema> gear = new List<dodatna_oprema>();
                dodatna_oprema aGear = (dodatna_oprema)dodatnaopremaBindingSource.Current;
                if (aGear == null)
                    return;
                gear.Add(aGear);
                if (new Logic().DeleteGearList(gear))
                {
                    customGridViewLeft.DeleteRow();
                    --maxOldRowIndexGridLeft;
                }
            }
        }

        void DeleteEmployeeTypes()
        {
            if (customGridViewRight.SelectedRows.Count != 1)
            {
                return;
            }
            if (customGridViewRight.SelectedRows[0].Index < zaposlenikvrstaBindingSource.Count)
            {
                if (!MessageBox.Show(this, "Želite li obrisati odabrani red?", "Pozor", MessageBoxButtons.YesNo).Equals(DialogResult.Yes))
                    return;
                //novi dodani red
                if (customGridViewRight.SelectedRows[0].Index > maxOldRowIndexGridRight)
                {
                    customGridViewRight.DeleteRow();
                    return;
                }
                List<zaposlenik_vrsta> employeeTypes = new List<zaposlenik_vrsta>();
                zaposlenik_vrsta employeeType = (zaposlenik_vrsta)zaposlenikvrstaBindingSource.Current;
                if (employeeType == null)
                    return;
                employeeTypes.Add(employeeType);
                if (new Logic().DeleteEmployeeTypesList(employeeTypes))
                {
                    customGridViewRight.DeleteRow();
                    --maxOldRowIndexGridRight;
                }
            }
        }

    }
}
