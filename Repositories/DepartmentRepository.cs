using RestAPI.Entities;
using RestAPI.Entities.DBContext;

namespace RestAPI.Repositories
{
    public class DepartmentRepository
    {
        private readonly BusMealDBContext _bus;
        private readonly List<Department> departments = new();

        public DepartmentRepository(BusMealDBContext bus)
        {
            _bus = bus;
            departments = _bus.Department.ToList();
        }

        public IEnumerable<Department> GetDepartments()
        {
            return departments;
        }
    }
}