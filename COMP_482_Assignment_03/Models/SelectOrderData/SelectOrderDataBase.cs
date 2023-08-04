using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COMP_482_Assignment_03.Models.SelectOrderData
{
	public interface SelectOrderDataBase
	{
		public StoreOrder SelectedOrder { get; set; }
	}
}
