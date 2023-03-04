using Microsoft.AspNetCore.Mvc;
using PierreLLC.Models;
using System.Collections.Generic;

namespace PierreLLC.Controllers
{
  public class OrderController : Controller
  {

    [HttpGet("/categories/{categoryId}/items/new")]
    public ActionResult New(int vendorId)
    {
      Vendor vendor = Vendor.Find(vendorId);
      return View(vendor);
    }

    [HttpGet("/categories/{categoryId}/orders/{orderId}")]
    public ActionResult Show(int vendorId, int orderId)
    {
      Order order = Order.Find(orderId);
      Vendor category = Vendor.Find(vendorId);
      Dictionary<string, object> model = new Dictionary<string, object>();
      model.Add("order", order);
      model.Add("vendor", vendor);
      return View(model);
    }
  }
}