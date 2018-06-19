namespace Tetris
{
    partial class SimpleGameForm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.GameTimer = new System.Windows.Forms.Timer(this.components);
            this.Score = new System.Windows.Forms.Label();
            this.Start = new System.Windows.Forms.Button();
            this.Stop = new System.Windows.Forms.Button();
            this.GameTime = new System.Windows.Forms.Label();
            this.Time = new System.Windows.Forms.Timer(this.components);
            this.NextFigureLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // GameTimer
            // 
            this.GameTimer.Interval = 500;
            this.GameTimer.Tick += new System.EventHandler(this.GameTimer_Tick);
            // 
            // Score
            // 
            this.Score.AutoSize = true;
            this.Score.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Score.Location = new System.Drawing.Point(461, 9);
            this.Score.Name = "Score";
            this.Score.Size = new System.Drawing.Size(30, 31);
            this.Score.TabIndex = 0;
            this.Score.Text = "0";
            // 
            // Start
            // 
            this.Start.Location = new System.Drawing.Point(467, 616);
            this.Start.Name = "Start";
            this.Start.Size = new System.Drawing.Size(105, 23);
            this.Start.TabIndex = 1;
            this.Start.TabStop = false;
            this.Start.Text = "Start";
            this.Start.UseVisualStyleBackColor = true;
            this.Start.Click += new System.EventHandler(this.Start_Click);
            // 
            // Stop
            // 
            this.Stop.Enabled = false;
            this.Stop.Location = new System.Drawing.Point(467, 587);
            this.Stop.Name = "Stop";
            this.Stop.Size = new System.Drawing.Size(105, 23);
            this.Stop.TabIndex = 3;
            this.Stop.TabStop = false;
            this.Stop.Text = "Stop";
            this.Stop.UseVisualStyleBackColor = true;
            this.Stop.Click += new System.EventHandler(this.Stop_Click);
            // 
            // GameTime
            // 
            this.GameTime.AutoSize = true;
            this.GameTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.GameTime.Location = new System.Drawing.Point(461, 40);
            this.GameTime.Name = "GameTime";
            this.GameTime.Size = new System.Drawing.Size(128, 31);
            this.GameTime.TabIndex = 4;
            this.GameTime.Text = "00:00:00";
            // 
            // Time
            // 
            this.Time.Interval = 1000;
            this.Time.Tick += new System.EventHandler(this.Time_Tick);
            // 
            // NextFigureLabel
            // 
            this.NextFigureLabel.AutoSize = true;
            this.NextFigureLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.NextFigureLabel.Location = new System.Drawing.Point(480, 187);
            this.NextFigureLabel.Name = "NextFigureLabel";
            this.NextFigureLabel.Size = new System.Drawing.Size(77, 15);
            this.NextFigureLabel.TabIndex = 5;
            this.NextFigureLabel.Text = "Next figure";
            // 
            // SimpleGameForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightSteelBlue;
            this.ClientSize = new System.Drawing.Size(584, 651);
            this.Controls.Add(this.NextFigureLabel);
            this.Controls.Add(this.GameTime);
            this.Controls.Add(this.Stop);
            this.Controls.Add(this.Start);
            this.Controls.Add(this.Score);
            this.MaximumSize = new System.Drawing.Size(600, 689);
            this.MinimumSize = new System.Drawing.Size(600, 689);
            this.Name = "SimpleGameForm";
            this.Text = "Tetris";
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.GameForm_KeyUp);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.Timer GameTimer;
        private System.Windows.Forms.Label Score;
        private System.Windows.Forms.Button Start;
        private System.Windows.Forms.Button Stop;
        private System.Windows.Forms.Label GameTime;
        private System.Windows.Forms.Timer Time;
        private System.Windows.Forms.Label NextFigureLabel;
    }
}

