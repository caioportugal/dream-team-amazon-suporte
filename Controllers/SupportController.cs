using Amazon.Suporte.Services;
using Amazon.Suporte.ViewModel;
using Amazon.Suporte.Model;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using Amazon.Suporte.Enum;
using System.Collections.Generic;
using System.Linq;
using System;
using System.Threading.Tasks;

namespace AmazonSuporte.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SupportController : ControllerBase
    {
        private IProblemService _problemService;
        private IProducerService _producerService;
        private IMapper _mapper;
        public SupportController(IProblemService problemService,
                                IProducerService producerService,
                                IMapper mapper)
        {
            _problemService = problemService;
            _producerService = producerService;
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
        public ActionResult<ProblemResponse> Post(ProblemRequest problemRequest)
        {
            var problemResponse = _producerService.SendMessage(_mapper.Map<Problem>(problemRequest));
            if (problemResponse.Success)
                return Ok(problemResponse.Message);
            return BadRequest(problemResponse.Message);
        }

        [HttpGet("status")]
        public ActionResult<IEnumerable<ProblemResponse>> GetProblemStatus(StatusEnum status)
        {
            var problems = _problemService.GetProblemByStatus(status);
            if (!problems.Any())
                return NotFound();
            return Ok(problems.Select(x => _mapper.Map<ProblemResponse>(x)).ToList());
        }
    }
}
