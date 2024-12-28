using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DDIAPI.Models;

namespace DDIAPI.Controllers
{
    public class DrugCategoryController : Controller
    {
        private readonly DDIAPIContext _context;

        public DrugCategoryController(DDIAPIContext context)
        {
            _context = context;
        }

        // GET: api/DrugCategory
        [HttpGet]
        [Route("api/DrugCategory")]
        public async Task<IActionResult> Index()
        {
            return Json(await _context.drugCategories.ToListAsync());
        }

        // GET: api/DrugCategory/{id}
        [HttpGet]
        [Route("api/DrugCategory/{id}")]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var drugCategory = await _context.drugCategories
                .FirstOrDefaultAsync(m => m.Id == id);

            if (drugCategory == null)
            {
                return NotFound();
            }

            return Json(drugCategory);
        }

        // POST: api/DrugCategory/Create
        [HttpPost]
        [Route("api/DrugCategory/Create")]
        public async Task<IActionResult> Create([FromBody] DrugCategory drugCategory)
        {
            _context.drugCategories.Add(drugCategory);
            await _context.SaveChangesAsync();
            return Ok(drugCategory);
        }

        // PUT: api/DrugCategory/Edit/{id}
        [HttpPut]
        [Route("api/DrugCategory/Edit/{id}")]
        public async Task<IActionResult> Edit(int id, [FromBody] DrugCategory drugCategory)
        {
            if (id != drugCategory.Id)
            {
                return NotFound();
            }

            try
            {
                _context.Update(drugCategory);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DrugExists(drugCategory.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Ok(drugCategory);
        }

        // DELETE: api/DrugCategory/Delete/{id}
        [HttpDelete]
        [Route("api/DrugCategory/Delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var drugCategory = await _context.drugCategories.FindAsync(id);
            if (drugCategory == null)
            {
                return NotFound();
            }

            _context.drugCategories.Remove(drugCategory);
            await _context.SaveChangesAsync();
            return Ok(drugCategory);
        }

        private bool DrugExists(int id)
        {
            return _context.drugCategories.Any(e => e.Id == id);
        }
    }
}