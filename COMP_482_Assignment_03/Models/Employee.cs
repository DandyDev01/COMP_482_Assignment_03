using COMP_482_Assignment_03.Utility;
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
		public string Password { get; set; }
		public StoreDepartment Department { get; set; }
		public EmployeeRole Role { get; set; }	
		public EmployeeWorkTime WorkTime { get; set; }

		public Employee(string _firstName, string _lastName, string _phoneNumber, string _EmployeeNumber, string _password,
			StoreDepartment _storeDepartment, EmployeeRole _role, EmployeeWorkTime _workTime)
		{
			FirstName = _firstName;
			LastName = _lastName;
			PhoneNumber = _phoneNumber;
			EmployeeNumber = _EmployeeNumber;
			Password = _password;
			Department = _storeDepartment;
			Role = _role;
			WorkTime = _workTime;
		}
	}
}
