using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COMP_482_Assignment_03.Models
{
	public class OrderTracker
	{
		public StoreOrder[] Orders { get { return orders.ToArray(); } }

		public StoreOrder Last { get { return orders[orders.Count - 1]; } }

		private readonly List<StoreOrder> orders;

		public OrderTracker(StoreOrder[] _orders)
		{
			orders = _orders.ToList();
		}

		public void Add(StoreOrder order)
		{
			if (order == null)
				return;

			orders.Add(order);
		}

		public StoreOrder Remove(string ID)
		{
			if (string.IsNullOrEmpty(ID) || string.IsNullOrWhiteSpace(ID))
				return null;

			StoreOrder order = orders.Where(x => x.ID == ID).FirstOrDefault();

			if (order == null)
				return null;

			orders.Remove(order);

			return order;
		}

		public StoreOrder Get(string ID)
		{
			if (string.IsNullOrEmpty(ID) || string.IsNullOrWhiteSpace(ID))
				return null;

			StoreOrder order = orders.Where(x => x.ID == ID).FirstOrDefault();

			if (order == null)
				return null;

			return order;
		}
	}
}
