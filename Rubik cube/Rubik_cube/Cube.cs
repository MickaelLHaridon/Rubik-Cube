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
        Texture2D[] faces;
        Vector3 position;
        Vector3 rotation;
        BasicEffect effect;
        float scale;
        SpriteBatch spritebatch;
        VertexPositionTexture[] verticesTex1;
        VertexPositionTexture[] verticesTex2;
        VertexPositionTexture[] verticesTex3;
        VertexPositionTexture[] verticesTex4;
        VertexPositionTexture[] verticesTex5;
        VertexPositionTexture[] verticesTex6;

        Camera cam;
        public Cube(Game game, Camera cam) : base(game)
        {
            this.cam = cam;
            position = new Vector3(0, 0, 0);
            rotation = new Vector3(0, 0, 0);

        }


        public void CreateCubeTexure()
        {
            verticesTex1 = new VertexPositionTexture[]
            {

                new VertexPositionTexture(new Vector3(-1,1,-1), new Vector2(0,0)),
                new VertexPositionTexture(new Vector3(1,1,-1), new Vector2(1,0)),
                new VertexPositionTexture(new Vector3(-1,1,1), new Vector2(0,1)),
                new VertexPositionTexture(new Vector3(1,1,1), new Vector2(1,1))

            };

            verticesTex2 = new VertexPositionTexture[]
            {

                new VertexPositionTexture(new Vector3(1,1,1), new Vector2(0,0)),
                new VertexPositionTexture(new Vector3(1,1,-1), new Vector2(1,0)),
                new VertexPositionTexture(new Vector3(1,-1,1), new Vector2(0,1)),
                new VertexPositionTexture(new Vector3(1,-1,-1), new Vector2(1,1))

            };

            verticesTex3 = new VertexPositionTexture[]
            {

                new VertexPositionTexture(new Vector3(-1,1,1), new Vector2(0,0)),
                new VertexPositionTexture(new Vector3(1,1,1), new Vector2(1,0)),
                new VertexPositionTexture(new Vector3(-1,-1,1), new Vector2(0,1)),
                new VertexPositionTexture(new Vector3(1,-1,1), new Vector2(1,1))

            };

            verticesTex4 = new VertexPositionTexture[]
            {

                new VertexPositionTexture(new Vector3(-1,1,-1), new Vector2(0,0)),
                new VertexPositionTexture(new Vector3(-1,1,1), new Vector2(1,0)),
                new VertexPositionTexture(new Vector3(-1,-1,-1), new Vector2(0,1)),
                new VertexPositionTexture(new Vector3(-1,-1,1), new Vector2(1,1))

            };

            verticesTex5 = new VertexPositionTexture[]
            {

                new VertexPositionTexture(new Vector3(-1,1,-1), new Vector2(0,0)),
                new VertexPositionTexture(new Vector3(1,1,-1), new Vector2(1,0)),
                new VertexPositionTexture(new Vector3(-1,-1,-1), new Vector2(0,1)),
                new VertexPositionTexture(new Vector3(1,-1,1), new Vector2(1,1))

            };
            verticesTex6 = new VertexPositionTexture[]
            {

                new VertexPositionTexture(new Vector3(-1,-1,1), new Vector2(0,0)),
                new VertexPositionTexture(new Vector3(1,-1,1), new Vector2(1,0)),
                new VertexPositionTexture(new Vector3(-1,-1,-1), new Vector2(0,1)),
                new VertexPositionTexture(new Vector3(1,-1,-1), new Vector2(1,1))

            };
        }

        public void drawTexture(VertexPositionTexture[] v, Texture2D t, int i)
        {
            VertexBuffer B = new VertexBuffer(this.GraphicsDevice, typeof(VertexPositionTexture),
                v.Length, BufferUsage.WriteOnly);
            B.SetData(v);

            GraphicsDevice.SetVertexBuffer(B);
            effect.VertexColorEnabled = false;
            effect.TextureEnabled = true;
            effect.Texture = t;

            foreach (EffectPass pass in effect.CurrentTechnique.Passes)
            {
                pass.Apply();
                GraphicsDevice.DrawUserPrimitives<VertexPositionTexture>(PrimitiveType.TriangleStrip, v, 0, v.Length / 2);

            }
        }

        public override void Draw(GameTime gameTime)
        {
            base.Draw(gameTime);
            effect.View = cam.view;
            effect.Projection = cam.projection;
            effect.World = Matrix.CreateFromYawPitchRoll(this.rotation.Y,
            rotation.X, rotation.Z) * Matrix.CreateScale(4) * Matrix.CreateTranslation(position);

            drawTexture(verticesTex1, faces[0], 1);
            drawTexture(verticesTex2, faces[1], 2);
            drawTexture(verticesTex3, faces[2], 3);
            drawTexture(verticesTex4, faces[3], 4);
            drawTexture(verticesTex5, faces[4], 5);
            drawTexture(verticesTex6, faces[5], 6);





        }
        protected override void LoadContent()
        {
            spritebatch = new SpriteBatch(GraphicsDevice);
            effect = new BasicEffect(GraphicsDevice);
            CreateCubeTexure();
            faces = new Texture2D[6];
            faces[0] = ((Game1)Game).Content.Load<Texture2D>("Chrysanthemum");
            faces[1] = ((Game1)Game).Content.Load<Texture2D>("Desert");
            faces[2] = ((Game1)Game).Content.Load<Texture2D>("Hydrangeas");
            faces[3] = ((Game1)Game).Content.Load<Texture2D>("Lighthouse");
            faces[4] = ((Game1)Game).Content.Load<Texture2D>("Penguins");
            faces[5] = ((Game1)Game).Content.Load<Texture2D>("Tulips");

            ((Game1)Game).GraphicsDevice.SamplerStates[0] = SamplerState.PointClamp;

            base.LoadContent();
        }

    }
}
