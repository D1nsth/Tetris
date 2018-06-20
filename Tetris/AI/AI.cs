using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tetris.Figures;

namespace Tetris
{
    class AI
    {
        const short x = 40;//
        const short y = 40;//
        const short xSize = 11;//
        const short ySize = 16;//
        
        int[,] field;
        GameField _gameField;
        Cube _cube;

        public GameField GameField
        {
            get { return _gameField; }
        }
        public Cube cube
        {
            get { return _cube; }
        }
        public AI()
        {
            _gameField = new GameField();
            _cube = new Cube(_gameField);
            field = new int[ySize, xSize] {
               { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
               { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
               { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
               { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
               { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
               { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
               { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
               { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
               { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
               { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
               { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
               { -2, -2, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
               { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
               { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
               { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
               { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 }
            };
            
        }
        public void DrawField(Graphics graphic, SolidBrush FiguresBrush, SolidBrush FallenFiguresBrush)
        {
            graphic.Clear(Color.LightSteelBlue);

            graphic.DrawRectangle(new Pen(Color.Black), 0, 0, x * xSize, y * ySize);
            for (short i = 0; i < ySize; i++)
                for (short j = 0; j < xSize; j++)
                {
                    if (field[i, j] == -1)
                    {
                        graphic.FillRectangle(FiguresBrush, x * j, y * i, x, y);
                        graphic.DrawRectangle(new Pen(Color.Black), x * j, y * i, x, y);
                    }
                    else if (field[i, j] == -2)
                    {
                        graphic.FillRectangle(FallenFiguresBrush, x * j, y * i, x, y);
                        graphic.DrawRectangle(new Pen(Color.Black), x * j, y * i, x, y);
                    }
                    else
                    {
                        graphic.FillRectangle(new SolidBrush(Color.AntiqueWhite), x * j, y * i, x, y);
                        graphic.DrawRectangle(new Pen(Color.Black), x * j, y * i, x, y);
                    }
                }
        }
        public void CubeSearchPlace(out int xLocate, out int yLocate)
        {
            bool check = false;
            int y = _gameField.YSize - 2;
            int x = 0;
            while ((y > 0) && (!check))
            {
                x = 0;
                while ((x < _gameField.XSize - 2) && (!check))
                {
                    if ((_gameField.field[y, x] == 0) &&
                        (_gameField.field[y, x + 1] == 0) &&
                        (_gameField.field[y + 1, x] == 0) &&
                        (_gameField.field[y + 1, x + 1] == 0))
                    {
                        xLocate = x;
                        yLocate = y;
                        _gameField.field[y, x] = 2; //
                        _gameField.field[y, x + 1] = 2;//
                        _gameField.field[y + 1, x] = 2;//
                        _gameField.field[y + 1, x + 1] = 2;//
                        check = true;
                    }
                    x += 1;
                }
                y -= 1;
            }
            xLocate = -1;
            yLocate = -1;
            bool res = true;//
            //cubeSearchWay(xLocate, yLocate, ref res);//
        }

        public void CubeSearchWay()//int xLocate, int yLocate)
        {
            for (int y = 0; y < ySize; y++)
                for (int x = 0; x < xSize; x++)
                {
                    if (field[y, x] == 0) field[y, x] = -1;
                    if (field[y, x] == 2) field[y, x] = -2;
                }
            bool add = true;
            int step = 0;
            field[0, xSize / 2] = 0;
            while (add == true)
            {
                add = false;
                for (int y = 0; y < ySize; y++)
                    for (int x = 0; x < xSize; x++)
                    {
                        if (field[y, x] == step)
                        {
                            
                            if (y - 1 >= 0 && field[y - 1, x] != -2 && field[y - 1, x] == -1)
                                field[y - 1, x] = step + 1;
                            if (x - 1 >= 0 && field[y, x - 1] != -2 && field[y, x - 1] == -1)
                                field[y, x - 1] = step + 1;
                            if (y + 1 < ySize && field[y + 1, x] != -2 && field[y + 1, x] == -1)
                                field[y + 1, x] = step + 1;
                            if (x + 1 < xSize && field[y, x + 1] != -2 && field[y, x + 1] == -1)
                                field[y, x + 1] = step + 1;
                        }
                    }
                step++;
                add = true;
                if (field[ySize - 1, 1] != -1)//решение найдено
                    add = false;
                if (step > ySize * xSize)//решение не найдено
                    add = false;
            }
        }
    }
}
