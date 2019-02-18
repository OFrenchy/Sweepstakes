using System;
using System.Collections;
using System.Linq;
//using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;

using System.Collections.Generic;

using System.Text;



namespace Sweepstakes
{
    class Program
    {
        static void Main(string[] args)
        {

            StringReader stringReader = new StringReader("n"); // n = select Queue mgr, y = select Stack mgr
            Console.SetIn(stringReader);
            
            MarketingFirm marketingFirm = new MarketingFirm();

            stringReader = new StringReader("Spring Green Contest"); // name
            Console.SetIn(stringReader);
            stringReader = new StringReader("Your chance to win $1000"); // description
            Console.SetIn(stringReader);
            stringReader = new StringReader("$1000");   // prize
            Console.SetIn(stringReader);
            stringReader = new StringReader("Acme, Inc.");  // client company
            Console.SetIn(stringReader);
            stringReader = new StringReader("2/1/2019"); // start date
            Console.SetIn(stringReader);
            stringReader = new StringReader("2/17/2019 11:59 pm"); // end date/time
            Console.SetIn(stringReader);
            stringReader = new StringReader("2/18/2019 8:00 am"); // end date/time
            Console.SetIn(stringReader);

            marketingFirm.CreateNewSweepstakes();

            
            // launch user interface?




            Console.WriteLine("Hello World!");
        }
    }
}
