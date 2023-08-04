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
			if (employees == null)
				return;

			employees.Add(employee);
		}

		public Employee Remove(string employeeNumnber)
		{
			if (string.IsNullOrEmpty(employeeNumnber) || string.IsNullOrWhiteSpace(employeeNumnber))
				return null;

			Employee employee = employees.Where(x => x.EmployeeNumber == employeeNumnber).FirstOrDefault();

			if (employee == null)
				return null;

			employees.Remove(employee);

			return employee;
		}

		public Employee Get(string employeeNumber)
		{
			if (string.IsNullOrEmpty(employeeNumber) || string.IsNullOrWhiteSpace(employeeNumber))
				return null;

			Employee employee = employees.Where(x => x.EmployeeNumber == employeeNumber).FirstOrDefault();

			if (employee == null)
				return null;

			return employee;
		}
	}
}
