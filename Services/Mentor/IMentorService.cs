namespace MinimalApiClasswork.Services;

public interface IMentorService
{
    IEnumerable<Mentor> GetAllMentors();
    bool DeleteMentor(int id);
    bool UpdateMentor(Mentor mentor);
    bool AddMentor(Mentor mentor);
    Mentor? GetMentorById(int id);
}
