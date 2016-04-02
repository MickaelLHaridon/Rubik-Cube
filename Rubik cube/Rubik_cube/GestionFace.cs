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
        public Face[] faces
        {
            get; set;
        }
        public Cube[] lesCubes
        {
            get; set;
        }
        public Cube[] etatInitial
        {
            get; set;
        }
        bool leftShift = false;
        const float DROITE = 0;
        const float GAUCHE = 1;
        Random rand = new Random();
        KeyboardState oldKey;
        KeyboardState newKey;
        public float[,] rotations
        {
            get; set;
        }
        public Vector3[] vectRot
        {
            get; set;
        }

        public GestionFace(Game game) :base(game)
        {
            faces = new Face[6];
            for(int i=0; i<6;i++)
            {
                faces[i] = new Face(game,i, ((Game1)Game).Components.OfType<Camera>().First());
            }
            rotations = new float[6, 2] { { DROITE, MathHelper.PiOver2 }, { GAUCHE, -MathHelper.PiOver2 }, { GAUCHE, MathHelper.PiOver2 },
                { DROITE, -MathHelper.PiOver2 }, { DROITE, -MathHelper.PiOver2 }, { DROITE, MathHelper.PiOver2 } };
            vectRot = new Vector3[6] { Vector3.Forward, Vector3.Right, Vector3.Backward, Vector3.Left, Vector3.Down, Vector3.Up };
        }

        public override void Initialize()
        {
            lesCubes = ((Game1)Game).Components.OfType<Cube>().ToArray();
            etatInitial = lesCubes;
            UpdateFaces();
            base.Initialize();
        }

        public void UpdateFaces()
        {
            lesCubes = lesCubes.OrderBy(Cube => Cube.numeroPosition).ToArray();
            int i_face = 0;
            int i_back = 0;
            int i_droite = 0;
            int i_gauche = 0;
            int i_haut = 0;
            int i_bas = 0;

            for(int i = 0; i < 27; i++)
            {
                if (lesCubes[i].position.Z == 0)
                {
                    faces[0].AjouterCube(i_face, lesCubes[i]);
                    i_face++;
                }
                if (lesCubes[i].position.X == 2)
                {
                    faces[1].AjouterCube(i_droite, lesCubes[i]);
                    i_droite++;
                }

                if (lesCubes[i].position.Z == -4)
                {
                    faces[2].AjouterCube(i_back, lesCubes[i]);
                    i_back++;
                }
                if (lesCubes[i].position.X == -2)
                {
                    faces[3].AjouterCube(i_gauche, lesCubes[i]);
                    i_gauche++;
                }
                if (lesCubes[i].position.Y == -2)
                {
                    faces[4].AjouterCube(i_bas, lesCubes[i]);
                    i_bas++;
                }
                if (lesCubes[i].position.Y == 2)
                {
                    faces[5].AjouterCube(i_haut, lesCubes[i]);
                    i_haut++;
                }
            }
        }

        public void Melanger(int nombre)
        {
            for(int i = 0; i < nombre; i++)
            {
                int nb = rand.Next(0, 6);
                int direction = rand.Next(0, 2);
                if(direction == DROITE)
                {
                    faces[nb].TranslateFace(rotations[nb, 0]);
                    faces[nb].RotationFace(vectRot[nb], rotations[nb, 1]);
                }
                else
                {
                    faces[nb].TranslateFace(Math.Abs(rotations[nb, 0]-1));
                    faces[nb].RotationFace(vectRot[nb], -rotations[nb, 1]);
                }
                UpdateFaces();

             }


        }

        public override void Update(GameTime gameTime)
        {
            oldKey = newKey;
            newKey = Keyboard.GetState();

            if (newKey.IsKeyDown(Keys.Enter) && oldKey.IsKeyUp(Keys.Enter))
            {
                ((Game1)Game).Components.OfType<ResolutionRubik>().First().Resolution();
            }

            if (newKey.IsKeyDown(Keys.Space) && oldKey.IsKeyUp(Keys.Space))
            {
                Melanger(50);
            }
            if (newKey.IsKeyDown(Keys.LeftShift) && oldKey.IsKeyUp(Keys.LeftShift))
            {
                if (leftShift)
                    leftShift = false;
                else
                    leftShift = true;
            }

            if(leftShift)
            {
                if (newKey.IsKeyDown(Keys.NumPad1) && oldKey.IsKeyUp(Keys.NumPad1))
                {
                    faces[0].TranslateFace(Math.Abs(rotations[0, 0]-1));
                    faces[0].RotationFace(vectRot[0], -rotations[0, 1]);
                    UpdateFaces();
                }

                if (newKey.IsKeyDown(Keys.NumPad2) && oldKey.IsKeyUp(Keys.NumPad2))
                {
                    faces[1].TranslateFace(Math.Abs(rotations[1, 0]-1));
                    faces[1].RotationFace(vectRot[1], -rotations[1, 1]);
                    UpdateFaces();
                }
                if (newKey.IsKeyDown(Keys.NumPad3) && oldKey.IsKeyUp(Keys.NumPad3))
                {
                    faces[2].TranslateFace(Math.Abs(rotations[2, 0]-1));
                    faces[2].RotationFace(vectRot[2], -rotations[2, 1]);
                    UpdateFaces();
                }

                if (newKey.IsKeyDown(Keys.NumPad4) && oldKey.IsKeyUp(Keys.NumPad4))
                {
                    faces[3].TranslateFace(Math.Abs(rotations[3, 0]-1));
                    faces[3].RotationFace(vectRot[3], -rotations[3, 1]);
                    UpdateFaces();
                }
                if (newKey.IsKeyDown(Keys.NumPad5) && oldKey.IsKeyUp(Keys.NumPad5))
                {
                    faces[4].TranslateFace(Math.Abs(rotations[4, 0]-1));
                    faces[4].RotationFace(vectRot[4], -rotations[4, 1]);
                    UpdateFaces();
                }
                if (newKey.IsKeyDown(Keys.NumPad6) && oldKey.IsKeyUp(Keys.NumPad6))
                {
                    faces[5].TranslateFace(Math.Abs(rotations[5, 0]-1));
                    faces[5].RotationFace(vectRot[5], -rotations[5, 1]);
                    UpdateFaces();
                }
            }
            else
            {
                if (newKey.IsKeyDown(Keys.NumPad1) && oldKey.IsKeyUp(Keys.NumPad1))
                    {
                        faces[0].TranslateFace(rotations[0, 0]);
                        faces[0].RotationFace(vectRot[0], rotations[0, 1]);
                        UpdateFaces();
                    }
                
                if (newKey.IsKeyDown(Keys.NumPad2) && oldKey.IsKeyUp(Keys.NumPad2))
                    {
                        faces[1].TranslateFace(rotations[1,0]);
                        faces[1].RotationFace(vectRot[1], rotations[1, 1]);
                        UpdateFaces();
                    }
                if (newKey.IsKeyDown(Keys.NumPad3) && oldKey.IsKeyUp(Keys.NumPad3))
                {
                    faces[2].TranslateFace(rotations[2, 0]);
                    faces[2].RotationFace(vectRot[2], rotations[2, 1]);
                    UpdateFaces();
                }

                if (newKey.IsKeyDown(Keys.NumPad4) && oldKey.IsKeyUp(Keys.NumPad4))
                {
                    faces[3].TranslateFace(rotations[3, 0]);
                    faces[3].RotationFace(vectRot[3], rotations[3, 1]);
                    UpdateFaces();
                }
                if (newKey.IsKeyDown(Keys.NumPad5) && oldKey.IsKeyUp(Keys.NumPad5))
                {
                    faces[4].TranslateFace(rotations[4, 0]);
                    faces[4].RotationFace(vectRot[4], rotations[4, 1]);
                    UpdateFaces();
                }
                if (newKey.IsKeyDown(Keys.NumPad6) && oldKey.IsKeyUp(Keys.NumPad6))
                {
                    faces[5].TranslateFace(rotations[5, 0]);
                    faces[5].RotationFace(vectRot[5], rotations[5, 1]);
                    UpdateFaces();
                }
            }

            base.Update(gameTime);
        }
    }
}
