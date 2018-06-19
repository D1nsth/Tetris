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
    public partial class MainForm : Form
    {
        string mode;

        public MainForm()
        {
            InitializeComponent();
        }

        private void StartSingleForm()
        {
            Application.Run(new SimpleGameForm());
        }
        private void StartAiForm()
        {
            Application.Run(new AIGameForm());
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (mode == "single")
            {
                System.Threading.Thread gameThread = new System.Threading.Thread(StartSingleForm);
                gameThread.Start();
            }
            else if (mode == "ai")
            {
                System.Threading.Thread gameThread = new System.Threading.Thread(StartAiForm);
                gameThread.Start();
            }
        }

        private void SingleButton_Click(object sender, EventArgs e)
        {
            mode = "single";
            this.Close();
        }

        private void AiButton_Click(object sender, EventArgs e)
        {
            mode = "ai";
            this.Close();
        }
    }
}
