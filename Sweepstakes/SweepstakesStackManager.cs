using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sweepstakes
{
    public class SweepstakesStackManager : ISweepstakesManager
    {
        protected Stack stack;

        public SweepstakesStackManager()
        {
            // create stack
            stack = new Stack();
        }

        public void InsertSweepstakes(Sweepstakes sweepstakes)
        {
            try { stack.Push(sweepstakes); }
            catch (Exception thisException)
            {
                string exceptionMessage = thisException.ToString();
                if (thisException.Equals(new StackOverflowException()))
                {
                    UserInterface.displayMessage("The stack of sweepstakes is full - you must remove one or more before you can add another.", true);
                }
            }
        }
        public Sweepstakes GetSweepstakes(int sweepstakesID)
        {
            foreach (Sweepstakes sweepstakes in stack)
            {
                if (sweepstakes.SweepstakesID.Equals(sweepstakesID))
                {
                    return sweepstakes;
                }
            }
            return null;
        }
        public int Count { get { return stack.Count; } }

    }
}
