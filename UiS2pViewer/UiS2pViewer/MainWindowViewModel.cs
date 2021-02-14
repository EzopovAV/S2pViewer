using GraphControlLibrary;
using GraphControlLibrary.Enums;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Media;
using UiS2pViewer.Interfaces;
using UiS2pViewer.Models.Interfaces;

namespace UiS2pViewer
{
	public class MainWindowViewModel : INotifyPropertyChanged
	{
		private readonly IDialogService _dialogService;
		private readonly ISourceDataProvider _sourceDataProvider;

		public MainWindowViewModel(IDialogService dialogService, ISourceDataProvider sourceDataProvider)
		{
			_dialogService = dialogService;
			_sourceDataProvider = sourceDataProvider;

			SourceDatas = new ObservableCollection<ISourceData>();

			Curves = new ObservableCollection<Curve>
			{
				new Curve(
					new double[]{10, 30, 50, 70, 90, 110, 130, 150, 170, 190},
					new double[]{150, 140, 170, 120, 190, 100, 210, 80, 230, 60},
					10,
					new SolidColorBrush(Color.FromRgb(20, 20, 127)),
					LineType.solid),

				new Curve(
					new double[]{150, 140, 170, 120, 190, 100, 210, 80, 230, 60},
					new double[]{10, 30, 50, 70, 90, 110, 130, 150, 170, 190},
					10,
					new SolidColorBrush(Color.FromRgb(20, 127, 20)),
					LineType.solid),
			};
		}
		public ObservableCollection<Curve> Curves { get; set; }
		public ObservableCollection<IGraph> Graphs { get; set; }
		public ObservableCollection<ISourceData> SourceDatas { get; set; }

		private IGraph _selectedGraph;
		public IGraph SelectedGraph
		{
			get { return _selectedGraph; }
			set
			{
				_selectedGraph = value;
				OnPropertyChanged("SelectedGraph");
			}
		}

		private RelayCommand _openCommand;
		public RelayCommand OpenCommand
		{
			get
			{
				return _openCommand ??
					(_openCommand = new RelayCommand(obj =>
					{
						try
						{
							if (_dialogService.OpenFileDialog() == true)
							{
								var sourceData = _sourceDataProvider.GetSourceData(_dialogService.FilePath);
								SourceDatas.Add(sourceData);
								_dialogService.ShowMessage("File is opend.");
							}
						}
						catch (Exception ex)
						{
							_dialogService.ShowMessage(ex.Message);
						}
					}));
			}
		}

		public event PropertyChangedEventHandler PropertyChanged;
		public void OnPropertyChanged([CallerMemberName]string prop = "")
		{
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
		}
	}
}
