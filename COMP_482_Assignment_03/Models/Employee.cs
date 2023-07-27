using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COMP_482_Assignment_03.Models
{
	public class Employee
	{
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public string PhoneNumber { get; set; }
		public string EmployeeNumber { get; set; }

		public Employee(string _firstName, string _lastName, string _phoneNumber, string _EmployeeNumber)
		{
			FirstName = _firstName;
			LastName = _lastName;
			PhoneNumber = _phoneNumber;
			EmployeeNumber = _EmployeeNumber;
		}

		public Employee()
		{
			FirstName = string.Empty;
			LastName = string.Empty;
			PhoneNumber = string.Empty;
			EmployeeNumber = string.Empty;
		}
	}
}
