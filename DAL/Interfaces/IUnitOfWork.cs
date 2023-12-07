namespace DAL.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IProjectRepository Projects { get; }
        IEmployeeRepository Employees { get; }

        Task<int> SaveChangesAsync();
    }
}
