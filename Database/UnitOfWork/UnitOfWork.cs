namespace Amazon.Suporte.Database
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly SupportDBContext _context;
        public UnitOfWork(SupportDBContext context)
        {
            _context = context;
            ProblemRepository = new ProblemRepository(_context);

        }
        public IProblemRepository ProblemRepository { get; private set; }

        public int Complete()
        {
            return _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
