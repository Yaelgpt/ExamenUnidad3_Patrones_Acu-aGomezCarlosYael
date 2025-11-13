using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Miercoles
{
    public static class ColorPrinter
    {
        public static void Write(string text)
        {
            var def = Console.ForegroundColor;

            string normalizedAll = text.Replace(" ", "");
            ConsoleColor temaColor = ConsoleColor.Gray;
            if (normalizedAll.IndexOf("[NAVIDAD]", StringComparison.OrdinalIgnoreCase) >= 0)
                temaColor = ConsoleColor.Green;
            else if (normalizedAll.IndexOf("[HALLOWEEN]", StringComparison.OrdinalIgnoreCase) >= 0)
                temaColor = ConsoleColor.DarkYellow;
            else if (normalizedAll.IndexOf("[CUMPLEAÑOS]", StringComparison.OrdinalIgnoreCase) >= 0)
                temaColor = ConsoleColor.Cyan;

            bool hayUrgente = normalizedAll.IndexOf("[URGENTE]", StringComparison.OrdinalIgnoreCase) >= 0;

            foreach (var raw in text.Replace("\r\n", "\n").Split('\n'))
            {
                string line = raw;
                string trimmed = line.Trim();
                string noSpaces = trimmed.Replace(" ", "");
                string upperNoSpaces = noSpaces.ToUpperInvariant();


                if (hayUrgente)
                {
                    if (upperNoSpaces.Equals("[URGENTE]"))
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine(line);
                        Console.ForegroundColor = def;
                        continue;
                    }
                    if (EsBarraExclamacion(noSpaces))
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine(line);
                        Console.ForegroundColor = def;
                        continue;
                    }
                }


                if (EsLineaEstrellas(noSpaces)
                    || upperNoSpaces.Equals("[NAVIDAD]")
                    || upperNoSpaces.Equals("[HALLOWEEN]")
                    || upperNoSpaces.Equals("[CUMPLEAÑOS]")
                    || upperNoSpaces.Equals("FELIZNAVIDAD")
                    || upperNoSpaces.Equals("NOCHEDEHALLOWEEN")
                    || upperNoSpaces.Equals("FELIZCUMPLEAÑOS"))
                {
                    Console.ForegroundColor = temaColor;
                    Console.WriteLine(line);
                    Console.ForegroundColor = def;
                    continue;
                }


                if (upperNoSpaces.StartsWith("[TAMANIOX"))
                {
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine(line);
                    Console.ForegroundColor = def;
                    continue;
                }


                Console.WriteLine(line);
            }

            Console.ForegroundColor = def;
        }

        private static bool EsLineaEstrellas(string s)
        {
            if (string.IsNullOrWhiteSpace(s)) return false;
            if (s.Length < 5) return false;
            foreach (var ch in s) if (ch != '*') return false;
            return true;
        }

        private static bool EsBarraExclamacion(string s)
        {
            if (string.IsNullOrWhiteSpace(s)) return false;
            if (s.Length < 5) return false;
            int excl = 0;
            foreach (var ch in s) if (ch == '!') excl++;
            return excl >= (int)(s.Length * 0.9);
        }
    }
}
