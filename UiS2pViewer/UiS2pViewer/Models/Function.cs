using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Input;
using System.Windows.Media;
using UiS2pViewer.Enums;
using UiS2pViewer.Models.Interfaces;

namespace UiS2pViewer.Models
{
	class Function : IFunction
	{
		public string Name { get; set; }
		public ISourceData SourceData { get; set; }
		public Sparametrs Sparametrs { get; set; }
		public Color Color { get; set; }
		public ObservableCollection<IMarker> MarkerList { get; set; }

		private RelayCommand _addNewMarkerCommand;
		public ICommand AddNewMarkerCommand
		{
			get
			{
				return _addNewMarkerCommand ??
					(_addNewMarkerCommand = new RelayCommand(obj =>
					{
						if (MarkerList == null)
						{
							MarkerList = new ObservableCollection<IMarker>();
						}
						MarkerList.Add(new Marker
						{
							Name = "New marker",
							
						});
					}
					));
			}
		}

		public IEnumerable<double> DataX
		{
			get
			{
				foreach (var sample in SourceData.Samples)
				{
					yield return sample.Freq;
				}
			}
		}

		public IEnumerable<double> DataY
		{
			get
			{
				switch (Sparametrs)
				{
					case Sparametrs.S21Db:
						foreach (var sample in SourceData.Samples)
						{
							yield return sample.S21MagOrRe;
						}
						break;

					case Sparametrs.S21Degrees:
						foreach (var sample in SourceData.Samples)
						{
							yield return sample.S21AngOrIm;
						}
						break;

					case Sparametrs.S12Db:
						foreach (var sample in SourceData.Samples)
						{
							yield return sample.S12MagOrRe;
						}
						break;

					case Sparametrs.S12Degrees:
						foreach (var sample in SourceData.Samples)
						{
							yield return sample.S12AngOrIm;
						}
						break;

					case Sparametrs.S11Db:
						foreach (var sample in SourceData.Samples)
						{
							yield return sample.S11MagOrRe;
						}
						break;

					case Sparametrs.S11Degrees:
						foreach (var sample in SourceData.Samples)
						{
							yield return sample.S11AngOrIm;
						}
						break;

					case Sparametrs.S22Db:
						foreach (var sample in SourceData.Samples)
						{
							yield return sample.S22MagOrRe;
						}
						break;

					case Sparametrs.S22Degrees:
						foreach (var sample in SourceData.Samples)
						{
							yield return sample.S22AngOrIm;
						}
						break;

					default:
						throw new Exception("Unknown S-parametr");
				}
			}
		}
	}
}
