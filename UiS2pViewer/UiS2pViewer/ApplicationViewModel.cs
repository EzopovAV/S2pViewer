using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using UiS2pViewer.Models;
using UiS2pViewer.Models.Interfaces;

namespace UiS2pViewer
{
	public class ApplicationViewModel : INotifyPropertyChanged
	{
		private IGraph _selectedGraph;
		public ObservableCollection<IGraph> Graphs { get; set; }
		public ObservableCollection<ISourceData> SourceDatas { get; set; }
		public IGraph SelectedGraph
		{
			get { return _selectedGraph; }
			set
			{
				_selectedGraph = value;
				OnPropertyChanged("SelectedGraph");
			}
		}

		public ApplicationViewModel()
		{
			SourceDatas = new ObservableCollection<ISourceData>
			{
				new SourceDataProvider().GetSourceData("GPPM-1_Chanel-5_Rx_ATTen-2_PHase-9.s2p"),
				new SourceDataProvider().GetSourceData("ZVA40 mp200-ctrl1-0,0-ctrl2-0,0.s2p"),
				new SourceDataProvider().GetSourceData("AP003D01_RX_ATT_State31.s2p"),
			};
			Graphs = new ObservableCollection<IGraph>
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
			SelectedGraph = Graphs.FirstOrDefault();
		}

		public event PropertyChangedEventHandler PropertyChanged;
		public void OnPropertyChanged([CallerMemberName]string prop = "")
		{
			if (PropertyChanged != null)
				PropertyChanged(this, new PropertyChangedEventArgs(prop));
		}
	}
}
