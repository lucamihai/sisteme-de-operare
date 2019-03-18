using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laborator3
{
    public class Proces
    {
        public string Nume { get; set; }
        public uint ID { get; set; }

        public override string ToString()
        {
            return $"{ID}#{Nume}";
        }
    }
}
