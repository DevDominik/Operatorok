using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Operatorok
{
    public class Kifejezes
    {
        double elso, masodik;
        string muvelet;
        public Kifejezes(string beolvasott)
        {
            string[] veg = beolvasott.Split(' ');
            this.elso = Convert.ToDouble(veg[0]);
            this.masodik = Convert.ToDouble(veg[2]);
            this.muvelet = veg[1];
        }
        public double ElsoSzam { get { return elso; } }
        public double MasodikSzam { get { return masodik; } }
        public string Muvelet { get { return muvelet; } }
    }
}
