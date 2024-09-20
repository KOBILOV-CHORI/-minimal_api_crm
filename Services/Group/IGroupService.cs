namespace MinimalApiClasswork.Services;

public interface IGroupService
{
    IEnumerable<Group> GetAllGroups();
    bool DeleteGroup(int id);
    bool UpdateGroup(Group group);
    bool AddGroup(Group group);
    Group? GetGroupById(int id);
}
