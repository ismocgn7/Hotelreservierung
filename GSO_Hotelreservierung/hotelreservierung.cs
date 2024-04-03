using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GSO_Hotelreservierung.Model;
using GSO_Hotelreservierung.Daten;

namespace GSO_Hotelreservierung
{
    internal class hotelreservierung
    {
        private HotelreservierungContext dbContext = new HotelreservierungContext();

        public void AppStart()
        {
            Console.Clear();
            Console.WriteLine("Willkommen zur Hotelreservierung!\n");
            Console.WriteLine("1. Kunden");
            Console.WriteLine("2. Reservierung");
            Console.WriteLine("3. Zimmerkategorie");
            Console.Write("\nBitte wählen Sie eine Option: ");
            int option = Convert.ToInt32(Console.ReadLine());
            switch (option)
            {
                case 1:
                    Kunden();
                    break;
                case 2:
                    Reservierung();
                    break;
                case 3:
                    Zimmerkategorie();
                    break;
                default:
                    Console.WriteLine("Ungültige Option!");
                    break;
            }
        }

        public void Kunden()
        {
            Console.Clear();
            Console.WriteLine("Kunden Menü\n");
            Console.WriteLine("1. Erstellen");
            Console.WriteLine("2. Bearbeiten");
            Console.WriteLine("3. Anzeigen");
            Console.WriteLine("4. Hauptmenü");
            Console.Write("\nBitte wählen Sie eine Option: ");
            int option = Convert.ToInt32(Console.ReadLine());
            switch (option)
            {
                case 1:
                    KundenErstellen();
                    break;
                case 2:
                    KundenBearbeiten();
                    break;
                case 3:
                    KundenAnzeigen();
                    break;
                case 4:
                    AppStart();
                    break;
                default:
                    Console.WriteLine("Ungültige Option!");
                    break;
            }
        }

        public async void KundenErstellen()
        {
            Console.Write("Vorname: ");
            string vorname = Console.ReadLine();
            Console.Write("Nachname: ");
            string nachname = Console.ReadLine();
            Console.Write("Telefonnummer: ");
            string telefonnummer = Console.ReadLine();
            Console.Write("Adresse: ");
            string adresse = Console.ReadLine();
            Console.Write("Email: ");
            string email = Console.ReadLine();

            Kunde neuerKunde = new Kunde
            {
                Vorname = vorname,
                Nachname = nachname,
                Telefonnummer = telefonnummer,
                Adresse = adresse,
                Email = email
            };
            dbContext.Kunden.Add(neuerKunde);
            await dbContext.SaveChangesAsync();
            AppStart();
        }

        public async Task KundenBearbeiten()
        {
            Console.Clear();
            Console.WriteLine("Kunden Bearbeiten\n");
            Console.Write("Bitte geben Sie die ID des Kunden ein, den Sie bearbeiten möchten: ");
            int kundenId;
            if (!int.TryParse(Console.ReadLine(), out kundenId))
            {
                Console.WriteLine("Ungültige Eingabe für die Kunden-ID.");
                Console.ReadKey();
                KundenBearbeiten();
                return;
            }

            var kunde = await dbContext.Kunden.FindAsync(kundenId);
            if (kunde == null)
            {
                Console.WriteLine("Kunde nicht gefunden.");
                Console.ReadKey();
                KundenBearbeiten();
                return;
            }

            Console.WriteLine($"1. Vorname");
            Console.WriteLine($"2. Nachname");
            Console.WriteLine($"3. Telefonnummer");
            Console.WriteLine($"4. Adresse");
            Console.WriteLine($"5. Email");
            Console.Write("\nBitte wählen Sie eine Option: ");
            int option = Convert.ToInt32(Console.ReadLine());
            switch (option)
            {
                case 1:
                    Console.Write("Vorname: ");
                    kunde.Vorname = Console.ReadLine();
                    break;
                case 2:
                    Console.Write("Nachname: ");
                    kunde.Nachname = Console.ReadLine();
                    break;
                case 3:
                    Console.Write("Telefonnummer: ");
                    kunde.Telefonnummer = Console.ReadLine();
                    break;
                case 4:
                    Console.Write("Adresse: ");
                    kunde.Adresse = Console.ReadLine();
                    break;
                case 5:
                    Console.Write("Email: ");
                    kunde.Email = Console.ReadLine();
                    break;
                default:
                    Console.WriteLine("Ungültige Option!");
                    break;
            }

            await dbContext.SaveChangesAsync();

            Console.WriteLine("Kunde erfolgreich bearbeitet.");
            Console.ReadKey();
            Kunden();
        }

        public void KundenAnzeigen()
        {
            var kunden = dbContext.Kunden.ToList();

            foreach (var kunde in kunden)
            {
                Console.WriteLine($"Vorname: {kunde.Vorname}");
                Console.WriteLine($"Nachname: {kunde.Nachname}");
                Console.WriteLine($"Telefonnummer: {kunde.Telefonnummer}");
                Console.WriteLine($"Adresse: {kunde.Adresse}");
                Console.WriteLine($"Email: {kunde.Email}");
                Console.ReadKey();
            }

            AppStart();
        }

        public void Reservierung()
        {
            Console.Clear();
            Console.WriteLine("Reservierung Menü\n");
            Console.WriteLine("1. Erstellen");
            Console.WriteLine("2. Bearbeiten");
            Console.WriteLine("3. Anzeigen");
            Console.WriteLine("4. Hauptmenü");
            Console.Write("\nBitte wählen Sie eine Option: ");
            int option = Convert.ToInt32(Console.ReadLine());
            switch (option)
            {
                case 1:
                    ReservierungErstellen();
                    break;
                case 2:
                    ReservierungBearbeiten();
                    break;
                case 3:
                    ReservierungAnzeigen();
                    break;
                case 4:
                    AppStart();
                    break;
                default:
                    Console.WriteLine("Ungültige Option!");
                    break;
            }
        }

        public async void ReservierungErstellen()
        {
            Console.Write("Zimmer Nummer: ");
            int zimmer = Convert.ToInt32(Console.ReadLine());
            Console.Write("Kunden ID: ");
            int kundenId;
            if (!int.TryParse(Console.ReadLine(), out kundenId))
            {
                Console.WriteLine("Ungültige Eingabe für die Kunden-ID.");
                Console.ReadKey();
                ReservierungErstellen();
                return;
            }

            var kunde = await dbContext.Kunden.FindAsync(kundenId);
            if (kunde == null)
            {
                Console.WriteLine("Kunde nicht gefunden.");
                Console.ReadKey();
                ReservierungErstellen();
                return;
            }

            Console.Write("Check In Datum: ");
            string chechkindatum = Console.ReadLine();
            Console.Write("Check Out Datum: ");
            string chechkoutdatum = Console.ReadLine();

            Reservierung neueReservierung = new Reservierung
            {
                Zimmer = zimmer,
                Kunde = kundenId,
                chechkInDatum = chechkindatum,
                checkOutDatum = chechkoutdatum
            };
            dbContext.Reservierungen.Add(neueReservierung);
            await dbContext.SaveChangesAsync();
            AppStart();
        }

        public async Task ReservierungBearbeiten()
        {
            Console.Clear();
            Console.WriteLine("Reservierung Bearbeiten\n");
            Console.Write("Bitte geben Sie die ID der Reservirung ein, den Sie bearbeiten möchten: ");
            int reservierungId;
            if (!int.TryParse(Console.ReadLine(), out reservierungId))
            {
                Console.WriteLine("Ungültige Eingabe für die Reservierungs-ID.");
                Console.ReadKey();
                ReservierungBearbeiten();
                return;
            }

            var reservierung = await dbContext.Reservierungen.FindAsync(reservierungId);
            if (reservierung == null)
            {
                Console.WriteLine("Reservierung nicht gefunden.");
                Console.ReadKey();
                ReservierungBearbeiten();
                return;
            }

            Console.WriteLine($"1. Zimmer Nummer");
            Console.WriteLine($"2. Kunden ID");
            Console.WriteLine($"3. Check In Datum");
            Console.WriteLine($"4. Check out Datum");
            Console.Write("\nBitte wählen Sie eine Option: ");
            int option = Convert.ToInt32(Console.ReadLine());
            switch (option)
            {
                case 1:
                    Console.Write("Zimmer Nr: ");
                    reservierung.Zimmer = Convert.ToInt32(Console.ReadLine());
                    break;
                case 2:
                    Console.Write("Kunden ID: ");
                    reservierung.Kunde = Convert.ToInt32(Console.ReadLine());
                    break;
                case 3:
                    Console.Write("Check In Datum: ");
                    reservierung.chechkInDatum = Console.ReadLine();
                    break;
                case 4:
                    Console.Write("Check Out Datum: ");
                    reservierung.checkOutDatum = Console.ReadLine();
                    break;
                default:
                    Console.WriteLine("Ungültige Option!");
                    break;
            }

            await dbContext.SaveChangesAsync();

            Console.WriteLine("Reservierung erfolgreich bearbeitet.");
            Console.ReadKey();
            Reservierung();
        }

        public void ReservierungAnzeigen()
        {
            var reservierungen = dbContext.Reservierungen.ToList();

            foreach (var reservierung in reservierungen)
            {
                Console.WriteLine($"Zimmer Nr: {reservierung.Zimmer}");
                Console.WriteLine($"Kunden ID: {reservierung.Kunde}");
                Console.WriteLine($"Check In Datum: {reservierung.chechkInDatum}");
                Console.WriteLine($"Check Out Datum: {reservierung.checkOutDatum}");
                Console.ReadKey();  
            }

            AppStart();
        }

        public void Zimmerkategorie()
        {
            Console.Clear();
            Console.WriteLine("Zimmerkategorie Menü\n");
            Console.WriteLine("1. Erstellen");
            Console.WriteLine("2. Bearbeiten");
            Console.WriteLine("3. Anzeigen");
            Console.WriteLine("4. Hauptmenü");
            Console.Write("\nBitte wählen Sie eine Option: ");
            int option = Convert.ToInt32(Console.ReadLine());
            switch (option)
            {
                case 1:
                    ZimmerkategorieErstellen();
                    break;
                case 2:
                    ZimmerkategorieBearbeiten();
                    break;
                case 3:
                    ZimmerkategorieAnzeigen();
                    break;
                case 4:
                    AppStart();
                    break;
                default:
                    Console.WriteLine("Ungültige Option!");
                    break;
            }
        }

        public async void ZimmerkategorieErstellen()
        {
            Console.Write("Kategorie: ");
            string kategorie = Console.ReadLine();
            Console.Write("Preis: ");
            decimal preis = Convert.ToDecimal(Console.ReadLine());
            Console.Write("Beschreibung: ");
            string beschreibung = Console.ReadLine();

            ZimmerKategorie neueZimmerKategorie = new ZimmerKategorie
            {
                Kategorie = kategorie,
                Preis = preis,
                Beschreibung = beschreibung,
            };
            dbContext.ZimmerKategorien.Add(neueZimmerKategorie);
            await dbContext.SaveChangesAsync();
            AppStart();
        }

        public async Task ZimmerkategorieBearbeiten()
        {
            Console.Clear();
            Console.WriteLine("Zimmerkategorie Bearbeiten\n");
            Console.Write("Bitte geben Sie die ID der Zimmerkategorie ein, den Sie bearbeiten möchten: ");
            int zimmerkategorieId;
            if (!int.TryParse(Console.ReadLine(), out zimmerkategorieId))
            {
                Console.WriteLine("Ungültige Eingabe für die Zimmerkategorie-ID.");
                Console.ReadKey();
                ZimmerkategorieBearbeiten();
                return;
            }

            var zimmerkategorie = await dbContext.ZimmerKategorien.FindAsync(zimmerkategorieId);
            if (zimmerkategorie == null)
            {
                Console.WriteLine("Zimmerkategorie nicht gefunden.");
                Console.ReadKey();
                ZimmerkategorieBearbeiten();
                return;
            }

            Console.WriteLine($"1. Kategorie");
            Console.WriteLine($"2. Preis");
            Console.WriteLine($"3. Beschreibung");
            Console.Write("\nBitte wählen Sie eine Option: ");
            int option = Convert.ToInt32(Console.ReadLine());
            switch (option)
            {
                case 1:
                    Console.Write("Zimmer Nr: ");
                    zimmerkategorie.Kategorie = Console.ReadLine();
                    break;
                case 2:
                    Console.Write("Kunden ID: ");
                    zimmerkategorie.Preis = Convert.ToDecimal(Console.ReadLine());
                    break;
                case 3:
                    Console.Write("Check In Datum: ");
                    zimmerkategorie.Beschreibung = Console.ReadLine();
                    break;
                    break;
                default:
                    Console.WriteLine("Ungültige Option!");
                    break;
            }

            await dbContext.SaveChangesAsync();

            Console.WriteLine("Zimmerkategorie erfolgreich bearbeitet.");
            Console.ReadKey();
            Zimmerkategorie();
        }

        public void ZimmerkategorieAnzeigen()
        {
            var zimmerkategorien = dbContext.ZimmerKategorien.ToList();

            foreach (var zimmerkategorie in zimmerkategorien)
            {
                Console.WriteLine($"Kategorie: {zimmerkategorie.Kategorie}");
                Console.WriteLine($"Preis: {zimmerkategorie.Preis}");
                Console.WriteLine($"Beschreibung: {zimmerkategorie.Beschreibung}");
                Console.ReadKey();
            }

            AppStart();
        }
    }
}
