﻿/*======================================================================
| OrderServices class
|
| Name: OrderServices.cs
|
| Written by: Tobi AA- January 2023
|
| Purpose: Contains services available for a Order object.
|
| usage: Used in PaymentControler and other classes that may depend on it.
|
| Description of properties: None
|
|------------------------------------------------------------------
*/
using System;
using ConnectDatabase;
using MongoDB.Driver;
using MongoDB.Bson;
using Restaurant_Api.Models;
using System.Collections.ObjectModel;
using MongoDB.Bson.Serialization;

namespace Restaurant_Api.Services
{
    public class OrderServices
    {
        static ConnectDB connection = new ConnectDB();
        static IMongoCollection<Order> _orders = connection.Client.GetDatabase("Drum_Rock_Jerk").GetCollection<Order>("Orders");
        public OrderServices(IMongoDatabase database)
        {

        }
        // provides a list of orders
        public static List<Order> GetallOrder()
        {
            return _orders.Find(order => true).ToList();
        }
        //get customers orders
        public static Order GetOrder(string id)
        {
            FilterDefinition<Order> filter = Builders<Order>.Filter.Eq("_id", id);
            Order result = _orders.Find(filter).FirstOrDefault();
            return result;
        }
        //create an order 

        public static Order CreateOrder(Order order)
        {
            order._id = IdGenerator.GenerateId;
             _orders.InsertOne(order);
            return order;
            //add the item to a past order once it 
        }

        public static Order UpdateOrder(string orderId, Order orderIn)
        {
            var order = OrderServices.GetOrder(orderId);
            if (order == null)
            {
                return null;
            }

            var filter = Builders<Order>.Filter.Eq("_id", orderId);
            var update = Builders<Order>.Update
                .Set("CustomerName", orderIn.CustomerName)
                .Set("PhoneNumber", orderIn.PhoneNumber)
                .Set("items", orderIn.items)
                .Set("status", orderIn.status)
                .Set("TotalPrice", orderIn.TotalPrice);

            var options = new FindOneAndUpdateOptions<Order>();
            var updatedOrder = _orders.FindOneAndUpdate(filter, update, options);
            return updatedOrder;
        }




        //returns all the orders 
        public static List<Order> GetAllOrders()
        {
            var filter = Builders<Order>.Filter.Empty;
            var orders = _orders.Find(filter).ToList();
            Console.WriteLine("Filter results: " + string.Join(", ", orders));
            return orders;
        }


        public static List<Order> GetOrdersByEmail(FilterDefinition<Order> filter)
        {
            var orders = _orders.Find(filter).ToList();
            return orders;
        }






        public static void RemoveOrder(Order orderIn)
        {
            _orders.DeleteOne(order => order._id == orderIn._id);
        }
        //delete a single document from a collection that matches a specified filter. In

        public static void RemoveOrder(string id)
        {
            _orders.DeleteOne(order => order._id == id);
        }


    }

        
}

    






    


