using Dapper;
using Npgsql;

namespace MinimalApiClasswork.Services;

public class CourseService : ICourseService
{
    public IEnumerable<Course> GetAllCourses()
    {
        try
        {
            using (NpgsqlConnection connection = new NpgsqlConnection(SqlCommands.ConnectionString))
            {
                connection.Open();
                return connection.Query<Course>(SqlCommands.GetAllCourses);
            }
        }
        catch (NpgsqlException e)
        {
            Console.WriteLine(e.Message);
            throw;
        }
    }   

    public Course? GetCourseById(int id)
    {
        try
        {
            using ( NpgsqlConnection conn = new NpgsqlConnection(SqlCommands.ConnectionString))
            {
                conn.Open();
                return conn.QueryFirstOrDefault<Course>(SqlCommands.GetCourseById, new { Id = id });
            }
            
        }
        catch (NpgsqlException e)
        {
            Console.WriteLine(e.Message);
            throw;
        }
    }

    public bool AddCourse(Course course)
    {
        try
        {
            using (NpgsqlConnection connection= new NpgsqlConnection(SqlCommands.ConnectionString))
            {
                connection.Open();
                return connection.Execute(SqlCommands.AddCourse, course) > 0;
            }
        }
        catch (NpgsqlException e)
        {
            Console.WriteLine(e.Message);
            throw;
        }
    }

    public bool UpdateCourse(Course course)
    {
        try
        {
            using (NpgsqlConnection connection= new NpgsqlConnection(SqlCommands.ConnectionString))
            {
                connection.Open();
                return connection.Execute(SqlCommands.UpdateCourse, course) > 0;
            }
        }
        catch (NpgsqlException e)
        {
            Console.WriteLine(e.Message);
            throw;
        }
    }

    public bool DeleteCourse(int id)
    {
        try
        {
            using (NpgsqlConnection connection= new NpgsqlConnection(SqlCommands.ConnectionString))
            {
                connection.Open();
                return connection.Execute(SqlCommands.DeleteCourse, new {Id=id}) > 0;
            }
        }
        catch (NpgsqlException e)
        {
            Console.WriteLine(e.Message);
            throw;
        }
    }
}

file class SqlCommands
{
    public const string ConnectionString =
        "Server=localhost;Port=5432;Database=crm_crud_db;User Id=postgres;Password=01062007;";

    public const string GetAllCourses = "SELECT * FROM courses";
    public const string GetCourseById = "SELECT * FROM courses WHERE id = @id";
    public const string AddCourse = "INSERT INTO courses (name,price,createdat) VALUES (@name,@price,@createdat)";
    public const string UpdateCourse = "UPDATE courses SET name = @name, price = @price, createdat = @createdat WHERE id = @id";
    public const string DeleteCourse = "DELETE FROM courses WHERE id = @id";
}
