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
        VertexPositionColor[] verticesTex0;
        VertexPositionColor[] verticesTex1;
        VertexPositionColor[] verticesTex2;
        VertexPositionColor[] verticesTex3;
        VertexPositionColor[] verticesTex4;
        VertexPositionColor[] verticesTex5;

        Camera cam;
        public Cube(Game game, Vector3 pos, Vector3 rot) : base(game)
        {
            cam = ((Game1)Game).Components.OfType<Camera>().First();
            position = pos;
            rotation = rot;
        }


        public void CreateCubeTexure()
        {
            verticesTex0 = new VertexPositionColor[]
            {
                new VertexPositionColor(new Vector3(-1,1,1),  Color.Pink),
                new VertexPositionColor(new Vector3(1,1,1),  Color.Pink),
                new VertexPositionColor(new Vector3(-1,-1,1),  Color.Pink),
                new VertexPositionColor(new Vector3(1,-1,1),  Color.Pink)
            };

            verticesTex1 = new VertexPositionColor[]
            {
                new VertexPositionColor(new Vector3(1,1,1), Color.Red),
                new VertexPositionColor(new Vector3(1,1,-1), Color.Red),
                new VertexPositionColor(new Vector3(1,-1,1), Color.Red),
                new VertexPositionColor(new Vector3(1,-1,-1), Color.Red)
            };

            verticesTex2 = new VertexPositionColor[]
            {
                new VertexPositionColor(new Vector3(1,1,-1), Color.Green),
                new VertexPositionColor(new Vector3(-1,1,-1), Color.Green),
                new VertexPositionColor(new Vector3(1,-1,-1), Color.Green),
                new VertexPositionColor(new Vector3(-1,-1,-1), Color.Green)

            };

            verticesTex3 = new VertexPositionColor[]
            {

                new VertexPositionColor(new Vector3(-1,1,-1), Color.Yellow),
                new VertexPositionColor(new Vector3(-1,1,1), Color.Yellow),
                new VertexPositionColor(new Vector3(-1,-1,-1), Color.Yellow),
                new VertexPositionColor(new Vector3(-1,-1,1), Color.Yellow)

            };

            verticesTex4 = new VertexPositionColor[]
            {
                new VertexPositionColor(new Vector3(-1,-1,1), Color.Blue),
                new VertexPositionColor(new Vector3(1,-1,1),Color.Blue),
                new VertexPositionColor(new Vector3(-1,-1,-1),Color.Blue),
                new VertexPositionColor(new Vector3(1,-1,-1), Color.Blue)
            };

            verticesTex5 = new VertexPositionColor[]
            {
                new VertexPositionColor(new Vector3(-1,1,-1), Color.Orange),
                new VertexPositionColor(new Vector3(1,1,-1), Color.Orange),
                new VertexPositionColor(new Vector3(-1,1,1), Color.Orange),
                new VertexPositionColor(new Vector3(1,1,1), Color.Orange)


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
            drawColor(verticesTex0);
            drawColor(verticesTex1);
            drawColor(verticesTex2);
            drawColor(verticesTex3);
            drawColor(verticesTex4);
            drawColor(verticesTex5);

            base.Draw(gameTime);
        }

        public override void Update(GameTime gameTime)
        {
            rotation += new Vector3(0, 0.1f, 0);
            base.Update(gameTime);
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
