namespace BankiSzolgaltatasok
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Bank bank = new Bank();

            Tulajdonos t2 = new Tulajdonos("Teszt Elek");
            Tulajdonos t3 = new Tulajdonos("Teszt Elek");
            Szamla sz3 = bank.SzamlaNyitas(t2, 0);
            Szamla sz4 = bank.SzamlaNyitas(t2, 1);
            Szamla sz5 = bank.SzamlaNyitas(t3, 0);
            Szamla sz6 = bank.SzamlaNyitas(t3, 1);
            sz3.Befizet(30000);
            sz4.Befizet(35000);
            sz5.Befizet(75000);
            sz6.Befizet(70000);

            Console.WriteLine(bank.GetLegnagyobbEgyenleguSzamla(t2));




            Console.ReadKey();
        }
    }
}