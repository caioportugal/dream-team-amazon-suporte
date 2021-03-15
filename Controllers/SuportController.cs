using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using AmazonSuporte.ViewModel;

namespace AmazonSuporte.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SuportController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        [HttpGet("{id}")]
        public IEnumerable<ProblemResponse> Get(int id)
        {
            var rng = new Random();
            return Enumerable.Range(1, 1).Select(index => new ProblemResponse
            {
               ID = id,
               Title = "Software Installation",
               Description = "Software needs to be installed on remote machine"
            })
            .ToArray();
        }

        [HttpPost]
        public IActionResult Post(ProblemRequest problemRequest)
        {
            return Ok();
        }
    }
}
