using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Miercoles
{
    public class EmailSender : ISender
    {
        public string Nombre => "Email";
        public void Send(string texto, string destino)
        {
            Console.WriteLine($"[{Nombre} a {destino}]");
            ColorPrinter.Write(texto);
        }
    }
}
