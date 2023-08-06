using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace COMP_482_Assignment_03.Utility
{
	public abstract class Validator : INotifyDataErrorInfo
	{
		public bool IsValid { get; private set; }

		public bool HasErrors => propertyNameToError.Any();
		public event EventHandler<DataErrorsChangedEventArgs>? ErrorsChanged;

		private readonly Dictionary<string, List<string>> propertyNameToError;

		public Validator()
		{
			propertyNameToError = new Dictionary<string, List<string>>();
		}

		public IEnumerable GetErrors(string? propertyName)
		{
			throw new NotImplementedException();
		}

		private void BasicStringFieldValidation(string propertyName, string propertyValue)
		{
			propertyNameToError.Remove(propertyName);

			List<string> errors = new List<string>();
			propertyNameToError.Add(propertyName, errors);
			if (string.IsNullOrEmpty(propertyValue) || string.IsNullOrWhiteSpace(propertyValue))
			{
				propertyNameToError[propertyName].Add("Cannot be empty or white space");
				ErrorsChanged?.Invoke(this, new DataErrorsChangedEventArgs(propertyName));
			}

			if (char.IsWhiteSpace(propertyValue.FirstOrDefault()))
			{
				propertyNameToError[propertyName].Add("Cannot start with white space");
				ErrorsChanged?.Invoke(this, new DataErrorsChangedEventArgs(propertyName));
			}

			if (propertyNameToError[propertyName].Any() == false)
			{
				propertyNameToError.Remove(propertyName);
			}

			IsValid = !HasErrors;
		}

		//private void CostToRetailCostValidation(float retailCost, float cost, string propertyName)
		//{
		//	propertyNameToError.Remove(nameof(RetailCost));
		//	propertyNameToError.Remove(nameof(Cost));

		//	List<string> retailErrors = new List<string>();
		//	List<string> errors = new List<string>();
		//	propertyNameToError.Add(nameof(RetailCost), retailErrors);
		//	propertyNameToError.Add(nameof(Cost), errors);
		//	if (cost < retailCost)
		//	{
		//		propertyNameToError[nameof(RetailCost)].Add("cost cannot be less than retail cost");
		//		ErrorsChanged?.Invoke(this, new DataErrorsChangedEventArgs(nameof(RetailCost)));

		//		propertyNameToError[nameof(Cost)].Add("retail cost cannot be greater than cost");
		//		ErrorsChanged?.Invoke(this, new DataErrorsChangedEventArgs(nameof(Cost)));
		//	}

		//	if (propertyNameToError[nameof(RetailCost)].Any() == false)
		//	{
		//		propertyNameToError.Remove(nameof(RetailCost));
		//	}

		//	if (propertyNameToError[nameof(Cost)].Any() == false)
		//	{
		//		propertyNameToError.Remove(nameof(Cost));
		//	}

		//	IsValid = !HasErrors;
		//}

		private void CostValidation(string propertyName, float value)
		{
			propertyNameToError.Remove(propertyName);

			List<string> errors = new List<string>();
			propertyNameToError.Add(propertyName, errors);
			if (value < 0.01)
			{
				propertyNameToError[propertyName].Add("must have cost at least 1 cent");
				ErrorsChanged?.Invoke(this, new DataErrorsChangedEventArgs(propertyName));
			}
			if (propertyNameToError[propertyName].Any() == false)
			{
				propertyNameToError.Remove(propertyName);
			}

			IsValid = !HasErrors;
		}

		private void QuantityValidation(string propertyName, float value)
		{
			propertyNameToError.Remove(propertyName);

			List<string> errors = new List<string>();
			propertyNameToError.Add(propertyName, errors);
			if (value < 0)
			{
				propertyNameToError[propertyName].Add("Cannot be less than 0");
				ErrorsChanged?.Invoke(this, new DataErrorsChangedEventArgs(propertyName));
			}


			if (propertyNameToError[propertyName].Any() == false)
			{
				propertyNameToError.Remove(propertyName);
			}

			IsValid = !HasErrors;
		}
	}
}
