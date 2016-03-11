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

        public Face()
        { 

        }

        public Cube[] getCubes()
        {
            return cubes;
        }

    }
}
