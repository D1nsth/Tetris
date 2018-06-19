using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tetris
{
    public partial class AIGameForm : Form
    {
        Graphics graphic;
        AI ai;

        public AIGameForm()
        {
            InitializeComponent();
            graphic = CreateGraphics();
        }

        private void GameTimer_Tick(object sender, EventArgs e)
        {
            int x, y;
            ai.cubeSearchPlace(out x, out y);
            ai.gameField.DrawField(graphic, ai.cube.mainBrush, ai.cube.fallenBrush, "cube");
            
        }

        private void Start_Click(object sender, EventArgs e)
        {
            Start.Enabled = false;
            ai = new AI();
            //ai.DrawField(graphic, ai.cube.mainBrush, ai.cube.fallenBrush);
            //ai.cubeSearchWay();
            
            ai.gameField.DrawField(graphic, ai.cube.mainBrush, ai.cube.fallenBrush, "cube");
            GameTimer.Start();
        }
    }
}
