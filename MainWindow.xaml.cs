using System.Windows;
using memory.viewmodels;

namespace memory
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public MainWindow()
        {
            DataContext = new MainWindowViewModel();
            InitializeComponent(); 
        }


    }
}
