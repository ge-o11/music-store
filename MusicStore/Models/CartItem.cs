namespace MusicStore.Models;

public class CartItem
{
    public int ProductID { get; set; }
    public string ProductName { get; set; } = string.Empty;
    public decimal Price { get; set; }
    public int Quantity { get; set; }
    public string Image { get; set; } = string.Empty;
    public decimal Subtotal => Price * Quantity;
}
