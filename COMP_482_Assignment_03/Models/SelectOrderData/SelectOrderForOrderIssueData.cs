using COMP_482_Assignment_03.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COMP_482_Assignment_03.Models.SelectOrderData
{
	public class SelectOrderForOrderIssueData : SelectOrderDataBase
	{
		private readonly OrderIssueViewModel orderIssueVM;

		public SelectOrderForOrderIssueData(OrderIssueViewModel _orderIssueVM)
		{
			orderIssueVM = _orderIssueVM;
		}

		/// <summary>
		/// sets and gets OrderIssueViewModel.selectedOrder 
		/// </summary>
		public Order SelectedOrder 
		{
			get => orderIssueVM.SelectedOrder;
			set
			{
				orderIssueVM.SelectedOrder = value;
				orderIssueVM.SelectedOrderID = "Selected Order ID: " + value.ID;
			}
		}
	}
}
