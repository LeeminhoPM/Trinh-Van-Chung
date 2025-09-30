namespace ChungTrinhj.Repository.IRepository
{
    public interface IUnitOfWork
    {
        IEmployeeRepository Employee { get; }

        void Save();
    }
}
