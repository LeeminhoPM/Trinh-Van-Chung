using ChungTrinhj.Models;

namespace ChungTrinhj.Repository.IRepository
{
    public interface IEmployeeRepository : IRepository<Employee>
    {
        void Update(Employee obj);
    }
}
