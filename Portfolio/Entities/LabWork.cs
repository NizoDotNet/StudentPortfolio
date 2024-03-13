namespace Portfolio.Entities;

public class LabWork
{
    public string Id { get; set; }
    public string Name { get; set; }
    public bool Completed { get; set; } = false;
    public string SubjectId { get; set; }
    public Subject Subject { get; set; }
}
