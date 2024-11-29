using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EasyMonoGame;
using Microsoft.Xna.Framework;
using static System.Formats.Asn1.AsnWriter;

namespace EasyDemo2
{
    internal class Ball : Actor
    {
        private float Speed = 500;

        private int Lscore;
        private int Rscore;

        private float pause_time;

        public Ball()
        {
            ScaleRadius = 0.5f;
        }

        public override void Update(GameTime gameTime)
        {
            float deltaTime = (float)gameTime.ElapsedGameTime.TotalSeconds;
            pause_time -= deltaTime;
            Move(Speed * deltaTime);
            if (pause_time > 0)
            {
                return;
            }

            if(IsTouching(typeof(Racket))){
                Racket racket = (Racket)GetOneIntersectingActor(typeof(Racket));
                float angle = (this.Y - racket.Y) / 1;

                if (this.X > 400)
                {
                    Rotation = angle;
                    this.X = 750;
                }
                else
                {
                    Rotation = angle;
                    this.X = 50;
                }

            }


            if (this.X > 800)
            {
                Rscore += 1;
            }
            if (this.X < 0)
            {
                Lscore += 1;
            }
            World.ShowText(" " + Rscore, 100, 100);
            World.ShowText(" " + Lscore, 700, 100);
        }
    }
}