public class ReturnToBaseCommand : ICommand
{
    private readonly RobotVacuum _robotVacuum;

    public ReturnToBaseCommand(RobotVacuum robotVacuum)
    {
        _robotVacuum = robotVacuum;
    }

    public void Execute()
    {
        _robotVacuum.ReturnToBase();
    }
}