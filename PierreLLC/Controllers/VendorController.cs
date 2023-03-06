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
      List<Vendor> allVendors = Vendor.GetAll();
      return View(allVendors);
    }

    [HttpGet("/vendors/new")]
    public ActionResult New()
    {
      return View();
    }

    [HttpPost("/vendors")]
    public ActionResult Create(string VendorName, string vendorDescription)
    {
      Vendor newVendor = new Vendor(VendorName, vendorDescription);
      return RedirectToAction("Index");
    }

    [HttpGet("/vendors/{id}")]
    public ActionResult Show(int id)
    {
      Dictionary<string, object> Orders = new Dictionary<string, object>();
      Vendor selectedVendor = Vendor.Find(id);
      List<Order> VendorOrder = selectedVendor.Orders;
      Orders.Add("vendors", selectedVendor);
      Orders.Add("order", VendorOrder);
      return View(Orders);
    }


    // This one creates new Orders within a given Vendor, not new Vendors:

    [HttpPost("/vendors/{vendorId}/order")]
    public ActionResult Create(int VendorId, string orderDescription, string orderTitle, string orderDate, string orderPrice)
    {
      Dictionary<string, object> Orders = new Dictionary<string, object>();
      Vendor foundVendor = Vendor.Find(VendorId);
      Order newOrder = new Order(orderDescription, orderTitle, orderDate, orderPrice);
      foundVendor.AddOrder(newOrder);
      List<Order> VendorOrder = foundVendor.Orders;
      Orders.Add("order", VendorOrder);
      Orders.Add("vendors", foundVendor);
      return View("Show", Orders);
    }

  }
}