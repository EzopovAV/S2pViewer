using System;
using UiS2pViewer.Models.Interfaces;

namespace UiS2pViewer.Models
{
	public class SourceData : ISourceData
	{
		public string FullPathS2pFile { get; set; }
		public string Name { get; set; }
	}
}
