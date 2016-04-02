using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using System.Collections;

namespace Rubik_cube
{
    public class ResolutionRubik : Microsoft.Xna.Framework.GameComponent
    {
        Face[] faces;
        Cube[] lesCubes;
        Cube[] EtatSolution;
        List<Modele> EtatsVoisins;
        List<Modele> listeEtatsOuverts;
        List<Modele> listeEtatsFermes;

        public ResolutionRubik(Game game)
            : base(game)
        {
            faces = ((Game1)Game).Components.OfType<GestionFace>().First().faces;
            listeEtatsOuverts = new List<Modele>();
            listeEtatsFermes = new List<Modele>();
            EtatsVoisins = new List<Modele>();
            
        }
        
        public override void Initialize()
        {
            EtatSolution = ((Game1)Game).Components.OfType<GestionFace>().First().etatInitial;
            Console.WriteLine(EtatSolution.Count());
            base.Initialize();
        }
        
        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
        }

        public void Resolution ()
        {

            lesCubes = ((Game1)Game).Components.OfType<GestionFace>().First().lesCubes;
            Modele EtatDebut = new Modele(this.Game, lesCubes);
            listeEtatsOuverts.Add(EtatDebut);

            Modele minNoeud = EtatDebut;
            int f = minNoeud.f;
            for (int i = 0; i < listeEtatsOuverts.Count; i++)
            {
                if (listeEtatsOuverts[i].f < f)
                {
                    minNoeud = listeEtatsOuverts[i];
                    f = listeEtatsOuverts[i].f;
                }
            }

            listeEtatsFermes.Add(minNoeud);

            while (listeEtatsOuverts.Any())
            {
                for (int i = 0; i < listeEtatsOuverts.Count; i++)
                {
                    Modele etat = new Modele(this.Game,listeEtatsOuverts[i]);
                    EtatsVoisins = etat.findAlternatives(EtatSolution);

                    //((Game1)Game).Components.OfType<GestionFace>().First().UpdateFaces();

                    foreach (Modele Voisin in EtatsVoisins)
                    {
                        Console.WriteLine(Voisin.h + "," + Voisin.g);
                        //Console.WriteLine(Voisin.Etat[0].numeroCube);
                        List<int> list = new List<int>();
                        for (int j = 0; j < Voisin.Etat.Length; j++)
                        {
                            //list.Add((Voisin.Etat[j].numeroPosition));
                        }
                        list.ForEach(Console.Write);

                        if (Voisin.h == 0)
                        {
                            // Rubik Cube terminé
                            return;
                        }
                        else
                        {
                            if (!(listeEtatsOuverts.Contains(Voisin)) && !(listeEtatsFermes.Contains(Voisin)))
                            {
                                listeEtatsOuverts.Add(Voisin);
                            }
                            else if (!(listeEtatsOuverts.Contains(Voisin)) && listeEtatsOuverts[listeEtatsOuverts.IndexOf(Voisin)].f < Voisin.f)
                            {
                                listeEtatsOuverts.Remove(listeEtatsOuverts[listeEtatsOuverts.IndexOf(Voisin)]);
                                listeEtatsOuverts.Add(Voisin);
                            }
                            else if (!(listeEtatsFermes.Contains(Voisin)) && !(listeEtatsFermes[listeEtatsFermes.IndexOf(Voisin)].f < Voisin.f))
                            {
                                listeEtatsFermes.Remove(listeEtatsFermes[listeEtatsFermes.IndexOf(Voisin)]);
                                listeEtatsOuverts.Add(Voisin);
                            }
                        }
                    }
                }
            }

        }

        
    }
}
