using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Miercoles
{
    public class Notification
    {
        private readonly ISender _sender;
        public Notification(ISender sender) { _sender = sender; }

        public void Publicar(IMessage contenido, string destino)
        {
            _sender.Send(contenido.GetText(), destino);
        }
    }
}
