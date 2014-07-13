using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using LogicLayer;

namespace DrivingSchool
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new MainForm());
            //InitialLogic.PerformLogin();
            Begin();
        }

        static void Begin()
        {
            string role = "";
            bool bOk = false;
            Login login = new Login();
            while (true)
            {
                if (login.ShowDialog().Equals(DialogResult.OK))
                {
                    role = InitialLogic.CheckLogin(login.UserName, login.Password);
                    if (!role.Equals(String.Empty))
                    {
                        bOk = true;
                        break;
                    }
                    else
                    {
                        MessageBox.Show("Pogrešni unos");
                    }
                }
                else
                {
                    return;
                }
            }
            if (bOk)
            {
                switch (role)
                {
                    case "biguser":
                        Application.Run(new MainForm(login.UserName, true));
                        break;
                    case "smalluser":
                        Application.Run(new MainForm(login.UserName, false));
                        break;
                }
            }
        }
    }
}
