using COMP_482_Assignment_03.Utility;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Input;

namespace COMP_482_Assignment_03.ViewModels
{
	public enum IssueType { Missing_Item, Order_not_Received, Payment_Issue }
	
	public class OrderIssueViewModel : ObservableObject
	{
		public ICommand SubmitCommand { get; }
		public ICommand CancelCommand { get; }

		public ObservableCollection<Object> OpenOrderIssues { get; }
		public ICollectionView OpenOrderIssuesCollectionView { get; }
		public Array IssueTypes { get; } = Enum.GetValues(typeof(IssueType));
		public string Date { get; }

		private IssueType selectedIssueType;
		public IssueType SelectedIssueType
		{
			get
			{
				return selectedIssueType;
			}
			set
			{
				OnPropertyChanged(ref selectedIssueType, value);
			}
		}

		private StoreDepartment selectedEmpoyeeDepartment;
		public StoreDepartment SelectedEmpoyeeDepartment
		{
			get
			{
				return selectedEmpoyeeDepartment;
			}
			set
			{
				OnPropertyChanged(ref selectedEmpoyeeDepartment, value);
			}
		}

		private string issueDescription;
		public string IssueDescription
		{
			get
			{
				return issueDescription;
			}
			set
			{
				OnPropertyChanged(ref issueDescription, value);
			}
		}

		private string empoyeeName;
		public string EmpoyeeName
		{
			get
			{
				return empoyeeName;
			}
			set
			{
				OnPropertyChanged(ref empoyeeName, value);
			}
		}

		private string emloyeeNumber;
		public string EmployeeNumber
		{
			get
			{
				return emloyeeNumber;
			}
			set
			{
				OnPropertyChanged(ref emloyeeNumber, value);
			}
		}

		private readonly CollectionViewPropertySort collectionViewPropertySort;

		public OrderIssueViewModel()
		{
			OpenOrderIssues = new ObservableCollection<Object>();
			OpenOrderIssuesCollectionView = CollectionViewSource.GetDefaultView(OpenOrderIssues);

			collectionViewPropertySort = new CollectionViewPropertySort(OpenOrderIssuesCollectionView);

			Date = DateTime.Now.ToString();
		}
	}
}
