using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceRaceGame
{
    class Asteroid
    {
        public int x, y, size, speed;

        public Asteroid(int _x, int _y)
        {
            x = _x;
            y = _y;

            size = 12;
            speed = 5;
        }

        public void Move(Asteroid a, Boolean left)
        {
            switch (left)
            {
                case true:
                    a.x -= a.speed;
                    break;
                case false:
                    a.x += a.speed;
                    break;
            }
        }
    }
}
