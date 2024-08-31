using System.Reflection.Metadata;

public class Footballer
{
    public string Name { get; private set; }
    public int Age { get; private set; }
    private IFootballer _role;
    public IFootballer Role { 
    get {
        return _role;
    }
    set {
        _role = value;
    }
    }

    public Footballer(string name, int age, IFootballer role)
    {
        Name = name;
        Age = age;
        Role = role;
    }
}
public interface IFootballer {
    public string GetRole();
}
public class GoalKeeper : IFootballer {
    public string GetRole(){
        return "GoalKeeper";
    }
}
public class ForwardRole : IFootballer {
    public string GetRole(){
        return "Forward";
    }
}
public class DefenderRole  : IFootballer {
    public string GetRole(){
        return "DefenderRole";
    }
}
public class MidfieldRole : IFootballer {
    public string GetRole(){
        return "MidfieldRole";
    }
}

/// <summary>
/// Section of the another example
/// </summary>
/// 

public interface IDiscountSize {
    public double GetPrice(double price);
}
public class TeenPercentPriceDiscount : IDiscountSize
{
    public double GetPrice(double price)
    {
        return price * 0.9;
    }
}

public class TwentyPercentPriceDiscount : IDiscountSize
{
    public double GetPrice(double price)
    {
        return price * 0.8;
    }
}
public class ThirtyPercentPriceDiscount : IDiscountSize
{
    public double GetPrice(double price)
    {
        return price * 0.7;
    }
}
public class FiftyPercentPriceDiscount : IDiscountSize
{
    public double GetPrice(double price)
    {
        return price * 0.5;
    }
}

public class PriceCalculator
{
    public double CalculatePrice(double price, IDiscountSize size)
    {
       return size.GetPrice(price);
    }
}
public class DiscountMapperPriceCalculator {
    public double? CalculatePriceMap(double price, string size, IDictionary<string,double> collectionOfDiscounts){
        double? sizeOfDiscount = collectionOfDiscounts[size];
        if(sizeOfDiscount is null){
            throw new NullReferenceException("Please put the appropriate value in the size of the discount");
        }
        return price * sizeOfDiscount;
    }
}
internal class Program
{
    private static void Main()
    {
        Dictionary<string,double> collectionOfDiscounts = new Dictionary<string, double>(){
        {"10",0.9},
        {"20",0.8},
        {"30",0.7},
        {"50",0.5},
        };

        Dictionary<string,Footballer> map = new Dictionary<string, Footballer>()
        {
            {"One", new Footballer("Eden Hazard", 32, new ForwardRole())},
            {"Two", new Footballer("Joseph Kurtz", 39, new MidfieldRole())},
            {"Three", new Footballer("Joseph Kurtz", 39, new MidfieldRole())}
        };

        foreach(var item in map){
            Console.WriteLine(item.Key + " " + item.Value);
        }

        PriceCalculator priceCalculator = new PriceCalculator();
        DiscountMapperPriceCalculator discountMapperPriceCalculator = new DiscountMapperPriceCalculator();
        Console.WriteLine(priceCalculator.CalculatePrice(100.00, new FiftyPercentPriceDiscount()));
        Console.WriteLine(discountMapperPriceCalculator.CalculatePriceMap(100.00, "30",collectionOfDiscounts));
    }
}