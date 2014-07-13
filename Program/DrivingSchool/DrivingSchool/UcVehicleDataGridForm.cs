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
    public partial class UcVehicleDataGridForm : DrivingSchool.UcDataGridForm
    {
        List<vozilo> changedVehicles = new List<vozilo>();

        public UcVehicleDataGridForm()
        {
            InitializeComponent();
        }

        public UcVehicleDataGridForm(string name, ClickedEvent.ClickedButtonEventHandler eventHandler, bool allowInserting, bool allowPrinting)
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

        protected void FillGrid()
        {
            Logic l = new Logic();
            voziloBindingSource.DataSource = l.GetVehiclesList();
            vozilovrstaBindingSource.DataSource = l.GetVehiclesTypesList();
            maxOldRowIndex = voziloBindingSource.Count - 1;
        }

        bool Save()
        {
            Logic l = new Logic();
            List<int> list = GetOrderedListOfChangedRows();
            StringBuilder sb = new StringBuilder();
            foreach (int i in list)
            {
                changedVehicles.Add((vozilo)voziloBindingSource[i]);
            }
            KeyValuePair<int, List<string>> errors = l.CheckVehiclesUpdate(changedVehicles);
            if (errors.Value != null)
            {
                int index = errors.Key;
                foreach (string err in errors.Value)
                {
                    sb.Append(err + ",");
                }
                customGridView.ClearSelection();
                customGridView.Rows[list[index]].Selected = true;
                changedVehicles.Clear();
                MessageBox.Show(sb.ToString(0, sb.Length - 1));
                return false;
            }
            if (l.SaveVehicles(changedVehicles))
            {
                changedVehicles.Clear();
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
            if (customGridView.SelectedRows[0].Index < voziloBindingSource.Count)
            {
                if (!MessageBox.Show(this, "Želite li obrisati odabrani red?", "Pozor", MessageBoxButtons.YesNo).Equals(DialogResult.Yes))
                    return false;
                //novi dodani red
                if (customGridView.SelectedRows[0].Index > maxOldRowIndex)
                    return true;
                List<vozilo> vehicles = new List<vozilo>();
                vozilo vehicle = (vozilo)voziloBindingSource.Current;
                if (vehicle == null)
                    return false;
                vehicles.Add(vehicle);
                bool ret = new Logic().DeleteVehiclesList(vehicles);
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
