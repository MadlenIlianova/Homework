
using Calculator;

Pair usd_euro = new Pair(1.09,"USD/EURO");
Pair bgn_usd = new Pair(0.56,"USD/BGN");
Pair bgn_euro = new Pair(0.51,"EUR/BGN");
Console.WriteLine("Въведете тип на потребите:Normal/Special");
string customerType=Console.ReadLine();
if (customerType == "Normal")
{
    Console.WriteLine("Въведете име:");
    string name = Console.ReadLine();
    Console.WriteLine("Въведете баланс в BGN:");
    double balance = double.Parse (Console.ReadLine());
    NormalCustomer normalCustomer = new NormalCustomer(name,balance);
    Console.WriteLine("Към каква валута искате да направите обърнете баланса:USD/EURO/BGN ");
    string currrency = Console.ReadLine();
    if (currrency == "USD")
    {
        normalCustomer.ChangeValues(normalCustomer.Balance, bgn_usd.exchangeRate);
    }
    else if (currrency == "EURO")
    {
        normalCustomer.ChangeValues(normalCustomer.Balance,bgn_euro.exchangeRate);
    }
    Console.WriteLine(normalCustomer.ToString()); 
}
else if(customerType == "Special")
{
    Console.WriteLine("Въведете име:");
    string name = Console.ReadLine();
    Console.WriteLine("Въведете баланс:");
    double balance = double.Parse(Console.ReadLine());
    SpecialCustomer specialCustomer1 = new SpecialCustomer(name, balance);
    Console.WriteLine("Към каква валута искате да направите обърнете баланса:USD/EURO/BGN ");
    string currrency = Console.ReadLine();
    if (currrency == "USD")
    {
        specialCustomer1.ChangeValues(specialCustomer1.Balance, bgn_usd.exchangeRate);
    }
    else if (currrency == "EURO") 
    {
    specialCustomer1.ChangeValues(specialCustomer1.Balance, bgn_euro.exchangeRate);
    }
    Console.WriteLine(specialCustomer1.ToString()); 
}




