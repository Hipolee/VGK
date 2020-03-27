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
    
    public class StubManager 
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
                },
                new Jeu()
                {
                    Description="Vous êtes l'homme de la situation. Applaudi par vos pairs pour vos compétences et votre savoir, vous bravez tous les dangers dès qu'il s'agit de rendre service aux citoyens. Opérant dans l'ombre, personne ne connaît votre identité et les gens passent à côté de vous sans même vous remarquer. Vous êtes le seul à pouvoir remplir les missions qui vont vous être confiées car vous êtes le meilleur agent. Mais pas n'importe quel type d'agent... Un agent de la DDE.",
                    ImagePath = new Uri(@"..\..\Images\Travaux routiers Simulator.jpg",UriKind.Relative),
                    Titre = "Travaux routiers Simulator",
                    Categorie1=Categorie.Simulation,
                    Date=new DateTime(2011,10, 15),
                    Editeur = " UIG Entertainment",
                    Prix = 20f
                },
                new Jeu()
                {
                    Description="Street Fighter II sur Super Nintendo est le deuxième épisode du jeu de combat sorti en 1988 sur diverses consoles et bornes d'arcade. Vous avez le choix parmi huit personnages ayant chacun son propre style de jeu et ses propres techniques spéciales. Dans le mode solo, vous devez affronter les sept autres personnages plus quatre boss cachés. A deux, chacun choisit son personnage pour tenter d'éliminer l'autre.",
                    ImagePath = new Uri(@"..\..\Images\Street Fighter II.jpg",UriKind.Relative),
                    Titre = "Street Fighter II",
                    Categorie1=Categorie.Combat,
                    Categorie2=Categorie.Action,
                    Date=new DateTime(1992,09, 01),
                    Editeur = "Capcom",
                    Prix = 25f
                },
                new Jeu()
                {
                    Description="Half-Life est un jeu de tir à la première personne sur PC. Sous les traits de Gordon Freeman vous travaillez en tant que jeune scientifique dans un centre de recherche secret du nom de Black Mesa. Inévitablement, un incident vient perturber l'une de vos expériences sur un matériau inconnu. Toutes sortes d'entités aliens prennent alors possession de la station. Arriverez-vous à regagner la sortie pour appeler les secours ?",
                    ImagePath = new Uri(@"..\..\Images\Half-Life.jpg",UriKind.Relative),
                    Titre = "Half-Life",
                    Categorie1=Categorie.FPS,
                    Categorie2=Categorie.Action,
                    Date=new DateTime(1998,11, 19),
                    Editeur = "Sierra",
                    Prix = 10f
                }
            };
        public IEnumerable<Jeu> LesJeux
        {
            get
            {
                return _lesJeux;
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
