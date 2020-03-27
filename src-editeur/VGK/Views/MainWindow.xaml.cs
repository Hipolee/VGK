using Library;
using System.Windows;



namespace ModelView.Views
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        internal ViewModelBase MainManager
        {
            get
            {
                return (Application.Current as App).MainManager;
            }
        }
        public MainWindow()
        {
            InitializeComponent();

            DataContext = MainManager;
        }


    }
}
