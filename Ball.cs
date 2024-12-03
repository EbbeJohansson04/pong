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

            if (IsTouching(typeof(Racket)))
            {
                Racket racket = (Racket)GetOneIntersectingActor(typeof(Racket));
                float angle = (this.Y - racket.Y);

                if (this.X > 400)
                {
                    Rotation = -angle + 180;
                    this.X = 700;
                    World.ShowText("angle: " + angle, 400, 500);
                }
                else
                {
                    Rotation = angle +180;
                    this.X = 100;

                    World.ShowText("angle: " + angle, 400, 500);



                }


            }



            if (this.X > 800)
            {
                Rscore += 1;
                Speed = -Speed;

            }
            if (this.X < 0)
            {
                Lscore += 1;
                Speed = -Speed;
            }
            if (this.Y > 600)
            {
                Turn((180 - Rotation) * 2);
            }
            if (this.Y < 0)
            {
                Turn((180 - Rotation) * 2);
            }

            World.ShowText(" " + Rscore, 100, 100);
            World.ShowText(" " + Lscore, 700, 100);
        }
    }
}