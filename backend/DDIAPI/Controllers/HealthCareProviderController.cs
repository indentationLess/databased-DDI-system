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
public class HealthCareProviderController : Controller{
    private readonly DDIAPIContext _context;
    public HealthCareProviderController(DDIAPIContext context) {
        _context = context;
    }
    // GET: api/HealthCareProvider
    [HttpGet]
    [Route("api/HealthCareProvider")]
    public async Task<IActionResult> Index() {
        return Json(await _context.healthCareProviders.ToListAsync());
    }
    [HttpGet]
    [Route("api/HealthCareProvider/{id}")]
    // GET: HealthCareProvider/Details/5
    public async Task<IActionResult> Details(int? id) {
        if (id == null) {
            return NotFound();
        }
        var healthCareProvider = await _context.healthCareProviders
            .FirstOrDefaultAsync(m => m.Id == id);
        if (healthCareProvider == null) {
            return NotFound();
        }
        return Json(healthCareProvider);
    }
    // POST: HealthCareProvider/Create
    [HttpPost]
    [Route("api/HealthCareProvider/Create")]
    public async Task<IActionResult> Create( HealthCareProvider healthCareProvider) {
         _context.Add(healthCareProvider);
        await _context.SaveChangesAsync();
        
        return Json(healthCareProvider);
    }
    // POST: HealthCareProvider/Edit/5
    [HttpPut]
    [Route("api/HealthCareProvider/Edit/{id}")]
    public async Task<IActionResult> Edit(int id, HealthCareProvider healthCareProvider) {
        if (id != healthCareProvider.Id) {
            return NotFound();
        }
            try {
                _context.Update(healthCareProvider);
                await _context.SaveChangesAsync();
            } catch (DbUpdateConcurrencyException) {
                if (!HealthCareProviderExists(healthCareProvider.Id)) {
                    return NotFound();
                } else {
                    throw;
                }
            }
        return Json(healthCareProvider);
    }
    // POST: HealthCareProvider/Delete/5
    [HttpDelete]
    [Route("api/HealthCareProvider/Delete/{id}")]
    public async Task<IActionResult> Delete(int id) {
        var healthCareProvider = await _context.healthCareProviders.FindAsync(id);
        if (healthCareProvider == null) {
            return NotFound();
        }
        _context.healthCareProviders.Remove(healthCareProvider);
        await _context.SaveChangesAsync();
        return Json(healthCareProvider);
    }
    private bool HealthCareProviderExists(int id) {
        return _context.healthCareProviders.Any(e => e.Id == id);
    }
}