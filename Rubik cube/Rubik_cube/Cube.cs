using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Rubik_cube
{
    class Cube : DrawableGameComponent
    {
        public Color[] faces {
            get;
            set;
        }
        public Vector3 position {
            set;
            get;
        }
        public Vector3 rotation {
            set;
            get;
        }
        BasicEffect effect;
        public Matrix world
        {
            get; set;
        }
        public Matrix RotateTransform {
            get;set;
        }

        SpriteBatch spritebatch;
        VertexPositionColorTexture[] verticesTex0;
        VertexPositionColorTexture[] verticesTex1;
        VertexPositionColorTexture[] verticesTex2;
        VertexPositionColorTexture[] verticesTex3;
        VertexPositionColorTexture[] verticesTex4;
        VertexPositionColorTexture[] verticesTex5;

        Texture2D texture;

        public Camera cam
        {
            get;
            set;
        }

        public int numero
        {
            get;
            set;
        }

        public Cube(Game game,int num, Vector3 pos, Color[] colors) : base(game)
        {
            cam = ((Game1)Game).Components.OfType<Camera>().First();
            numero = num;
            position = pos;
            rotation = new Vector3(0,0,1);
            faces = colors;
            world = cam.world;
            RotateTransform = Matrix.Identity;
        }


        public void CreateCubeTexure()
        {
            verticesTex0 = new VertexPositionColorTexture[]
            {
                new VertexPositionColorTexture(new Vector3(-1,1,1),  faces[0], new Vector2(0,0)),
                new VertexPositionColorTexture(new Vector3(1,1,1),  faces[0], new Vector2(1,0)),
                new VertexPositionColorTexture(new Vector3(-1,-1,1),  faces[0], new Vector2(0,1)),
                new VertexPositionColorTexture(new Vector3(1,-1,1),  faces[0], new Vector2(1,1))
            };

            verticesTex1 = new VertexPositionColorTexture[]
            {
                new VertexPositionColorTexture(new Vector3(1,1,1), faces[1], new Vector2(0,0)),
                new VertexPositionColorTexture(new Vector3(1,1,-1), faces[1], new Vector2(1,0)),
                new VertexPositionColorTexture(new Vector3(1,-1,1), faces[1], new Vector2(0,1)),
                new VertexPositionColorTexture(new Vector3(1,-1,-1), faces[1], new Vector2(1,1))
            };

            verticesTex2 = new VertexPositionColorTexture[]
            {
                new VertexPositionColorTexture(new Vector3(1,1,-1), faces[2], new Vector2(0,0)),
                new VertexPositionColorTexture(new Vector3(-1,1,-1), faces[2], new Vector2(1,0)),
                new VertexPositionColorTexture(new Vector3(1,-1,-1), faces[2], new Vector2(0,1)),
                new VertexPositionColorTexture(new Vector3(-1,-1,-1), faces[2], new Vector2(1,1))

            };

            verticesTex3 = new VertexPositionColorTexture[]
            {

                new VertexPositionColorTexture(new Vector3(-1,1,-1), faces[3], new Vector2(0,0)),
                new VertexPositionColorTexture(new Vector3(-1,1,1), faces[3], new Vector2(1,0)),
                new VertexPositionColorTexture(new Vector3(-1,-1,-1), faces[3], new Vector2(0,1)),
                new VertexPositionColorTexture(new Vector3(-1,-1,1), faces[3], new Vector2(1,1))

            };

            verticesTex4 = new VertexPositionColorTexture[]
            {
                new VertexPositionColorTexture(new Vector3(-1,-1,1), faces[4], new Vector2(0,0)),
                new VertexPositionColorTexture(new Vector3(1,-1,1), faces[4], new Vector2(1,0)),
                new VertexPositionColorTexture(new Vector3(-1,-1,-1), faces[4], new Vector2(0,1)),
                new VertexPositionColorTexture(new Vector3(1,-1,-1), faces[4], new Vector2(1,1))
            };

            verticesTex5 = new VertexPositionColorTexture[]
            {
                new VertexPositionColorTexture(new Vector3(-1,1,-1), faces[5], new Vector2(0,0)),
                new VertexPositionColorTexture(new Vector3(1,1,-1), faces[5], new Vector2(1,0)),
                new VertexPositionColorTexture(new Vector3(-1,1,1), faces[5], new Vector2(0,1)),
                new VertexPositionColorTexture(new Vector3(1,1,1), faces[5], new Vector2(1,1))
            };
           
        }

        public void drawColorTexture(VertexPositionColorTexture[] v)
        {
            VertexBuffer B = new VertexBuffer(this.GraphicsDevice, typeof(VertexPositionColorTexture),
                v.Length, BufferUsage.WriteOnly);
            B.SetData(v);

            GraphicsDevice.SetVertexBuffer(B);
            effect.VertexColorEnabled = true;
            effect.TextureEnabled = true;
            effect.Texture = texture;

            foreach (EffectPass pass in effect.CurrentTechnique.Passes)
            {
                pass.Apply();
                GraphicsDevice.SamplerStates[0] = SamplerState.LinearClamp;
                GraphicsDevice.DrawUserPrimitives(PrimitiveType.TriangleStrip, v, 0, v.Length/2);
            }
        }
        public override void Draw(GameTime gameTime)
        {

            effect.View = cam.view;
            effect.Projection = cam.projection;
            effect.World = world * Matrix.CreateTranslation(position);
     
            drawColorTexture(verticesTex0);
            drawColorTexture(verticesTex1);
            drawColorTexture(verticesTex2);
            drawColorTexture(verticesTex3);
            drawColorTexture(verticesTex4);
            drawColorTexture(verticesTex5);

            base.Draw(gameTime);
        }

        public override void Update(GameTime gameTime)
        {
           
            base.Update(gameTime);
        }
        protected override void LoadContent()
        {
            spritebatch = new SpriteBatch(GraphicsDevice);
            effect = new BasicEffect(GraphicsDevice);
            texture = ((Game1)Game).Content.Load<Texture2D>("Coin");
            CreateCubeTexure();
       
            base.LoadContent();
        }
    }
}
