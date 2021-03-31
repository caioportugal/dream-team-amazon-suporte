using Amazon.Suporte.Model;
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

        public Problem GetProblemByIdentificator(string identificator)
        {
            return SupportDBContext.Problem
                   .FirstOrDefault(x => x.ProblemIdentificator == identificator);
        }
    }
}
