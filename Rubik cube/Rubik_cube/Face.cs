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
        //Cube[,] tabCubes;
        Camera cam;
        const int DROITE = 0;
        const int GAUCHE = 1;
        public Face(Game game,int num,Camera cam) :base(game)
        {
            this.cam = cam;

            cubes = new Cube[9];
            numFace = num;
            lesCubes = ((Game1)Game).Components.OfType<Cube>().ToArray();
            //tabCubes = ((Game1)Game).Components.OfType<EnsembleCubes>().First().getCubes();
        }

        public Cube[] getCubes()
        {
            return cubes;
        }
        public void UpdateFace(Cube[] temp)
        {
            switch (numFace)
            {
                /*
                case 0:
                    for (int i = 0; i < 9; i++)
                    {
                        lesCubes[0] 
                        tabCubes[0, i] = temp[i];
                    }
                    break;
                case 1:
                    tabCubes[0,2] = temp[0];
                    tabCubes[1,2] = temp[1];
                    tabCubes[2,2] = temp[2];

                    tabCubes[0,5] = temp[3];
                    tabCubes[1,5] = temp[4];
                    tabCubes[2,5] = temp[5];

                    tabCubes[0,8] = temp[6];
                    tabCubes[1,8] = temp[7];
                    tabCubes[2,8] = temp[8];
                    break;
                    
                case 2:
                    for (int i = 0; i < 9; i++)
                    {
                        tabCubes[2,i] = temp[i];
                    }
                    break;
                    
                case 3:
                    tabCubes[2, 0] = temp[0];
                    tabCubes[1, 0] = temp[1];
                    tabCubes[0, 0] = temp[2];

                    tabCubes[2, 3] = temp[3];
                    tabCubes[1, 3] = temp[4];
                    tabCubes[0, 3] = temp[5];

                    tabCubes[2, 6] = temp[6];
                    tabCubes[1, 6] = temp[7];
                    tabCubes[0, 6] = temp[8];
                    break;
                case 4:
                    tabCubes[2, 6] = temp[0];
                    tabCubes[2, 7] = temp[1];
                    tabCubes[2, 8] = temp[2];

                    tabCubes[1, 6] = temp[3];
                    tabCubes[1, 7] = temp[4];
                    tabCubes[1, 8] = temp[5];

                    tabCubes[0, 6] = temp[6];
                    tabCubes[0, 7] = temp[7];
                    tabCubes[0, 8] = temp[8];
                    break;
                case 5:
                    tabCubes[2, 0] = temp[0];
                    tabCubes[2, 1] = temp[1];
                    tabCubes[2, 2] = temp[2];

                    tabCubes[1, 0] = temp[3];
                    tabCubes[1, 1] = temp[4];
                    tabCubes[1, 2] = temp[5];

                    tabCubes[0, 0] = temp[6];
                    tabCubes[0, 1] = temp[7];
                    tabCubes[0, 2] = temp[8];
                    break;
                    */
            }
        }
        public void TranslateFace(int direction)
        {
            Vector3[] pos = new Vector3[9];
            int[] num = new int[9];
            /*
            switch (numFace)
            {
                case 0:
                    temp[0] = tabCubes[0, 6];
                    temp[1] = tabCubes[0, 3];
                    temp[2] = tabCubes[0, 0];
                    temp[3] = tabCubes[0, 7];
                    temp[4] = tabCubes[0, 4];
                    temp[5] = tabCubes[0, 1];
                    temp[6] = tabCubes[0, 8];
                    temp[7] = tabCubes[0, 5];
                    temp[8] = tabCubes[0, 2];
                    break;
                case 1:
                    // Console.WriteLine(tabCubes[0, 2].position);
                    //Console.WriteLine(tabCubes[0, 5].position);
                    //Console.WriteLine(tabCubes[0, 8].position);
                    temp[0] = tabCubes[0, 8];
                    temp[1] = tabCubes[0, 5];
                    temp[2] = tabCubes[0, 2];
                    temp[3] = tabCubes[1, 8];
                    temp[4] = tabCubes[1, 5];
                    temp[5] = tabCubes[1, 2];
                    temp[6] = tabCubes[2, 8];
                    temp[7] = tabCubes[2, 5];
                    temp[8] = tabCubes[2, 2];
                    break;
                case 2:
                    temp[0] = tabCubes[2, 6];
                    temp[1] = tabCubes[2, 3];
                    temp[2] = tabCubes[2, 0];
                    temp[3] = tabCubes[2, 7];
                    temp[4] = tabCubes[2, 4];
                    temp[5] = tabCubes[2, 1];
                    temp[6] = tabCubes[2, 8];
                    temp[7] = tabCubes[2, 5];
                    temp[8] = tabCubes[2, 2];
                    break;
                case 3:
                    temp[0] = tabCubes[2, 6];
                    temp[1] = tabCubes[2, 3];
                    temp[2] = tabCubes[2, 0];
                    temp[3] = tabCubes[1, 6];
                    temp[4] = tabCubes[1, 3];
                    temp[5] = tabCubes[1, 0];
                    temp[6] = tabCubes[0, 6];
                    temp[7] = tabCubes[0, 3];
                    temp[8] = tabCubes[0, 0];
                    break;
                case 4:
                    temp[0] = tabCubes[0, 6];
                    temp[1] = tabCubes[1, 6];
                    temp[2] = tabCubes[2, 6];
                    temp[3] = tabCubes[0, 7];
                    temp[4] = tabCubes[1, 7];
                    temp[5] = tabCubes[2, 7];
                    temp[6] = tabCubes[0, 8];
                    temp[7] = tabCubes[1, 8];
                    temp[8] = tabCubes[2, 8];
                    break;
                case 5:
                    temp[0] = tabCubes[0, 0];
                    temp[1] = tabCubes[1, 0];
                    temp[2] = tabCubes[2, 0];
                    temp[3] = tabCubes[0, 1];
                    temp[4] = tabCubes[1, 1];
                    temp[5] = tabCubes[2, 1];
                    temp[6] = tabCubes[0, 2];
                    temp[7] = tabCubes[1, 2];
                    temp[8] = tabCubes[2, 2];
                    break;
            }*/
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

                num[0] = cubes[2].numero;
                num[1] = cubes[5].numero;
                num[2] = cubes[8].numero;

                num[3] = cubes[1].numero;
                num[4] = cubes[4].numero;
                num[5] = cubes[7].numero;

                num[6] = cubes[0].numero;
                num[7] = cubes[3].numero;
                num[8] = cubes[6].numero;
            }
            if (direction == GAUCHE)
            {
                /*
                switch (numFace)
                {
                    case 0:
                        temp[0] = tabCubes[0, 2];
                        temp[1] = tabCubes[0, 5];
                        temp[2] = tabCubes[0, 8];
                        temp[3] = tabCubes[0, 1];
                        temp[4] = tabCubes[0, 4];
                        temp[5] = tabCubes[0, 7];
                        temp[6] = tabCubes[0, 0];
                        temp[7] = tabCubes[0, 3];
                        temp[8] = tabCubes[0, 6];
                        break;
                    case 1:
                        // Console.WriteLine(tabCubes[0, 2].position);
                        //Console.WriteLine(tabCubes[0, 5].position);
                        //Console.WriteLine(tabCubes[0, 8].position);
                        temp[0] = tabCubes[2, 2];
                        temp[1] = tabCubes[2, 5];
                        temp[2] = tabCubes[2, 8];
                        temp[3] = tabCubes[1, 2];
                        temp[4] = tabCubes[1, 5];
                        temp[5] = tabCubes[1, 8];
                        temp[6] = tabCubes[0, 2];
                        temp[7] = tabCubes[0, 5];
                        temp[8] = tabCubes[0, 8];
                        break;
                    case 2:
                        temp[0] = tabCubes[2, 2];
                        temp[1] = tabCubes[2, 5];
                        temp[2] = tabCubes[2, 8];
                        temp[3] = tabCubes[2, 1];
                        temp[4] = tabCubes[2, 4];
                        temp[5] = tabCubes[2, 7];
                        temp[6] = tabCubes[2, 0];
                        temp[7] = tabCubes[2, 3];
                        temp[8] = tabCubes[2, 6];
                        break;
                    case 3:
                        temp[0] = tabCubes[0, 0];
                        temp[1] = tabCubes[0, 3];
                        temp[2] = tabCubes[0, 6];
                        temp[3] = tabCubes[1, 0];
                        temp[4] = tabCubes[1, 3];
                        temp[5] = tabCubes[1, 6];
                        temp[6] = tabCubes[2, 0];
                        temp[7] = tabCubes[2, 3];
                        temp[8] = tabCubes[2, 6];
                        break;
                    case 4:
                        temp[0] = tabCubes[2, 8];
                        temp[1] = tabCubes[1, 8];
                        temp[2] = tabCubes[0, 8];
                        temp[3] = tabCubes[2, 7];
                        temp[4] = tabCubes[1, 7];
                        temp[5] = tabCubes[0, 7];
                        temp[6] = tabCubes[2, 6];
                        temp[7] = tabCubes[1, 6];
                        temp[8] = tabCubes[0, 6];
                        break;
                    case 5:
                        temp[0] = tabCubes[2, 2];
                        temp[1] = tabCubes[1, 2];
                        temp[2] = tabCubes[0, 2];
                        temp[3] = tabCubes[2, 1];
                        temp[4] = tabCubes[1, 1];
                        temp[5] = tabCubes[0, 1];
                        temp[6] = tabCubes[2, 0];
                        temp[7] = tabCubes[1, 0];
                        temp[8] = tabCubes[0, 0];
                        /*
                        temp[0] = tabCubes[0, 0];
                        temp[1] = tabCubes[1, 0];
                        temp[2] = tabCubes[2, 0];
                        temp[3] = tabCubes[0, 1];
                        temp[4] = tabCubes[1, 1];
                        temp[5] = tabCubes[2, 1];
                        temp[6] = tabCubes[0, 2];
                        temp[7] = tabCubes[1, 2];
                        temp[8] = tabCubes[2, 2];
                        
                        break;
                }*/
                pos[0] = cubes[6].position;
                pos[1] = cubes[3].position;
                pos[2] = cubes[0].position;
                 
                pos[3] = cubes[7].position;
                pos[4] = cubes[4].position;
                pos[5] = cubes[1].position;

                pos[6] = cubes[8].position;
                pos[7] = cubes[5].position;
                pos[8] = cubes[2].position;

                num[0] = cubes[6].numero;
                num[1] = cubes[3].numero;
                num[2] = cubes[0].numero;

                num[3] = cubes[7].numero;
                num[4] = cubes[4].numero;
                num[5] = cubes[1].numero;

                num[6] = cubes[8].numero;
                num[7] = cubes[5].numero;
                num[8] = cubes[2].numero;
            }
            for(int i = 0; i < 9; i++)
            {
                cubes[i].position = pos[i];
                cubes[i].numero = num[i];
            }
            
            //UpdateFace(temp);
            
        }
        public void RotationFace(float angle)
        {
            switch (numFace)
            {
                case 0:
                    for (int i = 0; i < 9; i++)
                    {
                        Matrix newWorld = cubes[i].world;
                        newWorld *= Matrix.CreateFromAxisAngle(Vector3.Forward, angle);
                        cubes[i].world = newWorld;   
                    }
                    break;
                case 1:
                    for (int i = 0; i < 9; i++)
                    {
                        Matrix newWorld = cubes[i].world;
                        newWorld *= Matrix.CreateFromAxisAngle(Vector3.Right, angle);
                        cubes[i].world = newWorld;
                    }
                    break;
                case 2:
                    for (int i = 0; i < 9; i++)
                    {
                        Matrix newWorld = cubes[i].world;
                        newWorld *= Matrix.CreateFromAxisAngle(Vector3.Backward, angle);
                        cubes[i].world = newWorld;
                    }
                    break;
                case 3:
                    for (int i = 0; i < 9; i++)
                    {
                        Matrix newWorld = cubes[i].world;
                        newWorld *= Matrix.CreateFromAxisAngle(Vector3.Left, angle);
                        cubes[i].world = newWorld;
                    }
                    break;
                case 4:
                    for (int i = 0; i < 9; i++)
                    {
                        Matrix newWorld = cubes[i].world;
                        newWorld *= Matrix.CreateFromAxisAngle(Vector3.Down, angle);
                        cubes[i].world = newWorld;
                    }
                    break;
                case 5:
                    for (int i = 0; i < 9; i++)
                    {
                        Matrix newWorld = cubes[i].world;
                        newWorld *= Matrix.CreateFromAxisAngle(Vector3.Up, angle);
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
