namespace Basket.Core.Entities;

public class ShoppingCart 
{
  public string UserName { get; set; } = string.Empty;

  public List<ShoppingCartItem> Items { get; set; } = [];

  public ShoppingCart()
  {
    
  }

  public ShoppingCart(string userName)
  {
    UserName = userName;
  }


}