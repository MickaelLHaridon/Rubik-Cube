using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Rubik_cube
{
    class Cube : DrawableGameComponent
    {
        Color[] faces;
        Vector3 position;
        Vector3 rotation;
        BasicEffect effect;
        float scale;
        SpriteBatch spritebatch;
        VertexPositionColor[] verticesTex1;
        VertexPositionColor[] verticesTex2;
        VertexPositionColor[] verticesTex3;
        VertexPositionColor[] verticesTex4;
        VertexPositionColor[] verticesTex5;
        VertexPositionColor[] verticesTex6;

        Camera cam;
        public Cube(Game game, Vector3 pos, Vector3 rot) : base(game)
        {
            cam = ((Game1)Game).Components.OfType<Camera>().First();
            position = pos;
            rotation = rot;
        }


        public void CreateCubeTexure()
        {
            Color couleur = Color.Red;
            verticesTex1 = new VertexPositionColor[]
            {

                new VertexPositionColor(new Vector3(-1,1,-1), couleur),
                new VertexPositionColor(new Vector3(1,1,-1),couleur),
                new VertexPositionColor(new Vector3(-1,1,1), couleur),
                new VertexPositionColor(new Vector3(1,1,1), couleur)

            };

            verticesTex2 = new VertexPositionColor[]
            {

                new VertexPositionColor(new Vector3(1,1,1), couleur),
                new VertexPositionColor(new Vector3(1,1,-1), couleur),
                new VertexPositionColor(new Vector3(1,-1,1), couleur),
                new VertexPositionColor(new Vector3(1,-1,-1), couleur)

            };

            verticesTex3 = new VertexPositionColor[]
            {

                new VertexPositionColor(new Vector3(-1,1,1), couleur),
                new VertexPositionColor(new Vector3(1,1,1), couleur),
                new VertexPositionColor(new Vector3(-1,-1,1), couleur),
                new VertexPositionColor(new Vector3(1,-1,1), couleur)

            };

            verticesTex4 = new VertexPositionColor[]
            {

                new VertexPositionColor(new Vector3(-1,1,-1), couleur),
                new VertexPositionColor(new Vector3(-1,1,1), couleur),
                new VertexPositionColor(new Vector3(-1,-1,-1), couleur),
                new VertexPositionColor(new Vector3(-1,-1,1), couleur)

            };

            verticesTex5 = new VertexPositionColor[]
            {

                new VertexPositionColor(new Vector3(-1,1,-1), couleur),
                new VertexPositionColor(new Vector3(1,1,-1), couleur),
                new VertexPositionColor(new Vector3(-1,-1,-1), couleur),
                new VertexPositionColor(new Vector3(1,-1,1), couleur)

            };
            verticesTex6 = new VertexPositionColor[]
            {

                new VertexPositionColor(new Vector3(-1,-1,1), couleur),
                new VertexPositionColor(new Vector3(1,-1,1), couleur),
                new VertexPositionColor(new Vector3(-1,-1,-1), couleur),
                new VertexPositionColor(new Vector3(1,-1,-1), couleur)

            };
        }


        public void drawColor(VertexPositionColor[] v)
        {
            foreach (EffectPass pass in effect.CurrentTechnique.Passes)
            {
                pass.Apply();
                GraphicsDevice.DrawUserPrimitives(PrimitiveType.TriangleStrip, v, 0, v.Length / 2);
            }
        }

        public override void Draw(GameTime gameTime)
        {
            effect.View = cam.view;
            effect.Projection = cam.projection;
            effect.World = Matrix.CreateFromYawPitchRoll(rotation.Y,
            rotation.X, rotation.Z) * Matrix.CreateScale(4) * Matrix.CreateTranslation(position);

            effect.VertexColorEnabled = true;

            drawColor(verticesTex1);
            drawColor(verticesTex2);
            drawColor(verticesTex3);
            drawColor(verticesTex4);
            drawColor(verticesTex5);
            drawColor(verticesTex6);

            base.Draw(gameTime);
        }

        protected override void LoadContent()
        {
            spritebatch = new SpriteBatch(GraphicsDevice);
            effect = new BasicEffect(GraphicsDevice);
            CreateCubeTexure();
       
            base.LoadContent();
        }

    }
}
