using System.Collections.Generic;

namespace VendorOrder.Models
{
  public class Vendor
  {
    private static int _vendorCount = 0;
    public static List<Vendor> Board { get; set; } = new List<Vendor>();

    public string Title { get; set; }

    public string Description { get; set; }

    public string Contact { get; set; }

    public int Index { get; set; }
    public int Id { get; set; }

    public Vendor(string title, string description, string contact)
    {
      Title = title;
      Description = description;
      Contact = contact;
      Index = Board.Count;
      Id = ++_vendorCount;
      Board.Add(this);
    }
    public static void ClearAll()
    {
      Board.Clear();
    }

    public static Vendor Find(int id)
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
      return Vendor.Board[0];
    }

    public static void DeleteVendor(int id)
    {
      Vendor ven = Find(id);
      Board.RemoveAt(ven.Index);
    }

    public static void UpdateVendor(int id, string title, string description, string contact)
    {
      Vendor ven = Find(id);
      ven.Title = title;
      ven.Description = description;
      ven.Contact = contact;

    }


  }
}