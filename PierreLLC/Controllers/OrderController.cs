using Microsoft.AspNetCore.Mvc;
using PierreLLC.Models;
using System.Collections.Generic;

namespace PierreLLC.Controllers
{
  public class OrderController : Controller
  {

    [HttpGet("/vendors/{vendorId}/order/new")]
    public ActionResult New(int vendorId)
    {
      Vendor vendor = Vendor.Find(vendorId);
      return View(vendor);
    }

    [HttpGet("/vendors/{vendorId}/order/{orderId}")]
    public ActionResult Show(int vendorId, int orderId)
    {
      Order order = Order.Find(orderId);
      Vendor category = Vendor.Find(vendorId);
      Dictionary<string, object> vendor = new Dictionary<string, object>();
      vendor.Add("order", order);
      vendor.Add("vendor", vendor);
      return View(vendor);
    }
  }
}