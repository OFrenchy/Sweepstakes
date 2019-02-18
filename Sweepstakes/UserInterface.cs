using System;
using System.Collections;
using System.Linq;

namespace Sweepstakes
{
    public static class UserInterface
    {
        public static Sweepstakes startupMarketingFirmCreateNewSweepstakes(MarketingFirm marketingFirm)
        {
            Console.WriteLine(marketingFirm.DetailsFinePrint);
            Sweepstakes sweepstakes = new Sweepstakes
                (
                    "Spring Green Contest",
                    1,
                    "Your chance to win $1000",
                    "$1000",
                    marketingFirm.ClientCompanyName, 
                    DateTime.Parse("2/1/2019"),
                    DateTime.Parse("2/17/2019 11:59 pm"),
                    DateTime.Parse("2/18/2019 9:00 am"),
                    marketingFirm.DetailsFinePrint,
                    marketingFirm.WinningEmailSubject,
                    marketingFirm.WinningEmailBodyMessage,
                    marketingFirm.NonWinningEmailSubject,
                    marketingFirm.NonWinningEmailBodyMessage
                );
            return sweepstakes;
        }

        public static int grandPrize
        {
            get => default(int);
            set
            {
            }
        }

        public static int sweepStakesDescription
        {
            get => default(int);
            set
            {
            }
        }

        public static int sweepstakesName
        {
            get => default(int);
            set
            {
            }
        }

        

        public static Contestant NewContestant()
        {
            throw new System.NotImplementedException();
        }

        public static string showWelcomeScreenGetManagementSelection()
        {
            clearScreen();
            // Construct the display of all the information the player needs to start
            string welcomeScreen = "";
            welcomeScreen = "\nWelcome to your Sweepstakes Management System!\n\n" +
                "Would you like to use Stack managment or Queue managment?\n" +
                "Enter Yes for Stack or No for Queue:";
            return promptForYesNoInput(welcomeScreen);
        }

        public static int pickWholeNumberOneThrough(int upperBound, string message, bool isRandom)
        {
            // pick a whole number from 1 to & including upperBound;  if you want a random number, don't prompt
            if (!isRandom)
            {
                int intInput = promptForIntegerInput(message, 1, upperBound);
                return intInput;
            }
            else
            {
                //generate random number from 1 to upperBound 
                displayMessage(message, false);
                Random randomGenerator = new Random();
                return (randomGenerator.Next(1, upperBound + 1));
            }
        }
        public static string promptForStringInput(string message)
        {
            string input = "";
            do
            {
                Console.WriteLine(message);
                input = Console.ReadLine().Trim();
            }
            while (input == "");
            return input;
        }
        public static string promptForYesNoInput(string message)  // returns y or n
        {
            string input = "";
            bool validInput = false;
            do
            {
                Console.WriteLine(message);
                input = Console.ReadLine().Trim().ToLower();
                if (input.Length > 0)
                {
                    input = input.ToLower();
                    input = input.Substring(0, 1);
                    if (input == "y" || input == "n")
                    {
                        validInput = true;
                    }
                }
            }
            while (validInput == false);
            return input;
        }
        public static int promptForIntegerInput(string message, int lowerBound, int upperBound)
        {
            int inputInteger = 0;
            bool isInteger;
            string input;
            do
            {
                isInteger = false;
                clearScreen();
                Console.WriteLine(message);
                input = Console.ReadLine();
                //bool isInteger = int.TryParse(input, inputInteger); 
                // in order to use try/catch
                try
                {
                    inputInteger = int.Parse(input);
                    isInteger = true;
                    if (inputInteger < lowerBound || inputInteger > upperBound)
                    {
                        Console.WriteLine("That number is out of range.");
                        Console.ReadLine();
                    }
                }
                // Note:  thisException is not used, but left in for future use/debugging/improvement
                catch (Exception thisException)
                {
                    Console.WriteLine("That is not a number.");
                    //Console.WriteLine(thisException.ToString());
                }
            }
            while (isInteger == false || inputInteger < lowerBound || inputInteger > upperBound);
            return inputInteger;
        }
        public static int promptForIntegerInput1OrGreater(string message)
        {
            int inputInteger = 0;
            int lowerBound = 1;
            bool isInteger;
            string input;
            do
            {
                isInteger = false;
                clearScreen();
                Console.WriteLine(message);
                input = Console.ReadLine();
                //bool isInteger = int.TryParse(input, inputInteger); 
                // in order to use try/catch
                try
                {
                    inputInteger = int.Parse(input);
                    isInteger = true;
                    if (inputInteger < lowerBound)
                    {
                        Console.WriteLine("That number is out of range.");
                        Console.ReadLine();
                    }
                }
                // Note:  thisException is not used, but left in for future use/debugging/improvement
                catch (Exception thisException)
                {
                    Console.WriteLine("That is not a number.");
                    //Console.WriteLine(thisException.ToString());
                }
            }
            while (isInteger == false || inputInteger < lowerBound);
            return inputInteger;
        }
        public static double promptForNumberInput(string message, double lowerBound, double upperBound)
        {
            double inputNumber = 0;
            bool isNumber;
            string input;
            do
            {
                isNumber = false;
                clearScreen();
                Console.WriteLine(message);
                input = Console.ReadLine();
                try
                {
                    inputNumber = double.Parse(input);
                    isNumber = true;
                    if (inputNumber < lowerBound || inputNumber > upperBound)
                    {
                        Console.WriteLine("That number is out of range.");
                        Console.ReadLine();
                    }
                }
                // Note:  thisException is not used, but left in for future use/debugging/improvement
                catch (Exception thisException)
                {
                    Console.WriteLine("That is not a number.");
                    //Console.WriteLine(thisException.ToString());
                }
            }
            while (isNumber == false || inputNumber < lowerBound || inputNumber > upperBound);
            return inputNumber;
        }
        // Note:  this method not used in RPSLS game;  left here as stub for future improvement
        public static char promptForCharInput(string message)
        {
            Console.WriteLine(message);
            // TODO - validate input
            //string test = Console.ReadLine();
            return Convert.ToChar(Console.ReadLine().Substring(0, 1).ToLower());
        }
        public static void displayMessage(string message, bool pauseForReturnEnter)
        {
            Console.WriteLine(message);
            if (pauseForReturnEnter)
            {
                Console.ReadLine();
            }
        }
        public static void clearScreen()
        {
            Console.Clear();
        }

        
        public static string padRightToColumn(int column, string stringToPad)
        {
            // pads the right side of the string up to column
            for (int i = stringToPad.Length; i < column; i++)
            {
                stringToPad = stringToPad + " ";
            }
            return stringToPad;
        }






    }
}