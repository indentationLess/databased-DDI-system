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
    public class InteractionController : ControllerBase
    {
        private readonly DDIAPIContext _context;

    public InteractionController(DDIAPIContext context) {
        _context = context;
    }

        // GET: api/Interaction/Check?drug1Id=1&drug2Id=2
        [HttpGet("Check")]
        [Route("api/Interaction/Check")]
        public async Task<IActionResult> CheckInteraction(int drug1Id, int drug2Id)
        {
            var interaction = await _context.interactions
                .Include(i => i.Drug1)
                .Include(i => i.Drug2)
                .Include(i => i.Severity)
                .FirstOrDefaultAsync(i => i.Drug1Id == drug1Id && i.Drug2Id == drug2Id);

            if (interaction == null)
            {
                return NotFound(new { Message = "No interaction found between the specified drugs." });
            }

            return Ok(interaction);
        }
    }
}