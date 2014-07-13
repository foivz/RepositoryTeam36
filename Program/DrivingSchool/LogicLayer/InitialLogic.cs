using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer;

namespace LogicLayer
{
    public static class InitialLogic
    {
        //static string userName;
        //static string password;
        static DbClass dbClass = DbClass.Instance;
        //public static string GetPass() { return password; }
        /*public static void PerformLogin()
        {
            string role = "";
            bool bOk = false;
            Login login = new Login();
            while (true)
            {
                if (login.ShowDialog().Equals(DialogResult.OK))
                {
                    //userName = login.UserName;
                    //password = login.Password;
                    //provjera unosa
                    role = dbClass.CheckUserLogin(login.UserName, login.Password);
                    if (!role.Equals(String.Empty))
                    {
                        //MessageBox.Show(role);
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
                    break;
                }
            }
            if (bOk)
            {
                switch (role)
                {
                    case "biguser":
                        Application.Run(new FormMain(login.UserName,true));
                        break;
                    case "smalluser":
                        Application.Run(new FormMain(login.UserName, false));
                        break;
                }
            }
        }*/
        public static string CheckLogin(string userName, string pass)
        {
            return dbClass.CheckUserLogin(userName, pass);
        }
    }
}
