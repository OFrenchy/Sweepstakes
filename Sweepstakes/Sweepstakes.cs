using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sweepstakes
{
    // I may use "SS", "ss_", and "_ss_" as aliases to shorten variable & method names
    public class Sweepstakes     
    {
        string name;
        string prize;
        string detailsFinePrint;
        DateTime startDate;
        DateTime endDateTime;
        DateTime drawingDateTime;
        bool prizePhysicallyAwarded;
        DateTime prizeTransferredDateTime;
        Dictionary<int, Contestant> contestants;
        int winningRegistrationNumber = -1;     // only gets set once

        public Sweepstakes(string sweepstakesName, )
        {
            this.name = sweepstakesName;
            contestants = new Dictionary<int, Contestant>();
        }
        public void PrintContestantInfo(Contestant contestant)
        {
            Console.WriteLine(contestant.ToString());
        }
        
        public int RegisterContestant(string lastName, string firstName, string emailAddress)
        {
            // get the next int from the dictionary 
            Contestant contestant = new Contestant(lastName, firstName, emailAddress);
            contestant.RegistrationNumber = contestants.Count + 1;
            contestants.Add(contestant.RegistrationNumber, contestant);
            return contestant.RegistrationNumber;
        }
        public Dictionary<int, Contestant> Contestants
        {
            get => contestants;
        }
        
        public string Name
        {
            get => name;
            set { if (name == null) name = value; }
        }

        public string PickWinner()
        {
            if (DateTime.Now < endDateTime)
            {
                UserInterface.displayMessage($"The end date and time of this sweepstakes is {endDateTime.ToLongDateString()}", true);
                return null;
            }
            Random random = new Random();
            winningRegistrationNumber = random.Next(1, contestants.Count + 1);
            Contestant winner = contestants[winningRegistrationNumber];
            drawingDateTime = DateTime.Now; //.ToLongDateString();
            return $"{winner.LastName}, {winner.FirstName}, {winner.EmailAddress}, {winner.RegistrationNumber}";
        }
        public int WinningRegistrationNumber
        {
            get => winningRegistrationNumber;
        }
        

    }
}