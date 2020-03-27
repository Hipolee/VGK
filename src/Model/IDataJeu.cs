using Model.Jeux;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public interface IDataJeu : IDataManager
    {
        IEnumerable<Jeu> LesJeux { get; }
    }
}
