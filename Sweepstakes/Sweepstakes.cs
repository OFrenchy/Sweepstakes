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
        int sweepstakesID;
        string sweepstakesName;
        string description;
        string prize;
        
        DateTime startDate;
        DateTime endDateTime;
        DateTime drawingDateTimeScheduled = DateTime.Parse("1/1/1900");
        DateTime drawingDateTimeActual = DateTime.Parse("1/1/1900");
        bool prizePhysicallyAwarded;
        DateTime prizeTransferredDateTime = DateTime.Parse("1/1/1900");
        Dictionary<int, Contestant> contestants;
        int winningRegistrationNumber = -1;     // only gets set once

        string clientCompanyName;
        string detailsFinePrint;
        string winningEmailSubject;
        string winningEmailBodyMessage;
        string nonWinningEmailSubject;
        string nonWinningEmailBodyMessage;


        public Sweepstakes(string sweepstakesName, int sweepstakesID, string description, string prize, 
            DateTime startDate, DateTime endDateTime,
            DateTime drawingDateTimeScheduled, 
            string clientCompanyName, string detailsFinePrint,
            string winningEmailSubject, string winningEmailBodyMessage, string nonWinningEmailSubject,
            string nonWinningEmailBodyMessage)
        {
            this.sweepstakesName = sweepstakesName;
            this.sweepstakesID = sweepstakesID;
            this.description = description;
            this.prize = prize;
            this.clientCompanyName = clientCompanyName;
            this.startDate = startDate;
            this.endDateTime = endDateTime;
            this.drawingDateTimeScheduled = drawingDateTimeScheduled;
            this.detailsFinePrint = detailsFinePrint;
            this.winningEmailSubject = winningEmailSubject;
            this.winningEmailBodyMessage = winningEmailBodyMessage;
            this.nonWinningEmailSubject = nonWinningEmailSubject;
            this.nonWinningEmailBodyMessage = nonWinningEmailBodyMessage;
            
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
        public string SweepstakesName
        {
            get => sweepstakesName;
            set { if (sweepstakesName == null) sweepstakesName = value; }
        }public int WinningRegistrationNumber
        {
            get => winningRegistrationNumber;
        }
        public string ClientCompanyName { get { return clientCompanyName; }}
        public int SweepstakesID { get { return sweepstakesID; } }
        
        public string Description { get { return description; } } 
        public string Prize { get { return prize; } }
        //public string detailsFinePrint;

        public DateTime StartDate { get { return startDate; } }
        public DateTime EndDateTime { get { return endDateTime; } }
        public DateTime DrawingDateTimeScheduled { get { return drawingDateTimeScheduled; } }
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
        public string WinningEmailSubject  // { get { return endDateTime; } }
        {
            get { return winningEmailSubject; }
            set { winningEmailSubject = value; }
        }
        public string WinningEmailBodyMessage
        {
            get { return winningEmailBodyMessage; }
            set { winningEmailBodyMessage = value; }
        }
        public string NonWinningEmailSubject
        {
            get { return nonWinningEmailSubject; }
            set { nonWinningEmailSubject = value; }
        }
        public string NonWinningEmailBodyMessage
        {
            get { return nonWinningEmailBodyMessage; }
            set { nonWinningEmailBodyMessage = value; }
        }

    }
}