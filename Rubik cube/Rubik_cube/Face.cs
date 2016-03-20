using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Rubik_cube
{
    class Face 
    {
        int numFace;
        Cube[] cubes;
        Camera cam;
        const int DROITE = 0;
        const int GAUCHE = 1;
        public Face(int num,Camera cam)
        {
            this.cam = cam;

            cubes = new Cube[9];
            numFace = num;
        }

        public Cube[] getCubes()
        {
            return cubes;
        }

        public void TranslateFace(int direction)
        {
            Vector3[] pos = new Vector3[9];

            if (direction == DROITE)
            {
                pos[0] = cubes[2].position;
                pos[1] = cubes[5].position;
                pos[2] = cubes[8].position;

                pos[3] = cubes[1].position;
                pos[4] = cubes[4].position;
                pos[5] = cubes[7].position;

                pos[6] = cubes[0].position;
                pos[7] = cubes[3].position;
                pos[8] = cubes[6].position;
            }
            if (direction == GAUCHE)
            {
                pos[0] = cubes[6].position;
                pos[1] = cubes[3].position;
                pos[2] = cubes[0].position;

                pos[3] = cubes[7].position;
                pos[4] = cubes[4].position;
                pos[5] = cubes[1].position;

                pos[6] = cubes[8].position;
                pos[7] = cubes[5].position;
                pos[8] = cubes[2].position;
            }

            for (int i = 0; i < 9; i++)
            {
                cubes[i].position = pos[i];
            }
        }
        public void RotationFace(float angle)
        {
            switch (numFace)
            {
                case 0:
                    for (int i = 0; i < 9; i++)
                    {
                        Vector3 pointToRotateAround = cubes[i].world.Translation +
                            cubes[i].world.Forward;
                        Matrix newWorld = cubes[i].world;
                        newWorld.Translation -= pointToRotateAround;
                        newWorld *= Matrix.CreateFromAxisAngle(Vector3.Forward, angle);
                        newWorld.Translation += pointToRotateAround;
                        cubes[i].world = newWorld;
                    }
                    break;
                case 1:
                    for (int i = 0; i < 9; i++)
                    {
                        Vector3 pointToRotateAround = cubes[i].world.Translation +
                             cubes[i].world.Right;
                        Matrix newWorld = cubes[i].world;
                        newWorld.Translation -= pointToRotateAround;
                        newWorld *= Matrix.CreateFromAxisAngle(Vector3.Right, angle);
                        newWorld.Translation += pointToRotateAround;
                        cubes[i].world = newWorld;
                    }
                    break;
                case 2:
                    for (int i = 0; i < 9; i++)
                    {
                        Vector3 pointToRotateAround = cubes[i].world.Translation +
                             cubes[i].world.Backward;
                        Matrix newWorld = cubes[i].world;
                        newWorld.Translation -= pointToRotateAround;
                        newWorld *= Matrix.CreateFromAxisAngle(Vector3.Backward, angle);
                        newWorld.Translation += pointToRotateAround;
                        cubes[i].world = newWorld;
                    }
                    break;
                case 3:
                    for (int i = 0; i < 9; i++)
                    {
                        Vector3 pointToRotateAround = cubes[i].world.Translation +
                             cubes[i].world.Left;
                        Matrix newWorld = cubes[i].world;
                        newWorld.Translation -= pointToRotateAround;
                        newWorld *= Matrix.CreateFromAxisAngle(Vector3.Left, angle);
                        newWorld.Translation += pointToRotateAround;
                        cubes[i].world = newWorld;
                    }
                    break;
                case 4:
                    for (int i = 0; i < 9; i++)
                    {
                        Vector3 pointToRotateAround = cubes[i].world.Translation +
                             cubes[i].world.Down;
                        Matrix newWorld = cubes[i].world;
                        newWorld.Translation -= pointToRotateAround;
                        newWorld *= Matrix.CreateFromAxisAngle(Vector3.Down, angle);
                        newWorld.Translation += pointToRotateAround;
                        cubes[i].world = newWorld;
                    }
                    break;
                case 5:
                    for (int i = 0; i < 9; i++)
                    {
                        Vector3 pointToRotateAround = cubes[i].world.Translation +
                             cubes[i].world.Up;
                        Matrix newWorld = cubes[i].world;
                        newWorld.Translation -= pointToRotateAround;
                        newWorld *= Matrix.CreateFromAxisAngle(Vector3.Up, angle);
                        newWorld.Translation += pointToRotateAround;
                        cubes[i].world = newWorld;
                    }
                    break;
            }
        }

     

        public void AjouterCube(int i, Cube cube)
        {
            cubes[i] = cube;
        }
    }
}
