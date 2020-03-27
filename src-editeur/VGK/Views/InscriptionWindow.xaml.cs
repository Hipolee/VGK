using Library;
using ModelView.ViewModels;
using Stub;
using System;
using System.Collections.Generic;
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
using System.Windows.Shapes;



namespace ModelView.Views
{
    /// <summary>
    /// Logique d'interaction pour InscriptionWindow.xaml
    /// </summary>
    public partial class InscriptionWindow : Window
    {
        public InscriptionWindow()
        {
            InitializeComponent();
            DataContext = new InscriptionViewModel();
            ((ViewModelBase)DataContext).CloseAction = () => this.Close();
        }
    }
}
