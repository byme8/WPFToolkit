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

    public class IntViewModel : ViewModel<int>
	{

	}

    public class StringViewModel : ViewModel<string>
	{

	}

    public class DoubleViewModel : ViewModel<double>
	{

	}
}
