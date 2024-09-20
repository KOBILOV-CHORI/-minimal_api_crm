namespace MinimalApiClasswork.Services;

public interface ICourseService
{
    IEnumerable<Course> GetAllCourses();
    bool DeleteCourse(int id);
    bool UpdateCourse(Course course);
    bool AddCourse(Course course);
    Course? GetCourseById(int id);
}
