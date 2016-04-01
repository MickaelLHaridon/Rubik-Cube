using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Rubik_cube
{
    class Face : GameComponent
    {
        int numFace;
        public Cube[] cubes {get;set;}
        Cube[] lesCubes;
        Camera cam;
        float angle;
        const float DROITE = 0;
        const float GAUCHE = 1;
        public Face(Game game,int num,Camera cam) :base(game)
        {
            this.cam = cam;
            angle = MathHelper.PiOver2;
            cubes = new Cube[9];
            numFace = num;
            lesCubes = ((Game1)Game).Components.OfType<Cube>().ToArray();
        }

        public Cube[] getCubes()
        {
            return cubes;
        }

        public void TranslateFace(float direction)
        {
            Vector3[] pos = new Vector3[9];
            int[] num = new int[9];

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
                
                num[0] = cubes[2].numeroPosition;
                num[1] = cubes[5].numeroPosition;
                num[2] = cubes[8].numeroPosition;

                num[3] = cubes[1].numeroPosition;
                num[4] = cubes[4].numeroPosition;
                num[5] = cubes[7].numeroPosition;

                num[6] = cubes[0].numeroPosition;
                num[7] = cubes[3].numeroPosition;
                num[8] = cubes[6].numeroPosition;
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
                
                num[0] = cubes[6].numeroPosition;
                num[1] = cubes[3].numeroPosition;
                num[2] = cubes[0].numeroPosition;

                num[3] = cubes[7].numeroPosition;
                num[4] = cubes[4].numeroPosition;
                num[5] = cubes[1].numeroPosition;

                num[6] = cubes[8].numeroPosition;
                num[7] = cubes[5].numeroPosition;
                num[8] = cubes[2].numeroPosition;
            }
            for(int i = 0; i < 9; i++)
            {
                cubes[i].position = pos[i];
                cubes[i].numeroPosition = num[i];
            }
                        
        }
        public void RotationFace(Vector3 axe,float angle)
        {
            for (int i = 0; i < 9; i++)
            {
                cubes[i].world *= Matrix.CreateFromAxisAngle(axe, angle);
            }
        }
        public void AjouterCube(int i, Cube cube)
        {
            cubes[i] = cube;
        }
    }
}
