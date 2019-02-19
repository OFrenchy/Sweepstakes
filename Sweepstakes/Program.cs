using System;
using System.Collections;
using System.Linq;
//using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;
using System.Collections.Generic;
using System.Text;

//(5 points)X As a developer, I want consistent commits and descriptive commit messages.
//(5 points)X As a developer, I want to create a Contestant class that has a first name, last name, email address, and registration number.
//(10 points)X As a developer, I want to create a user interface for any information the application would need to get from the user.One example would be the functionality to assign a Contestant object a first name, last name, email address, and registration number.
//(15 points)X As a developer, I want to create a Sweepstakes class that uses the Dictionary data structure as an underlying structure.The Sweepstakes class will have the following methods with full implementation(write the functionality) of each method:
//      -	Sweepstakes(string name)
//      -	void RegisterContestant(Contestant contestant)
//      -	string PickWinner()
//      -	void PrintContestantInfo(Contestant contestant)
//(10 points)X As a developer, I want to write an ISweepstakesManager interface with the following methods for a sweepstakes management system:
//      -	void InsertSweepstakes(Sweepstakes sweepstakes)
//      -	Sweepstakes GetSweepstakes()
//      -   As a developer, I needed to add a Count property of the Queue/Stack counts so that I can quickly know how many sweepstakes there are.
//(10 points)X As a developer, I want to create a SweepstakesStackManager class that uses the Stack data structure as an underlying structure.
//(10 points)X As a developer, I want to create a SweepstakesQueueManager class that uses the Queue data structure as an underlying structure.
//(10 points)X As a developer, I want my SweepstakesStackManager class and SweepstakesQueueManager class to inherit from the ISweepstakesManager interface and implement the methods from the ISweepstakesManager interface using Stack and Queue methods.
//(5 points)X As a developer, I want to create a MarketingFirm class. 
//(10 points)X As a developer, I want to implement dependency injection in my MarketingFirm class so that I can utilize a sweepstakes manager.
//(10 points)X As a developer, I want to use the factory design pattern to allow a user to choose between a SweepstakesStackManager or a SweepstakesQueueManager to manage the sweepstakes objects.


//Bonus Points:
//(5 points)?MAYBE? As a developer, I want to use the observer design pattern to notify all users of the winning contestant, with the winner of the sweepstakes getting a different message specifically congratulating them on being the winner.
//(5 points) As a developer, I want to send an actual email to a sweepstakes winner using an MailKit API https://github.com/jstedfast/MailKit



namespace Sweepstakes
{
    class Program
    {
        static void Main(string[] args)
        {
            // /TODO - in the future, set up a GUI to modify/update the various string fields in the 
            //          MarketingFirm class, etc.;
            //          also include a button to create a new sweepstakes.

            StringReader stringReader = new StringReader("n"); // n = select Queue mgr, y = select Stack mgr
            Console.SetIn(stringReader);
            
            MarketingFirm marketingFirm = new MarketingFirm();

            // Create the 1st sweepstakes
            Sweepstakes sweepstakes = UserInterface.startupMarketingFirmCreateNewSweepstakes(marketingFirm);

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

            // Create the 2nd sweepstakes
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
            
            // stop here to examine console output
            Console.WriteLine("Hello World!");
        }
    }
}
