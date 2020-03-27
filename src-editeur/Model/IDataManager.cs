using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.Jeux;
namespace Model
{
    public interface IDataManager
    {
        IEnumerable<Jeu> LesJeux { get; }

        IEnumerable<Editeur> LesEdit { get; }

        void Add(Jeu jeu);

        void Remove(Jeu jeu);

        void Update(Jeu jeu);
    }
}
