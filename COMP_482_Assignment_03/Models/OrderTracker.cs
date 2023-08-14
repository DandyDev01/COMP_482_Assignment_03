using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COMP_482_Assignment_03.Models
{
	public class OrderTracker
	{
		public Order[] Orders { get { return orders.ToArray(); } }

		public Order Last { get { return orders[orders.Count - 1]; } }

		private readonly List<Order> orders;

		public OrderTracker(Order[] _orders)
		{
			orders = _orders.ToList();
		}

		public void Add(Order order)
		{
			if (order == null)
				return;

			orders.Add(order);
		}

		public Order Remove(string ID)
		{
			if (string.IsNullOrEmpty(ID) || string.IsNullOrWhiteSpace(ID))
				return null;

			Order order = orders.Where(x => x.ID == ID).FirstOrDefault();

			if (order == null)
				return null;

			orders.Remove(order);

			return order;
		}

		public Order Get(string ID)
		{
			if (string.IsNullOrEmpty(ID) || string.IsNullOrWhiteSpace(ID))
				return null;

			Order order = orders.Where(x => x.ID == ID).FirstOrDefault();

			if (order == null)
				return null;

			return order;
		}
	}
}
