using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using DataLayer;

namespace LogicLayer
{
    public class Logic
    {
        private const int OIB_LENGTH = 11;
        DbClass dbClass = null;
        public Logic() { dbClass = DbClass.Instance; }

        /// <summary>
        /// Vraća listu korisnika.
        /// </summary>
        /// <returns></returns>
        public List<korisnik> GetUsersList()
        {
            return dbClass.GetUsersList();
        }
        public List<korisnik_status> GetUserStatusList()
        {
            return dbClass.GetUserStatusList();
        }
        public List<aktivnost> GetActivitiesList()
        {
            return dbClass.GetActivitiesList();
        }
        public List<korisnik_aktivnost> GetActivitiesForUser(int userId)
        {
            return dbClass.GetUserActivityForUser(userId);
        }
        public List<zaposlenik> GetEmployeesList()
        {
            return dbClass.GetEmployeesList();
        }
        public List<zaposlenik_vrsta> GetEmployeeTypesList()
        {
            return dbClass.GetEmployeeTypesList();
        }
        public List<drzava> GetCountriesList()
        {
            return dbClass.GetCountriesList();
        }
        public List<grad> GetTownsForCountry(int countryId)
        {
            return dbClass.GetTownsForCountry(countryId);
        }
        public List<grad> GetTownsList()
        {
            return dbClass.GetTownsList();
        }
        public List<vozilo> GetVehiclesList()
        {
            return dbClass.GetVehiclesList();
        }
        public List<vozilo_vrsta> GetVehiclesTypesList()
        {
            return dbClass.GetVehicleTypesList();
        }
        public List<kategorija> GetCategoriesList()
        {
            return dbClass.GetCategoriesList();
        }
        public List<dodatna_oprema> GetGearList()
        {
            return dbClass.GetGearList();
        }
        public List<vozilo_dodatna_oprema> GetGearForVehicle(int vehicleId)
        {
            return dbClass.GetGearForVehicle(vehicleId);
        }
        public List<v_korisnik> GetReportUsers()
        {
            return dbClass.GetReportUsers();
        }
        public List<v_zaposlenik> GetReportEmployees()
        {
            return dbClass.GetReportEmployees();
        }
        public List<v_vozilo> GetReportVehicles()
        {
            return dbClass.GetReportVehicles();
        }

        /*metode za spremanje promjena*/
        public bool SaveUsers(List<korisnik> usersList)
        {
            return dbClass.SaveChangesForUsers(usersList);
        }
        public bool SaveEmployees(List<zaposlenik> employeesList)
        {
            return dbClass.SaveChangesForEmployees(employeesList);
        }
        public bool SaveVehicles(List<vozilo> vehiclesList)
        {
            return dbClass.SaveChangesForVehicles(vehiclesList);
        }
        public bool SaveCountries(List<drzava> countriesList)
        {
            return dbClass.SaveChangesForCountries(countriesList);
        }
        public bool SaveTowns(List<grad> townsList)
        {
            return dbClass.SaveChangesForTowns(townsList);
        }
        public bool SaveVehicleTypes(List<vozilo_vrsta> vehicleTypesList)
        {
            return dbClass.SaveChangesForVehicleTypes(vehicleTypesList);
        }
        public bool SaveCategories(List<kategorija> categoriesList)
        {
            return dbClass.SaveChangesForCategories(categoriesList);
        }
        public bool SaveGear(List<dodatna_oprema> gearList)
        {
            return dbClass.SaveChangesForGear(gearList);
        }
        public bool SaveEmployeeTypes(List<zaposlenik_vrsta> employeeTypesList)
        {
            return dbClass.SaveChangesForEmployeeTypes(employeeTypesList);
        }
        public bool SaveUserActivities(List<korisnik_aktivnost> activitiesToDelete, List<korisnik_aktivnost> userActivitiesList)
        {
            return dbClass.SaveUserActivities(activitiesToDelete, userActivitiesList);
        }
        public bool SaveUserStatus(List<korisnik_status> userStatusesList)
        {
            return dbClass.SaveChangesForUserStatuses(userStatusesList);
        }
        public bool SaveActivities(List<aktivnost> activitiesList)
        {
            return dbClass.SaveChangesForActivities(activitiesList);
        }
        public bool SaveVehicleGear(int vehicleId, List<vozilo_dodatna_oprema> gear)
        {
            return dbClass.SaveVehicleGear(vehicleId, gear);
        }

        /*metode za brisanje*/
        /// <summary>
        /// Omogućava brisanje liste osoba
        /// </summary>
        /// <param name="personsList">Lista osoba koju treba obrisati</param>
        /// <returns>True uspjelo brisanje, false nije uspjelo brisanje</returns>
        public bool DeletePersonsList(List<osoba> personsList)
        {
            return dbClass.DeletePersonsList(personsList);
        }
        public bool DeleteVehiclesList(List<vozilo> vehiclesList)
        {
            return dbClass.DeleteVehiclesList(vehiclesList);
        }
        public bool DeleteCountriesList(List<drzava> countriesList)
        {
            //ako postoje gradovi za neku državu ne dozvoljava brisanje, potrebno je prvo obrisati gradove
            if (countriesList.Where(c => dbClass.GetTownsForCountry(c.drzava_id).Count > 0).FirstOrDefault() != null)
                return false;
            return dbClass.DeleteCountriesList(countriesList);
        }
        public bool DeleteTownsList(List<grad> townsList)
        {
            return dbClass.DeleteTownsList(townsList);
        }
        public bool DeleteVehicleTypesList(List<vozilo_vrsta> vehiclesTypesList)
        {
            return dbClass.DeleteVehicleTypesList(vehiclesTypesList);
        }
        public bool DeleteCategoriesList(List<kategorija> categoriesList)
        {
            return dbClass.DeleteCategoriesList(categoriesList);
        }
        public bool DeleteGearList(List<dodatna_oprema> gearList)
        {
            return dbClass.DeleteGearList(gearList);
        }
        public bool DeleteEmployeeTypesList(List<zaposlenik_vrsta> employeeTypesList)
        {
            return dbClass.DeleteEmployeeTypesList(employeeTypesList);
        }
        public bool DeleteStatusesList(List<korisnik_status> statusesList)
        {
            return dbClass.DeleteStatusesList(statusesList);
        }
        public bool DeleteActivitiesList(List<aktivnost> activitiesList)
        {
            return dbClass.DeleteActivitiesList(activitiesList);
        }
        public bool DeleteUserActivitiesList(List<korisnik_aktivnost> userActivitiesList)
        {
            return dbClass.DeleteUserActivitiesList(userActivitiesList);
        }
        public bool DeleteGearListForVehicle(int vehicleId, List<vozilo_dodatna_oprema> vehicleGearList)
        {
            return dbClass.DeleteVehicleGearList(vehicleId, vehicleGearList);
        }

        /*metode za unos novih*/
        /// <summary>
        /// Dodaje novog zaposlenika.
        /// </summary>
        /// <param name="employee"></param>
        /// <returns></returns>
        public bool AddEmployee(zaposlenik employee)
        {
            dbClass.AddEmployee(employee);
            return true;
        }
        /// <summary>
        /// Dodaje novog korisnika.
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public bool AddUser(korisnik user)
        {
            dbClass.AddUser(user);
            return true;
        }

        /*metode za provjeru unosa*/
        public List<string> CheckPersonInsert<T>(T person) where T : osoba
        {
            List<string> retInfo = new List<string>();
            if (person.ime == null || person.ime.Equals(String.Empty))
                retInfo.Add("ime");
            if (person.prezime == null || person.prezime.Equals(String.Empty))
                retInfo.Add("prezime");
            if (person.oib == null || dbClass.IsOibNumberFromSomeoneElse(person) || person.oib.Length != OIB_LENGTH)
                retInfo.Add("oib");
            if (person.nadnevak_rod.Equals(null) || person.nadnevak_rod.Year == 1)
                retInfo.Add("nadnevak rodenja");
            if (person.spol == null)
                retInfo.Add("spol");
            if (person.adresa == null || person.adresa.Equals(String.Empty))
                retInfo.Add("adresa");
            if (person.grad_id == 0)
                retInfo.Add("grad");
            korisnik user = person as korisnik;
            if (user != null)
            {
                if (user.status_id == 0)
                    retInfo.Add("status");
            }
            else
            {
                zaposlenik employee = person as zaposlenik;
                if (employee.vrsta == 0)
                    retInfo.Add("vrsta");
            }
            return retInfo;
        }
        public KeyValuePair<int, List<string>> CheckPersonsUpdate<T>(List<T> personsList) where T : osoba
        {
            List<string> retInfo = new List<string>();
            foreach (osoba person in personsList)
            {
                if (person.ime == null || person.ime.Equals(String.Empty))
                    retInfo.Add("ime");
                if (person.prezime == null || person.prezime.Equals(String.Empty))
                    retInfo.Add("prezime");
                if (person.oib == null || dbClass.IsOibNumberFromSomeoneElse(person) || person.oib.Length != OIB_LENGTH)
                    retInfo.Add("oib");
                if (person.nadnevak_rod.Equals(null) || person.nadnevak_rod.Year == 1)
                    retInfo.Add("nadnevak rodenja");
                if (person.spol == null)
                    retInfo.Add("spol");
                if (person.adresa == null || person.adresa.Equals(String.Empty))
                    retInfo.Add("adresa");
                if (person.grad_id == 0)
                    retInfo.Add("grad");
                korisnik user = person as korisnik;
                if (user != null)
                {
                    if (user.status_id == 0)
                        retInfo.Add("status");
                }
                else
                {
                    zaposlenik employee = person as zaposlenik;
                    if (employee.vrsta == 0)
                        retInfo.Add("vrsta");
                }
                if (retInfo.Count > 0)
                    return new KeyValuePair<int, List<string>>(personsList.IndexOf((T)person), retInfo);
            }
            //služi za provjeru oib-a ako prilikom unosa više osoba postoji poklapanje na koloni oib
            string item = (from p in personsList
                           group p by p.oib into pGroup
                           where pGroup.Count() > 1
                           select pGroup.Key).FirstOrDefault<string>();
            if (item != null)
            {
                int index = personsList.LastIndexOf(personsList.Where(p => p.oib.Equals(item)).Last());
                retInfo.Add("zauzeti OIB");
                return new KeyValuePair<int, List<string>>(index, retInfo);
            }
            return new KeyValuePair<int, List<string>>();
        }
        public KeyValuePair<int, List<string>> CheckVehiclesUpdate(List<vozilo> vehiclesList)
        {
            List<string> retInfo = new List<string>();
            foreach (vozilo v in vehiclesList)
            {
                if (v.marka == null || v.marka.Equals(String.Empty))
                    retInfo.Add("marka");
                if (v.naziv == null || v.naziv.Equals(String.Empty))
                    retInfo.Add("naziv");
                if (v.vrsta_id == 0)
                    retInfo.Add("vrsta");
                if (v.god_proiz == 0)
                    retInfo.Add("godina proizvodnje");
                if (v.nad_prve_reg.Equals(null) || v.nad_prve_reg.Year == 1)
                    retInfo.Add("nadnevak prve registracije");
                if (v.nad_reg_do.Equals(null) || v.nad_reg_do.Year == 1)
                    retInfo.Add("nadnevak isteka registracije");
                if (retInfo.Count > 0)
                    return new KeyValuePair<int, List<string>>(vehiclesList.IndexOf(v), retInfo);
            }
            return new KeyValuePair<int, List<string>>();
        }
        public KeyValuePair<int, List<string>> CheckCountriesUpdate(List<drzava> countriesList)
        {
            List<string> retInfo = new List<string>();
            foreach (drzava country in countriesList)
            {
                if (country.naziv == null || country.naziv.Equals(string.Empty) || dbClass.IsCountryNameTaken(country))
                    retInfo.Add("naziv");
                if (retInfo.Count > 0)
                    return new KeyValuePair<int, List<string>>(countriesList.IndexOf(country), retInfo);
            }
            string item = (from u in countriesList
                           group u by u.naziv into uGroup
                           where uGroup.Count() > 1
                           select uGroup.Key).FirstOrDefault<string>();
            if (item != null)
            {
                int index = countriesList.LastIndexOf(countriesList.Where(u => u.naziv.Equals(item)).Last());
                retInfo.Add("zauzeti naziv");
                return new KeyValuePair<int, List<string>>(index, retInfo);
            }
            return new KeyValuePair<int, List<string>>();
        }
        public KeyValuePair<int, List<string>> CheckTownsUpdate(List<grad> townsList)
        {
            List<string> retInfo = new List<string>();
            foreach (grad town in townsList)
            {
                if (town.naziv == null || town.naziv.Equals(string.Empty) || dbClass.IsTownNameTakenForCountry(town))
                    retInfo.Add("naziv");
                if (retInfo.Count > 0)
                    return new KeyValuePair<int, List<string>>(townsList.IndexOf(town), retInfo);
            }
            string item = (from u in townsList
                           group u by new { u.naziv, u.drzava_id } into uGroup
                           where uGroup.Count() > 1
                           select uGroup.Key.naziv).FirstOrDefault<string>();
            if (item != null)
            {
                int index = townsList.LastIndexOf(townsList.Where(u => u.naziv.Equals(item)).Last());
                retInfo.Add("zauzeti naziv");
                return new KeyValuePair<int, List<string>>(index, retInfo);
            }
            return new KeyValuePair<int, List<string>>();
        }
        public KeyValuePair<int, List<string>> CheckVehicleTypesUpdate(List<vozilo_vrsta> vehicleTypesList)
        {
            List<string> retInfo = new List<string>();
            foreach (vozilo_vrsta type in vehicleTypesList)
            {
                if (type.naziv == null || type.naziv.Equals(string.Empty) || dbClass.IsVehicleTypeNameTaken(type))
                    retInfo.Add("naziv");
                if (type.kat_id == 0)
                    retInfo.Add("kategorija");
                if (retInfo.Count > 0)
                    return new KeyValuePair<int, List<string>>(vehicleTypesList.IndexOf(type), retInfo);
            }
            string item = (from u in vehicleTypesList
                           group u by u.naziv into uGroup
                           where uGroup.Count() > 1
                           select uGroup.Key).FirstOrDefault<string>();
            if (item != null)
            {
                int index = vehicleTypesList.LastIndexOf(vehicleTypesList.Where(u => u.naziv.Equals(item)).Last());
                retInfo.Add("zauzeti naziv");
                return new KeyValuePair<int, List<string>>(index, retInfo);
            }
            return new KeyValuePair<int, List<string>>();
        }
        public KeyValuePair<int, List<string>> CheckCategoriesUpdate(List<kategorija> categoriesList)
        {
            List<string> retInfo = new List<string>();
            foreach (kategorija category in categoriesList)
            {
                if (category.naziv == null || category.naziv.Equals(string.Empty) || dbClass.IsCategoryNameTaken(category))
                    retInfo.Add("naziv");
                if (retInfo.Count > 0)
                    return new KeyValuePair<int, List<string>>(categoriesList.IndexOf(category), retInfo);
            }
            string item = (from c in categoriesList
                           group c by c.naziv into cGroup
                           where cGroup.Count() > 1
                           select cGroup.Key).FirstOrDefault<string>();
            if (item != null)
            {
                int index = categoriesList.LastIndexOf(categoriesList.Where(c => c.naziv.Equals(item)).Last());
                retInfo.Add("zauzeti naziv");
                return new KeyValuePair<int, List<string>>(index, retInfo);
            }
            return new KeyValuePair<int, List<string>>();
        }
        public KeyValuePair<int, List<string>> CheckGearUpdate(List<dodatna_oprema> gearList)
        {
            List<string> retInfo = new List<string>();
            foreach (dodatna_oprema gear in gearList)
            {
                if (gear.naziv == null || gear.naziv.Equals(string.Empty) || dbClass.IsGearNameTaken(gear))
                    retInfo.Add("naziv");
                if (retInfo.Count > 0)
                    return new KeyValuePair<int, List<string>>(gearList.IndexOf(gear), retInfo);
            }
            string item = (from g in gearList
                           group g by g.naziv into gGroup
                           where gGroup.Count() > 1
                           select gGroup.Key).FirstOrDefault<string>();
            if (item != null)
            {
                int index = gearList.LastIndexOf(gearList.Where(g => g.naziv.Equals(item)).Last());
                retInfo.Add("zauzeti naziv");
                return new KeyValuePair<int, List<string>>(index, retInfo);
            }
            return new KeyValuePair<int, List<string>>();
        }
        public KeyValuePair<int, List<string>> CheckEmployeeTypesUpdate(List<zaposlenik_vrsta> employeeTypesList)
        {
            List<string> retInfo = new List<string>();
            foreach (zaposlenik_vrsta type in employeeTypesList)
            {
                if (type.naziv == null || type.naziv.Equals(string.Empty) || dbClass.IsEmployeeTypeNameTaken(type))
                    retInfo.Add("naziv");
                if (retInfo.Count > 0)
                    return new KeyValuePair<int, List<string>>(employeeTypesList.IndexOf(type), retInfo);
            }
            string item = (from t in employeeTypesList
                           group t by t.naziv into tGroup
                           where tGroup.Count() > 1
                           select tGroup.Key).FirstOrDefault<string>();
            if (item != null)
            {
                int index = employeeTypesList.LastIndexOf(employeeTypesList.Where(t => t.naziv.Equals(item)).Last());
                retInfo.Add("zauzeti naziv");
                return new KeyValuePair<int, List<string>>(index, retInfo);
            }
            return new KeyValuePair<int, List<string>>();
        }
        public KeyValuePair<int, List<string>> CheckUserStatusesUpdate(List<korisnik_status> userStatussesList)
        {
            List<string> retInfo = new List<string>();
            foreach (korisnik_status status in userStatussesList)
            {
                if (status.naziv == null || status.naziv.Equals(string.Empty) || dbClass.IsUserStatusNameTaken(status))
                    retInfo.Add("naziv");
                if (retInfo.Count > 0)
                    return new KeyValuePair<int, List<string>>(userStatussesList.IndexOf(status), retInfo);
            }
            string item = (from s in userStatussesList
                           group s by s.naziv into sGroup
                           where sGroup.Count() > 1
                           select sGroup.Key).FirstOrDefault<string>();
            if (item != null)
            {
                int index = userStatussesList.LastIndexOf(userStatussesList.Where(s => s.naziv.Equals(item)).Last());
                retInfo.Add("zauzeti naziv");
                return new KeyValuePair<int, List<string>>(index, retInfo);
            }
            return new KeyValuePair<int, List<string>>();
        }
        public KeyValuePair<int, List<string>> CheckActivitiesUpdate(List<aktivnost> activitiesList)
        {
            List<string> retInfo = new List<string>();
            foreach (aktivnost activity in activitiesList)
            {
                if (activity.naziv == null || activity.naziv.Equals(string.Empty) || dbClass.IsActivityNameTaken(activity))
                    retInfo.Add("naziv");
                if (activity.trajanje_sati == 0)
                    retInfo.Add("trajanje sati");
                if (retInfo.Count > 0)
                    return new KeyValuePair<int, List<string>>(activitiesList.IndexOf(activity), retInfo);
            }
            string item = (from a in activitiesList
                           group a by a.naziv into aGroup
                           where aGroup.Count() > 1
                           select aGroup.Key).FirstOrDefault<string>();
            if (item != null)
            {
                int index = activitiesList.LastIndexOf(activitiesList.Where(a => a.naziv.Equals(item)).Last());
                retInfo.Add("zauzeti naziv");
                return new KeyValuePair<int, List<string>>(index, retInfo);
            }
            return new KeyValuePair<int, List<string>>();
        }
        public KeyValuePair<int, List<string>> CheckActivitiesForUserUpdate(List<korisnik_aktivnost> activitiesToDelete, List<korisnik_aktivnost> changedActivities)
        {
            List<string> retInfo = new List<string>();
            foreach (korisnik_aktivnost ua in changedActivities)
            {
                if (ua.aktivnost_id.Equals(0))
                    retInfo.Add("aktivnost");
                if (ua.od.Equals(null) || ua.od.Year.Equals(1))
                    retInfo.Add("od");
                if (dbClass.IsActivityForUserAdded(ua) && !activitiesToDelete.Any(ca => ca.aktivnost_id.Equals(ua.aktivnost_id) && ca.korisnik_id.Equals(ua.korisnik_id) && ca.od.Equals(ua.od)))
                    retInfo.Add("aktivnost-od");
                if (retInfo.Count > 0)
                    return new KeyValuePair<int, List<string>>(changedActivities.IndexOf(ua), retInfo);
            }
            var item = (from a in changedActivities
                        group a by new { a.korisnik_id, a.aktivnost_id, a.od } into aGroup
                        where aGroup.Count() > 1
                        select aGroup.Key).FirstOrDefault();
            if (item != null)
            {
                int index = changedActivities.LastIndexOf(changedActivities.Where(a => a.od.Equals(item.od)).Last());
                retInfo.Add("aktivnost-od");
                return new KeyValuePair<int, List<string>>(index, retInfo);
            }
            return new KeyValuePair<int, List<string>>();
        }
        public KeyValuePair<int, List<string>> CheckVehicleGearUpdate(List<vozilo_dodatna_oprema> vehicleGearList)
        {
            List<string> retInfo = new List<string>();
            foreach (vozilo_dodatna_oprema vg in vehicleGearList)
            {
                if (vg.oprema_id.Equals(0) || dbClass.VehicleContainsGear(vg))
                    retInfo.Add("oprema");
                if (retInfo.Count > 0)
                    return new KeyValuePair<int, List<string>>(vehicleGearList.IndexOf(vg), retInfo);
            }
            var item = (from g in vehicleGearList
                        group g by new { g.vozilo_id, g.oprema_id } into gGroup
                        where gGroup.Count() > 1
                        select gGroup.Key).FirstOrDefault();
            if (item != null)
            {
                int index = vehicleGearList.LastIndexOf(vehicleGearList.Where(g => g.oprema_id.Equals(item.oprema_id)).Last());
                retInfo.Add("oprema");
                return new KeyValuePair<int, List<string>>(index, retInfo);
            }
            return new KeyValuePair<int, List<string>>();
        }

    }
}
