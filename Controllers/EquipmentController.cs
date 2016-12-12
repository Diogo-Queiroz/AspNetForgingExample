using ForgingAhead.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;

namespace ForgingAhead.Controllers
{
	public class EquipmentController : Controller
	{
		private readonly ApplicationDbContext _context;

		public EquipmentController(ApplicationDbContext context)
		{
			_context =  context;
		}

		public IActionResult Index() 
		{
			ViewData["Title"] = "List fo Equipments";
			var model = _context.Equipments.OrderBy(c => c.ID).ToList();
			return View(model);
		}

		public IActionResult Details(int id)
		{
			ViewData["Title"] = "Details of Equipment";
			var model = _context.Equipments.FirstOrDefault(c => c.ID == id);
			return View(model);
		}

		public IActionResult Create()
		{
			ViewData["Title"] = "Create new Equipment";
			return View();
		}

		[HttpPost]
		public IActionResult Create(Equipment equipment)
		{
			_context.Equipments.Add(equipment);
			_context.SaveChanges();
			return RedirectToAction("Index");
		}

		public IActionResult Update(int id)
		{
			ViewData["Title"] = "Update equipment";
			var model = _context.Equipments.FirstOrDefault(c => c.ID == id);
			return View(model);
		}

		[HttpPost]
		public IActionResult Update(Equipment equipment)
		{
			_context.Entry(equipment).State = EntityState.Modified;
			_context.SaveChanges();
			return RedirectToAction("Index");
		}

		public IActionResult Delete(int id)
		{
			var original = _context.Equipments.FirstOrDefault(c => c.ID == id);
			if (original != null)
			{
				_context.Equipments.Remove(original);
				_context.SaveChanges();
			}
			return RedirectToAction("Index");
		}
	}
}