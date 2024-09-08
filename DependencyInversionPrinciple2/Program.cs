public enum Gender
{
    Male,
    Female
}
public enum Position
{
    Administrator,
    Manager,
    Executive
}
public class Employee
{
    public string Name { get; set; }
    public Gender Gender { get; set; }
    public Position Position { get; set; }
}
public interface IEmployeeManager {
    void AddEmployee(Employee employee);
}
public class EmployeeManager : IEmployeeManager
{
    private readonly List<Employee> _employees;
    
    public EmployeeManager(List<Employee> employees)
    {
        _employees = employees;
    }

    public void AddEmployee(Employee employee)
    {
        _employees.Add(employee);
    }

    public List<Employee> Employees => _employees;
}
public class EmployeeStatistics 
{ 
    private readonly IEmployeeManager _empManager; 
    public EmployeeStatistics(EmployeeManager empManager) 
    {
       _empManager = empManager; 
    } 

    public int CountFemaleManagers () => 
      _empManager.Employees.Count(emp => emp.Gender == Gender.Female && emp.Position == Position.Manager);
 }

 public class Program {
    private static void Main(string[] args){
     IEmployeeManager empManager = new EmployeeManager();
        empManager.AddEmployee(new Employee { Name = "Leen", Gender = Gender.Female, Position = Position.Manager });
        empManager.AddEmployee(new Employee { Name = "Mike", Gender = Gender.Male, Position = Position.Administrator });
        var stats = new EmployeeStatistics(empManager);
        Console.WriteLine($"Number of female managers in our company is: {stats.CountFemaleManagers()}");
    }
 }