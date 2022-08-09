using System;
using HotDesk.API.Models;
using HotDesk.API.Services;
using Microsoft.AspNetCore.Mvc;

namespace HotDesk.API.Controllers
{
    [ApiController]
    [Route("/desks")]
    public class DesksController : ControllerBase
    {
        private readonly IDeskService _deskService;

        public DesksController(IDeskService deskService)
        {
            _deskService = deskService;
        }

        [HttpGet]
        public async Task<ActionResult<Desk>> GetDesks()
        {
            var desks = await _deskService.GetDesksAsync();
            return Ok(desks);
        }

        [HttpGet("{id:length(24)}")]
        public async Task<ActionResult<Desk>> GetById(string id)
        {
            var desk = await _deskService.GetDeskByIdAsync(id);

            if (desk is null)
            {
                return NotFound();
            }

            return Ok(desk);
        }

        [HttpPost]
        public async Task<IActionResult> PostDesk(Desk desk)
        {
            await _deskService.InsertDeskAsync(desk);
            return CreatedAtAction(nameof(GetDesks), new { id = desk.Id }, desk);
        }

        [HttpDelete("{id:length(24)}")]
        public async Task<IActionResult> DeleteDesk(string id)
        {
            var desk = await _deskService.GetDeskByIdAsync(id);

            if (desk is null)
            {
                return NotFound();
            }

            await _deskService.DeleteDeskAsync(id);

            return Ok();
        }


        [HttpPut("{id:length(24)}")]
        public async Task<IActionResult> UpdateDesk(string id, Desk newDesk)
        {
            var desk = await _deskService.GetDeskByIdAsync(id);

            if (desk is null)
            {
                return NotFound();
            }

            newDesk.Id = desk.Id;

            await _deskService.UpdateDeskAsync(id, newDesk);

            return Ok();
        }

    }
}
