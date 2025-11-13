using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Miercoles
{
    public static class Input
    {
        public static int LeerOpcion(int min, int max)
        {
            while (true)
            {
                string s = Console.ReadLine();
                if (int.TryParse(s, out int v) && v >= min && v <= max) return v;
                Console.WriteLine("Opcion no valida intenta de nuevo");
            }
        }
    }
}
