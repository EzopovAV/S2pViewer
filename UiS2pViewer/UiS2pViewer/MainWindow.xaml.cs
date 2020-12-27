using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using UiS2pViewer.Models;
using UiS2pViewer.Models.Interfaces;

namespace UiS2pViewer
{
	/// <summary>
	/// Логика взаимодействия для MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		private ObservableCollection<ISourceData> _sourceData;

		private ObservableCollection<IGraph> _graphs;

		public MainWindow()
		{
			InitializeComponent();

			_sourceData = new ObservableCollection<ISourceData>
			{
				new SourceDataProvider().GetSourceData("GPPM-1_Chanel-5_Rx_ATTen-2_PHase-9.s2p"),
				new SourceDataProvider().GetSourceData("ZVA40 mp200-ctrl1-0,0-ctrl2-0,0.s2p"),
				new SourceDataProvider().GetSourceData("AP003D01_RX_ATT_State31.s2p"),
			};
			sourceDataTreeViewItem.ItemsSource = _sourceData;
			
			_graphs = new ObservableCollection<IGraph>
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
			graphsTreeViewItem.ItemsSource = _graphs;
			graphsTabControl.ItemsSource = _graphs;
		}
	}
}
