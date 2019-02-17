using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sweepstakes
{
    public class ISweepstakesManager
    {
        public string sweepstakesName;
        public string sweepstakesDescription;
        public string grandPrize;


        public void ContactContestants(Sweepstakes thisSS)
        {
            foreach (KeyValuePair<int, Contestant> kvp in thisSS.Contestants )
            {

                Console.WriteLine("Key = {0}, Value = {1}", kvp.Key, kvp.Value);
            }
        }
        

    }
}