using System.Collections.Generic;

namespace PierreLLC.Models
{
  public class Order
  {
    public string Description { get; set; }
    public int Id { get; }

    public string Title { get; set; }

    public string Date { get; set; }

    public string Price { get; set; }
    private static List<Order> _instances = new List<Order> { };

    public Order(string orderDescription, string orderTitle, string orderDate, string orderPrice)
    {
      Title = orderTitle;
      Date = orderDate;
      Price = orderPrice;
      Description = orderDescription;
      _instances.Add(this);
      Id = _instances.Count;
    }

    public static List<Order> GetAll()
    {
      return _instances;
    }

    public static void ClearAll()
    {
      _instances.Clear();
    }
    public static Order Find(int searchId)
    {
      return _instances[searchId-1];
    }
  }
}
