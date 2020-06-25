using MAS_projekt.Models.Orders;
using MAS_projekt.Models.People;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace MAS_projekt.DAL
{
    public class DbService
    {
        private MasDbContext _context = new MasDbContext();

        public void UpdateDbContext()
        {
            _context.SaveChanges();
        }

        public ICollection<Client> GetClients()
        {
            return _context.Clients.Include(x => x.Person).ToList();
        }

        public Client GetClientById(int id)
        {
            return _context.Clients.Include(x => x.Person).FirstOrDefault(x => x.Id == id);
        }

        public ICollection<Client> GetClientsFiltered(string filter)
        {
            return _context.Clients
                .Where(client => client.ClientNumberAndFullName.ToUpper().Contains(filter.ToUpper()))
                .Include(x => x.Person)
                .ToList();
        }

        public ICollection<Order> GetOrders()
        {
            return _context.Orders.Include(x => x.Client).ThenInclude(c => c.Person).ToList();
        }

        public ICollection<Order> GetOrdersOfClient(Client client)
        {
            return client.Orders.ToList();
        }

        public Order GetOrderById(int id)
        {
            return _context.Orders.Include(x => x.Client).FirstOrDefault(o => o.Id == id);
        }

        public void ChangeOrderState(Order order, OrderState newState)
        {
            order.State = newState;
            UpdateDbContext();
        }

        public void RejectOrder(Order order)
        {
            if (!order.State.Equals(OrderState.IN_PROGRESS))
            {
                throw new WrongOrderStateException(order, OrderState.IN_PROGRESS);
            }
            ChangeOrderState(order, OrderState.REJECTED);
        }

        public void CancelOrder(Order order)
        {
            if (!order.State.Equals(OrderState.CREATED))
            {
                throw new WrongOrderStateException(order, OrderState.CREATED);
            }
            ChangeOrderState(order, OrderState.CANCELED);
        }

        public void ProceedToNextOrderState(Order order)
        {
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

        public ICollection<Order> GetOrdersFilteredByNumber(string orderNumber)
        {
            return _context.Orders
                .Include(o => o.Client)
                .Where(order => order.OrderNumber.ToString().Contains(orderNumber))
                .ToList();
        }

        public ICollection<Order> GetOrdersOfClientFilteredByNumber(Client client, string orderNumber)
        {
            return GetOrdersOfClient(client)
                .Where(order => order.OrderNumber.ToString().Contains(orderNumber))
                .ToList();
        }
    }
}
