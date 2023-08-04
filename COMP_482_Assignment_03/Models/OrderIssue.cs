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
		public string ID { get; }
		public string OrderID { get; }
		public string Description { get; }
		public string EmployeeName { get; }
		public string EmployeeNumber { get; }
		public StoreDepartment Departement { get; }
		public IssueType IssueType { get; }
	
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
	}
}
