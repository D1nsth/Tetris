using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tetris.Figures
{
    public class Line : Figure
    {
        public Line(GameField gameField) : base(gameField)
        {
            xLocate = gameField.XSize / 2;
            yLocate = 0;
            gameField.field[0, xLocate - 1] = 1;
            gameField.field[0, xLocate] = 1;
            gameField.field[0, xLocate + 1] = 1;
            gameField.field[0, xLocate + 2] = 1;
        }
        public override void FallDown()
        {
            switch (status)
            {
                case 1:
                    if ((yLocate + 1 != gameField.YSize) &&
                        (gameField.field[yLocate + 1, xLocate - 1] != 2) &&
                        (gameField.field[yLocate + 1, xLocate] != 2) &&
                        (gameField.field[yLocate + 1, xLocate + 1] != 2) &&
                        (gameField.field[yLocate + 1, xLocate + 2] != 2))
                    {
                        Move_Status_1(1);
                        yLocate += 1;
                    }
                    else
                    {
                        fall = false;
                        Move_Status_1(2);
                    }
                    break;
                case 2:
                    if ((yLocate + 3 != gameField.YSize) &&
                        (gameField.field[yLocate + 3, xLocate] != 2))
                    {
                        Move_Status_2(1);
                        yLocate += 1;
                    }
                    else
                    {
                        fall = false;
                        Move_Status_2(2);
                    }
                    break;
            }
        }
        private void Move_Status_1(byte x)
        {
            if (x == 1)
            {
                gameField.field[yLocate, xLocate - 1] = 0;
                gameField.field[yLocate, xLocate] = 0;
                gameField.field[yLocate, xLocate + 1] = 0;
                gameField.field[yLocate, xLocate + 2] = 0;

                gameField.field[yLocate + 1, xLocate - 1] = x;
                gameField.field[yLocate + 1, xLocate] = x;
                gameField.field[yLocate + 1, xLocate + 1] = x;
                gameField.field[yLocate + 1, xLocate + 2] = x;
            }
            else
            {
                gameField.field[yLocate, xLocate - 1] = x;
                gameField.field[yLocate, xLocate] = x;
                gameField.field[yLocate, xLocate + 1] = x;
                gameField.field[yLocate, xLocate + 2] = x;
            }
        }
        private void Move_Status_2(byte x)
        {
            if (x == 1)
            {
                gameField.field[yLocate - 1, xLocate] = 0;
                gameField.field[yLocate + 3, xLocate] = 1;
            }
            else
            {
                gameField.field[yLocate - 1, xLocate] = 2;
                gameField.field[yLocate, xLocate] = 2;
                gameField.field[yLocate + 1, xLocate] = 2;
                gameField.field[yLocate + 2, xLocate] = 2;
            }
        }
        public override void JerkDown()
        {
            fall = false;
            switch (status)
            {
                case 1:
                    gameField.field[yLocate, xLocate - 1] = 0;
                    gameField.field[yLocate, xLocate] = 0;
                    gameField.field[yLocate, xLocate + 1] = 0;
                    gameField.field[yLocate, xLocate + 2] = 0;

                    SearchY_Status_1();

                    gameField.field[yLocate - 1, xLocate - 1] = 2;
                    gameField.field[yLocate - 1, xLocate] = 2;
                    gameField.field[yLocate - 1, xLocate + 1] = 2;
                    gameField.field[yLocate - 1, xLocate + 2] = 2;
                    break;
                case 2:
                    gameField.field[yLocate - 1, xLocate] = 0;
                    gameField.field[yLocate, xLocate] = 0;
                    gameField.field[yLocate + 1, xLocate] = 0;
                    gameField.field[yLocate + 2, xLocate] = 0;

                    SearchY_Status_2();

                    gameField.field[yLocate - 1, xLocate] = 2;
                    gameField.field[yLocate - 2, xLocate] = 2;
                    gameField.field[yLocate - 3, xLocate] = 2;
                    gameField.field[yLocate - 4, xLocate] = 2;
                    break;
            }
        }
        private void SearchY_Status_1()
        {
            bool found = false;
            int i = yLocate;
            while ((i < gameField.YSize) && (!found))
            {
                if ((gameField.field[i, xLocate - 1] == 2) ||
                    (gameField.field[i, xLocate] == 2) ||
                    (gameField.field[i, xLocate + 1] == 2) ||
                    (gameField.field[i, xLocate + 2] == 2))
                {
                    yLocate = i;
                    found = true;
                }
                i++;
            }
            if (!found)
                yLocate = gameField.YSize;
        }
        private void SearchY_Status_2()
        {
            bool found = false;
            int i = yLocate;
            while ((i < gameField.YSize) && (!found))
            {
                if (gameField.field[i, xLocate] == 2)
                {
                    yLocate = i;
                    found = true;
                }
                i++;
            }
            if (!found)
                yLocate = gameField.YSize;
        }
        public override void ShiftLeft()
        {
            switch (status)
            {
                case 1:
                    if ((xLocate - 1 != 0) &&
                        (gameField.field[yLocate, xLocate - 2] != 2))
                    {
                        gameField.field[yLocate, xLocate + 2] = 0;
                        gameField.field[yLocate, xLocate - 2] = 1;
                        xLocate -= 1;
                    }
                    break;
                case 2:
                    if ((xLocate != 0) &&
                        (gameField.field[yLocate - 1, xLocate - 1] != 2) &&
                        (gameField.field[yLocate, xLocate - 1] != 2) &&
                        (gameField.field[yLocate + 1, xLocate - 1] != 2) &&
                        (gameField.field[yLocate + 2, xLocate - 1] != 2))
                    {
                        gameField.field[yLocate - 1, xLocate] = 0;
                        gameField.field[yLocate, xLocate] = 0;
                        gameField.field[yLocate + 1, xLocate] = 0;
                        gameField.field[yLocate + 2, xLocate] = 0;

                        gameField.field[yLocate - 1, xLocate - 1] = 1;
                        gameField.field[yLocate, xLocate - 1] = 1;
                        gameField.field[yLocate + 1, xLocate - 1] = 1;
                        gameField.field[yLocate + 2, xLocate - 1] = 1;
                        xLocate -= 1;
                    }
                    break;
            }
        }
        public override void ShiftRight()
        {
            switch (status)
            {
                case 1:
                    if ((xLocate + 2 != gameField.XSize - 1) &&
                        (gameField.field[yLocate, xLocate + 3] != 2))
                    {
                        gameField.field[yLocate, xLocate - 1] = 0;
                        gameField.field[yLocate, xLocate + 3] = 1;
                        xLocate += 1;
                    }
                    break;
                case 2:
                    if ((xLocate != gameField.XSize - 1) &&
                        (gameField.field[yLocate - 1, xLocate + 1] != 2) &&
                        (gameField.field[yLocate, xLocate + 1] != 2) &&
                        (gameField.field[yLocate + 1, xLocate + 1] != 2) &&
                        (gameField.field[yLocate + 2, xLocate + 1] != 2))
                    {
                        gameField.field[yLocate - 1, xLocate] = 0;
                        gameField.field[yLocate, xLocate] = 0;
                        gameField.field[yLocate + 1, xLocate] = 0;
                        gameField.field[yLocate + 2, xLocate] = 0;

                        gameField.field[yLocate - 1, xLocate + 1] = 1;
                        gameField.field[yLocate, xLocate + 1] = 1;
                        gameField.field[yLocate + 1, xLocate + 1] = 1;
                        gameField.field[yLocate + 2, xLocate + 1] = 1;
                        xLocate += 1;
                    }
                    break;
            }
        }
        public override void Turn()
        {
            switch (status)
            {
                case 1:
                    if ((yLocate != 0) &&
                        (yLocate != gameField.YSize - 1) &&
                        (yLocate + 2 != gameField.YSize) &&
                        (gameField.field[yLocate - 1, xLocate] != 2) &&
                        (gameField.field[yLocate + 1, xLocate] != 2) &&
                        (gameField.field[yLocate + 2, xLocate] != 2))
                    {
                        gameField.field[yLocate, xLocate - 1] = 0;
                        gameField.field[yLocate, xLocate + 1] = 0;
                        gameField.field[yLocate, xLocate + 2] = 0;

                        gameField.field[yLocate - 1, xLocate] = 1;
                        gameField.field[yLocate + 1, xLocate] = 1;
                        gameField.field[yLocate + 2, xLocate] = 1;
                        status = 2;
                    }
                    break;
                case 2:
                    if ((xLocate != 0) &&
                        (xLocate != gameField.XSize - 1) &&
                        (xLocate + 2 != gameField.XSize) &&
                        (gameField.field[yLocate, xLocate - 1] != 2) &&
                        (gameField.field[yLocate, xLocate + 1] != 2) &&
                        (gameField.field[yLocate, xLocate + 2] != 2))
                    {
                        gameField.field[yLocate - 1, xLocate] = 0;
                        gameField.field[yLocate + 1, xLocate] = 0;
                        gameField.field[yLocate + 2, xLocate] = 0;

                        gameField.field[yLocate, xLocate - 1] = 1;
                        gameField.field[yLocate, xLocate + 1] = 1;
                        gameField.field[yLocate, xLocate + 2] = 1;
                        status = 1;
                    }
                    break;
            }
        }

        public override bool HasDrawingPlace()
        {
            throw new NotImplementedException();
        }
    }
}
