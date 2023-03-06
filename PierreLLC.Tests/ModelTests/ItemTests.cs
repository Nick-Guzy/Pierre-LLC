using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using PierreLLC.Models;
using System;

namespace PierreLLC.Tests
{
  [TestClass]
  public class OrderTests : IDisposable
  {

    public void Dispose()
    {
      Order.ClearAll();
    }

    [TestMethod]
    public void OrderConstructor_CreatesInstanceOfOrder_Order()
    {
      Order newOrder = new Order("test", "stuff", "thing", "money");
      Assert.AreEqual(typeof(Order), newOrder.GetType());
    }

    [TestMethod]
    public void GetDescription_ReturnsDescription_String()
    {
      //Arrange
      string description = "Person";
      string title = "Stuff";
      string date = "Thing";
      string price = "Money";

      //Act
      Order newOrder = new Order(description, title, date, price);
      string result = newOrder.Description;

      //Assert
      Assert.AreEqual(description, result);
    }

    [TestMethod]
    public void SetDescription_SetDescription_String()
    {
      //Arrange
      string description = "Person";
      string title = "Thing";
      string date = "Stuff";
      string price = "Money";
      Order newOrder = new Order(description, title, date, price);

      //Act
      string updatedDescription = "Product";
      newOrder.Description = updatedDescription;
      string result = newOrder.Description;

      //Assert
      Assert.AreEqual(updatedDescription, result);
    }

    [TestMethod]
    public void GetAll_ReturnsEmptyList_OrderList()
    {
      // Arrange
      List<Order> newList = new List<Order> { };

      // Act
      List<Order> result = Order.GetAll();

      // Assert
      CollectionAssert.AreEqual(newList, result);
    }

    [TestMethod]
    public void GetAll_ReturnsOrders_OrderList()
    {
      //Arrange
      string description01 = "Person";
      string description02 = "Product";
      string title01 = "Thing";
      string title02 = "Stuff";
      string date01 = "Thing";
      string date02 = "Stuff";
      string price01 = "Thing";
      string price02 = "Thing";
      Order newOrder1 = new Order(description01, title01, date01, price01);
      Order newOrder2 = new Order(description02, title02, date02, price02);
      List<Order> newList = new List<Order> { newOrder1, newOrder2 };

      //Act
      List<Order> result = Order.GetAll();

      //Assert
      CollectionAssert.AreEqual(newList, result);
    }
  }
}