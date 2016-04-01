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
        List<Cube[]> EtatsVoisins;
        List<Cube[]> listeEtatsOuverts;
        List<Cube[]> listeEtatsFermes;

        public ResolutionRubik(Game game)
            : base(game)
        {
            faces = ((Game1)Game).Components.OfType<GestionFace>().First().faces;
            listeEtatsOuverts = new List<Cube[]>();
            listeEtatsFermes = new List<Cube[]>();
            EtatsVoisins = new List<Cube[]>();
        }
        
        public override void Initialize()
        {
            base.Initialize();
        }
        
        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
        }

        public void Resolution ()
        {
            int g = 0;

            lesCubes = ((Game1)Game).Components.OfType<GestionFace>().First().lesCubes;

            listeEtatsOuverts.Add(lesCubes);

            while (!listeEtatsOuverts.Any())
            {

            }

        }

        public int calculCubesMalPlaces()
        {
            int h = 0;
            for (int i = 0; i < 27; i++)
            {
                if (lesCubes[i].numeroCube != lesCubes[i].numeroPosition)
                {
                    h++;
                }
            }
            return h;
        }

        public int calculF (int h,int g)
        {
            return h + g;
        }
    }
}
