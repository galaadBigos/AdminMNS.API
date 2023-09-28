using AdminMNS.API.Abstractions;
using AdminMNS.API.Domain.DTO;
using AdminMNS.API.Domain.Services;
using AdminMNS.API.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;

namespace AdminMNS.API.Controllers
{
	[ApiController]
	[Route("user")]
	public class UserController : Controller
	{
		private readonly IUserService _userService;

		public UserController(IUserService userService)
		{
			_userService = userService;
		}

		[HttpGet]
		[Route("")]
		public IEnumerable<UserItemDTO>? GetUsers()
		{
			return _userService.GetUserItemDTOs();
		}

		[HttpGet]
		[Route("id={id}")]
		public UserItemDTO? GetUser(int id)
		{
			return _userService.GetUserItemDTO(id);
		}

		[HttpGet]
		[Route("id-graduating-class={id}")]
		public List<UserItemDTO>? GetUsersByGraduatingClass(int id)
		{
			return _userService.GetUserItemDTOsByGraduatingClass(id);
		}

		[HttpPost]
		[Route("create")]
		public void PostUser(UserItemDTO userItemDTO)
		{
			_userService.PostNewUser(userItemDTO);
		}

		//[HttpPut]
		//[Route("update")]
		//public IActionResult UpdateUser()
		//{
		//	try
		//	{

		//	}
		//	catch (Exception)
		//	{

		//		throw;
		//	}
		//}

		[HttpDelete]
		[Route("delete")]
		public void DeleteUser(int id)
		{
			_userService.DeleteUser(id);
		}

		//// GET: UserController
		//public ActionResult Index()
		//{
		//	return View();
		//}

		//// GET: UserController/Details/5
		//public ActionResult Details(int id)
		//{
		//	return View();
		//}

		//// GET: UserController/Create
		//public ActionResult Create()
		//{
		//	return View();
		//}

		//// POST: UserController/Create
		//[HttpPost]
		//[ValidateAntiForgeryToken]
		//public ActionResult Create(IFormCollection collection)
		//{
		//	try
		//	{
		//		return RedirectToAction(nameof(Index));
		//	}
		//	catch
		//	{
		//		return View();
		//	}
		//}

		//// GET: UserController/Edit/5
		//public ActionResult Edit(int id)
		//{
		//	return View();
		//}

		//// POST: UserController/Edit/5
		//[HttpPost]
		//[ValidateAntiForgeryToken]
		//public ActionResult Edit(int id, IFormCollection collection)
		//{
		//	try
		//	{
		//		return RedirectToAction(nameof(Index));
		//	}
		//	catch
		//	{
		//		return View();
		//	}
		//}

		//// GET: UserController/Delete/5
		//public ActionResult Delete(int id)
		//{
		//	return View();
		//}

		//// POST: UserController/Delete/5
		//[HttpPost]
		//[ValidateAntiForgeryToken]
		//public ActionResult Delete(int id, IFormCollection collection)
		//{
		//	try
		//	{
		//		return RedirectToAction(nameof(Index));
		//	}
		//	catch
		//	{
		//		return View();
		//	}
		//}
	}
}
