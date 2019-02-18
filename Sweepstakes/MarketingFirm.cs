using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace Sweepstakes
{
    public class MarketingFirm
    {
        // Member variables
        ISweepstakesManager sweepstakesManager;

        string marketingCompanyName = "Wil-E-Coyote, Inc.";
        string marketingCompanyTelephoneNumber = "(123) 456-7890";
        string clientCompanyName = "Acme, Inc.";

        string detailsFinePrint =
            "Employees and relatives of employees of {clientCompanyName} and {marketingCompanyName} " +
            "and their subsidiaries are not eligible to enter.\n " +
            "The sweepstakes begins on {startDate} and ends at {endDateTime}. " +
            "The drawing will be held on {drawingDateTimeScheduled}. " +
            "The winning number is not transferrable.";
        string winningEmailSubject = "Congratulations on your {clientCompanyName} {ss_Name} Sweepstakes Entry";
        string winningEmailBodyMessage = "Congratulations to {FirstName} {LastName}!\n  " +
            "You are the winner of the {prize} " +
            "in the {clientCompanyName} {ss_Name} Sweepstakes!\n " +
            "Your ticket number {registrationNumber} was picked to win!\n  " +
            "Please contact {marketingCompanyName} at {marketingCompanyTelephoneNumber} to discuss the details.  \n\n" +
            "Once again, congratulations!";
        string nonWinningEmailSubject = "Your {clientCompanyName} {ss_Name} Sweepstakes Entry";
        string nonWinningEmailBodyMessage = "Unfortunately, {FirstName} {LastName} did not win " +
            "in the {clientCompanyName} {ss_Name} Sweepstakes.\n  " +
            "Your ticket number was {registrationNumber}.  The winning ticket, number {winningRegistrationNumber},\n " +
            "was randomly picked at {drawingDateTimeActual}\n\n" +
            "{clientCompanyName} would like to thank you for playing!  We hope you win next time!";

        // Constructor
        public MarketingFirm()
        {
            if (UserInterface.showWelcomeScreenGetManagementSelection() == "y")
            {
                sweepstakesManager = new SweepstakesStackManager();
            }
            else sweepstakesManager = new SweepstakesQueueManager();
        }

        // Member methods
        
        public int CreateNewSweepstakes()
        {
            int newSweepstakesID = sweepstakesManager.Count + 1;
            
            Sweepstakes sweepstakes = new Sweepstakes (
                UserInterface.promptForStringInput("Enter sweepstakes name: "),
                newSweepstakesID,
                UserInterface.promptForStringInput("Enter description:"),
                UserInterface.promptForStringInput("Enter prize:"),
                UserInterface.promptForStringInput("Enter client company name:"),
                DateTime.Parse(UserInterface.promptForStringInput("Enter start date in '1/1/2000' format:")),
                DateTime.Parse(UserInterface.promptForStringInput("Enter end date & time in '1/1/2000 1:00 pm' format:")),
                DateTime.Parse(UserInterface.promptForStringInput("Enter the scheduled drawing date & time in '1/1/2000 1:00 pm' format:")),
                detailsFinePrint,
                winningEmailSubject, 
                winningEmailBodyMessage,
                nonWinningEmailSubject, 
                nonWinningEmailBodyMessage
            );
            sweepstakesManager.InsertSweepstakes(sweepstakes);
            return newSweepstakesID;
        }
        public string ClientCompanyName { get => clientCompanyName; }
        public string DetailsFinePrint
        {
            get => detailsFinePrint;
            set => detailsFinePrint = value;
        }
        public string WinningEmailSubject
        {
            get => winningEmailSubject;
            set => winningEmailSubject = value;
        }
        public string WinningEmailBodyMessage
        {
            get => winningEmailBodyMessage;
            set => winningEmailBodyMessage = value;
        }
        public string NonWinningEmailSubject
        {
            get => nonWinningEmailSubject;
            set => nonWinningEmailSubject = value;
        }
        public string NonWinningEmailBodyMessage
        {
            get => nonWinningEmailBodyMessage;
            set => nonWinningEmailBodyMessage = value;
        }
        public ISweepstakesManager SweepstakesManager
        {
            get => sweepstakesManager;
        }

        public void ContactContestants(Sweepstakes thisSS)
        {
            foreach (Contestant contestant in thisSS.Contestants.Values)
            {
                // TODO - change this later to not be nearly duplicate 
                if (contestant.RegistrationNumber != thisSS.WinningRegistrationNumber)
                {
                    string thisMessageSubject = ReplaceFields(thisSS.NonWinningEmailSubject, contestant, thisSS);
                    string thisMessageBody = ReplaceFields(thisSS.NonWinningEmailSubject, contestant, thisSS);
                    string messageForConsoleWrite =
                        "=================================================\nSubject:  \n" +
                        thisMessageSubject +
                        "=================================================\nBody:  \n" +
                        thisMessageBody;
                    UserInterface.displayMessage(messageForConsoleWrite, false);
                }
                else
                {
                    string thisMessageSubject = ReplaceFields(thisSS.WinningEmailSubject, contestant, thisSS);
                    string thisMessageBody = ReplaceFields(thisSS.WinningEmailBodyMessage, contestant, thisSS);
                    string messageForConsoleWrite =
                        "=================================================\nSubject:  \n" +
                        thisMessageSubject +
                        "=================================================\nBody:  \n" +
                        thisMessageBody;
                    UserInterface.displayMessage(messageForConsoleWrite.ToString(), false);
                }
            }
        }
        private string ReplaceFields(string stringToReplaceFields, Contestant contestant, Sweepstakes thisSS)
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append(stringToReplaceFields);
            stringBuilder.Replace("{clientCompanyName}", thisSS.ClientCompanyName);
            stringBuilder.Replace("{marketingCompanyName}", marketingCompanyName);
            stringBuilder.Replace("{marketingCompanyTelephoneNumber}", marketingCompanyTelephoneNumber);
            stringBuilder.Replace("{startDate}", thisSS.StartDate.ToShortDateString());
            stringBuilder.Replace("{endDateTime}", thisSS.EndDateTime.ToShortDateString());
            stringBuilder.Replace("{drawingDateTimeScheduled}", thisSS.DrawingDateTimeScheduled.ToShortDateString());
            stringBuilder.Replace("{ss_Name}", thisSS.SweepstakesName);
            stringBuilder.Replace("{FirstName}", contestant.FirstName);
            stringBuilder.Replace("{LastName}", contestant.LastName);
            stringBuilder.Replace("{prize}", thisSS.Prize);
            stringBuilder.Replace("{registrationNumber}", contestant.RegistrationNumber.ToString());
            stringBuilder.Replace("{winningRegistrationNumber}", thisSS.WinningRegistrationNumber.ToString());
            //stringBuilder.Replace("{}", );
            //stringBuilder.Append("\n");
            return stringBuilder.ToString();
        }
    }
}