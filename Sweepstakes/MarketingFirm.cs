namespace Sweepstakes
{
    public class MarketingFirm
    {
        // Member variables
        ISweepstakesManager SSManager;


        // Constructor
        public MarketingFirm()
        {
            if (UserInterface.showWelcomeScreenGetManagementSelection() == "y")
            {
                SSManager = new SweepstakesStackManager();
            }
            else SSManager = new SweepstakesQueueManager();



        }

        // Member methods


    }
}