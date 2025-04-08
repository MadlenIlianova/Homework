using CarManager.Data;

namespace CarManager 
{
    public class Program 
    {
        static void Main() 
        {
            CarDbContext db = new CarDbContext();
            db.CompareCars(1, 2);
        }
    }

}
