using COMP_482_Assignment_03.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COMP_482_Assignment_03.Models
{
	public class OrderIssue
	{
		public string ID { get; set; }
		public string OrderID { get; set; }
		public string Description { get; set; }
		public string EmployeeName { get; set; }
		public string EmployeeNumber { get; set; }
		public StoreDepartment Departement { get; set; }
		public IssueType IssueType { get; set; }
	
		public OrderIssue(string _id, string _orderID, string _description, string _employeeName, string _employeeNumber, 
			StoreDepartment _depatement, IssueType _issueType)
		{
			ID = _id;
			OrderID = _orderID;
			Description = _description;
			EmployeeName = _employeeName;
			EmployeeNumber = _employeeNumber;
			Departement = _depatement;
			IssueType = _issueType;
		}

		public OrderIssue()
		{
			ID = string.Empty;
			OrderID = string.Empty;
			Description = string.Empty;
			EmployeeName = string.Empty;
			EmployeeNumber = string.Empty;
			Departement = StoreDepartment.Grocery;
			IssueType = IssueType.Missing_Item;
		}
	}
}
