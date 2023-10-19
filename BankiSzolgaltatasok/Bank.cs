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
                    HitelSzamla szamla = szamlaLista[i] as HitelSzamla;
                    if (szamla != null)
                    {
                        osszHitel += szamla.HitelKeret;
                    }
                }
                return osszHitel;
            }
        }

        public Szamla SzamlaNyitas(Tulajdonos tulajdonos, int hitelKeret)
        {
            Szamla szamla;
            if (hitelKeret < 0)
            {
                throw new ArgumentException();
            }
            else if (hitelKeret == 0)
            {
                szamla = new MegtakaritasiSzamla(tulajdonos);
            }
            else 
            {
                szamla = new HitelSzamla(tulajdonos, hitelKeret);
            }
            szamlaLista.Add(szamla);
            return szamla;
        }

        public long GetOsszEgyenleg(Tulajdonos tulajdonos)
        {
            long osszEgyenleg = 0;
            for (int i = 0; i < szamlaLista.Count; i++)
            {
                if (szamlaLista[i].Tulajdonos == tulajdonos)
                {
                    osszEgyenleg += szamlaLista[i].AktualisEgyenleg;
                }
            }
            return osszEgyenleg;
        }

        public Szamla GetLegnagyobbEgyenleguSzamla(Tulajdonos tulajdons)
        {

            int legnagyobbSzamlaErteke = int.MinValue;
            int index = -1;
            for (int i = 0; i < szamlaLista.Count; i++)
            {
                if (szamlaLista[i].Tulajdonos == tulajdons && legnagyobbSzamlaErteke < szamlaLista[i].AktualisEgyenleg)
                {
                    legnagyobbSzamlaErteke = szamlaLista[i].AktualisEgyenleg;
                    index = i;
                }
            }
            if (index >= 0)
            {
                return szamlaLista[index];
            }
            return null;
        }

    }
}
