using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using MailKit.Net.Smtp;
using MailKit;
using MimeKit;


namespace Sweepstakes
{
    public class MarketingFirm
    {
        // Member variables
        ISweepstakesManager sweepstakesManager;
        bool queueFalseStackTrue;

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
        string winningEmailBodyMessage = "Congratulations to {FirstName} {LastName}!\n" +
            "You are the winner of the {prize} " +
            "in the {clientCompanyName} {ss_Name} Sweepstakes!\n" +
            "Your ticket number {registrationNumber} was picked to win!\n" +
            "Please contact {marketingCompanyName} at {marketingCompanyTelephoneNumber} to discuss the details.  \n\n" +
            "Once again, congratulations!";
        string nonWinningEmailSubject = "Your {clientCompanyName} {ss_Name} Sweepstakes Entry";
        string nonWinningEmailBodyMessage = "Unfortunately, {FirstName} {LastName} did not win " +
            "in the {clientCompanyName} {ss_Name} Sweepstakes.\n" +
            "Your ticket number was {registrationNumber}.  The winning ticket, number {winningRegistrationNumber},\n" +
            "was randomly picked at {drawingDateTimeActual}\n\n" +
            "{clientCompanyName} would like to thank you for playing!  We hope you win next time!";

        // Constructor
        public MarketingFirm()
        {
            if (UserInterface.showWelcomeScreenGetManagementSelection() == "y")
            {
                sweepstakesManager = new SweepstakesStackManager();
                queueFalseStackTrue = true;
            }
            else
            {
                sweepstakesManager = new SweepstakesQueueManager();
                queueFalseStackTrue = false;
            }
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
                DateTime.Parse(UserInterface.promptForStringInput("Enter start date in '1/1/2000' format:")),
                DateTime.Parse(UserInterface.promptForStringInput("Enter end date & time in '1/1/2000 1:00 pm' format:")),
                DateTime.Parse(UserInterface.promptForStringInput("Enter the scheduled drawing date & time in '1/1/2000 1:00 pm' format:")),
                UserInterface.promptForStringInput("Enter client company name:"),
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
                    string thisMessageBody = ReplaceFields(thisSS.NonWinningEmailBodyMessage, contestant, thisSS);
                    string messageForConsoleWrite =
                        "\n=================================================\nSubject:  \n" +
                        thisMessageSubject +
                        "\n=================================================\nBody:  \n" +
                        thisMessageBody;
                    UserInterface.displayMessage(messageForConsoleWrite, false);


                    //======================================================================================================
                    // This code adapted from https://github.com/jstedfast/MailKit
                    // MailKit is Copyright (C) 2013-2019 Xamarin Inc. and is licensed under the MIT license:
                    //Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated documentation files(the "Software"), to deal in the Software without restriction, including without limitation the rights to use, copy, modify, merge, publish, distribute, sublicense, and/ or sell copies of the Software, and to permit persons to whom the Software is furnished to do so, subject to the following conditions: The above copyright notice and this permission notice shall be included in all copies or substantial portions of the Software.
                    //THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT.IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
                    var message = new MimeMessage();
                    message.From.Add(new MailboxAddress("DB Cooper", "XYZ@wi.rr.com"));
                    message.To.Add(new MailboxAddress(contestant.FirstName + " " + contestant.LastName, "XYZ@wi.rr.com"));
                    message.Subject = thisMessageSubject;
                    message.Body = new TextPart("plain")
                    { Text = thisMessageBody  };
                    // TODO - when time permits, move this (except the send line) to the prior to the foreach, 
                    //  and move the disconnect to after the foreach
                    //  so it doesn't have to authenticate, connect, & disconnect for each message
                    using (var client = new SmtpClient())
                    {
                        // For demo-purposes, accept all SSL certificates (in case the server supports STARTTLS)
                        client.ServerCertificateValidationCallback = (s, c, h, e) => true;

                        client.Connect("mail.twc.com", 587, false);

                        // Note: only needed if the SMTP server requires authentication
                        // "emailAddressPrefix", "pwd"
                        client.Authenticate("", "");
                        client.Send(message);
                        client.Disconnect(true);
                    }
                    //======================================================================================================

                }
                else
                {
                    string thisMessageSubject = ReplaceFields(thisSS.WinningEmailSubject, contestant, thisSS);
                    string thisMessageBody = ReplaceFields(thisSS.WinningEmailBodyMessage, contestant, thisSS);
                    string messageForConsoleWrite =
                        "\n =================================================\nSubject:  \n" +
                        thisMessageSubject +
                        "\n=================================================\nBody:  \n" +
                        thisMessageBody;
                    UserInterface.displayMessage(messageForConsoleWrite.ToString(), false);


                    //======================================================================================================
                    // This code adapted from https://github.com/jstedfast/MailKit
                    // MailKit is Copyright (C) 2013-2019 Xamarin Inc. and is licensed under the MIT license:
                    //Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated documentation files(the "Software"), to deal in the Software without restriction, including without limitation the rights to use, copy, modify, merge, publish, distribute, sublicense, and/ or sell copies of the Software, and to permit persons to whom the Software is furnished to do so, subject to the following conditions: The above copyright notice and this permission notice shall be included in all copies or substantial portions of the Software.
                    //THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT.IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
                    var message = new MimeMessage();
                    message.From.Add(new MailboxAddress("DB Cooper", "XYZ@wi.rr.com"));
                    message.To.Add(new MailboxAddress(contestant.FirstName + " " + contestant.LastName, "XYZ@wi.rr.com"));
                    message.Subject = thisMessageSubject;
                    message.Body = new TextPart("plain")
                    { Text = thisMessageBody };
                    // TODO - when time permits, move this (except the send line) to the prior to the foreach, 
                    //  and move the disconnect to after the foreach
                    //  so it doesn't have to authenticate, connect, & disconnect for each message
                    using (var client = new SmtpClient())
                    {
                        // For demo-purposes, accept all SSL certificates (in case the server supports STARTTLS)
                        client.ServerCertificateValidationCallback = (s, c, h, e) => true;

                        client.Connect("mail.twc.com", 587, false);

                        // Note: only needed if the SMTP server requires authentication
                        // "emailAddressPrefix", "pwd"
                        client.Authenticate("", "");
                        client.Send(message);
                        client.Disconnect(true);
                    }
                    //======================================================================================================

                }//else
            }//foreach
            //client.Disconnect(true);
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
            stringBuilder.Replace("{drawingDateTimeActual}", thisSS.DrawingDateTimeActual.ToShortDateString() + " " + thisSS.DrawingDateTimeActual.ToShortTimeString());

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