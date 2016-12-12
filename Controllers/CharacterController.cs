using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using ForgingAhead.Models;
using System.Linq;
using System.ComponentModel.DataAnnotations;

namespace ForgingAhead.Controllers
{
	public class CharacterController : Controller
	{
		private readonly ApplicationDbContext _context;

		public CharacterController(ApplicationDbContext context)
		{
			_context = context;
		}

		public IActionResult Index()
		{
			ViewData["Title"] = "Characters";
			var model = _context.Characters.OrderBy(e => e.Name).ToList();
			return View(model);
		}

		public IActionResult GetActive()
		{
			ViewData["Title"] = "Active Characters";
			var model = _context.Characters.Where(e => e.isActive).OrderBy(e => e.Name).ToList();
			return View("Index", model);
		}

		public IActionResult Details(string name)
		{
			var model = _context.Characters.FirstOrDefault(e => e.Name == name);
			return View(model);
		}
		
		public IActionResult Create() 
		{
			ViewData["Title"] = "Create Character";
			return View();
		}

		[HttpPost]
		public IActionResult Create(Character character)
		{
				_context.Characters.Add(character);
				_context.SaveChanges();
				return RedirectToAction("Index");
		}

		public IActionResult Update(int id) 
		{
			var model = _context.Characters.FirstOrDefault(e => e.ID == id);
			return View(model);
		}

		[HttpPost]
		public IActionResult Update(Character character)
		{
			_context.Entry(character).State = EntityState.Modified;
			_context.SaveChanges();
			return RedirectToAction("Index");
		}

		public IActionResult Delete(int id)
		{
			var original = _context.Characters.FirstOrDefault(e => e.ID == id);
			if(original != null)
			{
				_context.Characters.Remove(original);
				_context.SaveChanges();
			}
			return RedirectToAction("Index");
		}
	}
}