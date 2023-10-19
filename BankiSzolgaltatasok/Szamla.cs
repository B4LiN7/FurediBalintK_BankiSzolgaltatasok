using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankiSzolgaltatasok
{
    public abstract class Szamla : BankiSzolgaltatas
    {
        protected int aktualisEgyenleg;

        protected Szamla(Tulajdonos tulajdonos) : base(tulajdonos) 
        {
            this.aktualisEgyenleg = 0;
        }

        public int AktualisEgyenleg { get => aktualisEgyenleg; }

        public void Befizet(int osszeg)
        {
            aktualisEgyenleg += Math.Abs(osszeg);
        }

        public bool Kivesz(int osszeg)
        {
            if (aktualisEgyenleg - Math.Abs(osszeg) > 0)
            {
                aktualisEgyenleg -= Math.Abs(osszeg);
                return true;
            }
            return false;       
        }

        public Kartya UjKartya(string kartyaSzam)
        {
            return new Kartya(base.Tulajdonos, kartyaSzam, this);
        }
    }
}
