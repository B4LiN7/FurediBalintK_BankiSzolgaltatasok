using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankiSzolgaltatasok
{
    public class MegtakaritasiSzamla : Szamla
    {
        public static double alapKamat = 1.1;
        private double kamat;

        public MegtakaritasiSzamla(Tulajdonos tulajdonos) : base(tulajdonos) 
        { 
            kamat = alapKamat;
        }

        public double Kamat { get => kamat; set => kamat = value; }

        public override bool Kivesz(int osszeg)
        {
            if (base.aktualisEgyenleg - osszeg >= 0)
            {
                base.aktualisEgyenleg -= Math.Abs(osszeg);
                return true;
            }
            return false;
        }

        public void KamatJovairas()
        {
            base.aktualisEgyenleg = Convert.ToInt32(base.aktualisEgyenleg * this.kamat);
        }

    
    }
}
