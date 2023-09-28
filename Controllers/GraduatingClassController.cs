using AdminMNS.API.Abstractions;
using AdminMNS.API.App_Code.Exceptions;
using AdminMNS.API.Domain.DTO;
using AdminMNS.API.Domain.Services;
using AdminMNS.API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using System.Net;

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
		public IActionResult GetGraduatingClasses()
		{
			try
			{
				IEnumerable<GraduatingClass>? result = _graduatingClassService.GetGraduatingClasses();
				return result != null ? Ok(result) : NoContent();
			}
			catch (SqlException ex)
			{
				return BadRequest(ErrorMessageHelper.DisplayErrorMessage(ex.Message, ex.Number));
			}
		}

		[HttpGet]
		[Route("id={id}")]
		public IActionResult GetGraduatingClassById(int id)
		{
			try
			{
				GraduatingClass? result = _graduatingClassService.GetGraduatingClassById(id);
				return result != null ? Ok(result) : NoContent();
			}
			catch (SqlException ex)
			{
				return BadRequest(ErrorMessageHelper.DisplayErrorMessage(ex.Message, ex.Number));
			}
		}

		[HttpPost]
		[Route("create")]
		public IActionResult PostGraduatingClass(GraduatingClassItemDTO graduatingClass)
		{
			try
			{
				_graduatingClassService.PostNewGraduatingClass(graduatingClass);
				return Ok();
			}
			catch (SqlException ex)
			{
				return BadRequest(ErrorMessageHelper.DisplayErrorMessage(ex.Message, ex.Number));
			}
			catch (InsertSqlException ex)
			{
				return  BadRequest(ErrorMessageHelper.DisplayErrorMessage(ex.Message));
			}
		}

		[HttpPut]
		[Route("update")]
		public IActionResult UpdateGraduatingClass(GraduatingClassItemDTO graduatingClass)
		{
			try
			{
				_graduatingClassService.UpdateGraduatingClass(graduatingClass);
				return Ok();
			}
			catch (SqlException ex)
			{
				return BadRequest(ErrorMessageHelper.DisplayErrorMessage(ex.Message, ex.Number));
			}
			catch (InsertSqlException ex)
			{
				return BadRequest(ErrorMessageHelper.DisplayErrorMessage(ex.Message));
			}
		}

		[HttpDelete]
		[Route("delete")]
		public IActionResult DeleteGraduatingClass(int id)
		{
			try
			{
				_graduatingClassService.DeleteGraduatingClassById(id);

				return Ok();
			}
			catch (SqlException ex)
			{
				return BadRequest(ErrorMessageHelper.DisplayErrorMessage(ex.Message, ex.Number));
			}
			catch (InsertSqlException ex)
			{
				return BadRequest(ErrorMessageHelper.DisplayErrorMessage(ex.Message));
			}
		}
	}
}
