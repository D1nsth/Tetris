using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;
using Tetris.Figures;

namespace Tetris
{
    public class Gameplay
    {
        int figureCount;
        int time;
        int score;
        string nowFigure;
        string nextFigure;
        GameField _gameField;
        Cube _cube;
        Line _line;
        Ltype _ltype;
        Jtype _jtype;
        Ttype _ttype;
        //Stype _stype;
        //Ztype _ztype;

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
        public string NowFigure
        {
            get { return nowFigure; }
        }
        public string NextFigure
        {
            get { return nextFigure; }
        }
        public Cube cube
        {
            get { return _cube; }
        }
        public Line line
        {
            get { return _line; }
        }
        public Ltype ltype
        {
            get { return _ltype; }
        }
        public Jtype jtype
        {
            get { return _jtype; }
        }
        public Ttype ttype
        {
            get { return _ttype; }
        }
        //public Stype stype
        //{
        //    get { return _stype; }
        //}
        //public Ztype ztype
        //{
        //    get { return _ztype; }
        //}
        public GameField gameField
        {
            get { return _gameField; }
        }
        public Gameplay()
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
            }

            nowFigure = nextFigure;

            #region switch(nowFigure)
            switch (nowFigure)
            {
                case "cube":
                    if ((gameField.field[0, gameField.XSize / 2] == 0) &&
                    (gameField.field[0, (gameField.XSize / 2) + 1] == 0) &&
                    (gameField.field[1, gameField.XSize / 2] == 0) &&
                    (gameField.field[1, (gameField.XSize / 2) + 1] == 0))
                    {
                        _cube = new Cube(_gameField);
                        _gameField.DrawField(graphic, _cube.mainBrush, _cube.fallenBrush, nextFigure);
                    }
                    else GameOver();
                    break;
                case "line":
                    if ((gameField.field[0, (gameField.XSize / 2) - 1] == 0) &&
                    (gameField.field[0, gameField.XSize / 2] == 0) &&
                    (gameField.field[0, (gameField.XSize / 2) + 1] == 0) &&
                    (gameField.field[0, (gameField.XSize / 2) + 2] == 0))
                    {
                        _line = new Line(_gameField);
                        _gameField.DrawField(graphic, _line.mainBrush, _line.fallenBrush, nextFigure);
                    }
                    else GameOver();
                    break;
                case "ltype":
                    if ((gameField.field[0, gameField.XSize / 2] == 0) &&
                    (gameField.field[1, gameField.XSize / 2] == 0) &&
                    (gameField.field[1, (gameField.XSize / 2) - 1] == 0) &&
                    (gameField.field[1, (gameField.XSize / 2) - 2] == 0))
                    {
                        _ltype = new Ltype(_gameField);
                        _gameField.DrawField(graphic, _ltype.mainBrush, _ltype.fallenBrush, nextFigure);
                    }
                    else GameOver();
                    break;
                case "jtype":
                    if ((gameField.field[0, gameField.XSize / 2] == 0) &&
                    (gameField.field[1, gameField.XSize / 2] == 0) &&
                    (gameField.field[1, (gameField.XSize / 2) + 1] == 0) &&
                    (gameField.field[1, (gameField.XSize / 2) + 2] == 0))
                    {
                        _jtype = new Jtype(_gameField);
                        _gameField.DrawField(graphic, _jtype.mainBrush, _jtype.fallenBrush, nextFigure);
                    }
                    else GameOver();
                    break;
                case "ttype":
                    if ((gameField.field[0, gameField.XSize / 2] == 0) &&
                    (gameField.field[1, gameField.XSize / 2] == 0) &&
                    (gameField.field[1, (gameField.XSize / 2) + 1] == 0) &&
                    (gameField.field[1, (gameField.XSize / 2) - 1] == 0))
                    {
                        _ttype = new Ttype(_gameField);
                        _gameField.DrawField(graphic, _ttype.mainBrush, _ttype.fallenBrush, nextFigure);
                    }
                    else GameOver();
                    break;
                    //case "stype":
                    //    _stype = new Stype(_gameField);
                    //    _gameField.DrawField(graphic, _stype.mainBrush, _stype.fallenBrush, nextFigure);
                    //    break;
                    //case "ztype":
                    //    _ztype = new Ztype(_gameField);
                    //    _gameField.DrawField(graphic, _ztype.mainBrush, _ztype.fallenBrush, nextFigure);
                    //    break;
            }
            #endregion

            int Next = random.Next(1, figureCount + 1);
            switch (Next)
            {
                case 1:
                    nextFigure = "cube";
                    break;
                case 2:
                    nextFigure = "line";
                    break;
                case 3:
                    nextFigure = "ltype";
                    break;
                case 4:
                    nextFigure = "jtype";
                    break;
                case 5:
                    nextFigure = "ttype";
                    break;
                case 6:
                    nextFigure = "stype";
                    break;
                case 7:
                    nextFigure = "ztype";
                    break;
            }
        }
        public void Start(Graphics graphic)
        {
            score = 0;
            int First = random.Next(1, figureCount + 1);
            switch (First)
            {
                case 1:
                    nowFigure = "cube";
                    _cube = new Cube(_gameField);
                    _gameField.DrawField(graphic, _cube.mainBrush, _cube.fallenBrush, nextFigure);
                    break;
                case 2:
                    nowFigure = "line";
                    _line = new Line(_gameField);
                    _gameField.DrawField(graphic, _line.mainBrush, _line.fallenBrush, nextFigure);
                    break;
                case 3:
                    nowFigure = "ltype";
                    _ltype = new Ltype(_gameField);
                    _gameField.DrawField(graphic, _ltype.mainBrush, _ltype.fallenBrush, nextFigure);
                    break;
                case 4:
                    nowFigure = "jtype";
                    _jtype = new Jtype(_gameField);
                    _gameField.DrawField(graphic, _jtype.mainBrush, _jtype.fallenBrush, nextFigure);
                    break;
                case 5:
                    nowFigure = "ttype";
                    _ttype = new Ttype(_gameField);
                    _gameField.DrawField(graphic, _ttype.mainBrush, _ttype.fallenBrush, nextFigure);
                    break;
                    //case 6:
                    //    nowFigure = "stype";
                    //    _stype = new Stype(_gameField);
                    //    _gameField.DrawField(graphic, _stype.mainBrush, _stype.fallenBrush, nextFigure);
                    //    break;
                    //case 7:
                    //    nowFigure = "ztype";
                    //    _ztype = new Ztype(_gameField);
                    //    _gameField.DrawField(graphic, _ztype.mainBrush, _ztype.fallenBrush, nextFigure);
                    //    break;
            }

            First = random.Next(1, figureCount + 1);
            switch (First)
            {
                case 1:
                    nextFigure = "cube";
                    break;
                case 2:
                    nextFigure = "line";
                    break;
                case 3:
                    nextFigure = "ltype";
                    break;
                case 4:
                    nextFigure = "jtype";
                    break;
                case 5:
                    nextFigure = "ttype";
                    break;
                case 6:
                    nextFigure = "stype";
                    break;
                case 7:
                    nextFigure = "ztype";
                    break;

            }
        }
        public void Stop(Graphics graphic)
        {
            switch (nowFigure)
            {
                case "cube":
                    _cube.JerkDown(_gameField);
                    _gameField.DrawField(graphic, _cube.mainBrush, _cube.fallenBrush, nextFigure);
                    break;
                case "line":
                    _line.JerkDown(_gameField);
                    _gameField.DrawField(graphic, _line.mainBrush, _line.fallenBrush, nextFigure);
                    break;
                case "ltype":
                    _ltype.JerkDown(_gameField);
                    _gameField.DrawField(graphic, _ltype.mainBrush, _ltype.fallenBrush, nextFigure);
                    break;
                case "jtype":
                    _jtype.JerkDown(_gameField);
                    _gameField.DrawField(graphic, _jtype.mainBrush, _jtype.fallenBrush, nextFigure);
                    break;
                case "ttype":
                    _ttype.JerkDown(_gameField);
                    _gameField.DrawField(graphic, _ttype.mainBrush, _ttype.fallenBrush, nextFigure);
                    break;
                    //case "stype":
                    //    _stype.JerkDown(_gameField);
                    //    _gameField.DrawField(graphic, _stype.mainBrush, _stype.fallenBrush, nextFigure);
                    //    break;
                    //case "ztype":
                    //    _ztype.JerkDown(_gameField);
                    //    _gameField.DrawField(graphic, _ztype.mainBrush, _ztype.fallenBrush, nextFigure);
                    //    break;
            }
        }
        public void GameOver()
        {


        }
        public void KeyPress(Graphics graphic, KeyEventArgs e)
        {
            switch (nowFigure)
            {
                #region cube
                case "cube":
                    if (_cube.Fall)
                    {
                        switch (e.KeyValue)
                        {
                            case 37:
                                _cube.ShiftLeft(_gameField);
                                _gameField.DrawField(graphic, _cube.mainBrush, _cube.fallenBrush, nextFigure);
                                break;
                            case 39:
                                _cube.ShiftRight(_gameField);
                                _gameField.DrawField(graphic, _cube.mainBrush, _cube.fallenBrush, nextFigure);
                                break;
                            case 40:
                                _cube.JerkDown(_gameField);
                                _gameField.DrawField(graphic, _cube.mainBrush, _cube.fallenBrush, nextFigure);
                                break;
                        }
                    }
                    break;
                #endregion
                #region line
                case "line":
                    if (_line.Fall)
                    {
                        switch (e.KeyValue)
                        {
                            case 37:
                                _line.ShiftLeft(_gameField);
                                _gameField.DrawField(graphic, _line.mainBrush, _line.fallenBrush, nextFigure);
                                break;
                            case 38:
                                _line.Turn(_gameField);
                                _gameField.DrawField(graphic, _line.mainBrush, _line.fallenBrush, nextFigure);
                                break;
                            case 39:
                                _line.ShiftRight(_gameField);
                                _gameField.DrawField(graphic, _line.mainBrush, _line.fallenBrush, nextFigure);
                                break;
                            case 40:
                                _line.JerkDown(_gameField);
                                _gameField.DrawField(graphic, _line.mainBrush, _line.fallenBrush, nextFigure);
                                break;
                        }
                    }
                    break;
                #endregion
                #region ltype
                case "ltype":
                    if (_ltype.Fall)
                    {
                        switch (e.KeyValue)
                        {
                            case 37:
                                _ltype.ShiftLeft(_gameField);
                                _gameField.DrawField(graphic, _ltype.mainBrush, _ltype.fallenBrush, nextFigure);
                                break;
                            case 38:
                                _ltype.Turn(_gameField);
                                _gameField.DrawField(graphic, _ltype.mainBrush, _ltype.fallenBrush, nextFigure);
                                break;
                            case 39:
                                _ltype.ShiftRight(_gameField);
                                _gameField.DrawField(graphic, _ltype.mainBrush, _ltype.fallenBrush, nextFigure);
                                break;
                            case 40:
                                _ltype.JerkDown(_gameField);
                                _gameField.DrawField(graphic, _ltype.mainBrush, _ltype.fallenBrush, nextFigure);
                                break;
                        }
                    }
                    break;
                #endregion
                #region jtype
                case "jtype":
                    if (_jtype.Fall)
                    {
                        switch (e.KeyValue)
                        {
                            case 37:
                                _jtype.ShiftLeft(_gameField);
                                _gameField.DrawField(graphic, _jtype.mainBrush, _jtype.fallenBrush, nextFigure);
                                break;
                            case 38:
                                _jtype.Turn(_gameField);
                                _gameField.DrawField(graphic, _jtype.mainBrush, _jtype.fallenBrush, nextFigure);
                                break;
                            case 39:
                                _jtype.ShiftRight(_gameField);
                                _gameField.DrawField(graphic, _jtype.mainBrush, _jtype.fallenBrush, nextFigure);
                                break;
                            case 40:
                                _jtype.JerkDown(_gameField);
                                _gameField.DrawField(graphic, _jtype.mainBrush, _jtype.fallenBrush, nextFigure);
                                break;
                        }
                    }
                    break;
                #endregion
                #region ttype
                case "ttype":
                    if (_ttype.Fall)
                    {
                        switch (e.KeyValue)
                        {
                            case 37:
                                _ttype.ShiftLeft(_gameField);
                                _gameField.DrawField(graphic, _ttype.mainBrush, _ttype.fallenBrush, nextFigure);
                                break;
                            case 38:
                                _ttype.Turn(_gameField);
                                _gameField.DrawField(graphic, _ttype.mainBrush, _ttype.fallenBrush, nextFigure);
                                break;
                            case 39:
                                _ttype.ShiftRight(_gameField);
                                _gameField.DrawField(graphic, _ttype.mainBrush, _ttype.fallenBrush, nextFigure);
                                break;
                            case 40:
                                _ttype.JerkDown(_gameField);
                                _gameField.DrawField(graphic, _ttype.mainBrush, _ttype.fallenBrush, nextFigure);
                                break;
                        }
                    }
                    break;
                    #endregion
            }
        }
    }
}
