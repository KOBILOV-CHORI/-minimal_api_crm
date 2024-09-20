namespace MinimalApiClasswork.Services;

public interface IStudentService
{
    IEnumerable<Student> GetAllStudents();
    bool DeleteStudent(int id);
    bool UpdateStudent(Student student);
    bool AddStudent(Student student);
    Student? GetStudentById(int id);
}
