using System;
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
		public ISourceData SourceData { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
		public Sparametrs Sparametrs { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
		public Color Color { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
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
	}
}
