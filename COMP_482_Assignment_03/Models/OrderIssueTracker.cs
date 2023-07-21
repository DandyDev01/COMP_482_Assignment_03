using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COMP_482_Assignment_03.Models
{
	public class OrderIssueTracker
	{
		public OrderIssue[] OrderIssues { get { return orderIssues.ToArray(); } }

		private readonly List<OrderIssue> orderIssues;

		public OrderIssueTracker(OrderIssue[] _orderIssues)
		{
			orderIssues = _orderIssues.ToList();
		}

		public void Add(OrderIssue orderIssue)
		{
			// data validation should already be done
			// just do a null check
		}

		public OrderIssue Remove(string ID)
		{
			return null;
		}

		public OrderIssue Get(string ID)
		{
			return null;
		}
	}
}
