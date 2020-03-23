using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using VendorOrder.Models;

namespace VendorOrder.Controllers
{
  public class VendorsController : Controller
  {

    [HttpGet("/vendors")]
    public ActionResult VendorsIndex()
    {
      List<Vendors> showList = Vendors.Board;
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
      Vendors order = new Vendors(title, description, contact);
      return RedirectToAction("VendorsIndex");
    }


    [HttpGet("/vendors/{id}")]
    public ActionResult Show(int id)
    {
      Vendors order = Vendors.Find(id);
      return View(order);
    }


    [HttpGet("/vendors/{id}/edit")]
    public ActionResult Edit(int id)
    {
      Vendors order = Vendors.Find(id);
      return View(order);
    }


    [HttpPost("/vendors/{id}")]
    public ActionResult Update(int id, string title, string description, string contact)
    {
      Vendors.UpdateVendor(id, title, description, contact);
      return RedirectToAction("VendorsIndex");
    }


    [HttpPost("/vendors/delete/{id}")]
    public ActionResult Delete(int id)
    {
      Vendors.DeleteVendor(id);
      return View();
    }
  }

}