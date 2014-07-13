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
        static DbClass dbClass = DbClass.Instance;

        /// <summary>
        /// Služi za provjeru korisničkog imena i lozinke.
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="pass"></param>
        /// <returns>Vraća naziv role u koju pripada korisnik ako su korisničko ime i lozinka odgovarajući.</returns>
        public static string CheckLogin(string userName, string pass)
        {
            return dbClass.CheckUserLogin(userName, pass);
        }
    }
}
