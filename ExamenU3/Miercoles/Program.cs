using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace Miercoles
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Texto de la notificacion:");
            string texto = Console.ReadLine() ?? "";

            Console.WriteLine("Tematica  0 Ninguna  1 Navidad  2 Halloween  3 Cumpleaños");
            int tema = Input.LeerOpcion(0, 3);

            Console.WriteLine("Es urgente  0 No  1 Si");
            bool urgente = Input.LeerOpcion(0, 1) == 1;

            Console.WriteLine("Tamanio 1 normal 2 grande 3 extra");
            int tamanio = Input.LeerOpcion(1, 3);

            Console.WriteLine("Canal  1 App  2 Email");
            int canal = Input.LeerOpcion(1, 2);

            Console.WriteLine("Destino ejemplo correo numero o usuario");
            string destino = Console.ReadLine() ?? "";

            IMessage mensaje = new PlainMessage(texto);

            bool necesitaDeco = false;
            if (tema != 0) necesitaDeco = true;
            if (urgente) necesitaDeco = true;
            if (tamanio > 1) necesitaDeco = true;

            if (necesitaDeco)
                mensaje = new SimpleDecorator(mensaje, tema, urgente, tamanio);

            ISender sender;
            switch (canal)
            {
                case 1: sender = new AppSender(); break;
                case 2: sender = new EmailSender(); break;
                default: sender = new AppSender(); break;
            }

            var noti = new Notification(sender);

            Console.WriteLine();
            Console.WriteLine("Vista previa");
            Console.WriteLine("-------------");
            ColorPrinter.Write(mensaje.GetText());
            Console.WriteLine("-------------");

            Console.WriteLine();
            Console.WriteLine("Estas seguro de enviar esta notificacion?  0 No  1 Si");
            int confirmar = Input.LeerOpcion(0, 1);
            if (confirmar == 0)
            {
                Console.WriteLine("Notificacion cancelada");
                return;
            }

            Console.WriteLine();
            Console.WriteLine("Enviando");
            noti.Publicar(mensaje, destino);
            Console.ReadKey();
        }
    }
}
