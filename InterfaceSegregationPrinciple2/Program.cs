public interface IWork
{
    void Work();
}
public interface IEat {
    void Eat();
}
public interface IHumanEmployee : IWork,IEat;

public class Employee : IHumanEmployee
{
    public void Work()
    {
    }

    public void Eat()
    {
        Console.WriteLine("We are Humans we need to eat");
    }
}

public class Robot : IWork
{
    public void Work()
    {
        //Code to work
    }
}

public class Program
{    
    static void Main()
    {
        var humanEmployees = new List<IHumanEmployee>
        {
            new Employee(),
            new Employee(),
            new Employee(),
        };
        var mechanicalEmployess = new List<IWork>(){
            new Robot(),
            new Robot(),
            new Robot()
        };

        humanEmployees.ForEach(x=>x.Eat());

    }
}