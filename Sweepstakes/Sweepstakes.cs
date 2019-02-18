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
        string clientCompanyName;
        string ss_ID;
        string ss_Name;
        string description;
        string prize;
        string detailsFinePrint;

        DateTime startDate;
        DateTime endDateTime;
        DateTime drawingDateTimeScheduled;
        DateTime drawingDateTimeActual = DateTime.Parse("1/1/1900");
        bool prizePhysicallyAwarded;
        DateTime prizeTransferredDateTime = DateTime.Parse("1/1/1900");
        Dictionary<int, Contestant> contestants;
        int winningRegistrationNumber = -1;     // only gets set once

        //string winningEmailSubject;
        //string winningEmailBodyMessage;
        //string nonWinningEmailSubject;
        //string nonWinningEmailBodyMessage;



        public Sweepstakes(string sweepstakesName)//, all other data req'd for new SS )
        {
            this.ss_Name = sweepstakesName;
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
        
        

        public string PickWinner()
        {
            if (DateTime.Now < endDateTime || DateTime.Now < drawingDateTimeScheduled)
            {
                UserInterface.displayMessage($"The end date and time of this sweepstakes is {endDateTime.ToLongDateString()}", true);
                return null;
            }
            Random random = new Random();
            winningRegistrationNumber = random.Next(1, contestants.Count + 1);
            drawingDateTimeActual = DateTime.Now; //.ToLongDateString();
            Contestant winner = contestants[winningRegistrationNumber];
            return $"{winner.LastName}, {winner.FirstName}, {winner.EmailAddress}, {winner.RegistrationNumber}";
        }
        public string Ss_Name
        {
            get => ss_Name;
            set { if (ss_Name == null) ss_Name = value; }
        }public int WinningRegistrationNumber
        {
            get => winningRegistrationNumber;
        }
        public string ClientCompanyName { get; }
        public string Ss_ID { get; }
        public string Description { get; }
        public string Prize { get; }
        //public string detailsFinePrint;

        public DateTime StartDate { get; }
        public DateTime EndDateTime { get; }
        public DateTime DrawingDateTimeScheduled { get; }
        public DateTime DrawingDateTimeActual
        {
            get => drawingDateTimeActual;
            set { if (drawingDateTimeActual.ToShortDateString() == "1/1/1900") drawingDateTimeActual = value; }
        }
        public bool PrizePhysicallyAwarded
        {
            get => prizePhysicallyAwarded;
            set { if (!prizePhysicallyAwarded) { prizePhysicallyAwarded = value; } }
        }
        public DateTime PrizeTransferredDateTime
        {
            get => prizeTransferredDateTime;
            set { if (prizeTransferredDateTime.ToShortDateString() == "1/1/1900") prizeTransferredDateTime = value; }
        }
        public string WinningEmailSubject { get; set; }
        public string WinningEmailBodyMessage { get; set; }
        public string NonWinningEmailSubject { get; set; }
        public string NonWinningEmailBodyMessage { get; set; }



    }
}