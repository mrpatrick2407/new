using Microsoft.AspNetCore.Mvc;
using Demo_App.Models;
using Moq;


namespace Demo_App.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly Mock<IEmployeeRepository> _mockRepo = new Mock<IEmployeeRepository>();



        List<Employee> employees = new List<Employee>
                 {
        new Employee { Id = 1, Name = "John Smith", Email = "john.smith@example.com",Department="Production",PhoneNumber="9566879211" },
        new Employee { Id = 2, Name = "Jane Doe", Email = "jane.doe@example.com" ,Department="Sales",PhoneNumber="9416879211" },
        new Employee { Id = 3, Name = "Bob Johnson", Email = "bob.johnson@example.com" ,Department="Marketing",PhoneNumber="9566459211" }
                 };

        public ActionResult Index()
        {
            
            _mockRepo.Setup(repo => repo.GetAllEmployees()).Returns(employees);
            var model = _mockRepo.Object.GetAllEmployees();
            return View(model);
        }

        public ActionResult Details(int id)
        {
            

            var mockEmployeeRepository = new Mock<IEmployeeRepository>();
            
            mockEmployeeRepository.Setup(repo => repo.GetEmployeeById(id)).Returns(employees.FirstOrDefault(e => e.Id == id));
            var employee = mockEmployeeRepository.Object.GetEmployeeById(id);


            return View(employee);
        }

        private ActionResult HttpNotFound()
        {
            throw new NotImplementedException();
        }
    }

}
