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
        GamePlay play;

        public SimpleGameForm()
        {
            InitializeComponent();
            graphic = CreateGraphics();
        }



        private void GameTimer_Tick(object sender, EventArgs e) //add
        {
            play.FallDown(graphic);
            
            Score.Text = play.Score.ToString();
            //if (play.Score == 1)
            //    GameTimer.Interval = 100;
        }

        private void GameForm_KeyUp(object sender, KeyEventArgs e)
        {
            //GameTimer.Stop();
            play.KeyPress(graphic, e);
            //GameTimer.Start();
        }

        private void Start_Click(object sender, EventArgs e)
        {
            Start.Enabled = false;
            Stop.Enabled = true;

            play = new GamePlay();
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
