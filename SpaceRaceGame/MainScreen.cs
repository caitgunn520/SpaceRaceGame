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
    public partial class MainScreen : UserControl
    {
        public MainScreen()
        {
            InitializeComponent();
        }

        private void startButton_Click(object sender, EventArgs e)
        {
            //remove mainscreen
            Form f = this.FindForm();
            f.Controls.Remove(this);

            //go to gamescreen
            GameScreen gs = new GameScreen();
            f.Controls.Add(gs);
        }

        private void quitButton_Click(object sender, EventArgs e)
        {
            //quit program

        }
    }
}
