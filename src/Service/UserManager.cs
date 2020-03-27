using Content.Utilisateurs;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XmlData;

namespace Service
{
    public static class UserManager
    {
        
        public static IDataUtilisateurs DataManager { get; set; } = new XmlDataUtilisateur();

        public static bool CheckUser(UtilisateurCommun user)
        {
            if (DataManager.LesUtilisateurs.Contains(user)) return true;
            return false;
        }
    }
}
