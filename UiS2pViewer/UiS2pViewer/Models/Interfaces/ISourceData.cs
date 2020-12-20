using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UiS2pViewer.Models.Interfaces
{
	public interface ISourceData
	{
		string FullPathS2pFile { get; set; }
		string Name { get; set; }
	}
}
