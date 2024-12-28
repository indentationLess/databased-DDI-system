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
    // GET: api/User
    [HttpGet]
    [Route("api/User")]
    public async Task<IActionResult> Index() {
        return Json(await _context.users.ToListAsync());
    }
    [HttpGet]
    [Route("api/User/{id}")]
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
        return Json(user);
    }
    // POST: User/Create
    [HttpPost]
    [Route("api/User/Create")]
    public async Task<IActionResult> Create( User user) {
         _context.Add(user);
        await _context.SaveChangesAsync();
        
        return Json(user);
    }
    // POST: User/Edit/5
    [HttpPut]
    [Route("api/User/Edit/{id}")]
    public async Task<IActionResult> Edit(int id, User user) {
        if (id != user.id) {
            return NotFound();
        }
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
        return Json(user);
    }
    private bool UserExists(int id) {
        return _context.users.Any(e => e.id == id);
    }
    // GET: User/Delete/5
    [HttpDelete]
    [Route("api/User/Delete/{id}")]
    public async Task<IActionResult> Delete(int? id) {
    if (id == null) {
        return NotFound();
    }

    var user = await _context.users.FirstOrDefaultAsync(m => m.id == id);
    if (user == null) {
        return NotFound();
    }

    _context.users.Remove(user);
    await _context.SaveChangesAsync();

    return NoContent();
    }
}
