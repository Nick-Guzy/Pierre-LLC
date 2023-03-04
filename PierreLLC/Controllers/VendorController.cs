using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using PierreLLC.Models;

namespace PierreLLC.Controllers
{
  public class VendorController : Controller
  {

    [HttpGet("/vendors")]
    public ActionResult Index()
    {
      List<Vendor> allCategories = Vendor.GetAll();
      return View(allCategories);
    }

    [HttpGet("/vendors/new")]
    public ActionResult New()
    {
      return View();
    }

    [HttpPost("/vendors")]
    public ActionResult Create(string VendorName)
    {
      Vendor newVendor = new Vendor(VendorName);
      return RedirectToAction("Index");
    }

    [HttpGet("/vendors/{id}")]
    public ActionResult Show(int id)
    {
      Dictionary<string, object> Orders = new Dictionary<string, object>();
      Vendor selectedVendor = Vendor.Find(id);
      List<Order> VendorOrder = selectedVendor.Orders;
      Orders.Add("vendor", selectedVendor);
      Orders.Add("order", VendorOrder);
      return View(Orders);
    }


    // This one creates new Items within a given Vendor, not new Categories:

    [HttpPost("/vendors/{vendorId}/order")]
    public ActionResult Create(int VendorId, string orderDescription)
    {
      Dictionary<string, object> Orders = new Dictionary<string, object>();
      Vendor foundVendor = Vendor.Find(VendorId);
      Order newOrder = new Order(orderDescription);
      foundVendor.AddOrder(newOrder);
      List<Order> VendorOrder = foundVendor.Orders;
      Orders.Add("order", VendorOrder);
      Orders.Add("vendor", foundVendor);
      return View("Show", Orders);
    }

  }
}