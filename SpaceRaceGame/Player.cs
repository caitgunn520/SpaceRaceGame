using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceRaceGame
{
    class Player
    {
        public int x, y, height, width, speed;

        public Player(int _x, int _y)
        {
            x = _x;
            y = _y;

            height = 30;
            width = 15;
            speed = 7;
        }

        public void Move(Player p, string dir)
        {
            switch (dir)
            {
                case "up":
                    p.y -= p.speed;
                    break;
                case "down":
                    p.y += p.speed;
                    break;
                case "left":
                    p.x -= p.speed;
                    break;
                case "right":
                    p.x += p.speed;
                    break;
                default:
                    break;
            }
        }
    }
}
