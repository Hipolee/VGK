using Model;
using Model.Jeux;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stub
{
    
    public class StubManager : IDataManager
    {
        private IEnumerable<Jeu> _lesJeux = new List<Jeu>{
                new Jeu()
                {
                    Description="Minecraft est un jeu vidéo de type « bac à sable » (construction complètement libre - sandbox en anglais) développé par le Suédois Markus Persson, alias Notch, puis par le studio de développement Mojang. Ce jeu vidéo plonge le joueur dans un univers généré aléatoirement et composé de voxels. Le jeu intègre un système d'artisanat axé sur l'exploitation de ressources naturelles (minéralogiques, fossiles, animales et végétales), puis sur leur transformation en produits artisanaux.",
                    ImagePath = new Uri(@"..\..\Images\Minecraft.jpg",UriKind.Relative),
                    Titre = "Minecraft",
                    Categorie1= Categorie.SandBox,
                    Categorie2=Categorie.Aventure,
                    Date=new DateTime(2009, 10, 27),
                    Editeur = "Mojang",
                    Prix = 20.00f
                },
                new Jeu()
                {
                    Description="League of Legends est un jeu compétitif en ligne rempli d'action, qui mélange l'intensité trépidante des jeux de stratégie en temps réel avec des éléments de jeu de rôle. Deux équipes de puissants champions, chacun avec un design et des compétences uniques, se heurtent de front sur de nombreux champs de bataille et dans des modes de jeu variés. Avec une liste de champions en expansion permanente, des mises à jour fréquentes et des événements compétitifs florissants, League of Legends offre des parties sans cesse renouvelées aux joueurs de tous niveaux.",
                    ImagePath = new Uri(@"..\..\Images\League of Legends.jpg",UriKind.Relative),
                    Titre = "League of Legends",
                    Categorie1=Categorie.Action,
                    Categorie2=Categorie.Stratégie,
                    Date=new DateTime(2011, 11, 18),
                    Editeur = "Riot",
                    Prix = 0f
                }
            };
        public IEnumerable<Jeu> LesJeux
        {
            get
            {
                return _lesJeux;
            }


        }

        public IEnumerable<Editeur> _lesEdit = new List<Editeur>
        {
            new Editeur()
            {
                Description="Blizzard Entertainment est une société américaine de développement et d’édition de jeux vidéo siégeant à Irvine en Californie.",
                ImagePath = new Uri (@"..\..\Images\Blizzard.jpg",UriKind.Relative),
                Nom = "Blizzard",
                DateCreation = new DateTime(1991, 02, 8)
            },
            new Editeur()
            {
                Description="Riot Games est une entreprise américaine d'édition et de développement de jeux vidéo fondée en 2006.",
                ImagePath= new Uri (@"..\..\Images\Riot.png",UriKind.Relative),
                Nom = "Riot",
                DateCreation = new DateTime(2006, 09, 15)
            }
        };

        public IEnumerable<Editeur> LesEdit
        {
            get
            {
                return _lesEdit;
            }


        }

        public void Add(Jeu jeu)
        {
            (_lesJeux as List<Jeu>).Add(jeu);
            Debug.WriteLine($"Le jeu {jeu.Titre} a été ajouté");
        }

        public void Remove(Jeu jeu)
        {
            (_lesJeux as List<Jeu>).Remove(jeu);
            Debug.WriteLine($"Le jeu {jeu.Titre} a été enlevé");
        }

        public void Update(Jeu jeu)
        {
            Debug.WriteLine($"Le jeu {jeu.Titre} a été modifié");
        }
    }

}
