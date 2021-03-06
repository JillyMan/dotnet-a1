﻿using System;
using System.Collections.Generic;

namespace OrderManagement.DataAccess.Contract.Models
{
    [Flags]
    public enum OrderStatus
    {
        New = 0,
        InProgress = 1,
        IsDone = 2
    }

    public class Order : BaseModel
    {
        public OrderStatus Status { get; set; }

        public string CustomerId { get; set; }

        public int? EmployeeId { get; set; }

        public DateTime? OrderDate { get; }

        public DateTime? RequiredDate { get; set; }

        public DateTime? ShippedDate { get; }

        public int? ShipVia { get; set; }

        public decimal? Freight { get; set; }

        public string ShipName { get; set; }

        public string ShipAddress { get; set; }

        public string ShipCity { get; set; }

        public string ShipRegion { get; set; }

        public string ShipPostalCode { get; set; }

        public string ShipCountry { get; set; }

        public IList<OrderDetail> OrderDetails { get; set; }

        public Order()
        {
        }

        public Order(DateTime? orderDate, DateTime? shippedDate, OrderStatus status)
        {
            OrderDate = orderDate;
            ShippedDate = shippedDate;
            Status = status;
        }
    }
}
