using Amazon.Suporte.Database;
using Amazon.Suporte.Enum;
using Amazon.Suporte.Model;
using System;

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
            var unitOfWork = new UnitOfWork(_context);
            unitOfWork.ProblemRepository.Add(problem);
            unitOfWork.Complete();            
            return problem;
        }        

        public Problem GetProblemByIdentificator(string identificator)
        {
            return new UnitOfWork(_context)
                   .ProblemRepository
                   .GetProblemByIdentificator(identificator);
        }        
    }
}
