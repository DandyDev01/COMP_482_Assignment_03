using COMP_482_Assignment_03.Models;
using COMP_482_Assignment_03.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COMP_482_Assignment_03.Services
{
	public class EmployeeDataService : IDataService<Employee>
	{
		public List<Employee> GetAll()
		{
			return new List<Employee>()
			{
				new Employee("James", "Bond", "780-345-3242", "000001", StoreDepartment.Grocery, EmployeeRole.Employee,
					EmployeeWorkTime.FullTime),
				new Employee("Amy", "Davis", "124-421-4422", "000003", StoreDepartment.Deliy, EmployeeRole.Employee,
					EmployeeWorkTime.FullTime),
				new Employee("Don", "Brie", "554-321-4000", "000004", StoreDepartment.Grocery, EmployeeRole.Employee,
					EmployeeWorkTime.FullTime),
				new Employee("Dave", "Larson", "780-543-2423", "000002", StoreDepartment.Bakery, EmployeeRole.DepartmentManager,
					EmployeeWorkTime.FullTime),
				new Employee("Mike", "Ikes", "598-123-3223", "000006", StoreDepartment.Produce, EmployeeRole.DepartmentManager,
					EmployeeWorkTime.FullTime),
				new Employee("Arthur", "PenDragon", "780-345-5682", "000008", StoreDepartment.Grocery, EmployeeRole.StoreManager,
					EmployeeWorkTime.FullTime),
				new Employee("Merlin", "Wizard", "780-315-3642", "000009", StoreDepartment.Grocery, EmployeeRole.DepartmentManager,
					EmployeeWorkTime.FullTime),
				new Employee("Tammy", "Bennet", "587-335-3782", "000010", StoreDepartment.Meat, EmployeeRole.Employee,
					EmployeeWorkTime.FullTime),
				new Employee("Tommy", "Dogooder", "780-325-3282", "000011", StoreDepartment.Grocery, EmployeeRole.Employee,
					EmployeeWorkTime.FullTime)
			};
		}
	}
}
