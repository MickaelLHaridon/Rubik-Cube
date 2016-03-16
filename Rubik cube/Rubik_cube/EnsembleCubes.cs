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
    /// <summary>
    /// This is a game component that implements IUpdateable.
    /// </summary>
    public class EnsembleCubes : GameComponent
    {
        Cube[,] tabCubes ;

        public EnsembleCubes(Game game)
            : base(game)
        {
            tabCubes = new Cube[3,9];
        }

        /// <summary>
        /// Allows the game component to perform any initialization it needs to before starting
        /// to run.  This is where it can query for any required services and load content.
        /// </summary>
        public override void Initialize()
        {
            CreerCubes();

            base.Initialize();
        }

        /// <summary>
        /// Allows the game component to update itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        public override void Update(GameTime gameTime)
        {

            base.Update(gameTime);
        }

        public void CreerCubes()
        {
            for(int i=0;i<3;i++)
            {
                tabCubes[i, 0] = new Cube(this.Game, new Vector3(-5, -5, -5*i), new Vector3(0, 0, 0));

                tabCubes[i, 1] = new Cube(this.Game, new Vector3(0, -5, -5*i), new Vector3(0, 0, 0));

                tabCubes[i, 2] = new Cube(this.Game, new Vector3(5, -5, -5*i), new Vector3(0, 0, 0));

                tabCubes[i, 3] = new Cube(this.Game, new Vector3(-5, 0, -5*i), new Vector3(0, 0, 0));

                tabCubes[i, 4] = new Cube(this.Game, new Vector3(0, 0, -5*i), new Vector3(0, 0, 0));

                tabCubes[i, 5] = new Cube(this.Game, new Vector3(5, 0, -5*i), new Vector3(0, 0, 0));

                tabCubes[i, 6] = new Cube(this.Game, new Vector3(-5, 5, -5*i), new Vector3(0, 0, 0));

                tabCubes[i, 7] = new Cube(this.Game, new Vector3(0, 5, -5*i), new Vector3(0, 0, 0));

                tabCubes[i, 8] = new Cube(this.Game, new Vector3(5, 5, -5*i), new Vector3(0, 0, 0));
            }
            

            for(int i=0;i<3;i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    ((Game1)Game).Components.Add(tabCubes[i, j]);
                }
            } 
        }
    }
}
