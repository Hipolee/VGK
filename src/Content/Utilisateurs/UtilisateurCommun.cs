using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Content.Utilisateurs
{
    [DataContract]
    public class UtilisateurCommun : Utilisateur
    {
        #region private
        private string _username;
        private string _password;
        

        #endregion

        #region public
        [DataMember]
        public string Username
        {
            get
            {
                return _username;
            }

            set
            {
                _username = value;
            }
        }

        [DataMember]
        public string Password
        {
            get
            {
                return _password;
            }

            set
            {
                _password = value;
            }
        }
        #endregion

        public UtilisateurCommun(string username, string password)
        {
            Username = username;
            Password = password;
            IsAuthenticated = true;
        }
        #region Equals
        public override bool Equals(object obj)
        {
            if (object.ReferenceEquals(obj, null))
            {
                return false;
            }

            if (object.ReferenceEquals(this, obj))
            {
                return true;
            }

            if (this.GetType() != obj.GetType())
            {
                return false;
            }

            return this.Equals(obj as UtilisateurCommun);
        }


        public bool Equals(UtilisateurCommun other)
        {
            if (Username != other.Username) return false;
            if (Password != other.Password) return false;
            return true;

        }
        #endregion
    }
}
