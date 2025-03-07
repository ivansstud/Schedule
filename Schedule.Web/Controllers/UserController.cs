using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Schedule.Core.Enums;
using Schedule.Core.Models;
using Schedule.Core.ValueObjects;
using Schedule.Infrastracture.EF;

namespace Schedule.Web.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UserController : ControllerBase
{
    private readonly AppDbContext _context;

    public UserController(AppDbContext context)
    {
        _context = context;
    }

    [HttpGet("[action]")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public ActionResult<AppUser> GetUser(long id)
    {
        var result = _context.Users.FirstOrDefault(x => x.Id == id);
        if (result == null)
        {
            return NotFound();
        }
        return result;
    }

    public sealed class CreateUserRequest
    {
        public long TelegramId { get; set; }    
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }

    [HttpPost("[action]")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public ActionResult<AppUser> CreateUser(CreateUserRequest request)
    {
        var userName = UserName.Create(request.FirstName, request.LastName).Value;
        var newUser = AppUser.Create(request.TelegramId, userName).Value;
        var result = _context.Users.Add(newUser).Entity;

        _context.SaveChanges();

        return result;
    }

    [HttpGet("[action]")]
    public ActionResult<AppUser[]> GetUsers()
    {
        return _context.Users.Include(x => x.Groups).Include(x => x.CreatedGroups).ToArray();
    }

    [HttpGet("[action]")]
    public ActionResult<Lesson?> GetLesson(long id)
    {
        return _context.Lessons.FirstOrDefault(x => x.Id == id);
    }

    public sealed class CreateLessonRequest
    {
        public string Name { get; set; }
        public long GroupId { get; set; }
        public LessonWeekType WeekType { get; set; }
        public TimeOnly StartTime { get; set; }
        public TimeOnly EndTime { get; set; }
        public string DayOfWeek { get; set; }
        public string? LessonType { get; set; } = null;
        public string? Auditorium { get; set; } = null;
        public string? Description { get; set; } = null;
        public string? TeacherName { get; set; } = null;
    }

    [HttpPost("[action]")]
    public ActionResult<Lesson> CreateLesson(CreateLessonRequest request)
    {
        var lessonTime = LessonTime.Create(request.StartTime, request.EndTime).Value;
        var dayOfWeek = LessonDayOfWeek.Create(request.DayOfWeek).Value;
        var lessonType = LessonType.Create(request.LessonType).Value;

        var newLesson = Lesson.Create(
            name: request.Name,
            grpupId: request.GroupId,
            weekType: request.WeekType,
            lessonTime: lessonTime,
            dayOfWeek: dayOfWeek,
            lessonType: LessonType.Create(request.LessonType).Value,
            auditorium: request.Auditorium,
            description: request.Description,
            teacherName: request.TeacherName
            ).Value;

        var result = _context.Lessons.Add(newLesson).Entity;

        _context.SaveChanges();

        return result;
    }

    [HttpGet("[action]")]
    public ActionResult<Lesson[]> GetLessons()
    {
        return _context.Lessons.ToArray();
    }

    [HttpGet("[action]")]
    public ActionResult<Group?> GetGroup(long id)
    {
        return _context.Groups.FirstOrDefault(x => x.Id == id);
    }

    [HttpGet("[action]")]
    public ActionResult<Group[]> GetGroups()
    {
        return _context.Groups.Include(x => x.Lessons).Include(x => x.Creator).ToArray();
    }

    public sealed class CreateGroupRequest
    {
        public string Name { get; set; }
        public long CreatorId { get; set; }
        public string ScheduleFormat { get; set; }
        public string? InstitutionName { get; set; }
        public string? Description { get; set; }
    }

    [HttpPost("[action]")]
    public ActionResult<Group> CreateGroup(CreateGroupRequest request)
    {
        var scheduleFormat = ScheduleFormat.Create(request.ScheduleFormat).Value;

        var newLesson = Group.Create(
            name: request.Name,
            creatorId: request.CreatorId,
            scheduleFormat: scheduleFormat,
            institutionName: request.InstitutionName,
            description: request.Description
            ).Value;

        var result = _context.Groups.Add(newLesson).Entity;

        _context.SaveChanges();

        return result;
    }
}
