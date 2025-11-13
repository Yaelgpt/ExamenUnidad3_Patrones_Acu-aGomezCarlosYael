using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Miercoles
{
    public interface ISender
    {
        string Nombre { get; }
        void Send(string texto, string destino);
    }
}
