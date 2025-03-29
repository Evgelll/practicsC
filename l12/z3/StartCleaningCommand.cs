public class StartCleaningCommand : ICommand
{
    private readonly RobotVacuum _robotVacuum;

    public StartCleaningCommand(RobotVacuum robotVacuum)
    {
        _robotVacuum = robotVacuum;
    }

    public void Execute()
    {
        _robotVacuum.StartCleaning();
    }
}