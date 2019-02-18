using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sweepstakes
{
    public class ISweepstakesManager
    {
        string marketingCompanyName = "Jack, Inc.";
        string clientCompanyName = "Presley, Inc.";
        string marketingCompanyTelephoneNumber = "(123) 456-7890";
        //string ss_ID;
        //string ss_Name;
        //string description;
        //string prize;
        //DateTime startDate;
        //DateTime endDateTime;
        //DateTime drawingDateTimeScheduled;

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

        private string ReplaceFields(string stringToReplaceFields, Contestant contestant, Sweepstakes thisSS)
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append(stringToReplaceFields);
            stringBuilder.Replace("{clientCompanyName}", clientCompanyName);
            stringBuilder.Replace("{clientCompanyName}", clientCompanyName);
            stringBuilder.Replace("{marketingCompanyName}", marketingCompanyName);
            stringBuilder.Replace("{marketingCompanyTelephoneNumber}", marketingCompanyTelephoneNumber);
            stringBuilder.Replace("{startDate}", thisSS.StartDate.ToShortDateString());
            stringBuilder.Replace("{endDateTime}", thisSS.EndDateTime.ToShortDateString());
            stringBuilder.Replace("{drawingDateTimeScheduled}", thisSS.DrawingDateTimeScheduled.ToShortDateString());
            stringBuilder.Replace("{ss_Name}", thisSS.Ss_Name);
            stringBuilder.Replace("{FirstName}", contestant.FirstName);
            stringBuilder.Replace("{LastName}", contestant.LastName);
            stringBuilder.Replace("{prize}", thisSS.Prize);
            stringBuilder.Replace("{registrationNumber}", contestant.RegistrationNumber.ToString());
            stringBuilder.Replace("{winningRegistrationNumber}", thisSS.WinningRegistrationNumber.ToString());
            //stringBuilder.Replace("{}", );
            //stringBuilder.Append("\n");
            return stringBuilder.ToString();
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
                        "=================================================\nBody:  \n"  +
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
    }
}