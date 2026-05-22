namespace MusicStore.Models;

public class Order
{
    public int OrderID { get; set; }
    public int UserID { get; set; }
    public decimal TotalPrice { get; set; }
    public DateTime OrderDate { get; set; } = DateTime.Now;
    public List<OrderItem> Items { get; set; } = new();
    public string Status { get; set; } = "Pending";
}

public class OrderItem
{
    public int ProductID { get; set; }
    public string ProductName { get; set; } = string.Empty;
    public decimal Price { get; set; }
    public int Quantity { get; set; }
}
