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
    class EnsembleCubes : GameComponent
    {
        Cube[,] tabCubes;
        Color[] couleurs;

        public EnsembleCubes(Game game)
            : base(game)
        {
            tabCubes = new Cube[3, 9];
            couleurs = new Color[6];
        }

        /// <summary>
        /// Allows the game component to perform any initialization it needs to before starting
        /// to run.  This is where it can query for any required services and load content.
        /// </summary>
        public override void Initialize()
        {
            InitColors();
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

        public void InitColors()
        {
            couleurs[0] = Color.Red;
            couleurs[1] = Color.Blue;
            couleurs[2] = Color.Orange;
            couleurs[3] = Color.Green;
            couleurs[4] = Color.Yellow;
            couleurs[5] = Color.White;
        }
        public Cube[,] getCubes()
        {
            return tabCubes;
        }

        public Color[] getCouleur(int p, int n)
        {
            Color[] colors = new Color[6];
            for (int i = 0; i < 6; i++)
                colors[i] = Color.Black;
            switch(p)
            {
                case 0:
                    switch(n) {

                    case 0:
                        colors[0] = couleurs[0];
                        colors[3] = couleurs[3];
                        colors[5] = couleurs[5];
                        break;
                    case 1 :
                        colors[0] = couleurs[0];
                        colors[5] = couleurs[5];
                        break;
                    case 2:
                        colors[0] = couleurs[0];
                        colors[1] = couleurs[1];
                        colors[5] = couleurs[5];
                        break;
                    case 3:
                            colors[0] = couleurs[0];
                            colors[3] = couleurs[3];
                        break;
                    case 4:
                            colors[0] = couleurs[0];
                        break;
                    case 5:
                            colors[0] = couleurs[0];
                            colors[1] = couleurs[1];
                        break;
                    case 6:
                            colors[0] = couleurs[0];
                            colors[3] = couleurs[3];
                            colors[4] = couleurs[4];
                        break;
                    case 7:
                            colors[0] = couleurs[0];
                            colors[4] = couleurs[4];
                        break;
                    case 8:
                            colors[0] = couleurs[0];
                            colors[1] = couleurs[1];
                            colors[4] = couleurs[4];
                            break;
                    }
                    break;

                case 1:
                    switch (n)
                    {

                        case 0:
                            colors[3] = couleurs[3];
                            colors[5] = couleurs[5];
                            break;
                        case 1:
                            colors[5] = couleurs[5];
                            break;
                        case 2:
                            colors[1] = couleurs[1];
                            colors[5] = couleurs[5];
                            break;
                        case 3:
                            colors[3] = couleurs[3];
                            break;
                        case 4:
                            break;
                        case 5:
                            colors[1] = couleurs[1];
                            break;
                        case 6:
                            colors[3] = couleurs[3];
                            colors[4] = couleurs[4];
                            break;
                        case 7:
                            colors[4] = couleurs[4];
                            break;
                        case 8:
                            colors[1] = couleurs[1];
                            colors[4] = couleurs[4];
                            break;
                    }
                    break;

                case 2:
                    switch (n)
                    {
                        case 0:
                            colors[2] = couleurs[2];
                            colors[3] = couleurs[3];
                            colors[5] = couleurs[5];
                            break;
                        case 1:
                            colors[2] = couleurs[2];
                            colors[5] = couleurs[5];
                            break;
                        case 2:
                            colors[2] = couleurs[2];
                            colors[5] = couleurs[5];
                            colors[1] = couleurs[1];
                            break;
                        case 3:
                            colors[2] = couleurs[2];
                            colors[3] = couleurs[3];
                            break;
                        case 4:
                            colors[2] = couleurs[2];
                            break;
                        case 5:
                            colors[2] = couleurs[2];
                            colors[1] = couleurs[1];
                            break;
                        case 6:
                            colors[2] = couleurs[2];
                            colors[4] = couleurs[4];
                            colors[3] = couleurs[3];
                            break;
                        case 7:
                            colors[2] = couleurs[2];
                            colors[4] = couleurs[4];
                            break;
                        case 8:
                            colors[2] = couleurs[2];
                            colors[1] = couleurs[1];
                            colors[4] = couleurs[4];
                            break;
                    }
                    break;
            }
            return colors;
        }
        public void CreerCubes()
        {
            
            for(int i=0;i<3;i++)
            {

                tabCubes[i, 0] = new Cube(this.Game, new Vector3(-2, 2, -2*i), getCouleur(i,0));
            
                tabCubes[i, 1] = new Cube(this.Game, new Vector3(0, 2, -2*i), getCouleur(i, 1));

                tabCubes[i, 2] = new Cube(this.Game, new Vector3(2, 2, -2*i), getCouleur(i, 2));

                tabCubes[i, 3] = new Cube(this.Game, new Vector3(-2, 0, -2*i), getCouleur(i, 3));

                tabCubes[i, 4] = new Cube(this.Game, new Vector3(0, 0, -2*i), getCouleur(i, 4));

                tabCubes[i, 5] = new Cube(this.Game, new Vector3(2, 0, -2*i), getCouleur(i, 5));

                tabCubes[i, 6] = new Cube(this.Game, new Vector3(-2, -2, -2*i), getCouleur(i, 6));

                tabCubes[i, 7] = new Cube(this.Game, new Vector3(0, -2, -2*i), getCouleur(i, 7));

                tabCubes[i, 8] = new Cube(this.Game, new Vector3(2, -2, -2*i), getCouleur(i, 8));

            }
            
            for (int i=0;i<3;i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    ((Game1)Game).Components.Add(tabCubes[i, j]);
                }
            }
        }
    }
}
