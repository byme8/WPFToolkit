using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPFToolkit.Test.ViewModels
{
	public abstract class ViewModel<TValue>
	{
		public string TypeName
			=> typeof(TValue).Name;
	}

	class IntViewModel : ViewModel<int>
	{

	}

	class StringViewModel : ViewModel<string>
	{

	}

	class DoubleViewModel : ViewModel<double>
	{

	}
}
