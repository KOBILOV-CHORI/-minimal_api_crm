namespace MinimalApiClasswork.Services;

public interface IStudentGroupService
{
    IEnumerable<StudentGroup> GetAllStudentGroups();
    bool DeleteStudentGroup(int id);
    bool UpdateStudentGroup(StudentGroup studentGroup);
    bool AddStudentGroup(StudentGroup studentGroup);
    StudentGroup? GetStudentGroupById(int id);
}
