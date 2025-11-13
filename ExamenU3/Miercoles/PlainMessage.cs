using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Miercoles
{
    public class PlainMessage : IMessage
    {
        private readonly string _text;
        public PlainMessage(string text) { _text = text; }
        public string GetText() => _text;
    }
}
