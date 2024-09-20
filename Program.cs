using Microsoft.AspNetCore.Mvc;
using MinimalApiClasswork.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

IStudentService studentService = new StudentService();
app.MapPost("/api/students", ([FromBody] Student student)=> studentService.AddStudent(student));
app.MapPut("/api/students", ([FromBody] Student student)=> studentService.UpdateStudent(student));
app.MapDelete("/api/students/{id}", ([FromRoute] int id)=> studentService.DeleteStudent(id));
app.MapGet("/api/students/{id}", ([FromRoute] int id) => studentService.GetStudentById(id));
app.MapGet("/api/students", ()=> studentService.GetAllStudents());

IMentorService mentorService = new MentorService();
app.MapPost("/api/mentors", ([FromBody] Mentor mentor)=> mentorService.AddMentor(mentor));
app.MapPut("/api/mentors", ([FromBody] Mentor mentor)=> mentorService.UpdateMentor(mentor));
app.MapDelete("/api/mentors/{id}", ([FromRoute] int id)=> mentorService.DeleteMentor(id));
app.MapGet("/api/mentors/{id}", ([FromRoute] int id) => mentorService.GetMentorById(id));
app.MapGet("/api/mentors", ()=> mentorService.GetAllMentors());

ICourseService courseService = new CourseService();
app.MapPost("/api/courses", ([FromBody] Course course)=> courseService.AddCourse(course));
app.MapPut("/api/courses", ([FromBody] Course course)=> courseService.UpdateCourse(course));
app.MapDelete("/api/courses/{id}", ([FromRoute] int id)=> courseService.DeleteCourse(id));
app.MapGet("/api/courses/{id}", ([FromRoute] int id) => courseService.GetCourseById(id));
app.MapGet("/api/courses", ()=> courseService.GetAllCourses());

IGroupService groupService = new GroupService();
app.MapPost("/api/groups", ([FromBody] Group group)=> groupService.AddGroup(group));
app.MapPut("/api/groups", ([FromBody] Group group)=> groupService.UpdateGroup(group));
app.MapDelete("/api/groups/{id}", ([FromRoute] int id)=> groupService.DeleteGroup(id));
app.MapGet("/api/groups/{id}", ([FromRoute] int id) => groupService.GetGroupById(id));
app.MapGet("/api/groups", ()=> groupService.GetAllGroups());

IMentorGroupService mentorGroupService = new MentorGroupService();
app.MapPost("/api/mentorGroups", ([FromBody] MentorGroup mentorGroup)=> mentorGroupService.AddMentorGroup(mentorGroup));
app.MapPut("/api/mentorGroups", ([FromBody] MentorGroup mentorGroup)=> mentorGroupService.UpdateMentorGroup(mentorGroup));
app.MapDelete("/api/mentorGroups/{id}", ([FromRoute] int id)=> mentorGroupService.DeleteMentorGroup(id));
app.MapGet("/api/mentorGroups/{id}", ([FromRoute] int id) => mentorGroupService.GetMentorGroupById(id));
app.MapGet("/api/mentorGroups", ()=> mentorGroupService.GetAllMentorGroups());

IStudentGroupService studentGroupService = new StudentGroupService();
app.MapPost("/api/studentGroups", ([FromBody] StudentGroup studentGroup)=> studentGroupService.AddStudentGroup(studentGroup));
app.MapPut("/api/studentGroups", ([FromBody] StudentGroup studentGroup)=> studentGroupService.UpdateStudentGroup(studentGroup));
app.MapDelete("/api/studentGroups/{id}", ([FromRoute] int id)=> studentGroupService.DeleteStudentGroup(id));
app.MapGet("/api/studentGroups/{id}", ([FromRoute] int id) => studentGroupService.GetStudentGroupById(id));
app.MapGet("/api/studentGroups", ()=> studentGroupService.GetAllStudentGroups());

app.UseHttpsRedirection();

app.Run();