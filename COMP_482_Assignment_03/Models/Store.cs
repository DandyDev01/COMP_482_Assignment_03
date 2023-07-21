using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COMP_482_Assignment_03.Models
{
	public class Store
	{
		private readonly EmployeeManager employeeManager;
		private readonly OrderIssueTracker orderIssueTracker;
		private readonly OrderTracker orderTracker;
		private readonly Inventory inventory;

		public Store(OrderIssueTracker _orderIssueTracker, Inventory _inventory, EmployeeManager _employeeManager, OrderTracker _orderTracker)
		{
			orderTracker = _orderTracker;
			employeeManager = _employeeManager;
			inventory = _inventory;
			orderIssueTracker = _orderIssueTracker;
		}
	}
}
