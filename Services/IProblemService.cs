using Amazon.Suporte.Enum;
using Amazon.Suporte.Model;
using System.Collections.Generic;

namespace Amazon.Suporte.Services
{
    public interface IProblemService
    {
        Problem CreateProblem(Problem problem);
        Problem GetProblem(int id);
        IEnumerable<Problem> GetProblemByStatus(StatusEnum status);
    }
}