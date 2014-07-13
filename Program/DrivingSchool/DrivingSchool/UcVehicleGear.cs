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
    public partial class UcVehicleGear : DrivingSchool.UcDataGridForm
    {
        int curVehicleId = 0;
        SortedList<int, vozilo> vehicles = new SortedList<int, vozilo>();
        List<vozilo_dodatna_oprema> changedGear = new List<vozilo_dodatna_oprema>();

        public UcVehicleGear()
        {
            InitializeComponent();
        }

        public UcVehicleGear(string name, ClickedEvent.ClickedButtonEventHandler eventHandler, bool allowInserting)
            : base(name, eventHandler, allowInserting)
        {
            InitializeComponent();
            FillInitial();
            vozilododatnaopremaBindingSource.AllowNew = true;
        }

        protected override void buttonSave_Click(object sender, EventArgs e)
        {
            if (Save())
            {
                ShowGrid();
            }
        }

        protected override void buttonDelete_Click(object sender, EventArgs e)
        {
            if (Delete())
            {
                base.buttonDelete_Click(this, null);
            }
        }

        private void comboBoxVehicle_SelectedIndexChanged(object sender, EventArgs e)
        {
            SetCurrentVehicleId();
            ShowGrid();
        }

        private void customGridView_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (maxOldRowIndex >= e.RowIndex)
                customGridView.Rows[e.RowIndex].ReadOnly = true;
        }

        void FillInitial()
        {
            foreach (vozilo vehicle in new Logic().GetVehiclesList())
            {
                comboBoxVehicle.Items.Add(vehicle.marka + " " + vehicle.naziv);
                vehicles.Add(comboBoxVehicle.Items.Count - 1, vehicle);
            }
            dodatnaopremaBindingSource.DataSource = new Logic().GetGearList();
            CheckVehiclesCombo();
        }

        void CheckVehiclesCombo()
        {
            if (comboBoxVehicle.SelectedIndex < 0)
            {
                customGridView.Enabled = false;
            }
            else
            {
                customGridView.Enabled = true;
            }
        }

        void SetCurrentVehicleId()
        {
            curVehicleId = vehicles[comboBoxVehicle.SelectedIndex].vozilo_id;
        }

        void ShowGrid()
        {
            vozilododatnaopremaBindingSource.DataSource = new Logic().GetGearForVehicle(curVehicleId);
            maxOldRowIndex = vozilododatnaopremaBindingSource.Count - 1;
            CheckVehiclesCombo();
        }

        bool Save()
        {
            Logic l = new Logic();
            List<int> list = GetOrderedListOfChangedRows();
            StringBuilder sb = new StringBuilder();
            foreach (int i in list)
            {
                changedGear.Add((vozilo_dodatna_oprema)vozilododatnaopremaBindingSource[i]);
                changedGear[changedGear.Count - 1].vozilo_id = curVehicleId;
            }
            KeyValuePair<int, List<string>> errors = l.CheckVehicleGearUpdate(changedGear);
            if (errors.Value != null)
            {
                int index = errors.Key;
                foreach (string err in errors.Value)
                {
                    sb.Append(err + ",");
                }
                customGridView.ClearSelection();
                customGridView.Rows[list[index]].Selected = true;
                changedGear.Clear();
                MessageBox.Show(sb.ToString(0, sb.Length - 1));
                return false;
            }
            if (l.SaveVehicleGear(curVehicleId, changedGear))
            {
                changedGear.Clear();
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
            if (customGridView.SelectedRows[0].Index < vozilododatnaopremaBindingSource.Count)
            {
                if (!MessageBox.Show(this, "Želite li obrisati odabrani red?", "Pozor", MessageBoxButtons.YesNo).Equals(DialogResult.Yes))
                    return false;
                //novi dodani red
                if (customGridView.SelectedRows[0].Index > maxOldRowIndex)
                    return true;
                List<vozilo_dodatna_oprema> gearList = new List<vozilo_dodatna_oprema>();
                gearList.Add((vozilo_dodatna_oprema)vozilododatnaopremaBindingSource.Current);
                bool ret = new Logic().DeleteGearListForVehicle(gearList);
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
