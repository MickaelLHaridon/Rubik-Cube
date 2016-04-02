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
        }
        
        public Modele (Game game, Modele etat) :base(game)
        {
            Etat = etat.Etat;
            this.g = etat.g;
            faces = ((Game1)Game).Components.OfType<GestionFace>().First().faces;
            alterEtats = new List<Modele>();
            rotations = ((Game1)Game).Components.OfType<GestionFace>().First().rotations;
            vectRot = ((Game1)Game).Components.OfType<GestionFace>().First().vectRot;
        }
        
        public override void Initialize()
        {
            base.Initialize();
        }

        public List<Modele> findAlternatives(Modele EtatSolution)
        {

            Modele Face0AlternativeGauche = (Modele)this.MemberwiseClone();
            Face0AlternativeGauche.faces[0].TranslateFace(Math.Abs(rotations[0, 0] - 1));
            Face0AlternativeGauche.faces[0].RotationFace(vectRot[0], -rotations[0, 1]);
            Face0AlternativeGauche.g += 1;
            Face0AlternativeGauche.h = calculCubesMalPlaces();
            Face0AlternativeGauche.f = calculF(h,g);
            alterEtats.Add(Face0AlternativeGauche);

            Modele Face0AlternativeDroite = (Modele)this.MemberwiseClone();
            Face0AlternativeDroite.faces[0].TranslateFace(rotations[0, 0]);
            Face0AlternativeDroite.faces[0].RotationFace(vectRot[0], rotations[0, 1]);
            Face0AlternativeDroite.g += 1;
            Face0AlternativeDroite.h = calculCubesMalPlaces();
            Face0AlternativeDroite.f = calculF(h, g);
            alterEtats.Add(Face0AlternativeDroite);

            Modele Face1AlternativeGauche = (Modele)this.MemberwiseClone();
            Face1AlternativeGauche.faces[1].TranslateFace(Math.Abs(rotations[1, 0] - 1));
            Face1AlternativeGauche.faces[1].RotationFace(vectRot[1], -rotations[1, 1]);
            Face1AlternativeGauche.g += 1;
            Face1AlternativeGauche.h = calculCubesMalPlaces();
            Face1AlternativeGauche.f = calculF(h, g);
            alterEtats.Add(Face1AlternativeGauche);

            Modele Face1AlternativeDroite = (Modele)this.MemberwiseClone();
            Face1AlternativeDroite.faces[1].TranslateFace(rotations[1, 0]);
            Face1AlternativeDroite.faces[1].RotationFace(vectRot[1], rotations[1, 1]);
            Face1AlternativeDroite.g += 1;
            Face1AlternativeDroite.h = calculCubesMalPlaces();
            Face1AlternativeDroite.f = calculF(h, g);
            alterEtats.Add(Face1AlternativeDroite);

            Modele Face2AlternativeGauche = (Modele)this.MemberwiseClone();
            Face2AlternativeGauche.faces[2].TranslateFace(Math.Abs(rotations[2, 0] - 1));
            Face2AlternativeGauche.faces[2].RotationFace(vectRot[2], -rotations[2, 1]);
            Face2AlternativeGauche.g += 1;
            Face2AlternativeGauche.h = calculCubesMalPlaces();
            Face2AlternativeGauche.f = calculF(h, g);
            alterEtats.Add(Face2AlternativeGauche);

            Modele Face2AlternativeDroite = (Modele)this.MemberwiseClone();
            Face2AlternativeDroite.faces[2].TranslateFace(rotations[2, 0]);
            Face2AlternativeDroite.faces[2].RotationFace(vectRot[2], rotations[2, 1]);
            Face2AlternativeDroite.g += 1;
            Face2AlternativeDroite.h = calculCubesMalPlaces();
            Face2AlternativeDroite.f = calculF(h, g);
            alterEtats.Add(Face2AlternativeDroite);

            Modele Face3AlternativeGauche = (Modele)this.MemberwiseClone();
            Face3AlternativeGauche.faces[3].TranslateFace(Math.Abs(rotations[3, 0] - 1));
            Face3AlternativeGauche.faces[3].RotationFace(vectRot[3], -rotations[3, 1]);
            Face3AlternativeGauche.g += 1;
            Face3AlternativeGauche.h = calculCubesMalPlaces();
            Face3AlternativeGauche.f = calculF(h, g);
            alterEtats.Add(Face3AlternativeGauche);

            Modele Face3AlternativeDroite = (Modele)this.MemberwiseClone();
            Face3AlternativeDroite.faces[3].TranslateFace(rotations[3, 0]);
            Face3AlternativeDroite.faces[3].RotationFace(vectRot[3], rotations[3, 1]);
            Face3AlternativeDroite.g += 1;
            Face3AlternativeDroite.h = calculCubesMalPlaces();
            Face3AlternativeDroite.f = calculF(h, g);
            alterEtats.Add(Face3AlternativeDroite);

            Modele Face4AlternativeGauche = (Modele)this.MemberwiseClone();
            Face4AlternativeGauche.faces[4].TranslateFace(Math.Abs(rotations[4, 0] - 1));
            Face4AlternativeGauche.faces[4].RotationFace(vectRot[4], -rotations[4, 1]);
            Face4AlternativeGauche.g += 1;
            Face4AlternativeGauche.h = calculCubesMalPlaces();
            Face4AlternativeGauche.f = calculF(h, g);
            alterEtats.Add(Face4AlternativeGauche);

            Modele Face4AlternativeDroite = (Modele)this.MemberwiseClone();
            Face4AlternativeDroite.faces[4].TranslateFace(rotations[4, 0]);
            Face4AlternativeDroite.faces[4].RotationFace(vectRot[4], rotations[4, 1]);
            Face4AlternativeDroite.g += 1;
            Face4AlternativeDroite.h = calculCubesMalPlaces();
            Face4AlternativeDroite.f = calculF(h, g);
            alterEtats.Add(Face4AlternativeDroite);

            Modele Face5AlternativeGauche = (Modele)this.MemberwiseClone();
            Face5AlternativeGauche.faces[5].TranslateFace(Math.Abs(rotations[5, 0] - 1));
            Face5AlternativeGauche.faces[5].RotationFace(vectRot[5], -rotations[5, 1]);
            Face5AlternativeGauche.g += 1;
            Face5AlternativeGauche.h = calculCubesMalPlaces();
            Face5AlternativeGauche.f = calculF(h, g);
            alterEtats.Add(Face5AlternativeGauche);

            Modele Face5AlternativeDroite = (Modele)this.MemberwiseClone();
            Face5AlternativeDroite.faces[5].TranslateFace(rotations[5, 0]);
            Face5AlternativeDroite.faces[5].RotationFace(vectRot[5], rotations[5, 1]);
            Face5AlternativeDroite.g += 1;
            Face5AlternativeDroite.h = calculCubesMalPlaces();
            Face5AlternativeDroite.f = calculF(h, g);
            alterEtats.Add(Face5AlternativeDroite);

            return alterEtats;
        }
        
        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
        }

        public int calculCubesMalPlaces()
        {
            int h = 0;
            for (int i = 0; i < 27; i++)
            {
                if (Etat[i].numeroCube != Etat[i].numeroPosition)
                {
                    h++;
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
