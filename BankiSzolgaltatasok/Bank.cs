using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankiSzolgaltatasok
{
    public class Bank
    {
        private List<Szamla> szamlaLista;

        public Bank()
        {
            this.szamlaLista = new List<Szamla>();
        }

        public long OsszHitelkeret
        { 
            get 
            {
                long osszHitel = 0;
                for (int i = 0; i < szamlaLista.Count; i++)
                {
                    osszHitel += szamlaLista[i].HitelKeret;
                }
                return osszHitel;
            }
        }

        public Szamla SzamlaNyitas(Tulajdonos tulajdonos, int hitelKeret)
        {
            if (hitelKeret < 0)
            {
                throw new Exception("A negatív hitelkeret nem érvényes");
            }
            return new HitelSzamla(tulajdonos, hitelKeret);
        }

        public long GetOsszEgyenleg(Tulajdonos tulajdonos)
        {
            long osszEgyenleg = 0;
            for (int i = 0; i < szamlaLista.Count; i++)
            {
                osszEgyenleg += szamlaLista[i].AktualisEgyenleg;
            }
            return osszEgyenleg;
        }

        public Szamla GetLegnagyobbEgyenleguSzamla(Tulajdonos tulajdons)
        {
            Szamla legnagyobbSzamla = null;
            for (int i = 0; i < szamlaLista.Count; i++)
            {
                if (szamlaLista[i].Tulajdonos == tulajdons && legnagyobbSzamla.AktualisEgyenleg < szamlaLista[i].AktualisEgyenleg)
                {
                    legnagyobbSzamla = szamlaLista[i];
                }
            }
            if (legnagyobbSzamla != null)
            {
                return legnagyobbSzamla;
            }
            return null;
        }

    }
}
