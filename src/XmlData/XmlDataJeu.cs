
using Model;
using Model.Jeux;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;


namespace XmlData
{
    public class XmlDataJeu :XmlDataManager, IDataJeu
    {

        private List<Jeu> _lesJeux = new List<Jeu>();
                
        DataContractSerializer Serializer { get; set; } = new DataContractSerializer(typeof(List<Jeu>));
        string xmlFile = "jeux.xml";

        public IEnumerable<Jeu> LesJeux
        {
            get
            {
                using (Stream s = File.OpenRead(xmlFile))
                {
                    _lesJeux = Serializer.ReadObject(s) as List<Jeu>;
                }

                return _lesJeux.AsReadOnly();
            }
        }

        public void Add(object obj)
        {
            Jeu jeu = obj as Jeu;
            if (jeu == null) return;
            if (_lesJeux.Contains(jeu)) return;
            _lesJeux.Add(jeu);
            SaveChanges();
        }

        public void Remove(object obj)
        {
            Jeu jeu = obj as Jeu;
            if (jeu == null) return;
            _lesJeux.Remove(jeu);
            SaveChanges();
        }

        public void Update(object obj)
        {
            Jeu jeu = obj as Jeu;
            if (jeu == null) return;
            if (!_lesJeux.Contains(jeu)) return;
            _lesJeux.Remove(jeu);
            _lesJeux.Add(jeu);
            SaveChanges();
        }

        protected override void SaveChanges()
        {
            using (Stream s = File.Create(xmlFile))
            {
                Serializer.WriteObject(s, _lesJeux);
            }
        }
    }
}
