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

        Cube[] Etat;
        Face[] faces;
        List<Cube[]> alterEtats;

        public Modele(Game game)
            : base(game)
        {
            Etat = ((Game1)Game).Components.OfType<GestionFace>().First().lesCubes;
            faces = ((Game1)Game).Components.OfType<GestionFace>().First().faces;
            alterEtats = new List<Cube[]>();
        }
        
        public Modele (Game game, Cube[] etat) :base(game)
        {

        }
        
        public override void Initialize()
        {
            base.Initialize();
        }

        public List<Modele> findAlternatives(Modele EtatSolution)
        {

            Modele Face1AlternativeGauche = (Modele)this.MemberwiseClone();
            Face1AlternativeGauche.faces[1].TranslateFace(1);
            //Face1AlternativeGauche.faces[1].RotationFace(-MathHelper.PiOver2);

            return null;
        }
        
        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
        }
    }
}
