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


namespace Rubik_cube
{
    public class Modele : Microsoft.Xna.Framework.GameComponent
    {
        public int f
        {
            get; set;
        }
        public int h
        {
            get; set;
        }
        public int g
        {
            get; set;
        }

        float[,] rotations;
        Vector3[] vectRot;


        public Cube[] Etat
        {
            get; set;
        }

        Cube[] EtatFinal;

        Face[] faces;
        List<Modele> alterEtats;

        public Modele(Game game, Cube[] etat)
            : base(game)
        {
            Etat = etat;
            faces = ((Game1)Game).Components.OfType<GestionFace>().First().faces;
            alterEtats = new List<Modele>();
            rotations = ((Game1)Game).Components.OfType<GestionFace>().First().rotations;
            vectRot = ((Game1)Game).Components.OfType<GestionFace>().First().vectRot;
            EtatFinal = ((Game1)Game).Components.OfType<GestionFace>().First().etatInitial;
        }
        
        public Modele (Game game, Modele etat) :base(game)
        {
            Etat = etat.Etat;
            this.g = etat.g;
            faces = ((Game1)Game).Components.OfType<GestionFace>().First().faces;
            alterEtats = new List<Modele>();
            rotations = ((Game1)Game).Components.OfType<GestionFace>().First().rotations;
            vectRot = ((Game1)Game).Components.OfType<GestionFace>().First().vectRot;
            EtatFinal = ((Game1)Game).Components.OfType<GestionFace>().First().etatInitial;
        }
        
        public override void Initialize()
        {
            base.Initialize();
        }

        public List<Modele> findAlternatives(Cube[] EtatSolution)
        {

            Modele Face0AlternativeGauche = (Modele)this.MemberwiseClone();
            Face0AlternativeGauche.faces[0].TranslateFace(Math.Abs(rotations[0, 0] - 1));
            Face0AlternativeGauche.faces[0].RotationFace(vectRot[0], -rotations[0, 1]);
            Face0AlternativeGauche.g += 1;
            //Face0AlternativeGauche.h = calcH2(Face0AlternativeGauche,EtatSolution);
            Face0AlternativeGauche.h = calculCubesMalPlaces(Face0AlternativeGauche);
            Face0AlternativeGauche.f = calculF(h,g);
            UpdateFacesModele(Face0AlternativeGauche);
            alterEtats.Add(Face0AlternativeGauche);

            Modele Face0AlternativeDroite = (Modele)this.MemberwiseClone();
            Face0AlternativeDroite.faces[0].TranslateFace(rotations[0, 0]);
            Face0AlternativeDroite.faces[0].RotationFace(vectRot[0], rotations[0, 1]);
            Face0AlternativeDroite.g += 1;
            //Face0AlternativeDroite.h = calcH2(Face0AlternativeDroite, EtatSolution);
            Face0AlternativeDroite.h = calculCubesMalPlaces(Face0AlternativeDroite);
            Face0AlternativeDroite.f = calculF(h, g);
            UpdateFacesModele(Face0AlternativeDroite);
            alterEtats.Add(Face0AlternativeDroite);

            Modele Face1AlternativeGauche = (Modele)this.MemberwiseClone();
            Face1AlternativeGauche.faces[1].TranslateFace(Math.Abs(rotations[1, 0] - 1));
            Face1AlternativeGauche.faces[1].RotationFace(vectRot[1], -rotations[1, 1]);
            Face1AlternativeGauche.g += 1;
            //Face1AlternativeGauche.h = calcH2(Face1AlternativeGauche, EtatSolution);
            Face1AlternativeGauche.h = calculCubesMalPlaces(Face1AlternativeGauche);
            Face1AlternativeGauche.f = calculF(h, g);
            UpdateFacesModele(Face1AlternativeGauche);
            alterEtats.Add(Face1AlternativeGauche);

            Modele Face1AlternativeDroite = (Modele)this.MemberwiseClone();
            Face1AlternativeDroite.faces[1].TranslateFace(rotations[1, 0]);
            Face1AlternativeDroite.faces[1].RotationFace(vectRot[1], rotations[1, 1]);
            Face1AlternativeDroite.g += 1;
            //Face1AlternativeDroite.h = calcH2(Face1AlternativeDroite, EtatSolution);
            Face1AlternativeDroite.h = calculCubesMalPlaces(Face1AlternativeDroite);
            Face1AlternativeDroite.f = calculF(h, g);
            UpdateFacesModele(Face1AlternativeDroite);
            alterEtats.Add(Face1AlternativeDroite);

            Modele Face2AlternativeGauche = (Modele)this.MemberwiseClone();
            Face2AlternativeGauche.faces[2].TranslateFace(Math.Abs(rotations[2, 0] - 1));
            Face2AlternativeGauche.faces[2].RotationFace(vectRot[2], -rotations[2, 1]);
            Face2AlternativeGauche.g += 1;
            //Face2AlternativeGauche.h = calcH2(Face2AlternativeGauche, EtatSolution);
            Face2AlternativeGauche.h = calculCubesMalPlaces(Face2AlternativeGauche);
            Face2AlternativeGauche.f = calculF(h, g);
            UpdateFacesModele(Face2AlternativeGauche);
            alterEtats.Add(Face2AlternativeGauche);

            Modele Face2AlternativeDroite = (Modele)this.MemberwiseClone();
            Face2AlternativeDroite.faces[2].TranslateFace(rotations[2, 0]);
            Face2AlternativeDroite.faces[2].RotationFace(vectRot[2], rotations[2, 1]);
            Face2AlternativeDroite.g += 1;
            //Face2AlternativeDroite.h = calcH2(Face2AlternativeDroite, EtatSolution);
            Face2AlternativeDroite.h = calculCubesMalPlaces(Face2AlternativeDroite);
            Face2AlternativeDroite.f = calculF(h, g);
            UpdateFacesModele(Face2AlternativeDroite);
            alterEtats.Add(Face2AlternativeDroite);

            Modele Face3AlternativeGauche = (Modele)this.MemberwiseClone();
            Face3AlternativeGauche.faces[3].TranslateFace(Math.Abs(rotations[3, 0] - 1));
            Face3AlternativeGauche.faces[3].RotationFace(vectRot[3], -rotations[3, 1]);
            Face3AlternativeGauche.g += 1;
            //Face3AlternativeGauche.h = calcH2(Face3AlternativeGauche, EtatSolution);
            Face3AlternativeGauche.h = calculCubesMalPlaces(Face3AlternativeGauche);
            Face3AlternativeGauche.f = calculF(h, g);
            UpdateFacesModele(Face3AlternativeGauche);
            alterEtats.Add(Face3AlternativeGauche);

            Modele Face3AlternativeDroite = (Modele)this.MemberwiseClone();
            Face3AlternativeDroite.faces[3].TranslateFace(rotations[3, 0]);
            Face3AlternativeDroite.faces[3].RotationFace(vectRot[3], rotations[3, 1]);
            Face3AlternativeDroite.g += 1;
            //Face3AlternativeDroite.h = calcH2(Face3AlternativeDroite, EtatSolution);
            Face3AlternativeDroite.h = calculCubesMalPlaces(Face3AlternativeDroite);
            Face3AlternativeDroite.f = calculF(h, g);
            UpdateFacesModele(Face3AlternativeDroite);
            alterEtats.Add(Face3AlternativeDroite);

            Modele Face4AlternativeGauche = (Modele)this.MemberwiseClone();
            Face4AlternativeGauche.faces[4].TranslateFace(Math.Abs(rotations[4, 0] - 1));
            Face4AlternativeGauche.faces[4].RotationFace(vectRot[4], -rotations[4, 1]);
            Face4AlternativeGauche.g += 1;
            //Face4AlternativeGauche.h = calcH2(Face4AlternativeGauche, EtatSolution);
            Face4AlternativeGauche.h = calculCubesMalPlaces(Face4AlternativeGauche);
            Face4AlternativeGauche.f = calculF(h, g);
            UpdateFacesModele(Face4AlternativeGauche);
            alterEtats.Add(Face4AlternativeGauche);

            Modele Face4AlternativeDroite = (Modele)this.MemberwiseClone();
            Face4AlternativeDroite.faces[4].TranslateFace(rotations[4, 0]);
            Face4AlternativeDroite.faces[4].RotationFace(vectRot[4], rotations[4, 1]);
            Face4AlternativeDroite.g += 1;
            //Face4AlternativeDroite.h = calcH2(Face4AlternativeDroite, EtatSolution);
            Face4AlternativeDroite.h = calculCubesMalPlaces(Face4AlternativeDroite);
            Face4AlternativeDroite.f = calculF(h, g);
            UpdateFacesModele(Face4AlternativeDroite);
            alterEtats.Add(Face4AlternativeDroite);

            Modele Face5AlternativeGauche = (Modele)this.MemberwiseClone();
            Face5AlternativeGauche.faces[5].TranslateFace(Math.Abs(rotations[5, 0] - 1));
            Face5AlternativeGauche.faces[5].RotationFace(vectRot[5], -rotations[5, 1]);
            Face5AlternativeGauche.g += 1;
            //Face5AlternativeGauche.h = calcH2(Face5AlternativeGauche, EtatSolution);
            Face5AlternativeGauche.h = calculCubesMalPlaces(Face5AlternativeGauche);
            Face5AlternativeGauche.f = calculF(h, g);
            UpdateFacesModele(Face5AlternativeGauche);
            alterEtats.Add(Face5AlternativeGauche);

            Modele Face5AlternativeDroite = (Modele)this.MemberwiseClone();
            Face5AlternativeDroite.faces[5].TranslateFace(rotations[5, 0]);
            Face5AlternativeDroite.faces[5].RotationFace(vectRot[5], rotations[5, 1]);
            Face5AlternativeDroite.g += 1;
            //Face5AlternativeDroite.h = calcH2(Face5AlternativeDroite, EtatSolution);
            Face5AlternativeDroite.h = calculCubesMalPlaces(Face5AlternativeDroite);
            Face5AlternativeDroite.f = calculF(h, g);
            UpdateFacesModele(Face5AlternativeDroite);
            alterEtats.Add(Face5AlternativeDroite);

            return alterEtats;
        }
        
        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
        }

        public void UpdateFacesModele(Modele modele)
        {
            modele.Etat = modele.Etat.OrderBy(Cube => Cube.numeroPosition).ToArray();
            int i_face = 0;
            int i_back = 0;
            int i_droite = 0;
            int i_gauche = 0;
            int i_haut = 0;
            int i_bas = 0;

            for (int i = 0; i < 27; i++)
            {
                if (modele.Etat[i].position.Z == 0)
                {
                    modele.faces[0].AjouterCube(i_face, modele.Etat[i]);
                    modele.Etat[i].CurrentFace = modele.faces[0];
                    i_face++;
                }
                if (modele.Etat[i].position.X == 2)
                {
                    modele.faces[1].AjouterCube(i_droite, modele.Etat[i]);
                    modele.Etat[i].CurrentFace = modele.faces[1];
                    i_droite++;
                }

                if (modele.Etat[i].position.Z == -4)
                {
                    modele.faces[2].AjouterCube(i_back, modele.Etat[i]);
                    modele.Etat[i].CurrentFace = modele.faces[2];
                    i_back++;
                }
                if (modele.Etat[i].position.X == -2)
                {
                    modele.faces[3].AjouterCube(i_gauche, modele.Etat[i]);
                    modele.Etat[i].CurrentFace = modele.faces[3];
                    i_gauche++;
                }
                if (modele.Etat[i].position.Y == -2)
                {
                    modele.faces[4].AjouterCube(i_bas, modele.Etat[i]);
                    modele.Etat[i].CurrentFace = modele.faces[4];
                    i_bas++;
                }
                if (modele.Etat[i].position.Y == 2)
                {
                    modele.faces[5].AjouterCube(i_haut, modele.Etat[i]);
                    modele.Etat[i].CurrentFace = modele.faces[5];
                    i_haut++;
                }
            }
        }

        public int calculCubesMalPlaces(Modele etat)
        {
            int h = 0;
            for (int i = 0; i < 27; i++)
            {
                if (i != etat.Etat[i].numeroCube)
                {
                    h++;
                }
                if (etat.Etat[i].FaceBase != etat.Etat[i].CurrentFace)
                {
                    h++;
                }
            }
            return h;
        }


        public int calcH2(Modele currentEtat, Cube[] solution)
        {
            int h = 0;
            for (int i = 0; i < currentEtat.Etat.Count(); i++)
            {
                if (currentEtat.Etat[i].numeroCube != solution[i].numeroCube)
                {
                    for (int j = 0; j < solution.Count(); j++)
                    {
                        if (currentEtat.Etat[j].numeroCube == solution[j].numeroCube)
                        {
                            if (i > j)
                            {
                                h += (i - j);
                            }
                            else
                            {
                                h += (j - i);
                            }
                        }
                    }

                }
            }
            return h;
        }

        public int calculF(int h, int g)
        {
            return h + g;
        }
    }
}
