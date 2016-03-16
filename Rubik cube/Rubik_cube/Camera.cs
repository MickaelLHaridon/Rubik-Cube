using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Rubik_cube
{
    class Camera : GameComponent
    {
        Vector3 camPosition;
        Vector3 camLookAt;
        Vector3 cible;
        float rotation;
        float angle;
        float distance;
        bool orbit = false;
        public Matrix view
        {
            get; set;
        }
        public Matrix projection
        {
            get; set;
        }
        public Matrix world
        {
            get; set;
        }

        public Camera(Game game) : base(game)
        {
            cible = new Vector3(0, 0, -5);
            camPosition = new Vector3(0, 0, 0);
            projection = Matrix.CreatePerspectiveFieldOfView(MathHelper.ToRadians(45f),Game.GraphicsDevice.DisplayMode.AspectRatio,1f, 1000f);
            view = Matrix.CreateLookAt(camPosition, cible, new Vector3(0f, 1f, 0f));
            world = Matrix.CreateWorld(cible, Vector3.Forward, Vector3.Up);
        }

        public override void Update(GameTime gameTime)
        {
            KeyboardState keyboardState = Keyboard.GetState();

            if (keyboardState.IsKeyDown(Keys.A))
            {
                camPosition.Z += 1;
                cible.Z += 1;
            }
            if (keyboardState.IsKeyDown(Keys.E))
            {
                camPosition.Z-= 1;
                cible.Z -= 1;
            }
            if (keyboardState.IsKeyDown(Keys.Q))
            {
                Matrix rotationMatrix = Matrix.CreateRotationY(MathHelper.ToRadians(-1.0f));
                camPosition = Vector3.Transform(camPosition, rotationMatrix);
            }
            if (keyboardState.IsKeyDown(Keys.D))
            {
                Matrix rotationMatrix = Matrix.CreateRotationY(MathHelper.ToRadians(1.0f));
                camPosition = Vector3.Transform(camPosition, rotationMatrix);
            }
 
            if (keyboardState.IsKeyDown(Keys.Z))
            {
                Matrix rotationMatrix = Matrix.CreateRotationX(MathHelper.ToRadians(1.0f));
                camPosition = Vector3.Transform(camPosition, rotationMatrix);
            }
            if (keyboardState.IsKeyDown(Keys.S))
            {
                Matrix rotationMatrix = Matrix.CreateRotationX(MathHelper.ToRadians(-1.0f));
                camPosition = Vector3.Transform(camPosition, rotationMatrix);
            }

            view = Matrix.CreateLookAt(camPosition, cible, Vector3.Up);

            base.Update(gameTime);
        }
    }
}
