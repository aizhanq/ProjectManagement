using DAL.EF;
using DAL.Interfaces;

namespace DAL.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationContext _context;
        private IProjectRepository _projectRepository;
        private IEmployeeRepository _employeeRepository;

        public UnitOfWork(ApplicationContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public IProjectRepository Projects
        {
            get { return _projectRepository ??= new ProjectRepository(_context); }
        }

        public IEmployeeRepository Employees
        {
            get { return _employeeRepository ??= new EmployeeRepository(_context); }
        }

        public async Task<int> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
