using Amazon.Suporte.Database;
using Amazon.Suporte.Enum;
using Amazon.Suporte.Model;
using System;
using System.Collections.Generic;

namespace Amazon.Suporte.Services
{
    public class ProblemService : IProblemService
    {
        private SupportDBContext _context;
        public ProblemService(SupportDBContext context)
        {
            _context = context;
        }

        public Problem CreateProblem(Problem problem)
        {
            problem.CreatedAt = DateTime.Now;
            problem.Status = StatusEnum.Created;
            using(var unitOfWork = new UnitOfWork(_context))
            {
                unitOfWork.ProblemRepository.Add(problem);
                unitOfWork.Complete();
            }
            return problem;
        }

        public Problem GetProblem(int id)
        {
            Problem problem = null;
            using(var unitOfWork = new UnitOfWork(_context))
            {
                problem = unitOfWork.ProblemRepository.Get(id);
            }
            return problem;
        }

        public IEnumerable<Problem> GetProblemByStatus(StatusEnum status)
        {
            var problems = new List<Problem>();
            using(var unitOfWork = new UnitOfWork(_context))
            {
                problems = (List<Problem>)unitOfWork.ProblemRepository.GetProblemByStatus(status);
            }
            return problems;
        }
    }
}
