using Dapper;
using Npgsql;

namespace MinimalApiClasswork.Services;

public class StudentService : IStudentService
{
    public IEnumerable<Student> GetAllStudents()
    {
        try
        {
            using (NpgsqlConnection connection = new NpgsqlConnection(SqlCommands.ConnectionString))
            {
                connection.Open();
                return connection.Query<Student>(SqlCommands.GetAllStudents);
            }
        }
        catch (NpgsqlException e)
        {
            Console.WriteLine(e.Message);
            throw;
        }
    }   

    public Student? GetStudentById(int id)
    {
        try
        {
            using ( NpgsqlConnection conn = new NpgsqlConnection(SqlCommands.ConnectionString))
            {
                conn.Open();
                return conn.QueryFirstOrDefault<Student>(SqlCommands.GetStudentById, new { Id = id });
            }
            
        }
        catch (NpgsqlException e)
        {
            Console.WriteLine(e.Message);
            throw;
        }
    }

    public bool AddStudent(Student student)
    {
        try
        {
            using (NpgsqlConnection connection= new NpgsqlConnection(SqlCommands.ConnectionString))
            {
                connection.Open();
                return connection.Execute(SqlCommands.AddStudent, student) > 0;
            }
        }
        catch (NpgsqlException e)
        {
            Console.WriteLine(e.Message);
            throw;
        }
    }

    public bool UpdateStudent(Student student)
    {
        try
        {
            using (NpgsqlConnection connection= new NpgsqlConnection(SqlCommands.ConnectionString))
            {
                connection.Open();
                return connection.Execute(SqlCommands.UpdateStudent, student) > 0;
            }
        }
        catch (NpgsqlException e)
        {
            Console.WriteLine(e.Message);
            throw;
        }
    }

    public bool DeleteStudent(int id)
    {
        try
        {
            using (NpgsqlConnection connection= new NpgsqlConnection(SqlCommands.ConnectionString))
            {
                connection.Open();
                return connection.Execute(SqlCommands.DeleteStudent, new {Id=id}) > 0;
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

    public const string GetAllStudents = "SELECT * FROM students";
    public const string GetStudentById = "SELECT * FROM students WHERE id = @id";
    public const string AddStudent = "INSERT INTO students (firstname,lastname,dateofbirth,email) VALUES (@firstname,@lastname,@dateofbirth, @email)";
    public const string UpdateStudent = "UPDATE students SET firstname = @firstname, lastname = @lastname, dateofbirth = @dateofbirth, email = @email WHERE id = @id";
    public const string DeleteStudent = "DELETE FROM students WHERE id = @id";
}
