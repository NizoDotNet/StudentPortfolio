namespace Portfolio.Entities;

public class Class
{
    public string Id { get; set; }
    public IList<AppUser> Students { get; set; }
    public IList<Subject> Subjects { get; set; }
}
