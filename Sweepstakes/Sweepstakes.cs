using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sweepstakes
{
    // I will use "ss_" and/or "_ss_" as aliases to shorten variable & method names
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

        int WinningRegistrationNumber = -1;     // only gets set once

        

        public Sweepstakes(string sweepstakesName, string)
        {
            this.name = sweepstakesName;
            
            contestants = new Dictionary<int, Contestant>();
            //Console.WriteLine(contestants.Count);

        }

        public Dictionary<int, Contestant> Contestants
        {
            get => contestants;
        }
            




        public string SweepstakesName
        {
            get => sweepstakesName;
            set { if (sweepstakesName == null)  sweepstakesName = value; }
        }

        public string PickWinner()
        {
            Random random = new Random();
            int WinningTicketNumber = random.Next(1, MaxRegistrationNumber + 1);
            Contestant winner = new Contestant();
            return $"{winner.LastName}, {winner.FirstName}, {winner.EmailAddress}, {winner.RegistrationNumber}";
        }
        public void RegisterContestant(Contestant contestant)
        {
            MaxRegistrationNumber++;
            contestant.RegistrationNumber = MaxRegistrationNumber;

            // Add this new contestant to the queue or stack


        }
    }
}