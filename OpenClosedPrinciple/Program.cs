public class Footballer
{
    public string Name { get; private set; }
    public int Age { get; private set; }
    public string Role { get; private set; }

    public Footballer(string name, int age, string role)
    {
        Name = name;
        Age = age;
        Role = role;
    }
}
public class Basketballer 
{
    public string Name { get; private set; }
    public int Age { get; private set; }
    public string Role { get; private set; }

    public Basketballer(string name, int age, string role)
    {
        Name = name;
        Age = age;
        Role = role;
    }
}
public interface IPlayerAgent<T> {
    public void GetPlayerRole(T player);
}
public class FootballerAgent : IPlayerAgent<Footballer> {
    public void GetPlayerRole(Footballer footballer)
    {
        // switch should be turned into map or some kind of pattern 
        // filter to implement because of the bunch of data to throw away


        switch (footballer.Role)
        {
            case "goalkeeper":
                Console.WriteLine($"The footballer, {footballer.Name} is a goalkeeper");
                break;
            case "defender":
                Console.WriteLine($"The footballer, {footballer.Name} is a defender");
                break;
            case "midfielder":
                Console.WriteLine($"The footballer, {footballer.Name} is a midfielder");
                break;
            case "forward":
                Console.WriteLine($"The footballer, {footballer.Name} plays in the forward line");
                break;
            default:
                throw new ArgumentException($"Unsupported role type: {footballer.Name}");
        }
   }
}

internal class Program
{
    private static void Main()
    {
        Footballer kante = new Footballer("Ngolo Kante", 31, "midfielder");
        Footballer hazard = new Footballer("Eden Hazard", 32, "forward");

    }
}