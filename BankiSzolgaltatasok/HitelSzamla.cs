using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankiSzolgaltatasok
{
    public class HitelSzamla : Szamla
    {
        private int hitelKeret;

        public HitelSzamla(Tulajdonos tulajdonos, int hitelKeret) : base(tulajdonos)
        {
            this.hitelKeret = hitelKeret;
        }

        public int HitelKeret { get => hitelKeret; }

        public new bool Kivesz(int osszeg)
        {
            if (base.aktualisEgyenleg - Math.Abs(osszeg) > hitelKeret)
            {
                base.aktualisEgyenleg -= Math.Abs(osszeg);
                return true;
            }
            return false;
        }
    }
}
