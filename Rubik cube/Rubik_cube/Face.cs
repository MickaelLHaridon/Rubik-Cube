using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Rubik_cube
{
    class Face
    {
        Vector3 position;
        Vector3 rotation;
        Cube[] cubes;

        public Face(Vector3 pos, Vector3 rot)
        {
            position = pos;
            rotation = rot;
            cubes = new Cube[6];
        }

        public Cube[] getCubes()
        {
            return cubes;
        }
        public void RotationFace(float x, float y, float z)
        {
            rotation = new Vector3(x,y,z);
        }

        public void AjouterCube(int i, Cube cube)
        {
            cubes[i] = cube;
        }
    }
}
