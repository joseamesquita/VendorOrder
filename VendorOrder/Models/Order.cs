using System.Collections.Generic;

namespace VendorOrder.Models
{
  public class Order
  {
    private static int _vendorCount = 0;
    public static List<Order> Board { get; set; } = new List<Order>();

    public string Title { get; set; }

    public string OrderDescription { get; set; }

    public int Price { get; set; }

    public string Date { get; set; }

    public int Index { get; set; }
    public int Id { get; set; }

    public Order(string orderName, string orderDescription, int price, string date)
    {
      Title = orderName;
      OrderDescription = orderDescription;
      Price = price;
      Date = date;
      Board.Add(this);
      Id = _vendorCount++;
    }
    public static void ClearAll()
    {
      Board.Clear();
    }
    public static List<Order> GetAll()
    {
      return Board;
    }
    public static Order Find(int id)
    {
      foreach (Order order in Board)
      {
        if (order.Id == id)
        {
          return order;
        }
      }
      return Board[0];
    }
  }
}