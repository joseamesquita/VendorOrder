using System.Collections.Generic;

namespace VendorOrder.Models
{
  public class Vendors
  {
    private static int _vendorCount = 1;
    public static List<Vendors> Board = new List<Vendors>();

    public List<Order> Orders { get; set; }

    public string Name { get; set; }

    public string Description { get; set; }

    public string Contact { get; set; }

    public int Index { get; set; }
    public int Id { get; set; }

    public Vendors(string name, string description, string contact)
    {
      Name = name;
      Description = description;
      Contact = contact;
      // Id = ++_vendorCount;
      Board.Add(this);
      // Index = Board.Count;
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
      // int index = 0;
      foreach (Vendors vendor in Board)
      {
        if (vendor.Id == id)
        {
          // vendor.Index = index;
          return vendor;
        }
        // index++;
      }
      return Board[0];
    }

    public static void DeleteVendor(int id)
    {
      Vendors ven = Find(id);
      Board.RemoveAt(ven.Index);
    }

    public static void UpdateVendor(int id, string name, string description, string contact)
    {
      Vendors ven = Find(id);
      ven.Name = name;
      ven.Description = description;
      ven.Contact = contact;

    }
    public void AddOrder(Order order)
    {
      Orders.Add(order);
    }


  }


}