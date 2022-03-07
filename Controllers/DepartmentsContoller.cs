using Microsoft.AspNetCore.Mvc;
using RestAPI.Entities;
using RestAPI.Repositories;

namespace RestAPI.Controllers
{
    [ApiController]
    [Route("department")] // GET / department
    public class DepartmentsContoller : ControllerBase
    {
        private readonly DepartmentRepository _repository;

        public DepartmentsContoller(DepartmentRepository repository)
        {
            _repository = repository;
        }

        [HttpGet] // Get / department
        public IEnumerable<Department> Get()
        {
            var departments = _repository.GetDepartments();
            return departments;
        }
    }
}