using Library;

using System.Windows.Controls;
using Stub;
using ModelView.Views;

namespace ModelView.Views
{
    /// <summary>
    /// Logique d'interaction pour GameView.xaml
    /// </summary>
    public partial class GameView : UserControl
    {
        internal ViewModelBase GameManager
        {
            get
            {
                return (App.Current as App).GameManager;
            }
        }
        public GameView()
        {
            InitializeComponent();
            DataContext = GameManager;
             

        }
    }
}
