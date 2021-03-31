namespace Amazon.Suporte.Database
{
    public interface IUnitOfWork
    {
        IProblemRepository ProblemRepository { get; }
        int Complete();
    }
}
