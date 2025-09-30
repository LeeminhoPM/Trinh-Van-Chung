using ChungTrinhj.Models;
using ChungTrinhj.Repository.IRepository;

namespace ChungTrinhj.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private ChungTrinhjDbContext _db;

        public UnitOfWork(ChungTrinhjDbContext db)
        {
            _db = db;
            Employee = new EmployeeRepository(_db);
        }

        public IEmployeeRepository Employee { get; private set; }

        public void Save()
        {
            _db.SaveChanges();
        }
    }
}
