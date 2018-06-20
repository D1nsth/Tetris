using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using Tetris.Figures;

namespace Tetris
{
    public abstract class Figure : IPlaceable, IBehavior
    {
        protected const short x = 20;
        protected const short y = 20;
        protected int xLocate;
        protected int yLocate;
        protected int status;
        protected bool fall;
        protected Random random;
        public SolidBrush mainBrush;
        public SolidBrush fallenBrush;

        protected GameField gameField;

        public Figure(GameField gameField)
        {
            random = new Random();
            fallenBrush = new SolidBrush(Color.LightGreen);//.BurlyWood);
            mainBrush = new SolidBrush(Color.FromArgb(random.Next(256), random.Next(256), random.Next(256)));
            status = 1;
            fall = true;
            this.gameField = gameField;
        }

        public static Figure GetFigure(GameField gameField, TypeFigures figureName)
        {
            Figure tempFigure = null; //= new Cube(gameField);
            switch (figureName)
            {
                case TypeFigures.CUBE:
                    tempFigure = new Cube(gameField);
                    break;
                case TypeFigures.LINE:
                    tempFigure = new Line(gameField);
                    break;
                case TypeFigures.LTYPE:
                    tempFigure = new Ltype(gameField);
                    break;
                case TypeFigures.JTYPE:
                    tempFigure = new Jtype(gameField);
                    break;
                case TypeFigures.TTYPE:
                    tempFigure = new Ttype(gameField);
                    break;
            }
            return tempFigure;
        }
        
        public bool Fall
        {
            get { return fall; }
        }
        public int XLocate
        {
            get { return xLocate; }
        }
        public int YLocate
        {
            get { return yLocate; }
        }
        public int Status
        {
            get { return status; }
        }
        public abstract void FallDown();
        public abstract void JerkDown();
        public abstract void ShiftLeft();
        public abstract void ShiftRight();
        public abstract void Turn();
        public abstract bool HasDrawingPlace();
    }
}
