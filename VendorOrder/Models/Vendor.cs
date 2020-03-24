using System.Collections.Generic;

namespace VendorOrder.Models
{
  public class Vendors
  {
    private static int _vendorCount = 0;
    public static List<Vendors> Board { get; set; } = new List<Vendors>();

    public List<Order> Orders { get; set; }

    public string Title { get; set; }

    public string Description { get; set; }

    public string Contact { get; set; }

    public int Index { get; set; }
    public int Id { get; set; }

    public Vendors(string title, string description, string contact)
    {
      Title = title;
      Description = description;
      Contact = contact;
      // Id = ++_vendorCount;
      Board.Add(this);
      Index = Board.Count;
      Id = ++_vendorCount;
      Orders = new List<Order> { };

    }
    public static void ClearAll()
    {
      Board.Clear();
    }

    public static List<Vendors> GetAll()
    {
      return Board;
    }

    public static Vendors Find(int id)
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
      return Vendors.Board[0];
    }

    public static void DeleteVendor(int id)
    {
      Vendors ven = Find(id);
      Board.RemoveAt(ven.Index);
    }

    public static void UpdateVendor(int id, string title, string description, string contact)
    {
      Vendors ven = Find(id);
      ven.Title = title;
      ven.Description = description;
      ven.Contact = contact;

    }
    public void AddOrder(Order order)
    {
      Orders.Add(order);
    }


  }


}