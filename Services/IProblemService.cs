using Amazon.Suporte.Model;

namespace Amazon.Suporte.Services
{
    public interface IProblemService
    {
        Problem CreateProblem(Problem problem);
        Problem GetProblem(int id);
    }
}