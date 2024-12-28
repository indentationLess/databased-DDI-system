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
public class DrugController : Controller {
    private readonly DDIAPIContext _context;
    public DrugController(DDIAPIContext context) {
        _context = context;
    }
    // GET: api/Drug
    [HttpGet]
    [Route("api/Drug")]
    public async Task<IActionResult> Index() {
        return Json(await _context.drugs.ToListAsync());
    }
    [HttpGet]
    [Route("api/Drug/{id}")]
    // GET: Drug/Details/5
    public async Task<IActionResult> Details(int? id) {
        if (id == null) {
            return NotFound();
        }
        var drug = await _context.drugs
            .FirstOrDefaultAsync(m => m.Id == id);
        if (drug == null) {
            return NotFound();
        }
        return Json(drug);
    }
    // POST: Drug/Create
// POST: Drug/Create
[HttpPost]
[Route("api/Drug/Create")]
public async Task<IActionResult> Create(Drug drug)
{
        _context.drugs.Add(drug);
        await _context.SaveChangesAsync();
        return Ok(drug);
    
}
    // POST: Drug/Edit/5
    [HttpPut]
    [Route("api/Drug/Edit/{id}")]
    public async Task<IActionResult> Edit(int id, Drug drug) {
        if (id != drug.Id) {
            return NotFound();
        }
            try {
                _context.Update(drug);
                await _context.SaveChangesAsync();
            } catch (DbUpdateConcurrencyException) {
                if (!DrugExists(drug.Id)) {
                    return NotFound();
                } else {
                    throw;
                }
            }
        return Ok(drug);
    }
    // POST: Drug/Delete/5
    [HttpDelete]
    [Route("api/Drug/Delete/{id}")]
    public async Task<IActionResult> Delete(int id) {
        var drug = await _context.drugs.FindAsync(id);
        if (drug == null) {
            return NotFound();
        }
        _context.drugs.Remove(drug);
        await _context.SaveChangesAsync();
        return Ok(drug);
    }
    private bool DrugExists(int id) {
        return _context.drugs.Any(e => e.Id == id);
    }
}