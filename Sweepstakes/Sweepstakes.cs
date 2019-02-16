using System;
using System.Collections;
using System.Linq;
using System.Text;

namespace Sweepstakes
{
    public class Sweepstakes
    {
        string sweepstakesName;
        int MaxRegistrationNumber=0;

        //DictionaryBase<string sweepstakesName, int asdfasdf > sweepstakes

        public Sweepstakes()
        {

        }

        public string SweepstakesName
        {
            get => default(int);
            set
            {
            }
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

        }
    }
}