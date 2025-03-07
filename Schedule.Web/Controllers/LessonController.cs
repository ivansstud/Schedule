using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Schedule.Core.Models;
using Schedule.Infrastracture.EF;

namespace Schedule.Web.Controllers;

[Route("api/[controller]")]
[ApiController]
public class LessonController : ControllerBase
{
	private readonly AppDbContext _context;

	public LessonController(AppDbContext context)
	{
		_context = context;
	}

	[HttpGet("[action]")]
	public ActionResult<Lesson[]> GetAllByGroupId(long groupId)
	{
		var a = _context.Lessons.ToArray();
		return a.Where(x => x.GroupId == groupId).ToArray();
	}
}
