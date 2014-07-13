using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DrivingSchool
{
    public partial class MainForm : Form
    {
        bool allowPrint;
        public MainForm()
        {
            InitializeComponent();
        }

        public MainForm(string user, bool allowPrinting)
        {
            InitializeComponent();
            this.Text = "Korisnik: " + user;
            allowPrint = allowPrinting;
        }

        private void zaposlenikToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowTab("Novi zaposlenik");
        }

        private void korisnikToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowTab("Novi korisnik");
        }

        private void menuStripLeft_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            if (IsMenuCheckOk(e.ClickedItem.Text))
                ShowTab(e.ClickedItem.Text);
            else
                tabControl1.SelectTab(e.ClickedItem.Text);
        }

        private bool ShowTab(string stringToShow)
        {
            bool b = false;
            tabControl1.TabPages.Add(stringToShow, stringToShow);
            switch (stringToShow)
            {
                case "Korisnici":
                    tabControl1.TabPages[tabControl1.TabPages.Count > 0 ? tabControl1.TabPages.Count - 1 : 0].Controls.Add(new UcUserDataGridForm(stringToShow, ControlTab, true, allowPrint));
                    b = true;
                    break;
                case "Korisnici ispis":
                    tabControl1.TabPages[tabControl1.TabPages.Count > 0 ? tabControl1.TabPages.Count - 1 : 0].Controls.Add(new UcReportUser(stringToShow, ControlTab));
                    b = true;
                    break;
                case "Zaposlenici":
                    tabControl1.TabPages[tabControl1.TabPages.Count > 0 ? tabControl1.TabPages.Count - 1 : 0].Controls.Add(new UcEmployeeDataGridForm(stringToShow, ControlTab, true, allowPrint));
                    b = true;
                    break;
                case "Zaposlenici ispis":
                    tabControl1.TabPages[tabControl1.TabPages.Count > 0 ? tabControl1.TabPages.Count - 1 : 0].Controls.Add(new UcReportEmployee(stringToShow, ControlTab));
                    b = true;
                    break;
                case "Vozila":
                    tabControl1.TabPages[tabControl1.TabPages.Count > 0 ? tabControl1.TabPages.Count - 1 : 0].Controls.Add(new UcVehicleDataGridForm(stringToShow, ControlTab, true, allowPrint));
                    b = true;
                    break;
                case "Vozila ispis":
                    tabControl1.TabPages[tabControl1.TabPages.Count > 0 ? tabControl1.TabPages.Count - 1 : 0].Controls.Add(new UcReportVehicle(stringToShow, ControlTab));
                    b = true;
                    break;
                case "Unos podataka":
                    tabControl1.TabPages[tabControl1.TabPages.Count > 0 ? tabControl1.TabPages.Count - 1 : 0].Controls.Add(new UcInitialData(stringToShow, ControlTab));
                    b = true;
                    break;
                case "Korisničke aktivnosti":
                    tabControl1.TabPages[tabControl1.TabPages.Count > 0 ? tabControl1.TabPages.Count - 1 : 0].Controls.Add(new UcUserActivitiesDataGridForm(stringToShow, ControlTab, true));
                    b = true;
                    break;
                case "Vozilo oprema":
                    tabControl1.TabPages[tabControl1.TabPages.Count > 0 ? tabControl1.TabPages.Count - 1 : 0].Controls.Add(new UcVehicleGear(stringToShow, ControlTab, true));
                    b = true;
                    break;
                case "Novi korisnik":
                    tabControl1.TabPages[tabControl1.TabPages.Count > 0 ? tabControl1.TabPages.Count - 1 : 0].Controls.Add(new UcInsertUser(stringToShow, ControlTab));
                    break;
                case "Novi zaposlenik":
                    tabControl1.TabPages[tabControl1.TabPages.Count > 0 ? tabControl1.TabPages.Count - 1 : 0].Controls.Add(new UcInsertEmployee(stringToShow, ControlTab));
                    break;
                default:
                    return false;
            }
            if (tabControl1.TabPages.Count > 0)
            {
                tabControl1.SelectTab(tabControl1.TabPages.Count - 1);
            }
            return b;
        }

        private void ControlTab(object sender, ClickedEvent.ClickedButtonEventArgs e)
        {
            switch (e.ClickedButton)
            {
                case ClickedEvent.ClickedButton.Cancel:
                    tabControl1.TabPages.RemoveAt(tabControl1.TabPages.IndexOfKey(e.Name));
                    break;
                case ClickedEvent.ClickedButton.Save:
                    if (e.Name.StartsWith("Novi "))
                        tabControl1.TabPages.RemoveAt(tabControl1.TabPages.IndexOfKey(e.Name));
                    break;
                case ClickedEvent.ClickedButton.Print:
                    switch (e.Name)
                    {
                        case "Korisnici":
                            ShowTab("Korisnici ispis");
                            break;
                        case "Zaposlenici":
                            ShowTab("Zaposlenici ispis");
                            break;
                        case "Vozila":
                            ShowTab("Vozila ispis");
                            break;
                    }
                    break;
            }
        }
        
        private bool IsMenuCheckOk(string stringToCheck)
        {
            if (tabControl1.TabPages.ContainsKey(stringToCheck))
                return false;
            return true;
        }
        
    }
}
