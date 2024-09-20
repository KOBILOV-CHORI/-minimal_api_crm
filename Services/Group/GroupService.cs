using Dapper;
using Npgsql;

namespace MinimalApiClasswork.Services;

public class GroupService : IGroupService
{
    public IEnumerable<Group> GetAllGroups()
    {
        try
        {
            using (NpgsqlConnection connection = new NpgsqlConnection(SqlCommands.ConnectionString))
            {
                connection.Open();
                return connection.Query<Group>(SqlCommands.GetAllGroups);
            }
        }
        catch (NpgsqlException e)
        {
            Console.WriteLine(e.Message);
            throw;
        }
    }   

    public Group? GetGroupById(int id)
    {
        try
        {
            using ( NpgsqlConnection conn = new NpgsqlConnection(SqlCommands.ConnectionString))
            {
                conn.Open();
                return conn.QueryFirstOrDefault<Group>(SqlCommands.GetGroupById, new { Id = id });
            }
            
        }
        catch (NpgsqlException e)
        {
            Console.WriteLine(e.Message);
            throw;
        }
    }

    public bool AddGroup(Group group)
    {
        try
        {
            using (NpgsqlConnection connection= new NpgsqlConnection(SqlCommands.ConnectionString))
            {
                connection.Open();
                return connection.Execute(SqlCommands.AddGroup, group) > 0;
            }
        }
        catch (NpgsqlException e)
        {
            Console.WriteLine(e.Message);
            throw;
        }
    }

    public bool UpdateGroup(Group group)
    {
        try
        {
            using (NpgsqlConnection connection= new NpgsqlConnection(SqlCommands.ConnectionString))
            {
                connection.Open();
                return connection.Execute(SqlCommands.UpdateGroup, group) > 0;
            }
        }
        catch (NpgsqlException e)
        {
            Console.WriteLine(e.Message);
            throw;
        }
    }

    public bool DeleteGroup(int id)
    {
        try
        {
            using (NpgsqlConnection connection= new NpgsqlConnection(SqlCommands.ConnectionString))
            {
                connection.Open();
                return connection.Execute(SqlCommands.DeleteGroup, new {Id=id}) > 0;
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

    public const string GetAllGroups = "SELECT * FROM groups";
    public const string GetGroupById = "SELECT * FROM groups WHERE id = @id";
    public const string AddGroup = "INSERT INTO groups (name,maxstudent,createdat,lessonperweek,courseid) VALUES (@name,@maxstudent,@createdat,@lessonperweek,@courseid)";
    public const string UpdateGroup = "UPDATE groups SET name = @name, maxstudent = @maxstudent, createdat = @createdat, lessonperweek =@lessonperweek, courseid = @courseid WHERE id = @id";
    public const string DeleteGroup = "DELETE FROM groups WHERE id = @id";
}
