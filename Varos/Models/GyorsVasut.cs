using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Varos.Models
{
    public  class GyorsVasut: Utazas
    {
        public override int arSzamitas()
        {
            return Alap * 2 + (Km * 50);
        }
    }
}
