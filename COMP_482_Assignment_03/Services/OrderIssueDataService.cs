using COMP_482_Assignment_03.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COMP_482_Assignment_03.Services
{
	public class OrderIssueDataService : IDataService<OrderIssue>
	{
		public List<OrderIssue> GetAll()
		{
			return new List<OrderIssue>();
		}
	}
}
