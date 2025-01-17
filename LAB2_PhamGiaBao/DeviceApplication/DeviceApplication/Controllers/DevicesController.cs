﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DeviceApplication.Data;
using DeviceApplication.Models;

namespace DeviceApplication.Controllers
{
	public class DevicesController : Controller
	{
		private readonly DeviceApplicationContext _context;

		public DevicesController(DeviceApplicationContext context)
		{
			_context = context;
		}

		// GET: Devices
		public async Task<IActionResult> Index(string searchString)
		{
			if (_context.Device == null)
			{
				return Problem("Null!!!");
			}

			var deviceApplicationContext = _context.Device.Include(d => d.Category).AsQueryable(); ;
			if (!string.IsNullOrEmpty(searchString))
			{
				deviceApplicationContext = deviceApplicationContext.Where(d => d.Name.Contains(searchString) ||
																		  d.Status.Contains(searchString) ||
																		 (d.Category != null && d.Category.Name.Contains(searchString)));
			}
			return View(await deviceApplicationContext.ToListAsync());
		}

		// GET: Devices/Details/5
		public async Task<IActionResult> Details(int? id)
		{
			if (id == null)
			{
				return NotFound();
			}

			var device = await _context.Device
				.Include(d => d.Category)
				.FirstOrDefaultAsync(m => m.Id == id);
			if (device == null)
			{
				return NotFound();
			}

			return View(device);
		}

		// GET: Devices/Create
		public IActionResult Create()
		{
			ViewData["CategoryId"] = new SelectList(_context.Category, "Id", "Id");
			return View();
		}

		// POST: Devices/Create
		// To protect from overposting attacks, enable the specific properties you want to bind to.
		// For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Create([Bind("Id,Name,CategoryId,Price,Status,DateOfEntry")] Device device)
		{
			if (ModelState.IsValid)
			{
				_context.Add(device);
				await _context.SaveChangesAsync();
				return RedirectToAction(nameof(Index));
			}
			ViewData["CategoryId"] = new SelectList(_context.Category, "Id", "Id", device.CategoryId);
			return View(device);
		}

		// GET: Devices/Edit/5
		public async Task<IActionResult> Edit(int? id)
		{
			if (id == null)
			{
				return NotFound();
			}

			var device = await _context.Device.FindAsync(id);
			if (device == null)
			{
				return NotFound();
			}
			ViewData["CategoryId"] = new SelectList(_context.Category, "Id", "Id", device.CategoryId);
			return View(device);
		}

		// POST: Devices/Edit/5
		// To protect from overposting attacks, enable the specific properties you want to bind to.
		// For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Edit(int id, [Bind("Id,Name,CategoryId,Price,Status,DateOfEntry")] Device device)
		{
			if (id != device.Id)
			{
				return NotFound();
			}

			if (ModelState.IsValid)
			{
				try
				{
					_context.Update(device);
					await _context.SaveChangesAsync();
				}
				catch (DbUpdateConcurrencyException)
				{
					if (!DeviceExists(device.Id))
					{
						return NotFound();
					}
					else
					{
						throw;
					}
				}
				return RedirectToAction(nameof(Index));
			}
			ViewData["CategoryId"] = new SelectList(_context.Category, "Id", "Id", device.CategoryId);
			return View(device);
		}

		// GET: Devices/Delete/5
		public async Task<IActionResult> Delete(int? id)
		{
			if (id == null)
			{
				return NotFound();
			}

			var device = await _context.Device
				.Include(d => d.Category)
				.FirstOrDefaultAsync(m => m.Id == id);
			if (device == null)
			{
				return NotFound();
			}

			return View(device);
		}

		// POST: Devices/Delete/5
		[HttpPost, ActionName("Delete")]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> DeleteConfirmed(int id)
		{
			var device = await _context.Device.FindAsync(id);
			if (device != null)
			{
				_context.Device.Remove(device);
			}

			await _context.SaveChangesAsync();
			return RedirectToAction(nameof(Index));
		}

		private bool DeviceExists(int id)
		{
			return _context.Device.Any(e => e.Id == id);
		}
	}
}
