using Microsoft.Xna.Framework;
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
        GraphicsDeviceManager graphics;
        public Matrix view
        {
            get; set;
        }
        public Matrix projection
        {
            get; set;
        }

        public Camera(Game game, GraphicsDeviceManager g, Vector3 camPosition, Vector3 camLookAt) : base(game)
        {
            this.camPosition = camPosition;
            this.camLookAt = camLookAt;
            graphics = g;
            view = Matrix.CreateLookAt(camPosition, camLookAt, Vector3.Up);
            projection = Matrix.CreatePerspectiveFieldOfView(MathHelper.ToRadians(45.0f), graphics.GraphicsDevice.Viewport.AspectRatio, 1.0f, 10000.0f);

        }
    }
}
