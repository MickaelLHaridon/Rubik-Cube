using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Rubik_cube
{
    class GestionFace : GameComponent
    {
        Face[] faces;
        Cube[,] tabCubes;
        bool[] appui = new bool[6];
        const int DROITE = 0;
        const int GAUCHE = 1;
        public GestionFace(Game game) :base(game)
        {
            faces = new Face[6];
            for(int i=0; i<6;i++)
            {
                faces[i] = new Face(game,i, ((Game1)Game).Components.OfType<Camera>().First());
                appui[i] = false;
            }     
        }

        public override void Initialize()
        {
            tabCubes = ((Game1)Game).Components.OfType<EnsembleCubes>().First().getCubes();
            UpdateFaces();
            base.Initialize();
        }

        public void UpdateFaces()
        {
            
            int i_face = 0;
            int i_back = 0;
            int i_droite = 0;
            int i_gauche = 0;
            int i_haut = 0;
            int i_bas = 0;

            for (int j = 0; j < 9; j++)
            {
                for (int i = 0; i < 3; i++)
                {
                    if (tabCubes[i, j].position.Z == 0)
                    {
                        faces[0].AjouterCube(i_face, tabCubes[i, j]);
                        i_face++;
                    }

                    if (tabCubes[i, j].position.X == 2)
                    {
                        Console.WriteLine(i_droite);
                        Console.WriteLine(tabCubes[i,j].position);

                        faces[1].AjouterCube(i_droite, tabCubes[i, j]);
                        i_droite++;
                    }

                    if (tabCubes[i, j].position.Z == -4)
                    {
                        faces[2].AjouterCube(i_back, tabCubes[i, j]);
                        i_back++;
                    }
                    if (tabCubes[i, j].position.X == -2)
                    {
                        faces[3].AjouterCube(i_gauche, tabCubes[i, j]);
                        i_gauche++;
                    }
                    if (tabCubes[i, j].position.Y == -2)
                    {
                        faces[4].AjouterCube(i_bas, tabCubes[i, j]);
                        i_bas++;
                    }
                    if (tabCubes[i, j].position.Y == 2)
                    {
                        faces[5].AjouterCube(i_haut, tabCubes[i, j]);
                        i_haut++;
                    }
                }
            }
            /*
            //face 0
            for (int i = 0; i < 9; i++)
            {
                faces[0].AjouterCube(i, tabCubes[0, i]);
                Console.WriteLine("i: "+i+" "+tabCubes[0, i].position);
            }
            //face 1
            faces[1].AjouterCube(0, tabCubes[0, 2]);
            faces[1].AjouterCube(3, tabCubes[0, 5]);
            faces[1].AjouterCube(6, tabCubes[0, 8]);

            faces[1].AjouterCube(1, tabCubes[1, 2]);
            faces[1].AjouterCube(4, tabCubes[1, 5]);
            faces[1].AjouterCube(7, tabCubes[1, 8]);

            faces[1].AjouterCube(2, tabCubes[2, 2]);
            faces[1].AjouterCube(5, tabCubes[2, 5]);
            faces[1].AjouterCube(8, tabCubes[2, 8]);

            //face 2
            for (int i = 0; i < 9; i++)
            {
                faces[2].AjouterCube(i, tabCubes[2, i]);
            }

            //face 3
            faces[3].AjouterCube(0, tabCubes[2, 0]);
            faces[3].AjouterCube(3, tabCubes[2, 3]);
            faces[3].AjouterCube(6, tabCubes[2, 6]);

            faces[3].AjouterCube(1, tabCubes[1, 0]);
            faces[3].AjouterCube(4, tabCubes[1, 3]);
            faces[3].AjouterCube(7, tabCubes[1, 6]);

            faces[3].AjouterCube(2, tabCubes[0, 0]);
            faces[3].AjouterCube(5, tabCubes[0, 3]);
            faces[3].AjouterCube(8, tabCubes[0, 6]);

            //face 4
            faces[4].AjouterCube(0, tabCubes[0, 6]);
            faces[4].AjouterCube(1, tabCubes[0, 7]);
            faces[4].AjouterCube(2, tabCubes[0, 8]);

            faces[4].AjouterCube(3, tabCubes[1, 6]);
            faces[4].AjouterCube(4, tabCubes[1, 7]);
            faces[4].AjouterCube(5, tabCubes[1, 8]);

            faces[4].AjouterCube(6, tabCubes[2, 6]);
            faces[4].AjouterCube(7, tabCubes[2, 7]);
            faces[4].AjouterCube(8, tabCubes[2, 8]);

            //face 5
            faces[5].AjouterCube(0, tabCubes[2, 0]);
            faces[5].AjouterCube(1, tabCubes[2, 1]);
            faces[5].AjouterCube(2, tabCubes[2, 2]);

            faces[5].AjouterCube(3, tabCubes[1, 0]);
            faces[5].AjouterCube(4, tabCubes[1, 1]);
            faces[5].AjouterCube(5, tabCubes[1, 2]);

            faces[5].AjouterCube(6, tabCubes[0, 0]);
            faces[5].AjouterCube(7, tabCubes[0, 1]);
            faces[5].AjouterCube(8, tabCubes[0, 2]);
            */
        }

        public override void Update(GameTime gameTime)
        {
            MouseState state = Mouse.GetState();

            KeyboardState keyboardState = Keyboard.GetState();
            if(keyboardState.IsKeyDown(Keys.NumPad1))
            {
                if(!appui[0])
                {
                    appui[0] = true;
                    faces[0].TranslateFace(DROITE); //GAUCHE
                    faces[0].RotationFace(MathHelper.PiOver2); //-
                    UpdateFaces();
                }
            }
            if (keyboardState.IsKeyUp(Keys.NumPad1))
                appui[0] = false;

            if (keyboardState.IsKeyDown(Keys.NumPad2))
            {
                if (!appui[1])
                {
                    appui[1] = true;
                    faces[1].TranslateFace(DROITE);
                    faces[1].RotationFace(-MathHelper.PiOver2);
                    UpdateFaces();
                }
            }
            if (keyboardState.IsKeyUp(Keys.NumPad2))
                appui[1] = false;

            if (keyboardState.IsKeyDown(Keys.NumPad3))
            {
                if (!appui[2])
                {
                    appui[2] = true;
                    faces[2].TranslateFace(DROITE);
                    faces[2].RotationFace(-MathHelper.PiOver2);
                    UpdateFaces();
                }
            }
            if (keyboardState.IsKeyUp(Keys.NumPad3))
                appui[2] = false;

            if (keyboardState.IsKeyDown(Keys.NumPad4))
            {
                if (!appui[3])
                {
                    appui[3] = true;
                    faces[3].TranslateFace(DROITE);
                    faces[3].RotationFace(-MathHelper.PiOver2);
                    UpdateFaces();
                }
            }
            if (keyboardState.IsKeyUp(Keys.NumPad4))
                appui[3] = false;
            if (keyboardState.IsKeyDown(Keys.NumPad5))
            {
                if (!appui[4])
                {
                    appui[4] = true;
                    faces[4].TranslateFace(DROITE);
                    faces[4].RotationFace(-MathHelper.PiOver2);
                    UpdateFaces();
                }
            }
            if (keyboardState.IsKeyUp(Keys.NumPad5))
                appui[4] = false;
            if (keyboardState.IsKeyDown(Keys.NumPad6))
            {
                if (!appui[5])
                {
                    appui[5] = true;
                    faces[5].TranslateFace(DROITE);
                    faces[5].RotationFace(-MathHelper.PiOver2);
                    UpdateFaces();
                }
            }
            if (keyboardState.IsKeyUp(Keys.NumPad6))
                appui[5] = false;

            base.Update(gameTime);
        }
    }
}
