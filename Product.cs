namespace Inventory;

public class Product
{
    public int ProductID { get; set; }
    public string Name { get; set; }
    public bool Available { get; set; }
    public decimal Price { get; set; }
    public int ProductTypeID { get; set; }
    public DateTime DateStocked { get; set; }
    public int DaysAvailable
    {
        get
        {
            TimeSpan timeAvailable = DateTime.Now - DateStocked;
            return timeAvailable.Days;
        }
    }
}