using ModelView.ViewModels;
using System.Windows;
using Stub;

namespace ModelView.Views
{
    /// <summary>
    /// Logique d'interaction pour App.xaml
    /// </summary>
    public partial class App : Application
    {

        internal MainViewModel MainManager { get; } = new MainViewModel();
        internal GameViewModel GameManager { get; } = new GameViewModel(new StubManager());
    }
}
