using Dapper;
using Npgsql;

namespace MinimalApiClasswork.Services;

public class MentorService : IMentorService
{
    public IEnumerable<Mentor> GetAllMentors()
    {
        try
        {
            using (NpgsqlConnection connection = new NpgsqlConnection(SqlCommands.ConnectionString))
            {
                connection.Open();
                return connection.Query<Mentor>(SqlCommands.GetAllMentors);
            }
        }
        catch (NpgsqlException e)
        {
            Console.WriteLine(e.Message);
            throw;
        }
    }   

    public Mentor? GetMentorById(int id)
    {
        try
        {
            using ( NpgsqlConnection conn = new NpgsqlConnection(SqlCommands.ConnectionString))
            {
                conn.Open();
                return conn.QueryFirstOrDefault<Mentor>(SqlCommands.GetMentorById, new { Id = id });
            }
            
        }
        catch (NpgsqlException e)
        {
            Console.WriteLine(e.Message);
            throw;
        }
    }

    public bool AddMentor(Mentor mentor)
    {
        try
        {
            using (NpgsqlConnection connection= new NpgsqlConnection(SqlCommands.ConnectionString))
            {
                connection.Open();
                return connection.Execute(SqlCommands.AddMentor, mentor) > 0;
            }
        }
        catch (NpgsqlException e)
        {
            Console.WriteLine(e.Message);
            throw;
        }
    }

    public bool UpdateMentor(Mentor mentor)
    {
        try
        {
            using (NpgsqlConnection connection= new NpgsqlConnection(SqlCommands.ConnectionString))
            {
                connection.Open();
                return connection.Execute(SqlCommands.UpdateMentor, mentor) > 0;
            }
        }
        catch (NpgsqlException e)
        {
            Console.WriteLine(e.Message);
            throw;
        }
    }

    public bool DeleteMentor(int id)
    {
        try
        {
            using (NpgsqlConnection connection= new NpgsqlConnection(SqlCommands.ConnectionString))
            {
                connection.Open();
                return connection.Execute(SqlCommands.DeleteMentor, new {Id=id}) > 0;
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

    public const string GetAllMentors = "SELECT * FROM Mentors";
    public const string GetMentorById = "SELECT * FROM Mentors WHERE id = @id";
    public const string AddMentor = "INSERT INTO Mentors (firstname,lastname,dateofbirth,email) VALUES (@FirstName,@LastName,@DateOfBirth, @email)";
    public const string UpdateMentor = "UPDATE Mentors SET firstname = @firstname, lastname = @lastname, dateofbirth = @dateofbirth, email = @email WHERE id = @id";
    public const string DeleteMentor = "DELETE FROM Mentors WHERE id = @id";
}
