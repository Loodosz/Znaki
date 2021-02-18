using System;
using System.Diagnostics;
using System.Reflection;
using Znaki.Extensions;

namespace Zgadula
{
    class Program
    {
        private static readonly string PRODUCT_NAME = FileVersionInfo.GetVersionInfo(Assembly.GetExecutingAssembly().Location).ProductName;
        private static readonly string PRODUCT_VERSION = FileVersionInfo.GetVersionInfo(Assembly.GetExecutingAssembly().Location).ProductVersion;
        private static readonly string COMPANY_NAME = FileVersionInfo.GetVersionInfo(Assembly.GetExecutingAssembly().Location).CompanyName;
        private static readonly string ASSEMBLY_VERSION = Assembly.GetExecutingAssembly().GetName().Version.ToString();

        private const int MIN_NUMBER = 1;
        private const int MAX_NUMBER = 1000;

        static void Main(string[] args)
        {
            DisplayGreeting();

            var player = GetPlayerName();

            DisplayGoodLuckToPlayer(player);

            var randomNumber = new Random().Next(MIN_NUMBER, MAX_NUMBER);
            var minNumber = MIN_NUMBER;
            var maxNumber = MAX_NUMBER;
            Console.WriteLine($"<{minNumber}> Zgadnij mnie <{maxNumber}>");

            var answerCounter = 0;

            while (true)
            {
                var answerInput = Console.ReadLine();

                if (!answerInput.IsNumber())
                {
                    WriteColorLine(ConsoleColor.Red, $"<{minNumber}> To nie liczba! <{maxNumber}>");
                    continue;
                }

                var answer = answerInput.AsNumber();
                if (answer < MIN_NUMBER || answer > MAX_NUMBER)
                {
                    WriteColorLine(ConsoleColor.Red, $"<{minNumber}> Poza przedziałem! <{maxNumber}>");
                    continue;
                }

                answerCounter++;
                if (answer < randomNumber)
                {
                    minNumber = answer;
                    WriteColorLine(ConsoleColor.Magenta, $"<{minNumber}> ? <{maxNumber}>");
                    continue;
                }

                if (answer > randomNumber)
                {
                    maxNumber = answer;
                    WriteColorLine(ConsoleColor.Magenta, $"<{minNumber}> ? <{maxNumber}>");
                    continue;
                }

                WriteColorLine(ConsoleColor.Green, $"<{minNumber}> Bravo! Zgadłeś za {answerCounter} razem! <{maxNumber}>");
                break;
            }
        }

        static void DisplayGreeting()
        {
            var text = $"[{PRODUCT_NAME}] Wersja: {PRODUCT_VERSION} ({ASSEMBLY_VERSION}), Autors: {COMPANY_NAME}";
            WriteColorLine(ConsoleColor.Red, text);
        }

        static string GetPlayerName()
        {
            Console.WriteLine("Jak się nazywasz gamerze?");
            return Console.ReadLine();
        }

        static void DisplayGoodLuckToPlayer(in string playerName)
        {
            var text = $"Powodzenia {playerName}!";
            WriteColorLine(ConsoleColor.Blue, text);
        }

        static void WriteColorLine(ConsoleColor color, in string text)
        {
            Console.ForegroundColor = color;
            Console.WriteLine(text);
            Console.ResetColor();
        }
    }
}
