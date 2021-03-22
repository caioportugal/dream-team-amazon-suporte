using Amazon.Suporte.Enum;
using Amazon.Suporte.Model;
using System.Collections.Generic;

namespace Amazon.Suporte.Database
{
    public interface IProblemRepository : IRepository<Problem>
    {
        IEnumerable<Problem> GetProblemByStatus(StatusEnum status);
    }
}
