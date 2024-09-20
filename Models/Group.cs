public class Group
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public int MaxStudents { get; set; }
    public DateTime CreatedAt { get; set; }
    public int LessonsPerWeek { get; set; }
    public int CourseId { get; set; }
}