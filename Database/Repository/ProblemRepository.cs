using Amazon.Suporte.Enum;
using Amazon.Suporte.Model;
using System.Collections.Generic;
using System.Linq;

namespace Amazon.Suporte.Database
{
    public class ProblemRepository : Repository<Problem>, IProblemRepository
    {
        public ProblemRepository(SupportDBContext context) : base(context) {}
        private SupportDBContext SupportDBContext
        {
            get { return Context as SupportDBContext; }
        }

        public IEnumerable<Problem> GetProblemByStatus(StatusEnum status)
        {
            return SupportDBContext.Problem.Where(x => x.Status == status).ToList();
        }
    }
}
