using System.Collections.Generic;
using System;

namespace VendorOrder.Models
{
  public class Vendor
  {
    private static int _vendorCount = 1;
    public static List<Vendor> Board = new List<Vendor>();

    public List<Order> Orders { get; set; }

    public string Name { get; set; }

    public string Description { get; set; }

    public string Contact { get; set; }

    public int Index { get; set; }
    public int Id { get; set; }

    public Vendor(string name, string description, string contact)
    {
      Name = name;
      Description = description;
      Contact = contact;
      Board.Add(this);
      Id = _vendorCount++;
      Orders = new List<Order> { };
    }
    public static void ClearAll()
    {
      Board.Clear();
    }
    public static List<Vendor> GetAll()
    {
      return Board;
    }
    public static Vendor Find(int id)
    {
      foreach (Vendor vendor in Board)
      {
        if (vendor.Id == id)
        {
          return vendor;
        }
      }
      return Board[0];
    }
    public void AddOrder(Order order)
    {
      Orders.Add(order);
    }
  }
}