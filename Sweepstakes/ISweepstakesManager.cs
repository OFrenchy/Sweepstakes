using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace Sweepstakes
{
    public interface ISweepstakesManager
    {
        Sweepstakes GetSweepstakes(int sweepstakesID);

        void InsertSweepstakes(Sweepstakes sweepstakes);

        //public Sweepstakes RemoveSweepstakes();

        int Count { get; }
    }
}