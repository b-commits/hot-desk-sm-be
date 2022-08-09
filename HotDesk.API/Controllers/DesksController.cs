using System;
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
        public IActionResult GetDesks()
        {
            return Ok(_deskService.GetDesks());
        }

    }
}

