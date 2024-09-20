using Dapper;
using Npgsql;

namespace MinimalApiClasswork.Services;

public class StudentGroupService : IStudentGroupService
{
    public IEnumerable<StudentGroup> GetAllStudentGroups()
    {
        try
        {
            using (NpgsqlConnection connection = new NpgsqlConnection(SqlCommands.ConnectionString))
            {
                connection.Open();
                return connection.Query<StudentGroup>(SqlCommands.GetAllStudentGroups);
            }
        }
        catch (NpgsqlException e)
        {
            Console.WriteLine(e.Message);
            throw;
        }
    }   

    public StudentGroup? GetStudentGroupById(int id)
    {
        try
        {
            using ( NpgsqlConnection conn = new NpgsqlConnection(SqlCommands.ConnectionString))
            {
                conn.Open();
                return conn.QueryFirstOrDefault<StudentGroup>(SqlCommands.GetStudentGroupById, new { Id = id });
            }
            
        }
        catch (NpgsqlException e)
        {
            Console.WriteLine(e.Message);
            throw;
        }
    }

    public bool AddStudentGroup(StudentGroup studentGroup)
    {
        try
        {
            using (NpgsqlConnection connection= new NpgsqlConnection(SqlCommands.ConnectionString))
            {
                connection.Open();
                return connection.Execute(SqlCommands.AddStudentGroup, studentGroup) > 0;
            }
        }
        catch (NpgsqlException e)
        {
            Console.WriteLine(e.Message);
            throw;
        }
    }

    public bool UpdateStudentGroup(StudentGroup studentGroup)
    {
        try
        {
            using (NpgsqlConnection connection= new NpgsqlConnection(SqlCommands.ConnectionString))
            {
                connection.Open();
                return connection.Execute(SqlCommands.UpdateStudentGroup, studentGroup) > 0;
            }
        }
        catch (NpgsqlException e)
        {
            Console.WriteLine(e.Message);
            throw;
        }
    }

    public bool DeleteStudentGroup(int id)
    {
        try
        {
            using (NpgsqlConnection connection= new NpgsqlConnection(SqlCommands.ConnectionString))
            {
                connection.Open();
                return connection.Execute(SqlCommands.DeleteStudentGroup, new {Id=id}) > 0;
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

    public const string GetAllStudentGroups = "SELECT * FROM studentGroups";
    public const string GetStudentGroupById = "SELECT * FROM studentGroups WHERE id = @id";
    public const string AddStudentGroup = "INSERT INTO studentGroups (studentid,groupid) VALUES (@studentid,@groupid)";
    public const string UpdateStudentGroup = "UPDATE studentGroups SET studentid = @studentid, groupid = @groupid WHERE id = @id";
    public const string DeleteStudentGroup = "DELETE FROM studentGroups WHERE id = @id";
}
