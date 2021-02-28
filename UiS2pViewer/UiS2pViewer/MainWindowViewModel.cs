using GraphControlLibrary;
using GraphControlLibrary.Enums;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Media;
using UiS2pViewer.Interfaces;
using UiS2pViewer.Models;
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

			Graphs = new ObservableCollection<IGraph>()
			{
				new Graph
				{
					Name = "S21",
					FunctionList = new List<IFunction>
					{
						new Function
						{
							Name = "S21, dB",
						},

						new Function
						{
							Name = "S21, °",
						}
					},
					ViewModel = new GraphPanelViewModel()
					{
						Curves = new ObservableCollection<Curve>
			{
				new Curve(
					new double[]{10, 30, 50, 70, 90, 110, 130, 150, 170, 190},
					new double[]{150, 140, 170, 120, 190, 100, 210, 80, 230, 60},
					10,
					new SolidColorBrush(Color.FromRgb(0, 200, 127)),
					GraphControlLibrary.Enums.LineType.solid),

				new Curve(
					new double[]{150, 140, 170, 120, 190, 100, 210, 80, 230, 60},
					new double[]{10, 30, 50, 70, 90, 110, 130, 150, 170, 190},
					10,
					new SolidColorBrush(Color.FromRgb(0, 127, 200)),
					GraphControlLibrary.Enums.LineType.solid),
			}
					}
				},

				new Graph
				{
					Name = "S12, dB",
					FunctionList = new List<IFunction>
					{
						new Function
						{
							Name = "S12, dB",
							MarkerList = new List<IMarker>
							{
								new Marker
								{
									Name = "marker1",
								},
								new Marker
								{
									Name = "marker2",
								},
								new Marker
								{
									Name = "marker3",
								},
							}
						}
					}
				},

				new Graph
				{
					Name = "S12, °",
					FunctionList = new List<IFunction>
					{
						new Function
						{
							Name = "S12, °",
							MarkerList = new List<IMarker>
							{
								new Marker
								{
									Name = "New marker",
								}
							}
						}
					}
				},

				new Graph
				{
					Name = "S11, dB",
					FunctionList = new List<IFunction>
					{
						new Function
						{
							Name = "S11, dB",
							MarkerList = new List<IMarker>
							{
								new Marker
								{
									Name = "New marker",
								}
							}
						}
					}
				},

				new Graph
				{
					Name = "S11, °",
					FunctionList = new List<IFunction>
					{
						new Function
						{
							Name = "S11, °",
							MarkerList = new List<IMarker>
							{
								new Marker
								{
									Name = "New marker",
								}
							}
						}
					}
				},

				new Graph
				{
					Name = "S22, dB",
					FunctionList = new List<IFunction>
					{
						new Function
						{
							Name = "S21, dB",
							MarkerList = new List<IMarker>
							{
								new Marker
								{
									Name = "New marker",
								}
							}
						}
					}
				},

				new Graph
				{
					Name = "S22, °",
					FunctionList = new List<IFunction>
					{
						new Function
						{
							Name = "S22, °",
							MarkerList = new List<IMarker>
							{
								new Marker
								{
									Name = "New marker",
								}
							}
						}
					}
				},
			};

			Graphs[0].ViewModel.AddCurve(new double[] { 10, 30, 50, 70, 90, 110, 130, 150, 170, 190 },
					new double[] { 150, 140, 170, 120, 190, 100, 210, 80, 230, 60 });
			//Curves = new ObservableCollection<Curve>
			//{
			//	new Curve(
			//		new double[]{10, 30, 50, 70, 90, 110, 130, 150, 170, 190},
			//		new double[]{150, 140, 170, 120, 190, 100, 210, 80, 230, 60},
			//		10,
			//		new SolidColorBrush(Color.FromRgb(20, 20, 0)),
			//		LineType.solid),

			//	new Curve(
			//		new double[]{150, 140, 170, 120, 190, 100, 210, 80, 230, 60},
			//		new double[]{10, 30, 50, 70, 90, 110, 130, 150, 170, 190},
			//		10,
			//		new SolidColorBrush(Color.FromRgb(20, 0, 20)),
			//		LineType.solid),
			//};
			//graphPanelViewModel = new GraphPanelViewModel(graphPanelContext);
			//graphPanelViewModel.Curves = Curves;
			//graphPanelViewModel.AddCurve(
			//	new double[] { 15, 140, 170, 120, 190, 100, 210, 80, 230, 60 },
			//	new double[] { 10, 300, 50, 70, 90, 110, 130, 150, 170, 190 });
		}
		//public GraphPanelViewModel graphPanelViewModel { get; set; }
		//public ObservableCollection<Curve> Curves { get; set; }
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
