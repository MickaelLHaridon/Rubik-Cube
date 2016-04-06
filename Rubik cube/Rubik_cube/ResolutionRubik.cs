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
            int i = 0;
            
            while (listeEtatsOuverts.Any())
            {

                int f = minNoeud.f;
                for (int j = 0; j < listeEtatsOuverts.Count; j++)
                {
                    if (listeEtatsOuverts[j].f < f)
                    {
                        minNoeud = listeEtatsOuverts[j];
                        f = listeEtatsOuverts[j].f;
                    }
                }

                listeEtatsFermes.Add(minNoeud);
                
                    EtatsVoisins = listeEtatsOuverts[i].findAlternatives(EtatSolution);

                    //((Game1)Game).Components.OfType<GestionFace>().First().UpdateFaces();

                    foreach (Modele Voisin in EtatsVoisins)
                    {

                        // Lignes de débuggage -------------------------
                        Console.WriteLine(Voisin.h + "," + Voisin.g);
                        //Console.WriteLine(Voisin.Etat[0].numeroCube);
                        List<int> list = new List<int>();
                        List<int> list2 = new List<int>();
                        for (int k = 0; k < Voisin.Etat.Length; k++)
                        {
                            //list.Add((Voisin.Etat[k].numeroCube));
                            list.Add(minNoeud.Etat[k].numeroPosition);
                        }
                        //list.ForEach(Console.Write);
                        //Console.Write("    ");

                        for (int k = 0; k < Voisin.Etat.Length; k++)
                        {
                            list2.Add(minNoeud.Etat[k].numeroCube);
                        }
                        //list2.ForEach(Console.Write);

                        //-----------------------------------------------


                        if (Voisin.h == 0)
                        {
                            // Rubik Cube terminé
                            return;
                        }
                        else
                        {
                            /*
                            if (!(listeEtatsOuverts.Contains(Voisin)) && !(listeEtatsFermes.Contains(Voisin)))
                            {
                                listeEtatsOuverts.Add(Voisin);
                            }
                            else if (!(listeEtatsOuverts.Contains(Voisin)) || !(listeEtatsOuverts[listeEtatsOuverts.IndexOf(Voisin)].f < Voisin.f))
                            {
                                listeEtatsOuverts.Remove(listeEtatsOuverts[listeEtatsOuverts.IndexOf(Voisin)]);
                                listeEtatsOuverts.Add(Voisin);
                            }
                            else if (!(listeEtatsFermes.Contains(Voisin)) || !(listeEtatsFermes[listeEtatsFermes.IndexOf(Voisin)].f < Voisin.f))
                            {
                                listeEtatsFermes.Remove(listeEtatsFermes[listeEtatsFermes.IndexOf(Voisin)]);
                                listeEtatsOuverts.Add(Voisin);
                            }*/

                            bool n1 = false, n2 = false, n3 = false; 
                            int kval = 0;
                            for (int j = 0; j < listeEtatsOuverts.Count; j++)
                            {
                                //Console.Write(listeEtatsOuverts[j].f + " : ");
                                //Console.Write(Voisin.f + ", ");

                                if (listeEtatsOuverts[j].Etat == Voisin.Etat)
                                {
                                    n1 = true;
                                    //Console.WriteLine(listeEtatsOuverts[j].f + " " + Voisin.f);
                                }
                                //if ((listeEtatsOuverts[j].Etat == Voisin.Etat) && (listeEtatsOuverts[listeEtatsOuverts.IndexOf(Voisin)].f < Voisin.f))
                                if ((listeEtatsOuverts[j].Etat == Voisin.Etat) && (listeEtatsOuverts[j].f < Voisin.f))
                                {
                                    n2 = true;
                                    kval = j;
                                }
                            }
                            //Console.WriteLine("");
                            for (int k = 0; k< listeEtatsFermes.Count; k++)
                            {
                                if (listeEtatsFermes[k].Etat == Voisin.Etat && n1 == false){
                                    n1 = true;
                                }
                                //if ((listeEtatsFermes[k].Etat == Voisin.Etat) && (listeEtatsFermes[listeEtatsFermes.IndexOf(Voisin)].f < Voisin.f))
                                if ((listeEtatsFermes[k].Etat == Voisin.Etat) && (listeEtatsFermes[k].f < Voisin.f))
                                {
                                    n3 = true;
                                    kval = k;
                                }
                            }
                            if (!n1 && !n2 && !n3) {
                                listeEtatsOuverts.Add(Voisin);
                                break;
                            }
                            if (n2) {
                                listeEtatsOuverts.Remove(listeEtatsOuverts[kval]);
                                listeEtatsOuverts.Add(Voisin);
                                break;
                            }
                            if (n3) {
                                listeEtatsFermes.Remove(listeEtatsFermes[kval]);
                                listeEtatsOuverts.Add(Voisin);
                                break;
                            }
                            n1 = false;
                            n2 = false;
                            n3 = false;
                            kval = 0;
                            }
                        }
                i++;
             }
            

        }

        
    }
}
