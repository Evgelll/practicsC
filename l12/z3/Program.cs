class Program
{
    static void Main(string[] args)
    {
        RobotVacuum robotVacuum = new RobotVacuum();
        RobotController robotController = new RobotController();

        ICommand startCleaning = new StartCleaningCommand(robotVacuum);
        robotController.SetCommand(startCleaning);
        robotController.ExecuteCommand(); 

        ICommand stopCleaning = new StopCleaningCommand(robotVacuum);
        robotController.SetCommand(stopCleaning);
        robotController.ExecuteCommand(); 

        ICommand returnToBase = new ReturnToBaseCommand(robotVacuum);
        robotController.SetCommand(returnToBase);
        robotController.ExecuteCommand(); 
    }
}