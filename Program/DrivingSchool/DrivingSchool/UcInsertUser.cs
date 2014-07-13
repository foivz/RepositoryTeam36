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
    public partial class UcInsertUser : DrivingSchool.UcInsertPerson
    {
        List<korisnik_status> userStatus = new List<korisnik_status>();

        public UcInsertUser()
        {
            InitializeComponent();
        }
        
        public UcInsertUser(string name, ClickedEvent.ClickedButtonEventHandler eventHandler)
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
            userStatus = l.GetUserStatusList();
            foreach (korisnik_status ks in userStatus)
            {
                comboBoxStatus.Items.Add(ks.naziv);
            }
            if (comboBoxStatus.Items.Count > 0)
            {
                comboBoxStatus.SelectedIndex = 0;
            }
            textBoxName.Select();
        }

        bool Save()
        {
            korisnik user = new korisnik();
            user.ime = textBoxName.Text;
            user.prezime = textBoxLastName.Text;
            user.oib = textBoxOib.Text;
            try
            {
                user.nadnevak_rod = DateTime.Parse(textBoxDateOfBirth.Text);
            }
            catch (ArgumentNullException) { }
            catch (FormatException) { }
            user.spol = comboBoxSex.Text;
            user.adresa = textBoxAddres.Text;
            user.grad_id = towns.Find(town => town.naziv.Equals(comboBoxTown.Text)).grad_id;
            user.status_id = userStatus.Find(userStat => userStat.naziv.Equals(comboBoxStatus.Text)).status_id;
            Logic l = new Logic();
            StringBuilder sb = new StringBuilder();
            List<string> errors = l.CheckPersonInsert<korisnik>(user);
            if (errors.Count > 0)
            {
                foreach (string err in errors)
                {
                    sb.Append(err + ",");
                }
                MessageBox.Show(sb.ToString(0, sb.Length - 1));
                return false;
            }
            return l.AddUser(user);
        }

    }
}
