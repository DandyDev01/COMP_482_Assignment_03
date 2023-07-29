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
			// validation should be done already
			// do null check

			orders.Add(order);
		}

		public StoreOrder Remove(string ID)
		{
			return null;
		}

		public StoreOrder Get(string ID)
		{
			return null;
		}
	}
}
