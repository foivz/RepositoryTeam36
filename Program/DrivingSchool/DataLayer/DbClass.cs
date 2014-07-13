using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Data.Entity.Infrastructure;
using Model;

namespace DataLayer
{
    public class DbClass
    {
        static DbClass instance = null;
        public static DbClass Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new DbClass();
                }
                return instance;
            }
        }

        AutoskolaEntities context = null;
        private DbClass()
        {
            context = new AutoskolaEntities();
        }
        private void Reset()
        {
            context.Dispose();
            context = new AutoskolaEntities();
        }

        /// <summary>
        /// Provjerava u bazi odgovara li upisano korisničko ime i lozinka.
        /// </summary>
        /// <param name="userName">Korisničko ime.</param>
        /// <param name="password">Lozinka.</param>
        /// <returns>Naziv role u koju pripada korisnik s imenom userName i lozinkom password ako je kombinacija ispravna. U protivon vraća prazni string.</returns>
        public string CheckUserLogin(string userName, string password)
        {
            System.Data.Entity.Core.Objects.ObjectParameter role = new System.Data.Entity.Core.Objects.ObjectParameter("roleName", typeof(string));
            context.CheckUserLogin(userName, password, role);
            return role.Value.ToString();
        }

        /// <summary>
        /// Vraća listu korisnika.
        /// </summary>
        /// <returns>Lista korisnika.</returns>
        public List<korisnik> GetUsersList()
        {
            return context.osoba.AsNoTracking().OfType<korisnik>().ToList();
        }
        public List<zaposlenik> GetEmployeesList()
        {
            return context.osoba.AsNoTracking().OfType<zaposlenik>().ToList();
        }
        public List<vozilo> GetVehiclesList()
        {
            return context.vozilo.AsNoTracking().ToList();
        }
        public List<drzava> GetCountriesList()
        {
            return context.drzava.AsNoTracking().ToList();
        }
        public List<grad> GetTownsForCountry(int countryId)
        {
            return context.grad.AsNoTracking().Where(town => town.drzava_id.Equals(countryId)).ToList();
        }
        public List<grad> GetTownsList()
        {
            return context.grad.AsNoTracking().ToList();
        }
        public List<kategorija> GetCategoriesList()
        {
            return context.kategorija.AsNoTracking().ToList();
        }
        public List<vozilo_vrsta> GetVehicleTypesList()
        {
            return context.vozilo_vrsta.AsNoTracking().ToList();
        }
        public List<dodatna_oprema> GetGearList()
        {
            return context.dodatna_oprema.AsNoTracking().ToList();
        }
        public List<zaposlenik_vrsta> GetEmployeeTypesList()
        {
            return context.zaposlenik_vrsta.AsNoTracking().ToList();
        }
        public List<korisnik_status> GetUserStatusList()
        {
            return context.korisnik_status.AsNoTracking().ToList();
        }
        public List<aktivnost> GetActivitiesList()
        {
            return context.aktivnost.AsNoTracking().ToList();
        }
        public List<korisnik_aktivnost> GetUserActivityForUser(int userId)
        {
            return context.korisnik_aktivnost.AsNoTracking().Where(userActivity => userActivity.korisnik_id.Equals(userId)).OrderBy(userA => userA.od).ToList();
        }
        public List<v_korisnik> GetReportUsers()
        {
            return context.v_korisnik.AsNoTracking().ToList();
        }
        public List<v_zaposlenik> GetReportEmployees()
        {
            return context.v_zaposlenik.AsNoTracking().ToList();
        }
        public List<v_vozilo> GetReportVehicles()
        {
            return context.v_vozilo.AsNoTracking().ToList();
        }
        public List<vozilo_dodatna_oprema> GetGearForVehicle(int vehicleId)
        {
            return context.vozilo_dodatna_oprema.Where(vg => vg.vozilo_id.Equals(vehicleId)).ToList();
        }

        /*metode za izmjenu*/
        /// <summary>
        /// Sprema promjene korisnika u bazu.
        /// </summary>
        /// <param name="changesUsers">Lista korisnik objekata koju treba pohraniti u bazu.</param>
        /// <returns>Vrijednost true označava uspjesno spremanje.</returns>
        public bool SaveChangesForUsers(List<korisnik> changedUsers)
        {
            foreach (korisnik k in changedUsers)
            {
                korisnik curUser = null;
                try
                {
                    curUser = context.osoba.OfType<korisnik>().First(k1 => k1.osoba_id.Equals(k.osoba_id));
                }
                catch (InvalidOperationException)
                {
                    context.osoba.Add(new korisnik() { ime = k.ime, prezime = k.prezime, oib = k.oib, nadnevak_rod = k.nadnevak_rod, spol = k.spol, adresa = k.adresa, grad_id = k.grad_id, status_id = k.status_id });
                    continue;
                }
                curUser.ime = k.ime;
                curUser.prezime = k.prezime;
                curUser.oib = k.oib;
                curUser.nadnevak_rod = k.nadnevak_rod;
                curUser.spol = k.spol;
                curUser.adresa = k.adresa;
                curUser.grad_id = k.grad_id;
                curUser.status_id = k.status_id;
            }
            try
            {
                context.SaveChanges();
            }
            catch (InvalidOperationException)
            {
                return false;
            }
            return true;
        }
        public bool SaveChangesForEmployees(List<zaposlenik> changedEmployees)
        {
            foreach (zaposlenik e in changedEmployees)
            {
                zaposlenik curEmployee = null;
                try
                {
                    curEmployee = context.osoba.OfType<zaposlenik>().First(e1 => e1.osoba_id.Equals(e.osoba_id));
                }
                catch (InvalidOperationException)
                {
                    context.osoba.Add(new zaposlenik() { ime = e.ime, prezime = e.prezime, oib = e.oib, nadnevak_rod = e.nadnevak_rod, spol = e.spol, adresa = e.adresa, grad_id = e.grad_id, vrsta = e.vrsta });
                    continue;
                }
                curEmployee.ime = e.ime;
                curEmployee.prezime = e.prezime;
                curEmployee.oib = e.oib;
                curEmployee.nadnevak_rod = e.nadnevak_rod;
                curEmployee.spol = e.spol;
                curEmployee.adresa = e.adresa;
                curEmployee.grad_id = e.grad_id;
                curEmployee.vrsta = e.vrsta;
            }
            try
            {
                context.SaveChanges();
            }
            catch (InvalidOperationException)
            {
                return false;
            }
            return true;
        }
        public bool SaveChangesForVehicles(List<vozilo> changedVehicles)
        {
            foreach (vozilo v in changedVehicles)
            {
                vozilo curVehicle = null;
                try
                {
                    curVehicle = context.vozilo.First(v1 => v1.vozilo_id.Equals(v.vozilo_id));
                }
                catch (InvalidOperationException)
                {
                    context.vozilo.Add(new vozilo() { vozilo_id = v.vozilo_id, marka = v.marka, naziv = v.naziv, vrsta_id = v.vrsta_id, god_proiz = v.god_proiz, nad_prve_reg = v.nad_prve_reg, nad_reg_do = v.nad_reg_do });

                    continue;
                }
                curVehicle.vozilo_id = v.vozilo_id;
                curVehicle.marka = v.marka;
                curVehicle.naziv = v.naziv;
                curVehicle.vrsta_id = v.vrsta_id;
                curVehicle.god_proiz = v.god_proiz;
                curVehicle.nad_prve_reg = v.nad_prve_reg;
                curVehicle.nad_reg_do = v.nad_reg_do;
            }
            try
            {
                context.SaveChanges();
            }
            catch (InvalidOperationException)
            {
                return false;
            }
            return true;
        }
        public bool SaveChangesForCountries(List<drzava> changedCountries)
        {
            foreach (drzava d in changedCountries)
            {
                drzava curCountry = null;
                try
                {
                    curCountry = context.drzava.First(d1 => d1.drzava_id.Equals(d.drzava_id));
                }
                catch (InvalidOperationException)
                {
                    context.drzava.Add(new drzava() { naziv = d.naziv });

                    continue;
                }
                curCountry.naziv = d.naziv;
            }
            try
            {
                context.SaveChanges();
            }
            catch (InvalidOperationException)
            {
                return false;
            }
            return true;
        }
        public bool SaveChangesForTowns(List<grad> changedTowns)
        {
            foreach (grad g in changedTowns)
            {
                grad curTown = null;
                try
                {
                    curTown = context.grad.First(g1 => g1.grad_id.Equals(g.grad_id));
                }
                catch (InvalidOperationException)
                {
                    context.grad.Add(new grad() { naziv = g.naziv, drzava_id = g.drzava_id });
                    continue;
                }
                curTown.naziv = g.naziv;
                curTown.drzava_id = g.drzava_id;
            }
            try
            {
                context.SaveChanges();
            }
            catch (InvalidOperationException)
            {
                return false;
            }
            return true;
        }
        public bool SaveChangesForCategories(List<kategorija> changedCategories)
        {
            foreach (kategorija k in changedCategories)
            {
                kategorija curCategory = null;
                try
                {
                    curCategory = context.kategorija.First(k1 => k1.kat_id.Equals(k.kat_id));
                }
                catch (InvalidOperationException)
                {
                    context.kategorija.Add(new kategorija() { kat_id = k.kat_id, naziv = k.naziv, opis = k.opis });

                    continue;
                }
                curCategory.kat_id = k.kat_id;
                curCategory.naziv = k.naziv;
                curCategory.opis = k.opis;
            }
            try
            {
                context.SaveChanges();
            }
            catch (InvalidOperationException)
            {
                return false;
            }
            return true;
        }
        public bool SaveChangesForVehicleTypes(List<vozilo_vrsta> changedVehicleTypes)
        {
            foreach (vozilo_vrsta v in changedVehicleTypes)
            {
                vozilo_vrsta curVehicleType = null;
                try
                {
                    curVehicleType = context.vozilo_vrsta.First(v1 => v1.vrsta_id.Equals(v.vrsta_id));
                }
                catch (InvalidOperationException)
                {
                    context.vozilo_vrsta.Add(new vozilo_vrsta() { naziv = v.naziv, kat_id = v.kat_id });

                    continue;
                }
                curVehicleType.naziv = v.naziv;
                curVehicleType.kat_id = v.kat_id;
            }
            try
            {
                context.SaveChanges();
            }
            catch (InvalidOperationException)
            {
                return false;
            }
            return true;
        }
        public bool SaveChangesForGear(List<dodatna_oprema> changedGear)
        {
            foreach (dodatna_oprema gear in changedGear)
            {
                dodatna_oprema curGear = null;
                try
                {
                    curGear = context.dodatna_oprema.First(g1 => g1.oprema_id.Equals(gear.oprema_id));
                }
                catch (InvalidOperationException)
                {
                    context.dodatna_oprema.Add(new dodatna_oprema() { naziv = gear.naziv, opis = gear.opis });

                    continue;
                }
                curGear.naziv = gear.naziv;
                curGear.opis = gear.opis;
            }
            try
            {
                context.SaveChanges();
            }
            catch (InvalidOperationException)
            {
                return false;
            }
            return true;
        }
        public bool SaveChangesForEmployeeTypes(List<zaposlenik_vrsta> changedEmployees)
        {
            foreach (zaposlenik_vrsta empType in changedEmployees)
            {
                zaposlenik_vrsta curType = null;
                try
                {
                    curType = context.zaposlenik_vrsta.First(type => type.vrsta_id.Equals(empType.vrsta_id));
                }
                catch (InvalidOperationException)
                {
                    context.zaposlenik_vrsta.Add(new zaposlenik_vrsta() { naziv = empType.naziv, opis = empType.opis });

                    continue;
                }
                curType.naziv = empType.naziv;
                curType.opis = empType.opis;
            }
            try
            {
                context.SaveChanges();
            }
            catch (InvalidOperationException)
            {
                return false;
            }
            return true;
        }
        public bool SaveChangesForUserStatuses(List<korisnik_status> userStatuses)
        {
            foreach (korisnik_status status in userStatuses)
            {
                korisnik_status curStatus = null;
                try
                {
                    curStatus = context.korisnik_status.First(us => us.status_id.Equals(status.status_id));
                }
                catch (InvalidOperationException)
                {
                    context.korisnik_status.Add(new korisnik_status() { naziv = status.naziv });
                    continue;
                }
                curStatus.naziv = status.naziv;
            }
            try
            {
                context.SaveChanges();
            }
            catch (InvalidOperationException)
            {
                return false;
            }
            return true;
        }
        public bool SaveChangesForActivities(List<aktivnost> userActivities)
        {
            foreach (aktivnost activity in userActivities)
            {
                aktivnost curActivity = null;
                try
                {
                    curActivity = context.aktivnost.First(ac => ac.aktivnost_id.Equals(activity.aktivnost_id));
                }
                catch (InvalidOperationException)
                {
                    context.aktivnost.Add(new aktivnost() { naziv = activity.naziv, opis = activity.opis, trajanje_sati = activity.trajanje_sati });

                    continue;
                }
                curActivity.naziv = activity.naziv;
                curActivity.opis = activity.opis;
                curActivity.trajanje_sati = activity.trajanje_sati;
            }
            try
            {
                context.SaveChanges();
            }
            catch (InvalidOperationException)
            {
                return false;
            }
            return true;
        }
        public bool SaveUserActivities(List<korisnik_aktivnost> activitiesToDelete, List<korisnik_aktivnost> userActivities)
        {
            foreach (korisnik_aktivnost userActivity in activitiesToDelete)
            {
                context.korisnik_aktivnost.Remove(context.korisnik_aktivnost.First(ua => ua.aktivnost_id.Equals(userActivity.aktivnost_id) && ua.korisnik_id.Equals(userActivity.korisnik_id) && ua.od.Equals(userActivity.od)));
            }
            foreach (korisnik_aktivnost userActivity in userActivities)
            {
                korisnik_aktivnost curActivity = null;
                try
                {
                    curActivity = context.korisnik_aktivnost.First(ua => ua.aktivnost_id.Equals(userActivity.aktivnost_id) && ua.korisnik_id.Equals(userActivity.korisnik_id) && ua.od.Equals(userActivity.od));
                    if (activitiesToDelete.Any(ca => ca.aktivnost_id.Equals(curActivity.aktivnost_id) && ca.korisnik_id.Equals(userActivity.korisnik_id) && ca.od.Equals(userActivity.od)))
                        context.korisnik_aktivnost.Add(new korisnik_aktivnost() { korisnik_id = userActivity.korisnik_id, aktivnost_id = userActivity.aktivnost_id, od = userActivity.od, @do = userActivity.@do, polozeno = userActivity.polozeno });
                }
                catch (InvalidOperationException)
                {
                    context.korisnik_aktivnost.Add(new korisnik_aktivnost() { korisnik_id = userActivity.korisnik_id, aktivnost_id = userActivity.aktivnost_id, od = userActivity.od, @do = userActivity.@do, polozeno = userActivity.polozeno });

                    continue;
                }
                curActivity.korisnik_id = userActivity.korisnik_id;
                curActivity.aktivnost_id = userActivity.aktivnost_id;
                curActivity.od = userActivity.od;
                curActivity.@do = userActivity.@do;
                curActivity.polozeno = userActivity.polozeno;
            }
            try
            {
                context.SaveChanges();
            }
            catch (InvalidOperationException)
            {
                return false;
            }
            return true;
        }
        public bool SaveVehicleGear(int vehicleId, List<vozilo_dodatna_oprema> vehicleGearList)
        {
            foreach (vozilo_dodatna_oprema gear in vehicleGearList)
            {
                vozilo_dodatna_oprema curGear = null;
                try
                {
                    curGear = context.vozilo_dodatna_oprema.First(vg => vg.oprema_id.Equals(gear.oprema_id) && vg.vozilo_id.Equals(vehicleId));
                }
                catch (InvalidOperationException)
                {
                    context.vozilo_dodatna_oprema.Add(new vozilo_dodatna_oprema() { vozilo_id = vehicleId, oprema_id = gear.oprema_id });
                    continue;
                }
                curGear.vozilo_id = vehicleId;
                curGear.oprema_id = gear.oprema_id;
            }
            try
            {
                context.SaveChanges();
            }
            catch (InvalidOperationException e)
            {
                Reset();
                return false;
            }
            return true;
        }

        /*metode za brisanje*/
        /// <summary>
        /// Briše iz baze listu objekata osoba.
        /// </summary>
        /// <param name="personsList">Lista objekata osoba koju treba obrisati.</param>
        /// <returns>Vrijednost true označava uspješno brisanje.</returns>
        public bool DeletePersonsList(List<osoba> personsList)
        {
            foreach (osoba person in personsList)
            {
                if (person is korisnik)
                    context.osoba.Remove(context.osoba.OfType<korisnik>().First(u => u.osoba_id.Equals(person.osoba_id)));
                else if (person is zaposlenik)
                    context.osoba.Remove(context.osoba.OfType<zaposlenik>().First(e => e.osoba_id.Equals(person.osoba_id)));
            }
            try
            {
                context.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
                Reset();
                return false;
            }
            return true;
        }
        public bool DeleteVehiclesList(List<vozilo> vehiclesList)
        {
            foreach (vozilo vehicle in vehiclesList)
            {
                context.vozilo.Remove(context.vozilo.First(v1 => v1.vozilo_id.Equals(vehicle.vozilo_id)));
            }
            try
            {
                context.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
                Reset();
                return false;
            }
            return true;
        }
        public bool DeleteCountriesList(List<drzava> countriesList)
        {
            foreach (drzava country in countriesList)
            {
                context.drzava.Remove(context.drzava.First(c => c.drzava_id.Equals(country.drzava_id)));
            }
            try
            {
                context.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
                Reset();
                return false;
            }
            return true;
        }
        public bool DeleteTownsList(List<grad> townsList)
        {
            foreach (grad town in townsList)
            {
                context.grad.Remove(context.grad.First(t => t.grad_id.Equals(town.grad_id)));
            }
            try
            {
                context.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
                Reset();
                return false;
            }
            return true;
        }
        public bool DeleteCategoriesList(List<kategorija> categoriesList)
        {
            foreach (kategorija category in categoriesList)
            {
                context.kategorija.Remove(context.kategorija.First(c => c.kat_id.Equals(category.kat_id)));
            }
            try
            {
                context.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
                Reset();
                return false;
            }
            return true;
        }
        public bool DeleteVehicleTypesList(List<vozilo_vrsta> vehiclesTypesList)
        {
            foreach (vozilo_vrsta type in vehiclesTypesList)
            {
                context.vozilo_vrsta.Remove(context.vozilo_vrsta.First(t => t.vrsta_id.Equals(type.vrsta_id)));
            }
            try
            {
                context.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
                Reset();
                return false;
            }
            return true;
        }
        public bool DeleteGearList(List<dodatna_oprema> gearList)
        {
            foreach (dodatna_oprema gear in gearList)
            {
                context.dodatna_oprema.Remove(context.dodatna_oprema.First(g1 => g1.oprema_id.Equals(gear.oprema_id)));
            }
            try
            {
                context.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
                Reset();
                return false;
            }
            return true;
        }
        public bool DeleteEmployeeTypesList(List<zaposlenik_vrsta> employeeTypeList)
        {
            foreach (zaposlenik_vrsta empType in employeeTypeList)
            {
                context.zaposlenik_vrsta.Remove(context.zaposlenik_vrsta.First(type => type.vrsta_id.Equals(empType.vrsta_id)));
            }
            try
            {
                context.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
                Reset();
                return false;
            }
            return true;
        }
        public bool DeleteStatusesList(List<korisnik_status> statusesList)
        {
            foreach (korisnik_status status in statusesList)
            {
                context.korisnik_status.Remove(context.korisnik_status.First(us => us.status_id.Equals(status.status_id)));
            }
            try
            {
                context.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
                Reset();
                return false;
            }
            return true;
        }
        public bool DeleteActivitiesList(List<aktivnost> activitiesList)
        {
            foreach (aktivnost activity in activitiesList)
            {
                context.aktivnost.Remove(context.aktivnost.First(ac => ac.aktivnost_id.Equals(activity.aktivnost_id)));
            }
            try
            {
                context.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
                Reset();
                return false;
            }
            return true;
        }
        public bool DeleteUserActivitiesList(List<korisnik_aktivnost> userActivitiesList)
        {
            foreach (korisnik_aktivnost userActivity in userActivitiesList)
            {
                context.korisnik_aktivnost.Remove(context.korisnik_aktivnost.First(ua => ua.aktivnost_id.Equals(userActivity.aktivnost_id) && ua.korisnik_id.Equals(userActivity.korisnik_id) && ua.od.Equals(userActivity.od)));
            }
            try
            {
                context.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
                Reset();
                return false;
            }
            return true;
        }
        public bool DeleteVehicleGearList(int vehicleId, List<vozilo_dodatna_oprema> vehicleGear)
        {
            foreach (vozilo_dodatna_oprema gear in vehicleGear)
            {
                context.vozilo_dodatna_oprema.Remove(gear);
            }
            try
            {
                context.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
                Reset();
                return false;
            }
            return true;
        }

        /*metode za dodavanje*/
        /// <summary>
        /// Dodaje novog zaposlenika u bazu.
        /// </summary>
        /// <param name="newEmployee">Objekt tipa zaposlenik kojega treba dodati.</param>
        public void AddEmployee(zaposlenik newEmployee)
        {
            context.osoba.Add(newEmployee);
            context.SaveChanges();
        }
        /// <summary>
        /// Dodaje novog korisnika u bazu.
        /// </summary>
        /// <param name="newUser"></param>
        public void AddUser(korisnik newUser)
        {
            context.osoba.Add(newUser);
            context.SaveChanges();
        }

        /*metode za provjeru*/
        /// <summary>
        /// Provjerava je li dodjeljeni OIB već OIB neke druge osobe.
        /// </summary>
        /// <param name="person">Objekt tipa osoba za kojega treba provjeriti OIb.</param>
        /// <returns>Vrijednost false označava da OIB nije tuđi. True znači da OIB pripada drugoj osobi.</returns>
        public bool IsOibNumberFromSomeoneElse(osoba person)
        {
            if (context.osoba.Where(p => p.oib.Equals(person.oib) && !p.osoba_id.Equals(person.osoba_id)).Count() > 0)
            {
                return true;
            }
            return false;
        }
        public bool IsCountryNameTaken(drzava country)
        {
            if (context.drzava.Where(c => c.naziv.Equals(country.naziv) && !c.drzava_id.Equals(country.drzava_id)).Count() > 0)
            {
                return true;
            }
            return false;
        }
        public bool IsTownNameTakenForCountry(grad town)
        {
            if (context.grad.Where(t => t.naziv.Equals(town.naziv) && t.drzava_id.Equals(town.drzava_id)).Count() > 0)
            {
                return true;
            }
            return false;
        }
        public bool IsVehicleTypeNameTaken(vozilo_vrsta type)
        {
            if (context.vozilo_vrsta.Where(t => t.naziv.Equals(type.naziv) && !t.vrsta_id.Equals(type.vrsta_id)).Count() > 0)
            {
                return true;
            }
            return false;
        }
        public bool IsCategoryNameTaken(kategorija category)
        {
            if (context.kategorija.Where(c => c.naziv.Equals(category.naziv) && !c.kat_id.Equals(category.kat_id)).Count() > 0)
            {
                return true;
            }
            return false;
        }
        public bool IsEmployeeTypeNameTaken(zaposlenik_vrsta type)
        {
            if (context.zaposlenik_vrsta.Where(t => t.naziv.Equals(type.naziv) && !t.vrsta_id.Equals(type.vrsta_id)).Count() > 0)
            {
                return true;
            }
            return false;
        }
        public bool IsGearNameTaken(dodatna_oprema gear)
        {
            if (context.dodatna_oprema.Where(g => g.naziv.Equals(gear.naziv) && !g.oprema_id.Equals(gear.oprema_id)).Count() > 0)
            {
                return true;
            }
            return false;
        }
        public bool IsUserStatusNameTaken(korisnik_status status)
        {
            if (context.korisnik_status.Where(s => s.naziv.Equals(status.naziv)).Count() > 0)
            {
                return true;
            }
            return false;
        }
        public bool IsActivityNameTaken(aktivnost activity)
        {
            if (context.aktivnost.Where(a1 => a1.naziv.Equals(activity.naziv) && !a1.aktivnost_id.Equals(activity.aktivnost_id)).Count() > 0)
            {
                return true;
            }
            return false;
        }
        public bool IsActivityForUserAdded(korisnik_aktivnost userActivity)
        {
            if (context.korisnik_aktivnost.Where(ua => ua.korisnik_id.Equals(userActivity.korisnik_id) && ua.aktivnost_id.Equals(userActivity.aktivnost_id) && ua.od.Equals(userActivity.od)).Count() > 0)
            {
                return true;
            }
            return false;
        }
        public bool VehicleContainsGear(vozilo_dodatna_oprema vehicleGear)
        {
            if (context.vozilo_dodatna_oprema.Where(vg => vg.vozilo_id.Equals(vehicleGear.vozilo_id) && vg.oprema_id.Equals(vehicleGear.oprema_id)).Count() > 0)
            {
                return true;
            }
            return false;
        }
    }
}
