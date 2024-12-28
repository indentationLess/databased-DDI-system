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
public class PatientController : Controller {
    private readonly DDIAPIContext _context;
    public PatientController(DDIAPIContext context) {
        _context = context;
    }
    // GET: api/Patient
    [HttpGet]
    [Route("api/Patient")]
    public async Task<IActionResult> Index() {
        return Json(await _context.patients.ToListAsync());
    }
    [HttpGet]
    [Route("api/Patient/{id}")]
    // GET: Patient/Details/5
    public async Task<IActionResult> Details(int? id) {
        if (id == null) {
            return NotFound();
        }
        var patient = await _context.patients
            .FirstOrDefaultAsync(m => m.Id == id);
        if (patient == null) {
            return NotFound();
        }
        return Json(patient);
    }
    // POST: Patient/Create
    [HttpPost]
    [Route("api/Patient/Create")]
    public async Task<IActionResult> Create(Patient patient)
{
    patient.Id = 0; // Reset Id to ensure database auto-generates it
    _context.patients.Add(patient);
    await _context.SaveChangesAsync();
    return Ok(patient);
}
    // POST: Patient/Edit/5
    [HttpPut]
    [Route("api/Patient/Edit/{id}")]
    public async Task<IActionResult> Edit(int id, Patient patient) {
        if (id != patient.Id) {
            return NotFound();
        }
            try {
                _context.Update(patient);
                await _context.SaveChangesAsync();
            } catch (DbUpdateConcurrencyException) {
                if (!PatientExists(patient.Id)) {
                    return NotFound();
                } else {
                    throw;
                }
            }
        return Json(patient);
    }
    private bool PatientExists(int id) {
        return _context.patients.Any(e => e.Id == id);
    }
}