using System.Collections.Generic;
using UiS2pViewer.Models.Interfaces;

namespace UiS2pViewer.Interfaces
{
	public interface IFunctionProvider
	{
		IFunction GenerateNewFunction(IEnumerable<ISourceData> sourceDatas);
		IFunction ModifyExistingFunction(IFunction function);
	}
}
