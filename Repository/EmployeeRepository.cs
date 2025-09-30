using ChungTrinhj.Models;
using ChungTrinhj.Repository.IRepository;

namespace ChungTrinhj.Repository
{
    public class EmployeeRepository : Repository<Employee>, IEmployeeRepository
    {
        private ChungTrinhjDbContext _db;

        public EmployeeRepository(ChungTrinhjDbContext db) : base(db)
        {
            _db = db;
        }

        public void Update(Employee obj)
        {
            _db.Employees.Update(obj);
        }
    }
}
