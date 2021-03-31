using Amazon.Suporte.Model;

namespace Amazon.Suporte.Database
{
    public interface IProblemRepository : IRepository<Problem>
    {
        Problem GetProblemByIdentificator(string identificator);
    }
}
