using System.Windows;
using System.Windows.Controls;

namespace GraphControlLibrary
{
	/// <summary>
	/// Логика взаимодействия для GraphPanel.xaml
	/// </summary>
	public partial class GraphPanel : UserControl
	{
		public GraphPanel()
		{
			InitializeComponent();
			//DataContext = new GraphPanelViewModel(); //Why?
		}

		private void graphPanel_SizeChanged(object sender, SizeChangedEventArgs e)
		{
			if (Curves.ItemsSource != null)
			{
				foreach (var item in Curves.ItemsSource)
				{
					var curve = (Curve)item;
					curve.NumberOfPointsToDisplay = (int)graphPanel.ActualWidth;
				}
			}
		}
	}
}
