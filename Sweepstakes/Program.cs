﻿using System;
using System.Collections;
using System.Linq;
//using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;

using System.Collections.Generic;

using System.Text;



namespace Sweepstakes
{
    class Program
    {
        static void Main(string[] args)
        {

            StringReader stringReader = new StringReader("n"); // n = select Queue mgr, y = select Stack mgr
            Console.SetIn(stringReader);
            
            MarketingFirm marketingFirm = new MarketingFirm();

            Sweepstakes sweepstakes = UserInterface.startupMarketingFirmCreateNewSweepstakes(marketingFirm);
            //int newSweepstakesID = marketingFirm.CreateNewSweepstakes();
            //Sweepstakes sweepstakes = marketingFirm.SweepstakesManager.GetSweepstakes(newSweepstakesID);

            // Add contestants
            sweepstakes.RegisterContestant("Tester", "Lester", "LT@Tester.com");
            sweepstakes.RegisterContestant("Tester", "Chester", "CT@Tester.com");
            sweepstakes.RegisterContestant("Tester", "Nester", "NT@Tester.com");
            sweepstakes.RegisterContestant("Tester", "Fester", "FT@Tester.com");

            Console.WriteLine(sweepstakes.Contestants[1].FirstName + sweepstakes.Contestants[1].RegistrationNumber);
            Console.WriteLine(sweepstakes.Contestants[2].FirstName + sweepstakes.Contestants[2].RegistrationNumber);
            Console.WriteLine(sweepstakes.Contestants[3].FirstName + sweepstakes.Contestants[3].RegistrationNumber);
            Console.WriteLine(sweepstakes.Contestants[4].FirstName + sweepstakes.Contestants[4].RegistrationNumber);

            Contestant contestant = sweepstakes.Contestants[2];
            sweepstakes.PrintContestantInfo(contestant);

            sweepstakes = UserInterface.startupMarketingFirmCreateNewSweepstakes(marketingFirm);
            int newSweepstakesID = sweepstakes.SweepstakesID;

            sweepstakes = marketingFirm.SweepstakesManager.GetSweepstakes(newSweepstakesID);

            // Add contestants
            sweepstakes.RegisterContestant("Stooge", "Curly", "CS@Stooge.com");
            int thisRegistrationNumberr = sweepstakes.RegisterContestant("Stooge", "Mo", "MS@Stooge.com");
            sweepstakes.RegisterContestant("Stooge", "Larry", "LS@Stooge.com");
            
            Console.WriteLine(sweepstakes.Contestants[1].FirstName + sweepstakes.Contestants[1].RegistrationNumber);
            Console.WriteLine(sweepstakes.Contestants[2].FirstName + sweepstakes.Contestants[2].RegistrationNumber);
            Console.WriteLine(sweepstakes.Contestants[3].FirstName + sweepstakes.Contestants[3].RegistrationNumber);
            
            contestant = sweepstakes.Contestants[thisRegistrationNumberr];
            sweepstakes.PrintContestantInfo(contestant);

            string winner = sweepstakes.PickWinner();
            Console.WriteLine("And the winner is..... " + winner);
            Console.WriteLine("The winner was picked on " + sweepstakes.DrawingDateTimeActual.ToShortDateString() + " at " +sweepstakes.DrawingDateTimeActual.ToShortTimeString());//   .ToLongDateString());

            marketingFirm.ContactContestants(sweepstakes);



            // launch user interface?




            Console.WriteLine("Hello World!");
        }
    }
}
