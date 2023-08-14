using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COMP_482_Assignment_03.Utility
{
	public enum StoreDepartment { Grocery, Produce, Meat, Deliy, Bakery };
	public enum IssueType { Missing_Item, Order_not_Received, Payment_Issue }
	public enum EmployeeRole { Employee, DepartmentManager, StoreManager };
	public enum EmployeeWorkTime { FullTime, PartTime, Seasonal, Perminant };
	public enum Status { Pending, Complete, Review };
	public enum OrderStatus { shipped, delivered, packing };
}
