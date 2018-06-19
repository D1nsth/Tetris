using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Tetris
{

    public class Cube : Figure
    {
        public Cube(GameField gameField) : base()
        {
            xLocate = gameField.XSize / 2;
            yLocate = 0;
            gameField.field[0, xLocate] = 1;
            gameField.field[0, xLocate + 1] = 1;
            gameField.field[1, xLocate] = 1;
            gameField.field[1, xLocate + 1] = 1;
        }
        public override void FallDown(GameField gameField)
        {
            if ((yLocate + 2 != gameField.YSize) &&
                (gameField.field[yLocate + 2, xLocate] != 2) &&
                (gameField.field[yLocate + 2, xLocate + 1] != 2))
            {
                Move(gameField, 1);
                yLocate += 1;
            }
            else
            {
                fall = false;
                Move(gameField, 2);
            }
        }
        private void Move(GameField gameField, byte x)
        {
            if (x == 1)
            {
                gameField.field[yLocate, xLocate] = 0;
                gameField.field[yLocate, xLocate + 1] = 0;
                gameField.field[yLocate + 1, xLocate] = x;
                gameField.field[yLocate + 1, xLocate + 1] = x;
                gameField.field[yLocate + 2, xLocate] = x;
                gameField.field[yLocate + 2, xLocate + 1] = x;
            }
            else
            {
                gameField.field[yLocate, xLocate] = x;
                gameField.field[yLocate, xLocate + 1] = x;
                gameField.field[yLocate + 1, xLocate] = x;
                gameField.field[yLocate + 1, xLocate + 1] = x;
            }
        }
        public override void JerkDown(GameField gameField)
        {
            fall = false;
            gameField.field[yLocate, xLocate] = 0;
            gameField.field[yLocate, xLocate + 1] = 0;
            gameField.field[yLocate + 1, xLocate] = 0;
            gameField.field[yLocate + 1, xLocate + 1] = 0;

            SearchY(gameField);

            gameField.field[yLocate - 2, xLocate] = 2;
            gameField.field[yLocate - 2, xLocate + 1] = 2;
            gameField.field[yLocate - 1, xLocate] = 2;
            gameField.field[yLocate - 1, xLocate + 1] = 2;
        }
        private void SearchY(GameField gameField)
        {
            bool found = false;
            int i = yLocate;
            while ((i < gameField.YSize) && (!found))
            {
                if ((gameField.field[i, xLocate] == 2) ||
                    (gameField.field[i, xLocate + 1] == 2))
                {
                    yLocate = i;
                    found = true;
                }
                i++;
            }
            if (!found)
                yLocate = gameField.YSize;
        }
        public override void ShiftLeft(GameField gameField)
        {
            if ((xLocate != 0) &&
                    (gameField.field[yLocate, xLocate - 1] != 2) &&
                    (gameField.field[yLocate + 1, xLocate - 1] != 2))
            {
                gameField.field[yLocate, xLocate + 1] = 0;
                gameField.field[yLocate + 1, xLocate + 1] = 0;
                gameField.field[yLocate, xLocate - 1] = 1;
                gameField.field[yLocate + 1, xLocate - 1] = 1;
                xLocate -= 1;
            }
        }
        public override void ShiftRight(GameField gameField)
        {
            if ((xLocate + 1 != gameField.XSize - 1) &&
                    (gameField.field[yLocate, xLocate + 2] != 2) &&
                    (gameField.field[yLocate + 1, xLocate + 2] != 2))
            {
                gameField.field[yLocate, xLocate] = 0;
                gameField.field[yLocate, xLocate + 2] = 1;
                gameField.field[yLocate + 1, xLocate] = 0;
                gameField.field[yLocate + 1, xLocate + 2] = 1;
                xLocate += 1;
            }
        }
        public override void Turn(GameField gameField) { }

        public override bool HasDrawingPlace()
        {
            return true;
        }
    }

}