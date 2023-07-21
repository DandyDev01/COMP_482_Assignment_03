using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COMP_482_Assignment_03.Models
{
	public class EmployeeManager
	{
		public Employee[] Employees { get { return employees.ToArray(); } }

		private readonly List<Employee> employees;

		public EmployeeManager(Employee[] _employees)
		{
			employees = _employees.ToList();
		}

		public void Add(Employee employee)
		{
			// validation should already be done
			// do a null check
		}

		public Employee Remove(string employeeNumnber)
		{
			return null;
		}

		public Employee Get(string employeeNumber)
		{
			return null;
		}
	}
}
