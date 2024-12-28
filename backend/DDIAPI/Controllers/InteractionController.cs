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

        public InteractionController(DDIAPIContext context)
        {
            _context = context;
        }

        // POST: api/Interaction/Check
        [HttpPost]
        [Route("api/Interaction/Check")]
        public async Task<IActionResult> CheckInteraction([FromBody] InteractionRequest request)
        {
            var interaction = await _context.interactions
                .Include(i => i.Drug1)
                .Include(i => i.Drug2)
                .Include(i => i.Severity)
                .FirstOrDefaultAsync(i => i.Drug1Id == request.Drug1Id && i.Drug2Id == request.Drug2Id);

            if (interaction == null)
            {
                return NotFound(new { Message = "No interaction found between the specified drugs." });
            }

            return new JsonResult(interaction);
        }
    }

    public class InteractionRequest
    {
        public int Drug1Id { get; set; }
        public int Drug2Id { get; set; }
    }
}