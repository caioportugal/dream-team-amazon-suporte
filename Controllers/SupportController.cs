using Amazon.Suporte.Services;
using Amazon.Suporte.ViewModel;
using Amazon.Suporte.Model;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using Amazon.Suporte.Enum;
using System.Collections.Generic;
using System.Linq;

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

        [HttpPost]
        public ActionResult<ProblemResponse> Post(ProblemRequest problemRequest)
        {
            var problemResponse = _producerService.SendMessage(_mapper.Map<Problem>(problemRequest));
            if (problemResponse.Success)
                return Ok(problemResponse.Message);
            return BadRequest(problemResponse.Message);
        }

        [HttpGet("{identificator}")]
        public ActionResult<ProblemResponse> GetProblemIdentificator(string identificator)
        {
            var problem = _problemService.GetProblemByIdentificator(identificator);
            if (problem == null)
                return NotFound();
            return Ok(_mapper.Map<ProblemResponse>(problem));
        }
    }
}
