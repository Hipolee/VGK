using Content.Utilisateurs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public interface IDataUtilisateurs : IDataManager
    {
        IEnumerable<UtilisateurCommun> LesUtilisateurs { get; }
    }
}
