using ImageDisplay.ViewModel;
using System.Windows;

namespace ImageDisplay
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new ImageDisplayViewModel();
        }
    }
}
