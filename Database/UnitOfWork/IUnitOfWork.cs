using System;

namespace Amazon.Suporte.Database
{
    public interface IUnitOfWork : IDisposable
    {
        IProblemRepository ProblemRepository { get; }
        int Complete();
    }
}
