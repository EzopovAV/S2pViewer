using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UiS2pViewer.Interfaces;
using UiS2pViewer.Models;
using UiS2pViewer.Models.Interfaces;

namespace UiS2pViewer
{
	public class FunctionProvider : IFunctionProvider
	{
		public IFunction GenerateNewFunction(IEnumerable<ISourceData> sourceDatas)
		{
			return new Function()
			{
				Name = "New func from provider",
				MarkerList = new ObservableCollection<IMarker>(),
				SourceData = sourceDatas.FirstOrDefault()
			};
		}

		public IFunction ModifyExistingFunction(IFunction function)
		{
			throw new NotImplementedException();
		}
	}
}
