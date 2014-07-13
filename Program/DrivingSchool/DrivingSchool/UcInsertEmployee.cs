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
    public partial class UcInsertEmployee : DrivingSchool.UcInsertPerson
    {
        List<zaposlenik_vrsta> employeeTypes = new List<zaposlenik_vrsta>();

        public UcInsertEmployee()
        {
            InitializeComponent();
        }

        public UcInsertEmployee(string name, ClickedEvent.ClickedButtonEventHandler eventHandler)
            : base(name, eventHandler)
        {
            InitializeComponent();
            FillInitial();
        }

        protected override void buttonSave_Click(object sender, EventArgs e)
        {
            if(Save())
                base.buttonSave_Click(this, null);
        }

        void FillInitial()
        {
            Logic l = new Logic();
            towns = l.GetTownsList();
            foreach (grad g in towns)
            {
                comboBoxTown.Items.Add(g.naziv);
            }
            if (comboBoxTown.Items.Count > 0)
            {
                comboBoxTown.SelectedIndex = 0;
            }
            employeeTypes = l.GetEmployeeTypesList();
            foreach (zaposlenik_vrsta zv in employeeTypes)
            {
                comboBoxType.Items.Add(zv.naziv);
            }
            if (comboBoxType.Items.Count > 0)
            {
                comboBoxType.SelectedIndex = 0;
            }
            textBoxName.Select();
        }

        bool Save()
        {
            zaposlenik emp = new zaposlenik();
            emp.ime = textBoxName.Text;
            emp.prezime = textBoxLastName.Text;
            emp.oib = textBoxOib.Text;
            try
            {
                emp.nadnevak_rod = DateTime.Parse(textBoxDateOfBirth.Text);
            }
            catch (ArgumentNullException) { }
            catch (FormatException) { }
            emp.spol = comboBoxSex.Text;
            emp.adresa = textBoxAddres.Text;
            emp.grad_id = towns.Find(town => town.naziv.Equals(comboBoxTown.Text)).grad_id;
            emp.vrsta = employeeTypes.Find(empType => empType.naziv.Equals(comboBoxType.Text)).vrsta_id;
            Logic l = new Logic();
            StringBuilder sb = new StringBuilder();
            List<string> errors = l.CheckPersonInsert<zaposlenik>(emp);
            if (errors.Count > 0)
            {
                foreach (string err in errors)
                {
                    sb.Append(err + ",");
                }
                MessageBox.Show(sb.ToString(0, sb.Length - 1));
                return false;
            }
            return l.AddEmployee(emp);
        }

    }
}
