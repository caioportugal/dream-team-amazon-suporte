using System;
using System.Collections.Generic;
using System.Linq;
using Amazon.Suporte.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace AmazonSuporte.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SuportController : ControllerBase
    {
        public SuportController() {}

        [HttpGet("{id}")]
        public IEnumerable<ProblemResponse> Get(int id)
        {
            var random = new Random();
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
