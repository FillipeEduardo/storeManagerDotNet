namespace storeManagerDotNet.Models;

public class Sale
{
    public int Id { get; set; }
    public DateTime Date { get; set; }

    public Sale()
    {
        Date = DateTime.Now;
    }
}
