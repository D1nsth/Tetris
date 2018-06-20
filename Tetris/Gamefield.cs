using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Tetris
{
    public class GameField
    {
        const short x = 40;
        const short y = 40;
        const short xSize = 11;
        const short ySize = 16;
        Pen mainPen;//, figuresPen;
        SolidBrush nextFigureBrush;
        public int[,] field;

        public GameField()
        {
            field = new int[ySize, xSize];
            for (int i = 0; i < ySize; i++)
                for (int j = 0; j < xSize; j++)
                    field[i, j] = 0;
            //{
            //{0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
            //{0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
            //{0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
            //{0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
            //{0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
            //{0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
            //{0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
            //{0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
            //{0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
            //{0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
            //{0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
            //{0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
            //{0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
            //{0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
            //{0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
            //{0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
            //{0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
            //{0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
            //{0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
            //{0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
            //{0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
            //};
            mainPen = new Pen(Color.Black);
            nextFigureBrush = new SolidBrush(Color.Azure);//.BlanchedAlmond);
        }
        public short XSize
        {
            get { return xSize; }
        }
        public short YSize
        {
            get { return ySize; }
        }
        public void Load(Graphics graphic)
        {
            graphic.Clear(Color.RoyalBlue);//.White);
            graphic.DrawRectangle(mainPen, 0, 0, xSize * x, ySize * y);
        }
        public void DrawField(Graphics graphic, SolidBrush FiguresBrush, SolidBrush FallenFiguresBrush, TypeFigures nextFigure) //add
        {
            graphic.Clear(Color.LightSteelBlue);//.White);

            DrawNextFigure(graphic, nextFigure);

            graphic.DrawRectangle(mainPen, 0, 0, x * xSize, y * ySize);
            for (short i = 0; i < ySize; i++)
                for (short j = 0; j < xSize; j++)
                {
                    if (field[i, j] == 1)
                    {
                        graphic.FillRectangle(FiguresBrush, x * j, y * i, x, y);
                        graphic.DrawRectangle(mainPen, x * j, y * i, x, y);
                    }
                    if (field[i, j] == 2)
                    {
                        graphic.FillRectangle(FallenFiguresBrush, x * j, y * i, x, y);
                        graphic.DrawRectangle(mainPen, x * j, y * i, x, y);
                    }
                }
        }
        private void DrawNextFigure(Graphics graphic, TypeFigures nextFigure)
        {
            graphic.DrawRectangle(mainPen, 468, 86, 99, 99);
            switch (nextFigure)
            {
                case TypeFigures.CUBE:
                    graphic.FillRectangle(nextFigureBrush, 468, 119, 66, 66);
                    graphic.DrawRectangle(mainPen, 501, 152, 33, 33);
                    graphic.DrawRectangle(mainPen, 468, 152, 33, 33);
                    graphic.DrawRectangle(mainPen, 501, 119, 33, 33);
                    graphic.DrawRectangle(mainPen, 468, 119, 33, 33);
                    break;
                case TypeFigures.LINE:
                    graphic.FillRectangle(nextFigureBrush, 468, 136, 99, 25);
                    graphic.DrawRectangle(mainPen, 468, 136, 25, 25);
                    graphic.DrawRectangle(mainPen, 493, 136, 25, 25);
                    graphic.DrawRectangle(mainPen, 518, 136, 25, 25);
                    graphic.DrawRectangle(mainPen, 543, 136, 24, 25);
                    break;
                case TypeFigures.LTYPE:
                    graphic.FillRectangle(nextFigureBrush, 468, 152, 99, 33);
                    graphic.FillRectangle(nextFigureBrush, 534, 119, 33, 33);
                    graphic.DrawRectangle(mainPen, 468, 152, 33, 33);
                    graphic.DrawRectangle(mainPen, 501, 152, 33, 33);
                    graphic.DrawRectangle(mainPen, 534, 152, 33, 33);
                    graphic.DrawRectangle(mainPen, 534, 119, 33, 33);
                    break;
                case TypeFigures.JTYPE:
                    graphic.FillRectangle(nextFigureBrush, 468, 119, 33, 33);
                    graphic.FillRectangle(nextFigureBrush, 468, 152, 99, 33);
                    graphic.DrawRectangle(mainPen, 468, 119, 33, 33);
                    graphic.DrawRectangle(mainPen, 468, 152, 33, 33);
                    graphic.DrawRectangle(mainPen, 501, 152, 33, 33);
                    graphic.DrawRectangle(mainPen, 534, 152, 33, 33);
                    break;
                case TypeFigures.TTYPE:
                    graphic.FillRectangle(nextFigureBrush, 501, 119, 33, 33);
                    graphic.FillRectangle(nextFigureBrush, 468, 152, 99, 33);
                    graphic.DrawRectangle(mainPen, 501, 119, 33, 33);
                    graphic.DrawRectangle(mainPen, 468, 152, 33, 33);
                    graphic.DrawRectangle(mainPen, 501, 152, 33, 33);
                    graphic.DrawRectangle(mainPen, 534, 152, 33, 33);
                    break;
            }
        }
        public bool CheckFillingTheLine(int Y)
        {
            bool result = true;
            for (int i = 0; i < xSize; i++)
            {
                if (field[Y, i] != 2)
                    result = false;
            }
            return result;
        }
        public void ShiftDownField(int yStart)
        {
            for (int y = yStart; y > 0; y--)
            {
                for (int x = 0; x < xSize; x++)
                {
                    field[y, x] = field[y - 1, x];
                }
            }
        }
    }
}
