using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace ePress_Ksiazki
{
    [Serializable]
    [XmlInclude(typeof(Ksiazka))]
    [XmlInclude(typeof(Album))]
    [XmlInclude(typeof(Romans))]
    [XmlInclude(typeof(Sensacyjna))]
    [XmlInclude(typeof(Kryminał))]
    public class Ksiazka
    {
        public string Tytul;
        public Autor autor;
        public int rok_wydania;
        public double ile_stron;
        public float cena;

        public Autor Autor
        {
            get
            {
                return autor;
            }
        }
        public string tytul
        {
            get
            {
                return tytul;
            }
        }
        public Ksiazka()
        {
            Tytul = null;
            autor = null;
            rok_wydania = 0;
            ile_stron = 0;
            cena = 0;
        }
        public Ksiazka(string tytul, Autor autor, int rok_wydania, double ile_stron, float cena)
        {
            this.Tytul = tytul;
            this.autor = autor;
            this.rok_wydania = rok_wydania;
            this.ile_stron = ile_stron;
            this.cena = cena;
        }
        public override string ToString()
        {
            return "Tytul : " + Tytul + " Autor: " + autor + " Rok wydania: " + rok_wydania + " Ilosc stron: " + ile_stron + " Cena: " + cena;
        }

        List<Ksiazka> ksiazkalista = new List<Ksiazka>();

        public void Dodaj(Ksiazka ksiazka)
        {
            ksiazkalista.Add(ksiazka);
        }
        public void Usun(Ksiazka ksiazka)
        {
            ksiazkalista.Remove(ksiazka);
        }
        public void Usun_konkretna(int a)
        {
            ksiazkalista.RemoveAt(a);
        }
        public void Wypisz()
        {
            ksiazkalista.ForEach(x => Console.WriteLine(x));
        }
        public int Ilosc()
        {
            Console.WriteLine(ksiazkalista.Count());
            int liczba;
            liczba = ksiazkalista.Count();
            return liczba;
        }
        public void Wypisz<T>()
        {
            ksiazkalista.Where(x => x is T).ToList().ForEach(x => Console.WriteLine(x));
        }
        public Ksiazka Wyszukaj(string tytul, string nazwisko)
        {
            return ksiazkalista.Find(x => x.Autor.nazwisko.Equals(nazwisko) && x.Tytul.Equals(tytul));
        }
        public Ksiazka Wyszukaj_po_autorze(string nazwisko)
        {
            return ksiazkalista.Find(x => x.Autor.nazwisko.Equals(nazwisko));
        }
        public Ksiazka Wyszukaj_po_tytule(string tytul)
        {
            return ksiazkalista.Find(x => x.Tytul.Equals(tytul));
        }
        public void Zapisz()
        {
            var serializacja = new XmlSerializer(ksiazkalista.GetType());
            using (var zapis = XmlWriter.Create("ksiazki.xml", new XmlWriterSettings
            {
                Indent = true,
                IndentChars = "\t",
                NewLineOnAttributes = false,
                OmitXmlDeclaration = true
            }))
            {
                serializacja.Serialize(zapis, ksiazkalista);
            }
        }
        public void Odczytaj()
        {
            var serializacja = new XmlSerializer(ksiazkalista.GetType());
            try
            {
                using (var czytanie = XmlReader.Create("ksiazki.xml"))
                {
                    ksiazkalista = (List<Ksiazka>) serializacja.Deserialize(czytanie);
                }
                Console.WriteLine("Wczytywanie udane");
            }
            catch(FileNotFoundException)
            {
                Console.WriteLine("Nie ma takiego pliku ksiazki.xml");
            }
        }
    }
    public class Romans : Ksiazka
    {
        public Romans() : base()
        {

        }
        public Romans(string tytul, Autor autor, int rokwydania, double ilestron, float cena) : base(tytul, autor, rokwydania, ilestron, cena)
        {

        }
        public override string ToString()
        {
            return "Romans: " + base.ToString();
        }
    }
    public class Sensacyjna : Ksiazka
    {
        public Sensacyjna() : base()
        {

        }
        public Sensacyjna(string tytul, Autor autor, int rokwydania, double ilestron, float cena) : base(tytul, autor, rokwydania, ilestron, cena)
        {

        }
        public override string ToString()
        {
            return "Sensacyjna: " + base.ToString();
        }
    }
    public class Kryminał : Ksiazka
    {
        public Kryminał() : base()
        {

        }
        public Kryminał(string tytul, Autor autor, int rokwydania, double ilestron, float cena) : base(tytul, autor, rokwydania, ilestron, cena)
        {

        }
        public override string ToString()
        {
            return "Kryminał: " + base.ToString();
        }
    }
    public class Album : Ksiazka
    {
        public Album() : base()
        {

        }
        public Album(string tytul, Autor autor, int rokwydania, double ilestron, float cena) : base(tytul, autor, rokwydania, ilestron, cena)
        {

        }
        public override string ToString()
        {
            return "Album: " + base.ToString();
        }
    }

    [Serializable]
    [XmlInclude(typeof(Czasopismo))]
    [XmlInclude(typeof(Miesiecznik))]
    [XmlInclude(typeof(Tygodnik))]
    public class Czasopismo
    {
        public string Tytul;
        public int numer_egzemplarza;
        public double ile_stron;
        public float cena;
        public Czasopismo()
        {
            Tytul = null;
            numer_egzemplarza = 0;
            ile_stron = 0;
            cena = 0;
        }
        public Czasopismo(string tytul, int numer_egz, double ile_stron, float cena)
        {
            this.Tytul = tytul;
            this.numer_egzemplarza = numer_egz;
            this.ile_stron = ile_stron;
            this.cena = cena;
        }
        public override string ToString()
        {
            return "Tytul: " + Tytul + " Numer egzemplarza: " + numer_egzemplarza + " Ilosc stron: " + ile_stron + " Cena: " + cena;
        }

        List<Czasopismo> czasopisma = new List<Czasopismo>();
        public void Dodaj(Czasopismo czasopismo)
        {
            czasopisma.Add(czasopismo);
        }
        public void Usun(Czasopismo czasopismo)
        {
            czasopisma.Remove(czasopismo);
        }
        public void Wypisz()
        {
            czasopisma.ForEach(x => Console.WriteLine(x));
        }
        public void Wypisz<T>()
        {
            czasopisma.Where(x => x is T).ToList().ForEach(x => Console.WriteLine(x));
        }
        public Czasopismo Wyszukaj<T>(string tytul, int numeregz)
        {
            return czasopisma.Find(x => x is T && x.Tytul.Equals(tytul) && x.numer_egzemplarza == numeregz);
        }
        public void Zapisz()
        {
            var serializacja = new XmlSerializer(czasopisma.GetType());
            using (var zapis = XmlWriter.Create("czasopisma.xml", new XmlWriterSettings
            {
                Indent = true,
                IndentChars = "\t",
                NewLineOnAttributes = false,
                OmitXmlDeclaration = true
            }))
            {
                serializacja.Serialize(zapis, czasopisma);
            }
        }
        public void Odczytaj()
        {
            var serializacja = new XmlSerializer(czasopisma.GetType());
            try
            {
                using (var czytanie = XmlReader.Create("czasopisma.xml"))
                {
                    czasopisma = (List<Czasopismo>)serializacja.Deserialize(czytanie);
                }
                Console.WriteLine("Pomyślnie wczytano plik czasopisma.xml");
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("Nie ma pliku czasopisma.xml");
            }
        }
    }
    public class Tygodnik : Czasopismo
    {
        public Tygodnik()
        {

        }
        public Tygodnik(string tytul, int numer, double ilestron, float cena) : base(tytul, numer, ilestron, cena)
        {

        }
        public override string ToString()
        {
            return "Tygodnik: " + base.ToString();
        }
    }
    public class Miesiecznik : Czasopismo
    {
        public Miesiecznik()
        {

        }
        public Miesiecznik(string tytul, int numer, double ilestron, float cena) : base(tytul, numer, ilestron, cena)
        {

        }
        public override string ToString()
        {
            return "Miesiecznik: " + base.ToString();
        }
    }
    public class Autor
    {
        public string imie;
        public string nazwisko;

        public Autor()
        {

        }
        public Autor(string imie, string nazwisko)
        {
            this.imie = imie;
            this.nazwisko = nazwisko;
        }
        public override string ToString()
        {
            return imie + " " + nazwisko;
        }

        List<Autor> listaautorzy = new List<Autor>();
        public void Dodaj(Autor autor)
        {
            listaautorzy.Add(autor);
        }
        public void Usun(Autor autor)
        {
            listaautorzy.Remove(autor);
        }
        public void Wypisz()
        {
            listaautorzy.ForEach(x => Console.WriteLine(x));
        }
        public Autor Wyszukaj(string nazwisko)
        {
            return listaautorzy.Find(x => x.nazwisko.Equals(nazwisko));
        }
        public void Zapisz()
        {
            var serializacja = new XmlSerializer(listaautorzy.GetType());
            using (var writer = XmlWriter.Create("autorzy.xml", new XmlWriterSettings
            {
                Indent = true,
                IndentChars = "\t",
                NewLineOnAttributes = false,
                OmitXmlDeclaration = true
            }))
            {
                serializacja.Serialize(writer, listaautorzy);
            }
        }
        public void Odczytaj()
        {
            var serializacja = new XmlSerializer(listaautorzy.GetType());
            try
            {
                using (var czytanie = XmlReader.Create("autorzy.xml"))
                {
                    listaautorzy = (List<Autor>)serializacja.Deserialize(czytanie);
                }
                Console.WriteLine("Pomyślnie wczytano plik autorzy.xml");
            }
            catch (System.IO.FileNotFoundException)
            {
                Console.WriteLine("Nie ma pliku autorzy.xml");
            }
        }
    }

    [Serializable]
    [XmlInclude(typeof(Umowa))]
    [XmlInclude(typeof(Umowa_o_dzielo))]
    [XmlInclude(typeof(Umowa_o_prace))]
    public class Umowa
    {
        protected float wyplata;
        protected Autor autor;
        protected int ile_miesiecy;
        public Autor Autor
        {
            get { return autor; }
        }
        public Umowa()
        {
            autor = null;
            wyplata = 0;
            ile_miesiecy = 0;
        }
        public Umowa(Autor autor, int ile_miesiecy, float wyplata)
        {
            this.autor = autor;
            this.ile_miesiecy = ile_miesiecy;
            this.wyplata = wyplata;
        }
        List<Umowa> umowy = new List<Umowa>();
        public void Dodaj(Umowa umowa)
        {
            umowy.Add(umowa);
        }
        public void Usun(Umowa umowa)
        {
            umowy.Remove(umowa);
        }
        public void Wypisz()
        {
            umowy.ForEach(x => Console.WriteLine(x));
        }
        public void Wypisz<T>()
        {
            umowy.Where(x => x is T).ToList().ForEach(x => Console.WriteLine(x));
        }
        public Umowa Wyszukaj(string imie, string nazwisko)
        {
            return umowy.Find(x => x.Autor.imie.Equals(imie) && x.Autor.nazwisko.Equals(nazwisko));
        }
        public void Zapisz()
        {
            var serializer = new XmlSerializer(umowy.GetType());
            using (var zapis = XmlWriter.Create("umowy.xml", new XmlWriterSettings
            {
                Indent = true,
                IndentChars = "\t",
                NewLineOnAttributes = false,
                OmitXmlDeclaration = true
            }))
            {
                serializer.Serialize(zapis, umowy);
            }
        }
        public void Odczytaj()
        {
            var serializacja = new XmlSerializer(umowy.GetType());
            try
            {
                using (var czytanie = XmlReader.Create("umowy.xml"))
                {
                    umowy = (List<Umowa>)serializacja.Deserialize(czytanie);
                }
                Console.WriteLine("Pomyślnie wczytano plik umowy.xml");
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("Nie ma pliku umowy.xml");
            }
        }
    }
    public class Umowa_o_prace : Umowa
    {
        public Umowa_o_prace() : base()
        {

        }
        public Umowa_o_prace(Autor autor, int ilemiesiecy, float wyplata) : base(autor, ilemiesiecy, wyplata)
        {

        }
    }
    public class Umowa_o_dzielo : Umowa
    {
        public Umowa_o_dzielo() : base()
        {

        }
        public Umowa_o_dzielo(Autor autor, int ilemiesiecy, float wyplata) : base(autor, ilemiesiecy, wyplata)
        {

        }
    }
    class Dział_Handlowy
    {
        public static void ilosc()
        {
            Console.Write("Ilosc pozycji w magazynie wyznosi: ");
            Kontroler.ksiazki.Ilosc();
            int liczba;
            liczba = Kontroler.ksiazki.Ilosc();
            if(liczba==0)
            {
                Console.WriteLine("Polki sklepowe so puste.");
                Console.ReadKey();
            }
            Console.ReadKey();
        }
        public static void dokonanie_zakupu()
        {
            int x;
            x = Kontroler.ksiazki.Ilosc();
            if (x == 0)
            {
                Console.WriteLine("Przeciez nic nie ma, co chcesz kupowac?");
                Console.ReadKey();
            }
            else
            {
                Console.WriteLine("Jaka pozycje chcesz nabyc:");
                Kontroler.ksiazki.Wypisz();
                Console.WriteLine("Podaj indeks interesujacej cie pozycji:(licz od dolu)");
                int liczba;
                liczba = int.Parse(Console.ReadLine());
                Kontroler.ksiazki.Usun_konkretna(liczba);
                Console.WriteLine("Zakup dokonany!");
                Console.WriteLine("Ksiazka jest juz w drodze.");
                Console.WriteLine("Liczba ksiazek na stanie:");
                Kontroler.ksiazki.Ilosc();
                Console.ReadKey();
            }
        }
        public static void Katalog()
        {
            Console.WriteLine("Oto pozycje ktore obecnie posiadamy:");
            Kontroler.ksiazki.Wypisz();
            Console.ReadKey();
        }
    }
    class Dział_Druku
    {
        string nazwa_drukarni;
        bool czyMozeDrukowacAlbum;
        public void Drukuj(Ksiazka ksiazka)
        {

        }
        public static void usterka()
        {
            Console.WriteLine("Drukarnia nie czynna. Za wszelkie utrudnienia przepraszamy.");
            Console.ReadKey();
        }
    }
    public class Dzial_Programowy
    {
        public Ksiazka do_druk_ksiazka;
        public void Wybierz_Drukarnie()
        {

        }
    }
    class Glowne_opcje_dodawania
    {
        public static Autor Dodaj_Autora()
        {
            string imie;
            string nazwisko;
            Console.Clear();
            Console.WriteLine("Podaj imie autora: ");
            imie = Console.ReadLine();
            Console.WriteLine("Podaj nazwisko autora: ");
            nazwisko = Console.ReadLine();

            Autor autor = new Autor(imie, nazwisko);
            Kontroler.autorzy.Dodaj(autor);
            return autor;
        }
        public static void Dodaj_Ksiazke()
        {
            Console.Clear();
            Console.WriteLine("Jaki typ ksiazki chcesz dodac?");
            Console.WriteLine("1-Album");
            Console.WriteLine("2-Romans");
            Console.WriteLine("3-Sensacyjna");
            Console.WriteLine("4-Kryminal");

            int a;
            a = int.Parse(Console.ReadLine());
            if (a > 4 || a < 1)
            {
                return;
            }
            else
            {
                int b;
                string tytul;
                int rok_wydania;
                double ile_stron;
                float cena;
                Autor autor = new Autor();

                Console.Clear();
                Console.WriteLine("Podaj tytul ksiazki: ");
                tytul = Console.ReadLine();
                Console.WriteLine("Podaj rok wydania ksiazki: ");
                rok_wydania = int.Parse(Console.ReadLine());
                Console.WriteLine("Podaj ilosc stron ksiazki: ");
                ile_stron = double.Parse(Console.ReadLine());
                Console.WriteLine("Podaj cene ksiazki: ");
                cena = float.Parse(Console.ReadLine());

                Console.WriteLine("Dodajesz nowego autora czy wybrać jednego z istniejacych?");
                Console.WriteLine("1-Wybrac z istniejacych.");
                Console.WriteLine("2-Dodac nowego autora.");
                string nazwisko;
                b = int.Parse(Console.ReadLine());
                if(b == 1)
                {
                    Kontroler.autorzy.Wypisz();
                    Console.WriteLine("Podaj nazisko autora:");
                    nazwisko = Console.ReadLine();
                    autor = Kontroler.autorzy.Wyszukaj(nazwisko);
                }
                if(b == 2)
                {
                    autor = Glowne_opcje_dodawania.Dodaj_Autora();
                }
                switch(a)
                {
                    case 1:
                        Album album = new Album(tytul,autor,rok_wydania,ile_stron,cena);
                        Kontroler.ksiazki.Dodaj(album);
                        break;
                    case 2:
                        Romans romans = new Romans(tytul, autor, rok_wydania, ile_stron, cena);
                        Kontroler.ksiazki.Dodaj(romans);
                        break;
                    case 3:
                        Sensacyjna sensacyjna = new Sensacyjna(tytul, autor, rok_wydania, ile_stron, cena);
                        Kontroler.ksiazki.Dodaj(sensacyjna);
                        break;
                    case 4:
                        Kryminał kryminał = new Kryminał(tytul, autor, rok_wydania, ile_stron, cena);
                        Kontroler.ksiazki.Dodaj(kryminał);
                        break;

                }
            }
        }
        public static void Dodaj_Czasopismo()
        {
            Console.Clear();
            string tytul;
            int numer_egzemplarza;
            double ilestron;
            float cena;
            Console.WriteLine("Jakiego typu czasopismo chcesz dodac?");
            Console.WriteLine("1-Miesiecznik");
            Console.WriteLine("2-Tygodnik");
            int wybor;
            wybor = int.Parse(Console.ReadLine());
            Console.WriteLine("Podaj tytul czasopisma: ");
            tytul = Console.ReadLine();
            Console.WriteLine("Podaj numer czasopisma: ");
            numer_egzemplarza = int.Parse(Console.ReadLine());
            Console.WriteLine("Podaj ilosc stron czasopisma: ");
            ilestron = double.Parse(Console.ReadLine());
            Console.WriteLine("Podaj cene czasopisma: ");
            cena = float.Parse(Console.ReadLine());

            switch(wybor)
            {
                case 1:
                    Miesiecznik miesiecznik = new Miesiecznik(tytul, numer_egzemplarza, ilestron, cena);
                    Kontroler.czasopisma.Dodaj(miesiecznik);
                    break;
                case 2:
                    Tygodnik tygodnik = new Tygodnik(tytul, numer_egzemplarza, ilestron, cena);
                    Kontroler.czasopisma.Dodaj(tygodnik);
                    break;
            }
        }
        public static void Dodaj_umowe()
        {
            Console.Clear();
            int ile_miesiecy;
            float wyplata;
            Autor autor = null;
            Console.WriteLine("Jak chcesz wybrac autora?");
            Console.WriteLine("1-Dodac nowego autora.");
            Console.WriteLine("2-Wybrac z istniejacych.");
            int wybor;
            string nazwisko;
            wybor = int.Parse(Console.ReadLine());
            switch(wybor)
            {
                case 1:
                    autor = Glowne_opcje_dodawania.Dodaj_Autora();
                    break;
                case 2:
                    Kontroler.autorzy.Wypisz();
                    Console.WriteLine("Podaj nazwisko autora.");
                    nazwisko = Console.ReadLine();
                    autor = Kontroler.autorzy.Wyszukaj(nazwisko);
                    break;
            }
            Console.WriteLine("Podaj wyplate zawarta w umowie:");
            wyplata = float.Parse(Console.ReadLine());
            Console.WriteLine("Podaj na ile miesiecy jest warta umowa:");
            ile_miesiecy = int.Parse(Console.ReadLine());
            Console.WriteLine("Jaka to ma byc umowa?");
            Console.WriteLine("1-Umowa o dzielo");
            Console.WriteLine("2-Umowa o prace");
            int wybor2;
            wybor2 = int.Parse(Console.ReadLine());

            switch (wybor2)
            {
                case 1:
                    Umowa_o_dzielo umowa_O_Dzielo = new Umowa_o_dzielo(autor, ile_miesiecy, wyplata); 
                    Kontroler.umowy.Dodaj(umowa_O_Dzielo);
                    break;
                case 2:
                    Umowa_o_prace umowa_O_Prace = new Umowa_o_prace(autor, ile_miesiecy, wyplata);
                    Kontroler.umowy.Dodaj(umowa_O_Prace);
                    break;
            }
        }
    }
    public static class Kontroler
    {
        public static Autor autorzy = new Autor();
        public static Ksiazka ksiazki = new Ksiazka();
        public static Czasopismo czasopisma = new Czasopismo();
        public static Umowa umowy = new Umowa();

        public static void Zapisz()
        {
            autorzy.Zapisz();
            ksiazki.Zapisz();
            czasopisma.Zapisz();
            umowy.Zapisz();
        }
        public static void Odczytaj()
        {
            autorzy.Odczytaj();
            ksiazki.Odczytaj();
            czasopisma.Odczytaj();
            umowy.Odczytaj();
        }
    }
    class Glowne_opcje_usuwania
    {
        public static string tytul;
        public static string nazwisko;
        public static int numer;
        public static void Usun_Autora()
        {
            Kontroler.autorzy.Wypisz();
            Console.WriteLine("Podaj nazwisko autora ktorego chcesz usunac:");
            string nazwisko;
            nazwisko = Console.ReadLine();
            var autor = Kontroler.autorzy.Wyszukaj(nazwisko);
            Kontroler.autorzy.Usun(autor);
        }
        public static void Usun_Ksiazke()
        {
            Console.Clear();
            Console.WriteLine("Podaj typ ksiazki do usuniecia: ");
            Console.WriteLine("1-Romans");
            Console.WriteLine("2-Sensacyjna");
            Console.WriteLine("3-Krymianl");
            Console.WriteLine("4-Album");

            int wybor;
            wybor = int.Parse(Console.ReadLine());
            if(wybor>4||wybor<1)
            {
                return;
            }
            Kontroler.ksiazki.Wypisz();
            Console.WriteLine("Podaj tytul ksiazki: ");
            tytul = Console.ReadLine();
            Console.WriteLine("Podaj nazwisko autora: ");
            nazwisko = Console.ReadLine();

            switch(wybor)
            {
                case 1:
                    var romans = Kontroler.ksiazki.Wyszukaj(tytul, nazwisko);
                    Kontroler.ksiazki.Usun(romans);
                    break;
                case 2:
                    var sensacyjna = Kontroler.ksiazki.Wyszukaj(tytul, nazwisko);
                    Kontroler.ksiazki.Usun(sensacyjna);
                    break;
                case 3:
                    var kryminal = Kontroler.ksiazki.Wyszukaj(tytul, nazwisko);
                    Kontroler.ksiazki.Usun(kryminal);
                    break;
                case 4:
                    var album = Kontroler.ksiazki.Wyszukaj(tytul, nazwisko);
                    Kontroler.ksiazki.Usun(album);
                    break;
            }
        }
        public static void Usun_Czasopismo()
        {
            Console.Clear();
            Console.WriteLine("Podaj typ czasopisma do usuniecia: ");
            Console.WriteLine("1-Miesiecznik.");
            Console.WriteLine("2-Tygodnik.");

            int wybor;
            wybor = int.Parse(Console.ReadLine());
            if (wybor > 3 || wybor < 1)
            {
                return;
            }

            Console.WriteLine("Podaj tytul czasopisma do usuniecia:");
            tytul = Console.ReadLine();
            Console.WriteLine("Podaj numer egzemplarza:");
            numer = int.Parse(Console.ReadLine());

            switch(wybor)
            {
                case 1:
                    var miesiecznik = Kontroler.czasopisma.Wyszukaj<Miesiecznik>(tytul, numer);
                    Kontroler.czasopisma.Usun(miesiecznik);
                    break;
                case 2:
                    var tygodnik = Kontroler.czasopisma.Wyszukaj<Tygodnik>(tytul, numer);
                    Kontroler.czasopisma.Usun(tygodnik);
                    break;
            }
        }
        public static void Usun_Umowe()
        {
            Console.Clear();
            Console.WriteLine("Jaki typ umowy chcesz usunac?");
            Console.WriteLine("1-Umowa o prace");
            Console.WriteLine("2-Umowa o dzieło");

            int wybor;
            wybor = int.Parse(Console.ReadLine());
            if(wybor>2 || wybor<1)
            {
                return;
            }
            Console.WriteLine("Podaj imie autora: ");
            var imie = Console.ReadLine();
            Console.WriteLine("Podaj nazwisko autora: ");
            nazwisko = Console.ReadLine();

            switch (wybor)
            {
                case 1:
                    var umowaoprace = Kontroler.umowy.Wyszukaj(imie, nazwisko);
                    Kontroler.umowy.Usun(umowaoprace);
                    break;
                case 2:
                    var umowaodzielo = Kontroler.umowy.Wyszukaj(imie, nazwisko);
                    Kontroler.umowy.Usun(umowaodzielo);
                    break;
            }
        }
    }
    class Glowne_opcje_wypisywania
    {
        public static void Wypisz_Autora()
        {
            Kontroler.autorzy.Wypisz();
            Console.ReadKey();
        }
        public static void Wypisz_Ksiazke()
        {
            int wybor;
            wybor = int.Parse(Console.ReadLine());
            switch (wybor)
            {
                case 1:
                    Kontroler.ksiazki.Wypisz<Romans>();
                    break;
                case 2:
                    Kontroler.ksiazki.Wypisz<Sensacyjna>();
                    break;
                case 3:
                    Kontroler.ksiazki.Wypisz<Kryminał>();
                    break;
                case 4:
                    Kontroler.ksiazki.Wypisz<Album>();
                    break;
                case 5:
                    Kontroler.ksiazki.Wypisz();
                    break;
            }
            Console.ReadKey();
        }
        public static void Wypisz_Czasopismo()
        {
            int wybor;
            wybor = int.Parse(Console.ReadLine());
            switch (wybor)
            {
                case 1:
                    Kontroler.czasopisma.Wypisz<Tygodnik>();
                    break;
                case 2:
                    Kontroler.czasopisma.Wypisz<Miesiecznik>();
                    break;
                case 3:
                    Kontroler.czasopisma.Wypisz();
                    break;
            }
            Console.ReadKey();
        }
        public static void Wypisz_umowy()
        {
            int wybor;
            wybor = int.Parse(Console.ReadLine());
            switch(wybor)
            {
                case 1:
                    Kontroler.umowy.Wypisz<Umowa_o_dzielo>();
                    break;
                case 2:
                    Kontroler.umowy.Wypisz<Umowa_o_prace>();
                    break;
                case 3:
                    Kontroler.umowy.Wypisz();
                    break;
            }
        }
    }
    public class Menu
    {
        public static int Poczatek_programu()
        {
            while(true)
            {
                Console.Clear();
                Console.WriteLine("Witaj w Wydawnictwie ePress");
                Console.WriteLine("Co chcesz zrobic?");
                Console.WriteLine("1-Dodawanie");
                Console.WriteLine("2-Wyswietlanie");
                Console.WriteLine("3-Usuwanie");
                Console.WriteLine("4-Drukowanie");
                Console.WriteLine("5-Sklep");
                Console.WriteLine("0-Zamknij aplikacje");
                int wybor;
                wybor = int.Parse(Console.ReadLine());
                switch(wybor)
                {
                    case 1:
                        Dodawanie();
                        break;
                    case 2:
                        Wypisywanie();
                        break;
                    case 3:
                        Usuwanie();
                        break;
                    case 4:
                        Dział_Druku.usterka();
                        break;
                    case 5:
                        Sklep();
                        break;
                    case 0:
                        return 0;
                }
            }
        }
        public static void Sklep()
        {
            Console.Clear();
            Console.WriteLine("Witaj w naszym e-skelepie. Co chcesz zrobic?");
            Console.WriteLine("1-Sprawdz ilosc ksiazek na magazynie");
            Console.WriteLine("2-Lista dostepnych pozycji");
            Console.WriteLine("3-Zakup wybranej ksiazki");
            Console.WriteLine("0-Wyjscie ze sklepu");
            int wybor;
            wybor = int.Parse(Console.ReadLine());
            switch (wybor)
            {
                case 1:
                    Dział_Handlowy.ilosc();
                    Sklep();
                    break;
                case 2:
                    Dział_Handlowy.Katalog();
                    Sklep();
                    break;
                case 3:
                    Dział_Handlowy.dokonanie_zakupu();
                    Sklep();
                    break;
                case 0:
                    Console.ReadKey();
                    break;
            }
        }
        public static void Dodawanie()
        {
            Console.Clear();
            Console.WriteLine("Co chcesz dodac?");
            Console.WriteLine("1-Dodaj ksiazke");
            Console.WriteLine("2-Dodaj czasopismo");
            Console.WriteLine("3-Dodaj autora");
            Console.WriteLine("4-Dodaj umowe");
            int wybor;
            wybor = int.Parse(Console.ReadLine());
            switch (wybor)
            {
                case 1:
                    Glowne_opcje_dodawania.Dodaj_Ksiazke();
                    break;
                case 2:
                    Glowne_opcje_dodawania.Dodaj_Czasopismo();
                    break;
                case 3:
                    Glowne_opcje_dodawania.Dodaj_Autora();
                    break;
                case 4:
                    Glowne_opcje_dodawania.Dodaj_umowe();
                    break;
            }
        }
        public static void Usuwanie()
        {
            Console.Clear();
            Console.WriteLine("Co chcesz usunac?");
            Console.WriteLine("1-Usun ksiazke");
            Console.WriteLine("2-Usun czasopismo");
            Console.WriteLine("3-Usun autora");
            Console.WriteLine("4-Usun umowe");
            int wybor;
            wybor = int.Parse(Console.ReadLine());

            switch(wybor)
            {
                case 1:
                    Glowne_opcje_usuwania.Usun_Ksiazke();
                    break;
                case 2:
                    Glowne_opcje_usuwania.Usun_Czasopismo();
                    break;
                case 3:
                    Glowne_opcje_usuwania.Usun_Autora();
                    break;
                case 4:
                    Glowne_opcje_usuwania.Usun_Umowe();
                    break;
            }
        }
        public static void Wypisywanie()
        {
            Console.Clear();
            Console.WriteLine("Co chcesz wyswietlic?");
            Console.WriteLine("1-Wyswietl ksiazke");
            Console.WriteLine("2-Wyswietl czasopismo");
            Console.WriteLine("3-Wyswietl autorow");
            Console.WriteLine("4-Wyswietl umowe");
            int wybor;
            wybor = int.Parse(Console.ReadLine());

            switch(wybor)
            {
                case 1:
                    Console.Clear();
                    Console.WriteLine("Podaj typ ksiazki: ");
                    Console.WriteLine("1. Album.");
                    Console.WriteLine("2. Romans.");
                    Console.WriteLine("3. Thriller");
                    Console.WriteLine("4. Sensacyjna");
                    Console.WriteLine("5. Wyswietl wszystkie ksiazki.");
                    Glowne_opcje_wypisywania.Wypisz_Ksiazke();
                    break;
                case 2:
                    Console.Clear();
                    Console.WriteLine("Podaj typ czasopisma: ");
                    Console.WriteLine("1. Tygodnik.");
                    Console.WriteLine("2. Miesiecznik.");
                    Console.WriteLine("3. Wyswietl wszystkie czasopisma.");
                    Glowne_opcje_wypisywania.Wypisz_Czasopismo();
                    break;
                case 3:
                    Glowne_opcje_wypisywania.Wypisz_Autora();
                    break;
                case 4:
                    Console.Clear();
                    Console.WriteLine("Podaj typ umowy: ");
                    Console.WriteLine("1. Umowa o prace.");
                    Console.WriteLine("2. Umowa o dzielo.");
                    Console.WriteLine("3. Wszystkie");
                    Glowne_opcje_wypisywania.Wypisz_umowy();
                    break;
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Kontroler.Odczytaj();
            Menu.Poczatek_programu();
            Kontroler.Zapisz();
        }
    }
}
