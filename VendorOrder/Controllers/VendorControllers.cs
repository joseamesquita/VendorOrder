using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using VendorOrder.Models;

namespace VendorOrder.Controllers
{
  public class VendorController : Controller
  {

    [HttpGet("/vendors")]
    public ActionResult VendorsIndex()
    {
      List<Vendor> showList = Vendor.Board;
      return View(showList);
    }


    [HttpGet("/vendors/new")]
    public ActionResult New()
    {

      return View();
    }


    [HttpPost("/vendors/create")]
    public ActionResult Create(string title, string description, string contact)
    {
      Vendor order = new Vendor(title, description, contact);
      return RedirectToAction("VendorsIndex");
    }


    [HttpGet("/vendors/{id}")]
    public ActionResult Show(int id)
    {
      Vendor order = Vendor.Find(id);
      return View(order);
    }


    [HttpGet("/vendors/{id}/edit")]
    public ActionResult Edit(int id)
    {
      Vendor order = Vendor.Find(id);
      return View(order);
    }


    [HttpPost("/vendors/{id}")]
    public ActionResult Update(int id, string title, string description, string contact)
    {
      Vendor.UpdateVendor(id, title, description, contact);
      return RedirectToAction("VendorsIndex");
    }


    [HttpPost("/vendors/delete/{id}")]
    public ActionResult Delete(int id)
    {
      Vendor.DeleteVendor(id);
      return View();
    }
  }

}