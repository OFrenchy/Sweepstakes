using System;
using System.Collections;
using System.Linq;

namespace Sweepstakes
{
    public static class UserInterface
    {
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

        public static SweepstakesQueueManager SweepstakesQueueManager
        {
            get => default(Sweepstakes.SweepstakesQueueManager);
            set
            {
            }
        }

        public static SweepstakesStackManager SweepstakesStackManager
        {
            get => default(Sweepstakes.SweepstakesStackManager);
            set
            {
            }
        }

        public static Contestant NewContestant()
        {
            throw new System.NotImplementedException();
        }
    }
}