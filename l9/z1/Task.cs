public class Task
{
    public int Id { get; set; }
    public string Title { get; set; }
    public int Priority { get; set; }

    public Task(int id, string title, int priority)
    {
        Id = id;
        Title = title;
        Priority = priority;
    }

    public override string ToString()
    {
        return $"ID: {Id}, Title: {Title}, Priority: {Priority}";
    }
}