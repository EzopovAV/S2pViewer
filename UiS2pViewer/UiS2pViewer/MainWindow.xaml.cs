using System.Windows;

namespace UiS2pViewer
{
	public partial class MainWindow : Window
	{
		public MainWindow()
		{
			InitializeComponent();
			DataContext = new MainWindowViewModel(new DefaultDialogService(), new SourceDataProvider());
		}
	}
}
