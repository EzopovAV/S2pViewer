using GraphControlLibrary;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
using System.Windows.Media;
using UiS2pViewer.Interfaces;
using UiS2pViewer.Models.Interfaces;

namespace UiS2pViewer.Models
{
	class Graph : IGraph
	{
		private readonly IFunctionProvider _functionProvider;
		private readonly IEnumerable<ISourceData> _sourceDatas;
		public Graph(IEnumerable<ISourceData> sourceDatas)
		{
			_sourceDatas = sourceDatas;
			_functionProvider = new FunctionProvider();
		}
		public string Name { get; set; }
		public XAxisSettings XAxisSettings { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
		public YAxisSettings YAxisSettings { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
		public YAxisSettings SecondYAxisSettings { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
		public bool ShowGrid { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
		public Color GridColor { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
		public bool UseSecondYaxis { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
		public ObservableCollection<IFunction> FunctionList { get; set; }
		public GraphPanelViewModel ViewModel { get; set; }

		private RelayCommand _addNewFunctionCommand;
		public ICommand AddNewFunctionCommand
		{
			get
			{
				return _addNewFunctionCommand ??
					(_addNewFunctionCommand = new RelayCommand(obj =>
					{
						var function = _functionProvider.GenerateNewFunction(_sourceDatas);
						FunctionList.Add(function);
						
						ViewModel.AddCurve(function.DataX.ToArray(), function.DataY.ToArray());
					}
					));
			}
		}
	}
}
