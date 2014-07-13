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
        AutoskolaEntities context = null;

        /// <summary>
        /// Vrača instancu klase
        /// </summary>
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

        #region Metode za dohvat podataka

        /// <summary>
        /// Vraća listu korisnika.
        /// </summary>
        /// <returns>Lista korisnika.</returns>
        public List<korisnik> GetUsersList()
        {
            return context.osoba.AsNoTracking().OfType<korisnik>().ToList();
        }

        /// <summary>
        /// Vraća listu zaposlenika.
        /// </summary>
        /// <returns></returns>
        public List<zaposlenik> GetEmployeesList()
        {
            return context.osoba.AsNoTracking().OfType<zaposlenik>().ToList();
        }

        /// <summary>
        /// Vraća listu vozila.
        /// </summary>
        /// <returns></returns>
        public List<vozilo> GetVehiclesList()
        {
            return context.vozilo.AsNoTracking().ToList();
        }

        /// <summary>
        /// Vraća listu drzava.
        /// </summary>
        /// <returns></returns>
        public List<drzava> GetCountriesList()
        {
            return context.drzava.AsNoTracking().ToList();
        }

        /// <summary>
        /// Vraća listu gradova određene države.
        /// </summary>
        /// <param name="countryId">Id države za koju treba vratiti gradove.</param>
        /// <returns></returns>
        public List<grad> GetTownsForCountry(int countryId)
        {
            return context.grad.AsNoTracking().Where(town => town.drzava_id.Equals(countryId)).ToList();
        }

        /// <summary>
        /// Vraća listu gradova.
        /// </summary>
        /// <returns></returns>
        public List<grad> GetTownsList()
        {
            return context.grad.AsNoTracking().ToList();
        }

        /// <summary>
        /// Vraća listu kategorija.
        /// </summary>
        /// <returns></returns>
        public List<kategorija> GetCategoriesList()
        {
            return context.kategorija.AsNoTracking().ToList();
        }

        /// <summary>
        /// Vraća listu vrsta vozila.
        /// </summary>
        /// <returns></returns>
        public List<vozilo_vrsta> GetVehicleTypesList()
        {
            return context.vozilo_vrsta.AsNoTracking().ToList();
        }

        /// <summary>
        /// Vraća listu dodatne opreme.
        /// </summary>
        /// <returns></returns>
        public List<dodatna_oprema> GetGearList()
        {
            return context.dodatna_oprema.AsNoTracking().ToList();
        }

        /// <summary>
        /// Vraća listu vrsta zaposlenika.
        /// </summary>
        /// <returns></returns>
        public List<zaposlenik_vrsta> GetEmployeeTypesList()
        {
            return context.zaposlenik_vrsta.AsNoTracking().ToList();
        }

        /// <summary>
        /// Vraća listu mogućih statusa korisnika.
        /// </summary>
        /// <returns></returns>
        public List<korisnik_status> GetUserStatusList()
        {
            return context.korisnik_status.AsNoTracking().ToList();
        }

        /// <summary>
        /// Vraća listu mogućih aktivnosti.
        /// </summary>
        /// <returns></returns>
        public List<aktivnost> GetActivitiesList()
        {
            return context.aktivnost.AsNoTracking().ToList();
        }

        /// <summary>
        /// Vraća listu aktivnosti za određenog korisnika.
        /// </summary>
        /// <param name="userId">Id korisnika za kojega treba vratiti aktivnosti.</param>
        /// <returns></returns>
        public List<korisnik_aktivnost> GetUserActivityForUser(int userId)
        {
            return context.korisnik_aktivnost.AsNoTracking().Where(userActivity => userActivity.korisnik_id.Equals(userId)).OrderBy(userA => userA.od).ToList();
        }

        /// <summary>
        /// Vraća listu dodatne opreme za određeno vozilo.
        /// </summary>
        /// <param name="vehicleId">Id vozila za koje treba vratiti dodatnu opremu.</param>
        /// <returns></returns>
        public List<vozilo_dodatna_oprema> GetGearForVehicle(int vehicleId)
        {
            return context.vozilo_dodatna_oprema.Where(vg => vg.vozilo_id.Equals(vehicleId)).ToList();
        }

        /// <summary>
        /// Vraća listu korisnika koja služi za prikazivanje u izvješću.
        /// </summary>
        /// <returns></returns>
        public List<v_korisnik> GetReportUsers()
        {
            return context.v_korisnik.AsNoTracking().ToList();
        }

        /// <summary>
        /// Vraća listu zaposlenika koja služi za prikazivanje u izvješću.
        /// </summary>
        /// <returns></returns>
        public List<v_zaposlenik> GetReportEmployees()
        {
            return context.v_zaposlenik.AsNoTracking().ToList();
        }

        /// <summary>
        /// Vraća listu vozila koja služi za prikazivanje u izvješću.
        /// </summary>
        /// <returns></returns>
        public List<v_vozilo> GetReportVehicles()
        {
            return context.v_vozilo.AsNoTracking().ToList();
        }

        #endregion

        #region Metode za izmjenu podataka

        /// <summary>
        /// Sprema promjene podataka o korisnicima u bazu.
        /// </summary>
        /// <param name="changesUsers">Lista korisnik objekata koju treba pohraniti u bazu.</param>
        /// <returns>Vrijednost true označava uspješno spremanje.</returns>
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

        /// <summary>
        /// Sprema promjene podataka o zaposlenicima u bazu.
        /// </summary>
        /// <param name="changedEmployees">Lista zaposlenik objekata koju treba pohraniti u bazu.</param>
        /// <returns>Vrijednost true označava uspješno spremanje.</returns>
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

        /// <summary>
        /// Sprema promjene podataka o vozilima u bazu.
        /// </summary>
        /// <param name="changedEmployees">Lista vozilo objekata koju treba pohraniti u bazu.</param>
        /// <returns>Vrijednost true označava uspješno spremanje.</returns>
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

        /// <summary>
        /// Sprema promjene podataka o državama u bazu.
        /// </summary>
        /// <param name="changedEmployees">Lista drzava objekata koju treba pohraniti u bazu.</param>
        /// <returns>Vrijednost true označava uspješno spremanje.</returns>
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

        /// <summary>
        /// Sprema promjene podataka o gradovima u bazu.
        /// </summary>
        /// <param name="changedEmployees">Lista grad objekata koju treba pohraniti u bazu.</param>
        /// <returns>Vrijednost true označava uspješno spremanje.</returns>
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

        /// <summary>
        /// Sprema promjene podataka o kategorijama u bazu.
        /// </summary>
        /// <param name="changedEmployees">Lista kategorija objekata koju treba pohraniti u bazu.</param>
        /// <returns>Vrijednost true označava uspješno spremanje.</returns>
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

        /// <summary>
        /// Sprema promjene podataka o vrstama vozila u bazu.
        /// </summary>
        /// <param name="changedEmployees">Lista vozilo_vrsta objekata koju treba pohraniti u bazu.</param>
        /// <returns>Vrijednost true označava uspješno spremanje.</returns>
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

        /// <summary>
        /// Sprema promjene podataka o dodatnoj opremi u bazu.
        /// </summary>
        /// <param name="changedEmployees">Lista dodatna_oprema objekata koju treba pohraniti u bazu.</param>
        /// <returns>Vrijednost true označava uspješno spremanje.</returns>
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

        /// <summary>
        /// Sprema promjene podataka o vrstama zaposlenika u bazu.
        /// </summary>
        /// <param name="changedEmployees">Lista zaposlenik_vrsta objekata koju treba pohraniti u bazu.</param>
        /// <returns>Vrijednost true označava uspješno spremanje.</returns>
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

        /// <summary>
        /// Sprema promjene podataka o statusima korisnika u bazu.
        /// </summary>
        /// <param name="changedEmployees">Lista korisnik_status objekata koju treba pohraniti u bazu.</param>
        /// <returns>Vrijednost true označava uspješno spremanje.</returns>
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

        /// <summary>
        /// Sprema promjene podataka o aktivnostima u bazu.
        /// </summary>
        /// <param name="changedEmployees">Lista aktivnost objekata koju treba pohraniti u bazu.</param>
        /// <returns>Vrijednost true označava uspješno spremanje.</returns>
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

        /// <summary>
        /// Sprema promjene podataka o aktivnostima korisnika u bazu.
        /// </summary>
        /// <param name="activitiesToDelete">Lista korisnik_aktivnost objekata koje treba obrisati iz baze.</param>
        /// <param name="userActivities">Lista korisnik_aktivnost objekata koju treba pohraniti u bazu.</param>
        /// <returns>Vrijednost true označava uspješno spremanje.</returns>
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

        /// <summary>
        /// Sprema promjene podataka o dodatnoj opremi za određeno vozilo.
        /// </summary>
        /// <param name="vehicleId">Id vozila za koje treba spremiti podatke.</param>
        /// <param name="vehicleGearList">Lista vozilo_dodatna_oprema objekata koju treba pohraniti u bazu.</param>
        /// <returns>Vrijednost true označava uspješno spremanje.</returns>
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

        #endregion

        #region Metode za brisanje

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

        /// <summary>
        /// Briše iz baze listu objekata vozilo.
        /// </summary>
        /// <param name="personsList">Lista objekata vozilo koju treba obrisati.</param>
        /// <returns>Vrijednost true označava uspješno brisanje.</returns>
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

        /// <summary>
        /// Briše iz baze listu objekata drzava.
        /// </summary>
        /// <param name="personsList">Lista drzava osoba koju treba obrisati.</param>
        /// <returns>Vrijednost true označava uspješno brisanje.</returns>
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

        /// <summary>
        /// Briše iz baze listu objekata grad.
        /// </summary>
        /// <param name="personsList">Lista grad osoba koju treba obrisati.</param>
        /// <returns>Vrijednost true označava uspješno brisanje.</returns>
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

        /// <summary>
        /// Briše iz baze listu objekata kategorija.
        /// </summary>
        /// <param name="personsList">Lista kategorija osoba koju treba obrisati.</param>
        /// <returns>Vrijednost true označava uspješno brisanje.</returns>
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

        /// <summary>
        /// Briše iz baze listu objekata vozilo_vrsta.
        /// </summary>
        /// <param name="personsList">Lista objekata vozilo_vrsta koju treba obrisati.</param>
        /// <returns>Vrijednost true označava uspješno brisanje.</returns>
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

        /// <summary>
        /// Briše iz baze listu objekata dodatna_oprema.
        /// </summary>
        /// <param name="personsList">Lista objekata dodatna_oprema koju treba obrisati.</param>
        /// <returns>Vrijednost true označava uspješno brisanje.</returns>
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

        /// <summary>
        /// Briše iz baze listu objekata zaposlenik_vrsta.
        /// </summary>
        /// <param name="personsList">Lista objekata zaposlenik_vrsta koju treba obrisati.</param>
        /// <returns>Vrijednost true označava uspješno brisanje.</returns>
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

        /// <summary>
        /// Briše iz baze listu objekata korisnik_status.
        /// </summary>
        /// <param name="personsList">Lista objekata korisnik_status koju treba obrisati.</param>
        /// <returns>Vrijednost true označava uspješno brisanje.</returns>
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

        /// <summary>
        /// Briše iz baze listu objekata aktivnost.
        /// </summary>
        /// <param name="personsList">Lista objekata aktivnost koju treba obrisati.</param>
        /// <returns>Vrijednost true označava uspješno brisanje.</returns>
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

        /// <summary>
        /// Briše iz baze listu objekata korisnik_aktivnost.
        /// </summary>
        /// <param name="personsList">Lista objekata korisnik_aktivnost koju treba obrisati.</param>
        /// <returns>Vrijednost true označava uspješno brisanje.</returns>
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

        /// <summary>
        /// Briše iz baze listu objekata vozilo_dodatna_oprema
        /// </summary>
        /// <param name="vehicleGear">Lista objekata vozilo_dodatna_oprema koju treba obrisati.</param>
        /// <returns>Vrijednost true označava uspješno brisanje.</returns>
        public bool DeleteVehicleGearList(List<vozilo_dodatna_oprema> vehicleGear)
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

        #endregion

        #region Metode za dodavanje

        /// <summary>
        /// Dodaje novog zaposlenika u bazu.
        /// </summary>
        /// <param name="newEmployee">Objekt tipa zaposlenik kojega treba dodati u bazu.</param>
        public void AddEmployee(zaposlenik newEmployee)
        {
            context.osoba.Add(newEmployee);
            context.SaveChanges();
        }

        /// <summary>
        /// Dodaje novog korisnika u bazu.
        /// </summary>
        /// <param name="newUser">Objekt tipa korisnik kojega treba dodati u bazu.</param>
        public void AddUser(korisnik newUser)
        {
            context.osoba.Add(newUser);
            context.SaveChanges();
        }

        #endregion

        #region Metode za provjeru

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

        /// <summary>
        /// Provjerava postoji li određeni naziv države u bazi.
        /// </summary>
        /// <param name="country">Objekt tipa drzava čije ime treba provjeriti.</param>
        /// <returns>Vrijednost true označava postojanje naziva države.</returns>
        public bool IsCountryNameTaken(drzava country)
        {
            if (context.drzava.Where(c => c.naziv.Equals(country.naziv) && !c.drzava_id.Equals(country.drzava_id)).Count() > 0)
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// Provjerava postoji li grad s određenim imenom za državu u bazi.
        /// </summary>
        /// <param name="town">Objekt tipa grad čije ime treba provjeriti.</param>
        /// <returns>Vrijednost true označava postojanje naziva grada za određenu državu.</returns>
        public bool IsTownNameTakenForCountry(grad town)
        {
            if (context.grad.Where(t => t.naziv.Equals(town.naziv) && t.drzava_id.Equals(town.drzava_id)).Count() > 0)
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// Provjerava postoji li naziv vrste vozila u bazi.
        /// </summary>
        /// <param name="type">Objekt tipa vozilo_vrsta čiji naziv treba provjeriti.</param>
        /// <returns>Vrijednost true označava postojanje naziva.</returns>
        public bool IsVehicleTypeNameTaken(vozilo_vrsta type)
        {
            if (context.vozilo_vrsta.Where(t => t.naziv.Equals(type.naziv) && !t.vrsta_id.Equals(type.vrsta_id)).Count() > 0)
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// Provjerava postoji li naziv kategorije u bazi.
        /// </summary>
        /// <param name="category">Objekt tipa kategorija čiji naziv treba provjeriti.</param>
        /// <returns>Vrijednost true označava postojanje naziva.</returns>
        public bool IsCategoryNameTaken(kategorija category)
        {
            if (context.kategorija.Where(c => c.naziv.Equals(category.naziv) && !c.kat_id.Equals(category.kat_id)).Count() > 0)
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// Provjerava postoji li naziv za vrstu zaposlenika u bazi.
        /// </summary>
        /// <param name="type">Objekt tipa zaposlenik_vrsta čiji naziv treba provjeriti.</param>
        /// <returns>Vrijednost true označava postojanje naziva.</returns>
        public bool IsEmployeeTypeNameTaken(zaposlenik_vrsta type)
        {
            if (context.zaposlenik_vrsta.Where(t => t.naziv.Equals(type.naziv) && !t.vrsta_id.Equals(type.vrsta_id)).Count() > 0)
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// Provjerava postoji li naziv za dodatnu opremu u bazi.
        /// </summary>
        /// <param name="type">Objekt tipa dodatna_oprema čiji naziv treba provjeriti.</param>
        /// <returns>Vrijednost true označava postojanje naziva.</returns>
        public bool IsGearNameTaken(dodatna_oprema gear)
        {
            if (context.dodatna_oprema.Where(g => g.naziv.Equals(gear.naziv) && !g.oprema_id.Equals(gear.oprema_id)).Count() > 0)
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// Provjerava postoji li naziv za staus korisnika u bazi.
        /// </summary>
        /// <param name="type">Objekt tipa zaposlenik_status čiji naziv treba provjeriti.</param>
        /// <returns>Vrijednost true označava postojanje naziva.</returns>
        public bool IsUserStatusNameTaken(korisnik_status status)
        {
            if (context.korisnik_status.Where(s => s.naziv.Equals(status.naziv)).Count() > 0)
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// Provjerava postoji li naziv za aktivnost u bazi.
        /// </summary>
        /// <param name="type">Objekt tipa aktivnost čiji naziv treba provjeriti.</param>
        /// <returns>Vrijednost true označava postojanje naziva.</returns>
        public bool IsActivityNameTaken(aktivnost activity)
        {
            if (context.aktivnost.Where(a1 => a1.naziv.Equals(activity.naziv) && !a1.aktivnost_id.Equals(activity.aktivnost_id)).Count() > 0)
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// Provjerava postoji li aktivnost za određenog korisnika u bazi.
        /// </summary>
        /// <param name="type">Objekt tipa korisnik_aktivnost kojega treba provjeriti.</param>
        /// <returns>Ako za određenog korisnika postoji određena aktivnost i ako je vrijednost polja od jednaka vraća true, inaće false.</returns>
        public bool IsActivityForUserAdded(korisnik_aktivnost userActivity)
        {
            if (context.korisnik_aktivnost.Where(ua => ua.korisnik_id.Equals(userActivity.korisnik_id) && ua.aktivnost_id.Equals(userActivity.aktivnost_id) && ua.od.Equals(userActivity.od)).Count() > 0)
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// Provjerava postoji li dodatna oprema za određeno vozilo u bazi.
        /// </summary>
        /// <param name="type">Objekt tipa vozilo_dodatna_oprema kojega treba provjeriti.</param>
        /// <returns>Vrijednost true označava postojanje opreme za određeno vozilo.</returns>
        public bool VehicleContainsGear(vozilo_dodatna_oprema vehicleGear)
        {
            if (context.vozilo_dodatna_oprema.Where(vg => vg.vozilo_id.Equals(vehicleGear.vozilo_id) && vg.oprema_id.Equals(vehicleGear.oprema_id)).Count() > 0)
            {
                return true;
            }
            return false;
        }

        #endregion

    }
}
