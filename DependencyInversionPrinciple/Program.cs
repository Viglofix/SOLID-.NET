public interface IEmployeeRepository {
    void Add(Employee employee);
}

public class Employee
{
    public string Name { get; set; } = "Stefan";
}

public class EmployeeRepository : IEmployeeRepository
{
    public void Add(Employee employee)
    {
        Console.WriteLine(employee.Name);
    }
}

public class EmployeeService
{
    private IEmployeeRepository _employeeRepository;
    public EmployeeService(IEmployeeRepository employeeRepository){
        _employeeRepository = employeeRepository;
    }

    public void Add(Employee employee)
    {
        _employeeRepository.Add(employee);
    }
} 
internal class Program
{
    private static void Main(string[] args)
    {
        var employeeService = new EmployeeService(new EmployeeRepository());
        employeeService.Add(new Employee());
        employeeService.Add(new Employee());
        employeeService.Add(new Employee());
    }
}