﻿using COMP_482_Assignment_03.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COMP_482_Assignment_03.Services
{
	public class OrderDataService : IDataService<Order>
	{
		public List<Order> GetAll()
		{
			return new List<Order>();
		}
	}
}
