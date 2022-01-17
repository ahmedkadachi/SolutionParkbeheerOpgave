using System;
using ParkBusinessLayer.Model;
using ParkDataLayer.Mappers;
using ParkDataLayer.Repositories;

namespace ConsoleTest
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            ParkbeheerContext pbx = new ParkbeheerContext();

            HuizenRepositoryEF huisRepo = new HuizenRepositoryEF();
            HuurderRepositoryEF huurderRepo = new HuurderRepositoryEF();
            ContractenRepositoryEF contractRepo = new ContractenRepositoryEF();
            pbx.Database.EnsureDeleted();
            pbx.Database.EnsureCreated();
            #region HUIS
            //Voeg toe
            Park p1 = new Park("1", "Ahmed Fantasy Park", "FantasyStraat");
            Park p2 = new Park("2", "Walid saaie park", "NergensStraat");

            Huis h1 = new Huis("Opgeeistenstraat", 1, p1);
            Huis h2 = new Huis("wolfstraat", 37, p1);
            Huis h3 = new Huis("koestraat", 44, p2);

            //huisRepo.VoegHuisToe(h1);
            huisRepo.VoegHuisToe(h2);
            huisRepo.VoegHuisToe(h3);

            //Geef en update
            Huis hus = huisRepo.GeefHuis(2);
            Console.WriteLine(hus);

            hus.ZetStraat("StouteWalidStraat");
            huisRepo.UpdateHuis(hus);
            Console.WriteLine(huisRepo.GeefHuis(2).ToString());


            //True als resultaat
            Console.WriteLine(huisRepo.HeeftHuis(3));

            //False als resultaat
            Console.WriteLine(huisRepo.HeeftHuis(333));
            #endregion

            #region HUURDER
            //voeg toe
            Huurder huurder1 = new Huurder("Ahmed", new Contactgegevens("ahmed@mail.com", "0479193429", "superStraat 12"));
            Huurder huurder2 = new Huurder("Walid", new Contactgegevens("walid@mail.com", "0472893917", "stommestraat 15"));
            huurderRepo.VoegHuurderToe(huurder1);
            huurderRepo.VoegHuurderToe(huurder2);


            //Geef en update
            Huurder huuu1 = huurderRepo.GeefHuurder(1);
            Console.WriteLine(huuu1.ToString());
            huuu1.Contactgegevens.Adres = "De Super SuperStraat";
            huurderRepo.UpdateHuurder(huuu1);
            Console.WriteLine(huuu1.ToString());

            //True als resultaat
            Console.WriteLine(huurderRepo.HeeftHuurder(1));

            //False als resultaat
            Console.WriteLine(huurderRepo.HeeftHuurder(333));
            #endregion

            #region HUURCONTRACT
            //Voeg toe
            Huurcontract hc1 = new Huurcontract("1", new Huurperiode(new DateTime(2019, 04, 12), 5), new Huurder("Huurder1", new Contactgegevens("email1", "tel1", "adres1")), h1);
            Huurcontract hc2 = new Huurcontract("2", new Huurperiode(new DateTime(2019, 04, 23), 5), new Huurder("Huurder2", new Contactgegevens("email2", "tel2", "adres2")), new Huis("Straat3", 3, new Park("1", "Park1", "Locatie1")));
            contractRepo.VoegContractToe(hc1);
            contractRepo.VoegContractToe(hc2);


            //Geef en update

            Console.WriteLine(contractRepo.GeefContract("2").ToString());
            hc2.Huurder.ZetNaam("De geweizigdeNaam");
            Console.WriteLine(contractRepo.GeefContract("2").ToString());

            //True als resultaat
            Console.WriteLine(contractRepo.HeeftContract(new DateTime(2019, 04, 11), 1, 5));

            //False als resultaat
            Console.WriteLine(contractRepo.HeeftContract(new DateTime(2019, 04, 13), 1, 3));
            #endregion
        }
    }
}
