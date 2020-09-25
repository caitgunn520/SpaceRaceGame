using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SpaceRaceGame
{
    public partial class GameScreen : UserControl
    {
        List<Player> playerList = new List<Player>();
        
        Player player1;
        Player player2;

        SolidBrush solidBrush = new SolidBrush(Color.White);
        
        public GameScreen()
        {
            InitializeComponent();
        }

        private void GameScreen_Load(object sender, EventArgs e)
        {
            player1 = new Player(138, 400);
            player2 = new Player(414, 400);
            playerList.Add(player1);
            playerList.Add(player2);

            //start timer
            gameLoopTimer.Enabled = true;

            //when P is pressed 
            //pause or unpause timer
        }
        
        private void GameScreen_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            switch(e.KeyCode)
            {
                case Keys.W:
                    player1.Move(player1, "up");
                    break;
                case Keys.S:
                    player1.Move(player1, "down");
                    break;
                case Keys.A:
                    player1.Move(player1, "left");
                    break;
                case Keys.D:
                    player1.Move(player1, "right");
                    break;
                case Keys.Up:
                    player2.Move(player2, "up");
                    break;
                case Keys.Down:
                    player2.Move(player2, "down");
                    break;
                case Keys.Left:
                    player2.Move(player2, "left");
                    break;
                case Keys.Right:
                    player2.Move(player2, "right");
                    break;
            }
        }

        private void gameLoopTimer_Tick(object sender, EventArgs e)
        {
            //when timer goes off
            //update object positions

            //if player collides with asteroid
            //send player to start

            //when player reaches end
            //they win

            Refresh();
        }

        private void GameScreen_Paint(object sender, PaintEventArgs e)
        {
            foreach (Player p in playerList)
            {
                e.Graphics.FillRectangle(solidBrush, p.x, p.y, p.width, p.height);
            }
        }
    }
}
