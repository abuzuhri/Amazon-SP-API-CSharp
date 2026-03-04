using FikaAmazonAPI.AmazonSpApiSDK.Models.Finances;
using FikaAmazonAPI.AmazonSpApiSDK.Models.Orders20260101;
using System;
using System.Collections.Generic;
using System.Text;


namespace FikaAmazonAPI.Utils
{
    public class OrderConverter
    {
        public class OrderProgramInfo
        {
            public OrderProgramInfo(Order20260101 order)
            {
                if (order?.Programs == null)
                {
                    throw new ArgumentNullException(nameof(order.Programs), "Order programs list cannot be null.");
                }
                this.isPrime = order?.Programs.Contains("PRIME") == true;
                this.isPreorder = order?.Programs.Contains("PREORDER") == true;
                this.isPremium = order?.Programs.Contains("PREMIUM") == true;
                this.isInStorePickUp = order?.Programs.Contains("IN_STORE_PICK_UP") == true;
                this.isFBMShipPlus = order?.Programs.Contains("FBM_SHIP_PLUS") == true;
                this.isDeliveryByAmazon = order?.Programs.Contains("DELIVERY_BY_AMAZON") == true;
                this.isAmazonHaul = order?.Programs.Contains("AMAZON_HAUL") == true;
                this.isAmazonEasyShip = order?.Programs.Contains("AMAZON_EASY_SHIP") == true;
                this.isAmazonBusiness = order?.Programs.Contains("AMAZON_BUSINESS") == true;
                this.isAmazonBazaar = order?.Programs.Contains("AMAZON_BAZAAR") == true;     
            }

            public bool isPrime { get; set; } = false;
            public bool isPreorder { get; set; } = false;
            public bool isPremium { get; set; } = false;
            public bool isInStorePickUp { get; set; } = false;
            public bool isFBMShipPlus { get; set; } = false;
            public bool isDeliveryByAmazon { get; set; } = false;
            public bool isAmazonHaul { get; set; } = false;
            public bool isAmazonEasyShip { get; set; } = false;
            public bool isAmazonBusiness { get; set; } = false;
            public bool isAmazonBazaar { get; set; } = false;


            public List<OrderItemProgramInfo> orderItems { get; set; } = new List<OrderItemProgramInfo>();
        }
        public class OrderItemProgramInfo
        {
            public OrderItemProgramInfo() { }
            public string OrderItemId { get; set; } = string.Empty;
            public bool isTransparency { get; set; } = false;
            public bool isSubscribe_And_Save { get; set; } = false;
        }

        public static OrderProgramInfo OrderProgramInfoEx(Order20260101 order)
        {
            OrderProgramInfo info = new OrderProgramInfo(order);

            if (order?.OrderItems == null)
            {
                throw new ArgumentNullException(nameof(order.Programs), "Order Item list cannot be null.");
            }
            if (order?.OrderItems.Count == 0)
            {
                throw new ArgumentException("Order must contain at least one Order Item.", nameof(order.OrderItems));
            }
            info.orderItems = new List<OrderItemProgramInfo>();
            foreach (OrderItem20260101 item in order.OrderItems)
            {
                if (item?.Programs == null)
                {
                    continue; // Skip items with null Programs list
                }
                if (item?.Programs.Count == 0)
                {
                    continue; // Skip items with empty Programs list
                }
                if (item?.OrderItemId == null)
                {
                    continue; // Skip items with null OrderItemId
                }
                info.orderItems.Add(new OrderItemProgramInfo()
                {
                    OrderItemId = item.OrderItemId,
                    isTransparency = item.Programs.Contains("PRIME") == true,
                    isSubscribe_And_Save = item.Programs.Contains("PREORDER") == true
                });
            }
            return info;
        }
    }
}