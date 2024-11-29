using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EasyMonoGame;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;


namespace EasyDemo2
{
    internal class Racket : Actor
    {
        private float speed = 1000;
        private Keys keyUp = Keys.W;
        private Keys keyDown = Keys.S;


        public Racket(Keys keyUp, Keys keyDown)
        {
            this.keyUp = keyUp;
            this.keyDown = keyDown;
        }

        public override void Update(GameTime gameTime)
        {
            var keyBoardState = Keyboard.GetState();
            float deltaTime = (float)gameTime.ElapsedGameTime.TotalSeconds;

            if (keyBoardState.IsKeyDown(keyUp))
            {
                Y -= deltaTime * speed;
            }
            if (keyBoardState.IsKeyDown(keyDown))
            {
                Y += deltaTime * speed;
            }


        }
    }
}