using Dapper;
using Npgsql;

namespace MinimalApiClasswork.Services;

public class MentorGroupService : IMentorGroupService
{
    public IEnumerable<MentorGroup> GetAllMentorGroups()
    {
        try
        {
            using (NpgsqlConnection connection = new NpgsqlConnection(SqlCommands.ConnectionString))
            {
                connection.Open();
                return connection.Query<MentorGroup>(SqlCommands.GetAllMentorGroups);
            }
        }
        catch (NpgsqlException e)
        {
            Console.WriteLine(e.Message);
            throw;
        }
    }   

    public MentorGroup? GetMentorGroupById(int id)
    {
        try
        {
            using ( NpgsqlConnection conn = new NpgsqlConnection(SqlCommands.ConnectionString))
            {
                conn.Open();
                return conn.QueryFirstOrDefault<MentorGroup>(SqlCommands.GetMentorGroupById, new { Id = id });
            }
            
        }
        catch (NpgsqlException e)
        {
            Console.WriteLine(e.Message);
            throw;
        }
    }

    public bool AddMentorGroup(MentorGroup mentorGroup)
    {
        try
        {
            using (NpgsqlConnection connection= new NpgsqlConnection(SqlCommands.ConnectionString))
            {
                connection.Open();
                return connection.Execute(SqlCommands.AddMentorGroup, mentorGroup) > 0;
            }
        }
        catch (NpgsqlException e)
        {
            Console.WriteLine(e.Message);
            throw;
        }
    }

    public bool UpdateMentorGroup(MentorGroup mentorGroup)
    {
        try
        {
            using (NpgsqlConnection connection= new NpgsqlConnection(SqlCommands.ConnectionString))
            {
                connection.Open();
                return connection.Execute(SqlCommands.UpdateMentorGroup, mentorGroup) > 0;
            }
        }
        catch (NpgsqlException e)
        {
            Console.WriteLine(e.Message);
            throw;
        }
    }

    public bool DeleteMentorGroup(int id)
    {
        try
        {
            using (NpgsqlConnection connection= new NpgsqlConnection(SqlCommands.ConnectionString))
            {
                connection.Open();
                return connection.Execute(SqlCommands.DeleteMentorGroup, new {Id=id}) > 0;
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

    public const string GetAllMentorGroups = "SELECT * FROM mentorGroups";
    public const string GetMentorGroupById = "SELECT * FROM mentorGroups WHERE id = @id";
    public const string AddMentorGroup = "INSERT INTO mentorGroups (mentorid,groupid) VALUES (@mentorid,@groupid)";
    public const string UpdateMentorGroup = "UPDATE mentorGroups SET mentorid = @mentorid, groupid = @groupid WHERE id = @id";
    public const string DeleteMentorGroup = "DELETE FROM mentorGroups WHERE id = @id";
}
