﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sweepstakes
{
    public class SweepstakesStackManager : ISweepstakesManager
    {
        public SweepstakesStackManager()
        {
            // create stack

        }

        public void InsertSweepstakes(Sweepstakes sweepstakes)
        {

        }
        public Sweepstakes GetSweepstakes()
        {
            Sweepstakes sweepstakesFound = new Sweepstakes("", 1, "", "", "",
                 DateTime.Parse("1/1/2010"), DateTime.Parse("1/1/2010"), DateTime.Parse("1/1/2010"),
                 "", "", "", "", "");

            return sweepstakesFound;
        }
    }
}
