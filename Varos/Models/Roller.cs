using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Varos.Models
{
    public class Roller:Utazas
    {
        public override int arSzamitas()
        {
            return (Km * 120);
        }
    }
}
