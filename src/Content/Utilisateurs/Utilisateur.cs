using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Content.Utilisateurs
{
    public abstract class Utilisateur
    {
        public bool IsAuthenticated { get; set; }
    }
}
