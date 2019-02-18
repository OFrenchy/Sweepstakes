﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sweepstakes
{
    public class SweepstakesQueueManager : ISweepstakesManager
    {
        Queue queue;
        public SweepstakesQueueManager()
        {
            // create queue
            queue = new Queue();
        }

        public void InsertSweepstakes(Sweepstakes sweepstakes)
        {
            queue.Enqueue(sweepstakes);
        }
        public Sweepstakes GetSweepstakes(int sweepstakesID)
        {
            foreach (Sweepstakes sweepstakes in queue)
            {
                if (sweepstakes.SweepstakesID.Equals(sweepstakesID))
                {
                    return sweepstakes;
                }
            }
            return null;
        }
        public int Count
        {
            get => queue.Count;
        }
    }
}