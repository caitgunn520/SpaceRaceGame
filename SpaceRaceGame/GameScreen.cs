using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Media;

namespace SpaceRaceGame
{
    public partial class GameScreen : UserControl
    {
        //control button booleans
        Boolean wKeyDown, aKeyDown, sKeyDown, dKeyDown, upArrowDown, leftArrowDown,
            downArrowDown, rightArrowDown;

        Random asterPosGen = new Random();

        //sound effect players
        SoundPlayer collideSound = new SoundPlayer(Properties.Resources.collision_sound_effect);
        SoundPlayer winSound = new SoundPlayer(Properties.Resources.win_sound_effect);
        
        List<Player> playerList = new List<Player>();
        List<Asteroid> leftAsterList = new List<Asteroid>();
        List<Asteroid> rightAsterList = new List<Asteroid>();
        
        Player player1;

        Player player2;

        SolidBrush solidBrush = new SolidBrush(Color.White);

        

        public GameScreen()
        {
            InitializeComponent();
        }

        private void GameScreen_Load(object sender, EventArgs e)
        {
            victoryLabel.Visible = false;
            endButton.Visible = false;
            endButton.Enabled = false;
            
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
                    wKeyDown = true;
                    break;
                case Keys.S:
                    sKeyDown = true;
                    break;
                case Keys.A:
                    aKeyDown = true;
                    break;
                case Keys.D:
                    dKeyDown = true;
                    break;
                case Keys.Up:
                    upArrowDown = true;
                    break;
                case Keys.Down:
                    downArrowDown = true;
                    break;
                case Keys.Left:
                    leftArrowDown = true;
                    break;
                case Keys.Right:
                    rightArrowDown = true;
                    break;
            }
        }

        private void GameScreen_KeyUp(object sender, KeyEventArgs e)
        {
            switch(e.KeyCode)
            {
                case Keys.W:
                    wKeyDown = false;
                    break;
                case Keys.S:
                    sKeyDown = false;
                    break;
                case Keys.A:
                    aKeyDown = false;
                    break;
                case Keys.D:
                    dKeyDown = false;
                    break;
                case Keys.Up:
                    upArrowDown = false;
                    break;
                case Keys.Down:
                    downArrowDown = false;
                    break;
                case Keys.Left:
                    leftArrowDown = false;
                    break;
                case Keys.Right:
                    rightArrowDown = false;
                    break;
            }    
        }

        private void gameLoopTimer_Tick(object sender, EventArgs e)
        {
            //when timer goes off
            //update object positions
            if(wKeyDown == true)
            {
                player1.Move(player1, "up");
            }
            if(sKeyDown == true)
            {
                player1.Move(player1, "down");
            }
            if(aKeyDown == true)
            {
                player1.Move(player1, "left");
            }
            if(dKeyDown == true)
            {
                player1.Move(player1, "right");
            }
            
            if(upArrowDown == true)
            {
                player2.Move(player2, "up");
            }
            if(downArrowDown == true)
            {
                player2.Move(player2, "down");
            }
            if(leftArrowDown == true)
            {
                player2.Move(player2, "left");
            }
            if(rightArrowDown == true)
            {
                player2.Move(player2, "right");
            }

            if(leftAsterList.Count < 10)
            {
                Asteroid newAster = new Asteroid(0, asterPosGen.Next(0, 490));
                leftAsterList.Add(newAster);
            }
            if (rightAsterList.Count < 10)
            {
                Asteroid newAster = new Asteroid(688, asterPosGen.Next(0, 490));
                rightAsterList.Add(newAster);
            }
            
            foreach (Asteroid a in leftAsterList)
            {
                a.Move(a, false);
            }
            foreach (Asteroid a in rightAsterList)
            {
                a.Move(a, true);
            }

            foreach (Asteroid a in leftAsterList)
            {
                if (a.x > 688)
                {
                    leftAsterList.Remove(a);
                    break;
                }
            }
            foreach (Asteroid a in rightAsterList)
            {
                if (a.x < 0)
                {
                    rightAsterList.Remove(a);
                    break;
                }
            }

            //if player collides with asteroid
            //send player to start
            Rectangle player1Rec = new Rectangle(player1.x, player1.y, player1.width,
                player1.height);
            Rectangle player2Rec = new Rectangle(player2.x, player2.y, player2.width,
                player2.height);

            if (leftAsterList.Count > 0)
            {
                for (int i = 0; i < leftAsterList.Count; i++)
                {
                    Rectangle asterRec = new Rectangle(leftAsterList[i].x,
                        leftAsterList[i].y, leftAsterList[i].size, leftAsterList[i].size);

                    if (asterRec.IntersectsWith(player1Rec))
                    {
                        player1.x = 138;
                        player1.y = 400;
                        collideSound.Play();
                    }

                    if (asterRec.IntersectsWith(player2Rec))
                    {
                        player2.x = 414;
                        player2.y = 400;
                        collideSound.Play();
                    }
                }
            }

            if (rightAsterList.Count > 0)
            {
                for (int i = 0; i < rightAsterList.Count; i++)
                {
                    Rectangle asterRec = new Rectangle(rightAsterList[i].x,
                        rightAsterList[i].y, rightAsterList[i].size, rightAsterList[i].size);

                    if (asterRec.IntersectsWith(player1Rec))
                    {
                        player1.x = 138;
                        player1.y = 400; 
                        collideSound.Play();
                    }

                    if (asterRec.IntersectsWith(player2Rec))
                    {
                        player2.x = 414;
                        player2.y = 400;
                        collideSound.Play();
                    }
                }
            }

            //when player reaches end
            //they win
            if (player1.y < 0)
            {
                Victory(true);
            }
            if (player2.y < 0)
            {
                Victory(false);
            }

            Refresh();
        }

        public void Victory(Boolean player1Win)
        {
            gameLoopTimer.Enabled = false;
            victoryLabel.Visible = true;

            if (player1Win == true)
            {
                victoryLabel.Text = "Player 1 Wins";
            }
            else
            {
                victoryLabel.Text = "Player 2 Wins";
            }

            winSound.Play();

            endButton.Visible = true;
            endButton.Enabled = true;
        }
        
        private void GameScreen_Paint(object sender, PaintEventArgs e)
        {
            foreach (Player p in playerList)
            {
                e.Graphics.FillRectangle(solidBrush, p.x, p.y, p.width, p.height);
            }

            foreach (Asteroid a in leftAsterList)
            {
                e.Graphics.FillRectangle(solidBrush, a.x, a.y, a.size, a.size);
            }
            foreach (Asteroid a in rightAsterList)
            {
                e.Graphics.FillRectangle(solidBrush, a.x, a.y, a.size, a.size);
            }
        }
        
        private void endButton_Click(object sender, EventArgs e)
        {
            Form f = this.FindForm();
            f.Controls.Remove(this);

            MainScreen ms = new MainScreen();
            f.Controls.Add(ms);
        }
    }
}
