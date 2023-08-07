using COMP_482_Assignment_03.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace COMP_482_Assignment_03.Utility
{
	public class Authenticator : IValueConverter
	{
		public bool Authenticate(Employee employee)
		{
			if (employee == null)
				return false;

			switch (employee.Role)
			{
				case EmployeeRole.Employee:
					return false;
				case EmployeeRole.DepartmentManager:
					return true;
				case EmployeeRole.StoreManager:
					return true;
				default:
					return false;
			}
		}

		public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			return Authenticate(value as Employee);
		}

		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			throw new NotImplementedException();
		}
	}
}
