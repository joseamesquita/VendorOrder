using System.Collections.Generic;

namespace VendorOrder.Models
{
  public class Order
  {
    private static int _vendorCount = 0;
    public static List<Order> Board { get; set; } = new List<Order>();

    public string Title { get; set; }

    public string Description { get; set; }

    public int Price { get; set; }

    public string Date { get; set; }

    public int Index { get; set; }
    public int Id { get; set; }

    public Order(string title, string description, int price, string date)
    {
      Title = title;
      Description = description;
      Price = price;
      Date = date;
      Index = Board.Count;
      Id = ++_vendorCount;
      Board.Add(this);
    }
    public static void ClearAll()
    {
      Board.Clear();
    }

    public static Order Find(int id)
    {
      int index = 0;
      foreach (var item in Board)
      {
        if (item.Id == id)
        {
          item.Index = index;
          return item;
        }
        index++;
      }
      return Order.Board[0];
    }

    public static void DeleteOrder(int id)
    {
      Order ord = Find(id);
      Board.RemoveAt(ord.Index);
    }

    public static void UpdateOrder(int id, string title, string description, int price, string date)
    {
      Order ord = Find(id);
      ord.Title = title;
      ord.Description = description;
      ord.Price = price;
      ord.Date = date;

    }


  }


}