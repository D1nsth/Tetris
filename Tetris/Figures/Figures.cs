using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using Tetris.Figures;

namespace Tetris
{
    public abstract class Figure: IPlaceable
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
        public Figure()
        {
            random = new Random();
            fallenBrush = new SolidBrush(Color.LightGreen);//.BurlyWood);
            mainBrush = new SolidBrush(Color.FromArgb(random.Next(256), random.Next(256), random.Next(256)));
            status = 1;
            fall = true;
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
        public abstract void FallDown(GameField gameField);
        public abstract void JerkDown(GameField gameField);
        public abstract void ShiftLeft(GameField gameField);
        public abstract void ShiftRight(GameField gameField);
        public abstract void Turn(GameField gameField);
        public abstract bool HasDrawingPlace();
    }
}
