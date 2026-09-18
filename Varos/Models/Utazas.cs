using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Varos.Models
{
    public abstract class Utazas
    {
        public int Alap = 450;
        public int Km;

        public abstract int arSzamitas();
    }
}
