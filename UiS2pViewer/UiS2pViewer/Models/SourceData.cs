using normalizerS2Pfiles;
using System.Collections.Generic;
using UiS2pViewer.Models.Interfaces;

namespace UiS2pViewer.Models
{
	public class SourceData : ISourceData
	{
		public SourceData(string fullPathS2pFile, IEnumerable<Sample> samples, string name = "")
		{
			FullPathS2pFile = fullPathS2pFile;
			Samples = samples;
			Name = name;
		}
		public string Name { get; set; }
		public string FullPathS2pFile { get; }
		public IEnumerable<Sample> Samples { get; }
	}
}
