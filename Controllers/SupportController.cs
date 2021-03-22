using Amazon.Suporte.Services;
using Amazon.Suporte.ViewModel;
using Amazon.Suporte.Model;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using Amazon.Suporte.Enum;
using System.Collections.Generic;
using System.Linq;
using System;

namespace AmazonSuporte.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SupportController : ControllerBase
    {
        private IProblemService _problemService;
        private IMapper _mapper;
        public SupportController(IProblemService problemService,
                                IMapper mapper)
        {
            _problemService = problemService;
            _mapper = mapper;
        }

        [HttpGet("{id}")]
        public ActionResult<ProblemResponse> Get(int id)
        {
            var problem = _problemService.GetProblem(id);
            if (problem == null)
                return NotFound();
            return Ok(_mapper.Map<ProblemResponse>(problem));
        }

        [HttpPost]
        public IActionResult Post(ProblemRequest problemRequest)
        {
            var problemResponse = _mapper.Map<ProblemResponse>
                                  (
                                      _problemService.CreateProblem(_mapper.Map<Problem>(problemRequest))
                                  );
            return CreatedAtAction(nameof(Get), new { id = problemResponse.ID }, problemResponse);
        }

        [HttpGet("status")]
        public ActionResult<IEnumerable<ProblemResponse>> GetProblemStatus(StatusEnum status)
        {
            var problems = _problemService.GetProblemByStatus(status);
            if (!problems.Any())
                return NotFound();
            return Ok(problems.Select(x=> _mapper.Map<ProblemResponse>(x)).ToList());
        }
    }
}
