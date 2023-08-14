using COMP_482_Assignment_03.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COMP_482_Assignment_03.Models.SelectOrderData
{
	public class SelectOrderForEditData : SelectOrderDataBase
	{
		public Order SelectedOrder 
		{
			get;
			set;
		}
	}
}
