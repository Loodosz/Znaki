using System;

namespace Zgadula
{
    class Program
    {
        static void Main(string[] args)
        {
            Powitanie();

            string gracz = PoznajGracza();

            Powodzenia(gracz);

            Random random = new Random();
            int minimum = 1;
            int maksymum = 1000;

            int zagadka = random.Next(minimum,maksymum);
            bool dobrze = false;
            Console.WriteLine($"<{minimum}> Zgadnij mnie <{maksymum}>");

            int licznik = 0;

            while (!dobrze)
            {
                string input = Console.ReadLine();
                int odgadka;
                bool isNumber = int.TryParse(input, out odgadka);

                if (!isNumber)
                {
                    NapiszKolorowyTekst(ConsoleColor.Red, $"<{minimum}> To nie liczba! <{maksymum}>");
                    continue;
                }
                if (odgadka < 1 || odgadka > 1000)
                {
                    NapiszKolorowyTekst(ConsoleColor.Red, $"<{minimum}> Poza przedziałem! <{maksymum}>");
                    continue;
                }

                if (odgadka < zagadka)
                {
                    licznik = licznik + 1;
                    minimum = odgadka;
                    NapiszKolorowyTekst(ConsoleColor.Magenta, $"<{minimum}> ? <{maksymum}>");

                }
                else if (odgadka > zagadka)
                {
                    licznik = licznik + 1;
                    maksymum = odgadka;
                    NapiszKolorowyTekst(ConsoleColor.Magenta, $"<{minimum}> ? <{maksymum}>");
                }
                else
                {
                    dobrze = true;
                    licznik = licznik + 1;
                    NapiszKolorowyTekst(ConsoleColor.Green, $"<{minimum}> Bravo! Zgadłeś za {licznik} razem! <{maksymum}>");
                }
            }

                      
        }

        static void Powitanie()
        {
            string apkaNazwa = "Zgadula";
            int apkaWersja = 1;
            string apkaAutor = "Lood";
            string tekst = $"[{apkaNazwa}] Wersja: 0.0.{apkaWersja}, Autor: {apkaAutor}";
            NapiszKolorowyTekst(ConsoleColor.Red, tekst);
        }

        static string PoznajGracza()
        {
            Console.WriteLine("Jak się nazywasz gamerze?");
            string pobierzGracza = Console.ReadLine();
            return pobierzGracza;
        }

        static void Powodzenia(string gracz)
        {
            string tekst = $"Powodzenia {gracz}!";
            NapiszKolorowyTekst(ConsoleColor.Blue, tekst);
        }

        static void NapiszKolorowyTekst(ConsoleColor kolor, string tekst)
        {
            Console.ForegroundColor = kolor;
            Console.WriteLine(tekst);
            Console.ResetColor();
        }
    }
}
