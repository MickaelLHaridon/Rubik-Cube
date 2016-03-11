using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Rubik_cube
{
    class GestionFace : GameComponent
    {
        Face[] faces;
        public GestionFace(Game game) :base(game)
        {
            faces = new Face[6];
            for(int i=0; i<6;i++)
            {
                faces[i] = new Face(new Vector3(0,0,0),new Vector3(0,0,0)); 
            }
        }
    }
}
