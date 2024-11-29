using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EasyMonoGame;
using Microsoft.Xna.Framework.Input;

namespace EasyDemo2
{
    internal class MyWorld : World
    {
        public MyWorld() : base(800, 600)
        {
            BackgroundTileName = "bluerock";
            Add(new Ball(), "ball", 400, 300);
            Add(new Racket(Keys.W, Keys.S), "lighthouse", 20, 300);
            Add(new Racket(Keys.Up, Keys.Down), "lighthouse", 780, 300);
        }
    }
}