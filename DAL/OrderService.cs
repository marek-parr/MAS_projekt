﻿using MAS_projekt.Models.Orders;
using MAS_projekt.Models.People;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.ObjectModel;
using System.Linq;

namespace MAS_projekt.DAL
{
    public class OrderService
    {
        private readonly MasDbContext _context = new MasDbContext();

        public void UpdateDbContext()
        {
            _context.SaveChanges();
        }

        public ObservableCollection<Order> GetOrders()
        {
            return new ObservableCollection<Order>(_context.Orders
                .Include(order => order.Client)
                    .ThenInclude(c => c.Person)
                .Include(order => order.Items)
                    .ThenInclude(item => item.Product)
                .ToList());
        }


        public ObservableCollection<Order> GetOrdersInProgressOrCreated()
        {
            return new ObservableCollection<Order>(_context.Orders
                .Where(order => order.State.Equals(OrderState.CREATED) || order.State.Equals(OrderState.IN_PROGRESS))
                .Include(order => order.Client)
                    .ThenInclude(c => c.Person)
                .Include(order => order.Items)
                    .ThenInclude(item => item.Product)
                .ToList());
        }

        public ObservableCollection<Order> GetOrdersOfClient(Client client)
        {
            if (client == null)
            {
                return GetOrders();
            }
            return new ObservableCollection<Order>(client.Orders);
        }

        public Order GetOrderById(int id)
        {
            return _context.Orders
                .Include(o => o.Client)
                    .ThenInclude(c => c.Person)
                .Include(o => o.Items)
                    .ThenInclude(i => i.Product)
                .FirstOrDefault(o => o.Id == id);
        }

        public void ChangeOrderState(Order order, OrderState newState)
        {
            order.State = newState;
            UpdateDbContext();
        }

        public void RejectOrder(int orderId)
        {
            var order = GetOrderById(orderId);
            if (!order.State.Equals(OrderState.IN_PROGRESS))
            {
                throw new WrongOrderStateException(order, OrderState.IN_PROGRESS);
            }
            order.CanceledOrRejected = DateTime.Now;
            ChangeOrderState(order, OrderState.REJECTED);
        }

        public void CancelOrder(int orderId)
        {
            var order = GetOrderById(orderId);
            if (!order.State.Equals(OrderState.CREATED))
            {
                throw new WrongOrderStateException(order, OrderState.CREATED);
            }
            order.CanceledOrRejected = DateTime.Now;
            ChangeOrderState(order, OrderState.CANCELED);
        }

        public void ProceedToNextOrderState(int orderId)
        {
            var order = GetOrderById(orderId);
            switch (order.State)
            {
                case OrderState.CREATED:
                    ChangeOrderState(order, OrderState.IN_PROGRESS);
                    break;
                case OrderState.IN_PROGRESS:
                    ChangeOrderState(order, OrderState.DONE);
                    break;
                default:
                    throw new WrongOrderStateException(order);
            }
        }

        public ObservableCollection<Order> GetOrdersFilteredByNumber(string orderNumber)
        {
            return new ObservableCollection<Order>(_context.Orders
                .Include(o => o.Client)
                    .ThenInclude(c => c.Person)
                .Include(o => o.Items)
                    .ThenInclude(i => i.Product)
                .Where(order => order.OrderNumber.ToString().Contains(orderNumber))
                .ToList());
        }

        public ObservableCollection<Order> GetOrdersOfClientFilteredByNumber(Client client, string orderNumber)
        {
            return new ObservableCollection<Order>(GetOrdersOfClient(client)
                .Where(order => order.OrderNumber.ToString().Contains(orderNumber))
                .ToList());
        }
    }
}
