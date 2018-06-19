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
    public partial class SimpleGameForm : Form
    {
        Graphics graphic;
        Gameplay play;

        public SimpleGameForm()
        {
            InitializeComponent();
            graphic = CreateGraphics();
        }



        private void GameTimer_Tick(object sender, EventArgs e) //add
        {
            switch (play.NowFigure)
            {
                case "cube":
                    if (play.cube.Fall)
                    {
                        play.cube.FallDown(play.gameField);
                        play.gameField.DrawField(graphic, play.cube.mainBrush, play.cube.fallenBrush, play.NextFigure);
                    }
                    else { play.NextFigures(graphic); }
                    break;
                case "line":
                    if (play.line.Fall)
                    {
                        play.line.FallDown(play.gameField);
                        play.gameField.DrawField(graphic, play.line.mainBrush, play.line.fallenBrush, play.NextFigure);
                    }
                    else { play.NextFigures(graphic); }
                    break;
                case "ltype":
                    if (play.ltype.Fall)
                    {
                        play.ltype.FallDown(play.gameField);
                        play.gameField.DrawField(graphic, play.ltype.mainBrush, play.ltype.fallenBrush, play.NextFigure);
                    }
                    else { play.NextFigures(graphic); }
                    break;
                case "jtype":
                    if (play.jtype.Fall)
                    {
                        play.jtype.FallDown(play.gameField);
                        play.gameField.DrawField(graphic, play.jtype.mainBrush, play.jtype.fallenBrush, play.NextFigure);
                    }
                    else { play.NextFigures(graphic); }
                    break;
                case "ttype":
                    if (play.ttype.Fall)
                    {
                        play.ttype.FallDown(play.gameField);
                        play.gameField.DrawField(graphic, play.ttype.mainBrush, play.ttype.fallenBrush, play.NextFigure);
                    }
                    else { play.NextFigures(graphic); }
                    break;
                    //case "stype":
                    //    if (play.stype.Fall)
                    //    {
                    //        play.stype.FallDown(play.gameField);
                    //        play.gameField.DrawField(graphic, play.stype.mainBrush, play.stype.fallenBrush, play.NextFigure);
                    //    }
                    //    else { play.NextFigures(graphic); }
                    //    break;
                    //case "ztype":
                    //    if (play.ztype.Fall)
                    //    {
                    //        play.ztype.FallDown(play.gameField);
                    //        play.gameField.DrawField(graphic, play.ztype.mainBrush, play.ztype.fallenBrush, play.NextFigure);
                    //    }
                    //    else { play.NextFigures(graphic); }
                    //    break;
            }
            Score.Text = play.Score.ToString();
            //if (play.Score == 1)
            //    GameTimer.Interval = 100;
        }

        private void GameForm_KeyUp(object sender, KeyEventArgs e)
        {
            GameTimer.Stop();
            play.KeyPress(graphic, e);
            GameTimer.Start();
        }

        private void Start_Click(object sender, EventArgs e)
        {
            Start.Enabled = false;
            Stop.Enabled = true;

            play = new Gameplay();
            play.Start(graphic);
            GameTimer.Start();
            Time.Start();
        }

        private void Stop_Click(object sender, EventArgs e)
        {
            Start.Enabled = true;
            Stop.Enabled = false;
            play.Stop(graphic);
            GameTimer.Stop();
            Time.Stop();
        }

        private void Time_Tick(object sender, EventArgs e)
        {
            play.Time += 1;

            int hour = 0, minutes = 0, seconds = 0;

            seconds = play.Time % 3600 % 60;
            if (seconds == 60)
            {
                minutes += 1;
                seconds = 0;
            }
            minutes += play.Time % 3600 / 60;
            if (minutes == 60)
            {
                hour += 1;
                minutes = 0;
            }
            hour += play.Time / 3600;

            #region output time
            if (hour < 10)
            {
                if (minutes < 10)
                {
                    if (seconds < 10)
                        GameTime.Text = "0" + hour + ":0" + minutes + ":0" + seconds;
                    else
                        GameTime.Text = "0" + hour + ":0" + minutes + ":" + seconds;
                }
                else
                {
                    if (seconds < 10)
                        GameTime.Text = "0" + hour + ":" + minutes + ":0" + seconds;
                    else
                        GameTime.Text = "0" + hour + ":" + minutes + ":" + seconds;
                }
            }
            else
            {
                if (minutes < 10)
                {
                    if (seconds < 10)
                        GameTime.Text = hour + ":0" + minutes + ":0" + seconds;
                    else
                        GameTime.Text = hour + ":0" + minutes + ":" + seconds;
                }
                else
                {
                    if (seconds < 10)
                        GameTime.Text = hour + ":" + minutes + ":0" + seconds;
                    else
                        GameTime.Text = hour + ":" + minutes + ":" + seconds;
                }
            }
            #endregion
        }
    }
}
