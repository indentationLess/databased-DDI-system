using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DDIAPI.Models;
namespace DDIAPI.Controllers;
public class UserController : Controller {
    private readonly DDIAPIContext _context;
    public UserController(DDIAPIContext context) {
        _context = context;
    }
    // GET: User
    public async Task<IActionResult> Index() {
        return View(await _context.users.ToListAsync());
    }
    // GET: User/Details/5
    public async Task<IActionResult> Details(int? id) {
        if (id == null) {
            return NotFound();
        }
        var user = await _context.users
            .FirstOrDefaultAsync(m => m.id == id);
        if (user == null) {
            return NotFound();
        }
        return View(user);
    }
    // GET: User/Create
    public IActionResult Create() {
        return View();
    }
    // POST: User/Create
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("id,firstName,lastName,email,phone,role,username,password")] User user) {
        if (ModelState.IsValid) {
            _context.Add(user);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        return View(user);
    }
    // GET: User/Edit/5
    public async Task<IActionResult> Edit(int? id) {
        if (id == null) {
            return NotFound();
        }
        var user = await _context.users.FindAsync(id);
        if (user == null) {
            return NotFound();
        }
        return View(user);
    }
    // POST: User/Edit/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, [Bind("id,firstName,lastName,email,phone,role,username,password")] User user) {
        if (id != user.id) {
            return NotFound();
        }
        if (ModelState.IsValid) {
            try {
                _context.Update(user);
                await _context.SaveChangesAsync();
            } catch (DbUpdateConcurrencyException) {
                if (!UserExists(user.id)) {
                    return NotFound();
                } else {
                    throw;
                }
            }
            return RedirectToAction(nameof(Index));
        }
        return View(user);
    }
    private bool UserExists(int id) {
        return _context.users.Any(e => e.id == id);
    }
    // GET: User/Delete/5
    public async Task<IActionResult> Delete(int? id) {
        if (id == null) {
            return NotFound();
        }
        var user = await _context.users
            .FirstOrDefaultAsync(m => m.id == id);
            return View(user);
    }
}
