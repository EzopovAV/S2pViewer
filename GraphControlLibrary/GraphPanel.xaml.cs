using System.Windows.Controls;
using System.Windows.Shapes;

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
			DataContext = new GraphPanelViewModel();
		}
	}
}
