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
public class DrugCategoryController : Controller {
    private readonly DDIAPIContext _context;
    public DrugCategoryController(DDIAPIContext context) {
        _context = context;
    }
    // GET: api/DrugCategory
    [HttpGet]
    [Route("api/DrugCategory")]
    public async Task<IActionResult> Index() {
        return Json(await _context.drugCategories.ToListAsync());
    }
    [HttpGet]
    [Route("api/DrugCategory/{id}")]
    // GET: DrugCategory/Details/5
    public async Task<IActionResult> Details(int? id) {
        if (id == null) {
            return NotFound();
        }
        var drug = await _context.drugCategories
            .FirstOrDefaultAsync(m => m.Id == id);
        if (drug == null) {
            return NotFound();
        }
        return Json(drug);
    }
    // POST: DrugCategory/Create
[HttpPost]
[Route("api/DrugCategory/Create")]
public async Task<IActionResult> Create(DrugCategory drugCategory)
{
        _context.drugCategories.Add(drugCategory);
        await _context.SaveChangesAsync();
        return Ok(drugCategory);
    
}
    // POST: DrugCategory/Edit/5
    [HttpPut]
    [Route("api/DrugCategory/Edit/{id}")]
    public async Task<IActionResult> Edit(int id, DrugCategory drugCategory) {
        if (id != drugCategory.Id) {
            return NotFound();
        }
            try {
                _context.Update(drugCategory);
                await _context.SaveChangesAsync();
            } catch (DbUpdateConcurrencyException) {
                if (!DrugExists(drugCategory.Id)) {
                    return NotFound();
                } else {
                    throw;
                }
            }
        return Ok(drugCategory);
    }
    // POST: DrugCategory/Delete/5
    [HttpDelete]
    [Route("api/DrugCategory/Delete/{id}")]
    public async Task<IActionResult> Delete(int id) {
        var drugCategory = await _context.drugCategories.FindAsync(id);
        if (drugCategory == null) {
            return NotFound();
        }
        _context.drugCategories.Remove(drugCategory);
        await _context.SaveChangesAsync();
        return Ok(drugCategory);
    }
    private bool DrugExists(int id) {
        return _context.drugCategories.Any(e => e.Id == id);
    }
}