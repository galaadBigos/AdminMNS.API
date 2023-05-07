using AdminMNS.API.Abstractions;
using AdminMNS.API.Domain.DTO;
using AdminMNS.API.Domain.Services;
using AdminMNS.API.Models;
using Microsoft.AspNetCore.Mvc;

namespace AdminMNS.API.Controllers
{
	[ApiController]
	[Route("graduating-class")]
	public class GraduatingClassController : Controller
	{
		private readonly IGraduatingClassService _graduatingClassService;

		public GraduatingClassController(IGraduatingClassService graduatingClassService)
		{
			_graduatingClassService = graduatingClassService;
		}

		[HttpGet]
		[Route("")]
		public IEnumerable<GraduatingClass>? GetGraduatingClasses()
		{
			return _graduatingClassService.GetGraduatingClasses();
		}

		[HttpGet]
		[Route("id={id}")]
		public GraduatingClass? GetGraduatingClassById(int id)
		{
			return _graduatingClassService.GetGraduatingClassById(id);
		}
	}
}
