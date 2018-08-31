using YouLearn.Infra.Persistencia.EF;

namespace YouLearn.Infra.Transactions
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly YouLearnContext _context;

        public UnitOfWork(YouLearnContext context)
        {
            _context = context;
        }

        public void Commit()
        {
            _context.SaveChanges();
        }
    }
}