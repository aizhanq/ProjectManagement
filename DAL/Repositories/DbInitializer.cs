using DAL.EF;
using DAL.Entities;
using DAL.Interfaces;

namespace DAL.Repositories
{
    public class DbInitializer : IDbInitializer
    {
        private readonly ApplicationContext _context;

        public DbInitializer(ApplicationContext context)
        {
            _context = context;
        }
     
        public void Initialize()
        {
            // Добавляем начальные данные сотрудников
            // Проверяем, есть ли уже данные в базе
            if (_context.Employees.Any() && _context.Projects.Any())
            {
                return; // База данных уже инициализирована
            }
            
            var employees = new[]
                        {
                        new Employee { FirstName = "Бегимай", LastName = "Калысбекова", MiddleName = "Эмильевна", Email = "kbegimay@gmail.com" },
                        new Employee { FirstName = "Ринат", LastName = "Исаков", MiddleName = "Алмазович", Email = "isakov93@gmail.com" },
                        new Employee { FirstName = "Максим", LastName = "Василенко", MiddleName = "Николаевич", Email = "maxvasilenko@gmail.com" },
                        new Employee { FirstName = "Алина", LastName = "Жумалиева", MiddleName = "Мунарбековна", Email = "jumalina@gmail.com" },
                        new Employee { FirstName = "Евгений", LastName = "Ковалев", MiddleName = "Дмитриевич", Email = "eugene9999@gmail.com" },
                        new Employee { FirstName = "Дарика", LastName = "Алымкулова", MiddleName = "Калисбековна", Email = "sundara@gmail.com" }

                        };

            _context.Employees.AddRange(employees);
            _context.SaveChanges();

            var projects = new[]
                 {
                     new Project
                     {
                         ProjectName = "Online Bank",
                         CustomerCompany = "Mbank",
                         ExecutorCompany = "AppSoft",
                         ManagerId = employees[1].EmployeeId,
                         Manager = employees[1],
                         StartDate = DateTime.Now.AddDays(-5),
                         EndDate = DateTime.Now.AddDays(15),
                         Priority = 2
                     },
                     new Project
                     {
                         ProjectName = "DeliveryApp",
                         CustomerCompany = "HealthyFood",
                         ExecutorCompany = "AppSoft",
                         ManagerId = employees[2].EmployeeId,
                         Manager = employees[2],
                         StartDate = DateTime.Now.AddDays(-10),
                         EndDate = DateTime.Now.AddDays(20),
                         Priority = 5
                     },                   
                     new Project
                     {
                         ProjectName = "AI Closet",
                         CustomerCompany = "DeFacto",
                         ExecutorCompany = "AppSoft",
                         ManagerId = employees[4].EmployeeId,
                         Manager = employees[4],
                         StartDate = DateTime.Now.AddDays(-23),
                         EndDate = DateTime.Now.AddDays(13),
                         Priority = 1
                     }

                 };

             _context.Projects.AddRange(projects);
             _context.SaveChanges();                    
        }
    }
}
