using System;
using System.Collections;
using System.Linq;
using System.Text;

namespace Sweepstakes
{
    public class Sweepstakes
    {
        string sweepstakesName;
        ISweepstakesManager sweepstakesManager; // = new ISweepstakesManager();
        int MaxRegistrationNumber = 0;

        //DictionaryBase<string sweepstakesName, int asdfasdf > sweepstakes

        public Sweepstakes(string sweepstakesName, bool falseQueueTypeTrueStackType)
        {
            this.sweepstakesName = sweepstakesName;
            if (falseQueueTypeTrueStackType) { sweepstakesManager = new SweepstakesStackManager(); }
            else { sweepstakesManager = new SweepstakesQueueManager(); }
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