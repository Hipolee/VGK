using System.Collections.Generic;
using Content.Utilisateurs;
using System.Runtime.Serialization;
using System.IO;
using Model;
using System;

namespace XmlData
{
    public class XmlDataUtilisateur : XmlDataManager, IDataUtilisateurs
    {
        private List<UtilisateurCommun> _lesUtilisateurs = new List<UtilisateurCommun> {new UtilisateurCommun("arthur","123")
                
            };

        DataContractSerializer Serializer { get; set; } = new DataContractSerializer(typeof(List<UtilisateurCommun>));

        public IEnumerable<UtilisateurCommun> LesUtilisateurs
        {
            get
            {
                /*using (Stream s = File.OpenRead(xmlFile))
                {
                    _lesUtilisateurs = Serializer.ReadObject(s) as List<UtilisateurCommun>;
                }*/

                return _lesUtilisateurs.AsReadOnly();
            }
            
        }

        string xmlFile = "utilisateurs.xml";

        protected override void SaveChanges()
        {
            using (Stream s = File.Create(xmlFile))
            {
                Serializer.WriteObject(s, _lesUtilisateurs);
            }
        }

        public void Add(object obj)
        {
            UtilisateurCommun user = obj as UtilisateurCommun;
            if (user == null) return;
            _lesUtilisateurs.Add(user);
            SaveChanges();

        }

        public void Remove(object obj)
        {
            UtilisateurCommun user = obj as UtilisateurCommun;
            if (user == null) return;
            _lesUtilisateurs.Remove(user);
            SaveChanges();
        }

        public void Update(object obj)
        {
            throw new NotImplementedException();
        }
    }
}
