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
        float scale;
        public Matrix world
        {
            get; set;
        }
        public Matrix RotateTransform {
            get;set;
        }
        public float angle { get; set; }

        SpriteBatch spritebatch;
        VertexPositionColor[] verticesTex0;
        VertexPositionColor[] verticesTex1;
        VertexPositionColor[] verticesTex2;
        VertexPositionColor[] verticesTex3;
        VertexPositionColor[] verticesTex4;
        VertexPositionColor[] verticesTex5;

        public Camera cam
        {
            get;
            set;
        }

        public Cube(Game game, Vector3 pos, Color[] colors) : base(game)
        {
            cam = ((Game1)Game).Components.OfType<Camera>().First();
            position = pos;
            rotation = new Vector3(0,0,1);
            faces = colors;
            scale = 1;
            world = cam.world;
            RotateTransform = Matrix.Identity;
            angle = 0;
        }


        public void CreateCubeTexure()
        {
            verticesTex0 = new VertexPositionColor[]
            {
                new VertexPositionColor(new Vector3(-1,1,1),  faces[0]),
                new VertexPositionColor(new Vector3(1,1,1),  faces[0]),
                new VertexPositionColor(new Vector3(-1,-1,1),  faces[0]),
                new VertexPositionColor(new Vector3(1,-1,1),  faces[0])
            };

            verticesTex1 = new VertexPositionColor[]
            {
                new VertexPositionColor(new Vector3(1,1,1), faces[1]),
                new VertexPositionColor(new Vector3(1,1,-1), faces[1]),
                new VertexPositionColor(new Vector3(1,-1,1), faces[1]),
                new VertexPositionColor(new Vector3(1,-1,-1), faces[1])
            };

            verticesTex2 = new VertexPositionColor[]
            {
                new VertexPositionColor(new Vector3(1,1,-1), faces[2]),
                new VertexPositionColor(new Vector3(-1,1,-1), faces[2]),
                new VertexPositionColor(new Vector3(1,-1,-1), faces[2]),
                new VertexPositionColor(new Vector3(-1,-1,-1), faces[2])

            };

            verticesTex3 = new VertexPositionColor[]
            {

                new VertexPositionColor(new Vector3(-1,1,-1), faces[3]),
                new VertexPositionColor(new Vector3(-1,1,1), faces[3]),
                new VertexPositionColor(new Vector3(-1,-1,-1), faces[3]),
                new VertexPositionColor(new Vector3(-1,-1,1), faces[3])

            };

            verticesTex4 = new VertexPositionColor[]
            {
                new VertexPositionColor(new Vector3(-1,-1,1), faces[4]),
                new VertexPositionColor(new Vector3(1,-1,1), faces[4]),
                new VertexPositionColor(new Vector3(-1,-1,-1), faces[4]),
                new VertexPositionColor(new Vector3(1,-1,-1), faces[4])
            };

            verticesTex5 = new VertexPositionColor[]
            {
                new VertexPositionColor(new Vector3(-1,1,-1), faces[5]),
                new VertexPositionColor(new Vector3(1,1,-1), faces[5]),
                new VertexPositionColor(new Vector3(-1,1,1), faces[5]),
                new VertexPositionColor(new Vector3(1,1,1), faces[5])
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
            effect.World = world * Matrix.CreateTranslation(position); //* Matrix.CreateFromAxisAngle(rotation, angle);
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
           /* KeyboardState keyboardState = Keyboard.GetState();
            Viewport viewport = Game.GraphicsDevice.Viewport;
            Vector3 origine = new Vector3(viewport.Width / 2, viewport.Height / 2,0);
            if (keyboardState.IsKeyDown(Keys.Z))
            {
                effect.World += Matrix.CreateTranslation(origine) *
                Matrix.CreateRotationY((float) Math.PI / 2) *
                Matrix.CreateTranslation(-origine);
            }
            if (keyboardState.IsKeyDown(Keys.S))
            {
                effect.World *= Matrix.CreateTranslation(-origine) *
                Matrix.CreateRotationY((float)-Math.PI / 2) *
                Matrix.CreateTranslation(origine);
            }
            if (keyboardState.IsKeyDown(Keys.Q))
            {
                effect.World *= Matrix.CreateTranslation(-origine) *
                Matrix.CreateRotationX((float)Math.PI / 2) *
                Matrix.CreateTranslation(origine);
            }
            if (keyboardState.IsKeyDown(Keys.S))
            {
                effect.World *= Matrix.CreateTranslation(-origine) *
                Matrix.CreateRotationX((float)-Math.PI / 2) *
                Matrix.CreateTranslation(origine);
            }
            if (keyboardState.IsKeyDown(Keys.A))
            {
                effect.World *= Matrix.CreateTranslation(-origine) *
                Matrix.CreateRotationZ((float)Math.PI / 2) *
                Matrix.CreateTranslation(origine);
            }
            if (keyboardState.IsKeyDown(Keys.E))
            {
                effect.World *= Matrix.CreateTranslation(origine) *
                Matrix.CreateRotationZ((float)-Math.PI / 2) *
                Matrix.CreateTranslation(origine);
            }*/
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
