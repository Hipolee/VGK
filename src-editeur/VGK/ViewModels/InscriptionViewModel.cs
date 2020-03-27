using Library;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;


namespace ModelView.ViewModels
{
    class InscriptionViewModel : ViewModelBase
    {
        public ICommand RetourCommand { get; set; }
        public InscriptionViewModel() : base()
        {
            RetourCommand = new DelegateCommand(o=>CloseAction(),o=>true);
        }
    }
}
