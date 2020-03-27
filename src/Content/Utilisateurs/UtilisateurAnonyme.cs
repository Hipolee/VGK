using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Content.Utilisateurs
{
    public class UtilisateurAnonyme:Utilisateur
    {
        public UtilisateurAnonyme()
        {
            IsAuthenticated = false;
        }
    }
}
