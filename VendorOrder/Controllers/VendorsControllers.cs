using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using VendorOrder.Models;

namespace VendorOrder.Controllers
{
  public class VendorsController : Controller
  {

    [HttpGet("/vendors")]
    public ActionResult Index()
    {
      List<Vendors> showList = Vendors.GetAll();
      return View(showList);
    }


    [HttpGet("/vendors/new")]
    public ActionResult New()
    {

      return View();
    }


    [HttpPost("/vendors/create")]
    public ActionResult Create(string name, string description, string contact)
    {
      Vendors order = new Vendors(name, description, contact);
      return RedirectToAction("Index");
    }

    [HttpPost("/vendors/{vendorId}/orders")]
    public ActionResult Create(int id, string name, string description, int price, string date)
    {
      Dictionary<string, object> model = new Dictionary<string, object>();
      Vendors foundVendor = Vendors.Find(id);
      Order newOrder = new Order(name, description, price, date);
      foundVendor.AddOrder(newOrder);
      List<Order> vendorOrders = foundVendor.Orders;
      model.Add("orders", vendorOrders);
      model.Add("vendor", foundVendor);
      return View("Show", model);
    }



    [HttpGet("/vendors/{id}")]
    public ActionResult Show(int id)
    {
      Dictionary<string, object> model = new Dictionary<string, object>();
      Vendors selectedVendors = Vendors.Find(id);
      List<Order> vendorOrders = selectedVendors.Orders;
      model.Add("vendor", selectedVendors);
      model.Add("orders", vendorOrders);
      return View(model);
    }




    [HttpGet("/vendors/{id}/edit")]
    public ActionResult Edit(int id)
    {
      Vendors order = Vendors.Find(id);
      return View(order);
    }


    [HttpPost("/vendors/{id}")]
    public ActionResult Update(int id, string name, string description, string contact)
    {
      Vendors.UpdateVendor(id, name, description, contact);
      return RedirectToAction("Index");
    }


    [HttpPost("/vendors/delete/{id}")]
    public ActionResult Delete(int id)
    {
      Vendors.DeleteVendor(id);
      return View();
    }


  }

}