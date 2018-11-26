using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace Tetris
{
    public enum TypeFigures
    {
        CUBE,
        LINE,
        LTYPE,
        JTYPE,
        TTYPE
    }

    public class GamePlay
    {
        int figureCount;
        int time;
        int score;
        TypeFigures nowFigure;
        TypeFigures nextFigure;
        GameField _gameField;

        Figure figure;
        Random random;
        public int Score
        {
            get { return score; }
        }
        public int Time
        {
            set { time = value; }
            get { return time; }
        }
        public GameField gameField
        {
            get { return _gameField; }
        }

        public GamePlay()
        {
            score = 0;
            time = 0;
            figureCount = 5;
            random = new Random();
            _gameField = new GameField();
        }

        public void NextFigures(Graphics graphic)
        {
            for (int y = 1; y < _gameField.YSize; y++)
            {
                if (_gameField.CheckFillingTheLine(y))
                {
                    _gameField.ShiftDownField(y);
                    score += gameField.XSize;
                }
                else GameOver();
            }

            nowFigure = nextFigure;
            nextFigure = (TypeFigures)random.Next(0, figureCount);

            figure = CreateFigure();
            _gameField.DrawField(graphic, figure.mainBrush, figure.fallenBrush, nextFigure);
        }
        public void Start(Graphics graphic)
        {
            score = 0;
            nowFigure = (TypeFigures)random.Next(0, figureCount);
            nextFigure = (TypeFigures)random.Next(0, figureCount);
            
            figure = Figure.GetFigure(_gameField, nowFigure);
            _gameField.DrawField(graphic, figure.mainBrush, figure.fallenBrush, nextFigure);
        }
        public void Stop(Graphics graphic)
        {
            figure.JerkDown();
            _gameField.DrawField(graphic, figure.mainBrush, figure.fallenBrush, nextFigure);
        }
        public void GameOver()
        {


        }
        public void KeyPress(Graphics graphic, KeyEventArgs e)
        {
            if (figure.Fall)
            {
                switch (e.KeyValue)
                {
                    case 37:
                        figure.ShiftLeft();
                        _gameField.DrawField(graphic, figure.mainBrush, figure.fallenBrush, nextFigure);
                        break;
                    case 38:
                        figure.Turn();
                        _gameField.DrawField(graphic, figure.mainBrush, figure.fallenBrush, nextFigure);
                        break;
                    case 39:
                        figure.ShiftRight();
                        _gameField.DrawField(graphic, figure.mainBrush, figure.fallenBrush, nextFigure);
                        break;
                    case 40:
                        figure.JerkDown();
                        _gameField.DrawField(graphic, figure.mainBrush, figure.fallenBrush, nextFigure);
                        break;
                }
            }          
        }

        public void FallDown(Graphics graphic)
        {
            if (figure.Fall)
            {
                figure.FallDown();
                _gameField.DrawField(graphic, figure.mainBrush, figure.fallenBrush, nextFigure);
            }
            else { NextFigures(graphic); }
        }

        public Figure CreateFigure()
        {
            return Figure.GetFigure(_gameField, nowFigure);
        }
    }
}
