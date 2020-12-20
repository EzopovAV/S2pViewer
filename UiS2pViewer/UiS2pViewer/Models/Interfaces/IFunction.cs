using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UiS2pViewer.Enums;

namespace UiS2pViewer.Models.Interfaces
{
	interface IFunction
	{
		string Name { get; set; }
		ISourceData SourceData { get; set; }
		Sparametrs Sparametrs { get; set; }
	}
}
