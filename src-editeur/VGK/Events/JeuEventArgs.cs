using Model.Jeux;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VGK.Events
{
    public class JeuEventArgs : EventArgs
    {
        public Jeu Jeu { get; set; }
    }
}
