namespace MinimalApiClasswork.Services;

public interface IMentorGroupService
{
    IEnumerable<MentorGroup> GetAllMentorGroups();
    bool DeleteMentorGroup(int id);
    bool UpdateMentorGroup(MentorGroup MentorGroup);
    bool AddMentorGroup(MentorGroup MentorGroup);
    MentorGroup? GetMentorGroupById(int id);
}
