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

			DataContext = new ApplicationViewModel();
		}
	}
}
