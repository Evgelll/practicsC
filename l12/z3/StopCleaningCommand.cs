public class StopCleaningCommand : ICommand
{
    private readonly RobotVacuum _robotVacuum;

    public StopCleaningCommand(RobotVacuum robotVacuum)
    {
        _robotVacuum = robotVacuum;
    }

    public void Execute()
    {
        _robotVacuum.StopCleaning();
    }
}