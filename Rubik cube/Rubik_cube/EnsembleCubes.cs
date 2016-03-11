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
            tabCubes[0,0] = new Cube(this.Game, new Vector3(-5, -5, -5),new Vector3(90, 90, 90));

            tabCubes[0,1] = new Cube(this.Game, new Vector3(0, -5, -5), new Vector3(90, 90, 90));

            tabCubes[0,2] = new Cube(this.Game, new Vector3(5, -5, -5), new Vector3(90, 90, 90));

            tabCubes[0,3] = new Cube(this.Game, new Vector3(-5, 0, -5), new Vector3(90, 90, 90));

            tabCubes[0,4] = new Cube(this.Game, new Vector3(0, 0, -5), new Vector3(90, 90, 90));

            tabCubes[0,5] = new Cube(this.Game, new Vector3(5, 0, -5), new Vector3(90, 90, 90));

            tabCubes[0,6] = new Cube(this.Game, new Vector3(-5, 5, -5), new Vector3(90, 90, 90));

            tabCubes[0,7] = new Cube(this.Game, new Vector3(0, 5, -5), new Vector3(90, 90, 90));

            tabCubes[0,8] = new Cube(this.Game, new Vector3(5, 5, -5), new Vector3(90, 90, 90));            


            for (int i=0; i<9; i++)
            {
                ((Game1)Game).Components.Add(tabCubes[0, i]);
            }
            /*
            Cube cube10 = new Cube(this.Game, new Vector3(0, 0, 0), new Vector3(0, 0, 0));
            ((Game1)Game).Components.Add(cube10);
            

            Cube cube11 = new Cube(this.Game, new Vector3(0, 0, 0), new Vector3(0, 0, 0));
            ((Game1)Game).Components.Add(cube11);
            

            Cube cube12 = new Cube(this.Game, new Vector3(0, 0, 0), new Vector3(0, 0, 0));
            ((Game1)Game).Components.Add(cube12);
            */
        }
    }
}
