using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tetris.Figures
{
    public class Ttype : Figure
    {
        public Ttype(GameField gameField) : base(gameField)
        {
            xLocate = gameField.XSize / 2; ;
            yLocate = 1;
            gameField.field[0, xLocate] = 1;
            gameField.field[1, xLocate] = 1;
            gameField.field[1, xLocate - 1] = 1;
            gameField.field[1, xLocate + 1] = 1;
        }
        public override void FallDown()
        {
            switch (status)
            {
                #region case 1
                case 1:
                    if ((yLocate + 1 != gameField.YSize) &&
                        (gameField.field[yLocate + 1, xLocate] != 2) &&
                        (gameField.field[yLocate + 1, xLocate - 1] != 2) &&
                        (gameField.field[yLocate + 1, xLocate + 1] != 2))
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
                #endregion
                #region case 2
                case 2:
                    if ((yLocate + 2 != gameField.YSize) &&
                        (gameField.field[yLocate + 2, xLocate] != 2) &&
                        (gameField.field[yLocate + 1, xLocate - 1] != 2))
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
                #endregion
                #region case 3
                case 3:
                    if ((yLocate + 2 != gameField.YSize) &&
                        (gameField.field[yLocate + 2, xLocate] != 2) &&
                        (gameField.field[yLocate + 1, xLocate - 1] != 2) &&
                        (gameField.field[yLocate + 1, xLocate + 1] != 2))
                    {
                        Move_Status_3(1);
                        yLocate += 1;
                    }
                    else
                    {
                        fall = false;
                        Move_Status_3(2);
                    }
                    break;
                #endregion
                #region case 4
                case 4:
                    if ((yLocate + 2 != gameField.YSize) &&
                        (gameField.field[yLocate + 2, xLocate] != 2) &&
                        (gameField.field[yLocate + 1, xLocate + 1] != 2))
                    {
                        Move_Status_4(1);
                        yLocate += 1;
                    }
                    else
                    {
                        fall = false;
                        Move_Status_4(2);
                    }
                    break;
                    #endregion
            }
        }
        private void Move_Status_1(byte x)
        {
            if (x == 1)
            {
                gameField.field[yLocate - 1, xLocate] = 0;
                gameField.field[yLocate, xLocate - 1] = 0;
                gameField.field[yLocate, xLocate + 1] = 0;

                gameField.field[yLocate + 1, xLocate] = x;
                gameField.field[yLocate + 1, xLocate + 1] = x;
                gameField.field[yLocate + 1, xLocate - 1] = x;
            }
            else
            {
                gameField.field[yLocate, xLocate] = x;
                gameField.field[yLocate, xLocate - 1] = x;
                gameField.field[yLocate, xLocate + 1] = x;
                gameField.field[yLocate - 1, xLocate] = x;
            }
        }
        private void Move_Status_2(byte x)
        {
            if (x == 1)
            {
                gameField.field[yLocate - 1, xLocate] = 0;
                gameField.field[yLocate, xLocate - 1] = 0;

                gameField.field[yLocate + 1, xLocate - 1] = x;
                gameField.field[yLocate + 2, xLocate] = x;
            }
            else
            {
                gameField.field[yLocate, xLocate] = x;
                gameField.field[yLocate - 1, xLocate] = x;
                gameField.field[yLocate + 1, xLocate] = x;
                gameField.field[yLocate, xLocate - 1] = x;
            }
        }
        private void Move_Status_3(byte x)
        {
            if (x == 1)
            {
                gameField.field[yLocate, xLocate] = 0;
                gameField.field[yLocate, xLocate + 1] = 0;
                gameField.field[yLocate, xLocate - 1] = 0;

                gameField.field[yLocate + 2, xLocate] = x;
                gameField.field[yLocate + 1, xLocate + 1] = x;
                gameField.field[yLocate + 1, xLocate - 1] = x;
            }
            else
            {
                gameField.field[yLocate, xLocate] = x;
                gameField.field[yLocate, xLocate + 1] = x;
                gameField.field[yLocate, xLocate - 1] = x;
                gameField.field[yLocate + 1, xLocate] = x;
            }
        }
        private void Move_Status_4(byte x)
        {
            if (x == 1)
            {
                gameField.field[yLocate - 1, xLocate] = 0;
                gameField.field[yLocate, xLocate + 1] = 0;

                gameField.field[yLocate + 2, xLocate] = x;
                gameField.field[yLocate + 1, xLocate + 1] = x;
            }
            else
            {
                gameField.field[yLocate, xLocate] = x;
                gameField.field[yLocate, xLocate + 1] = x;
                gameField.field[yLocate - 1, xLocate] = x;
                gameField.field[yLocate + 1, xLocate] = x;
            }
        }
        public override void JerkDown()
        {
            fall = false;
            switch (status)
            {
                #region case 1
                case 1:
                    gameField.field[yLocate, xLocate] = 0;
                    gameField.field[yLocate, xLocate - 1] = 0;
                    gameField.field[yLocate, xLocate + 1] = 0;
                    gameField.field[yLocate - 1, xLocate] = 0;

                    SearchY_Status_1();

                    gameField.field[yLocate - 1, xLocate] = 2;
                    gameField.field[yLocate - 1, xLocate + 1] = 2;
                    gameField.field[yLocate - 1, xLocate - 1] = 2;
                    gameField.field[yLocate - 2, xLocate] = 2;
                    break;
                #endregion
                #region case 2
                case 2:
                    gameField.field[yLocate - 1, xLocate] = 0;
                    gameField.field[yLocate, xLocate] = 0;
                    gameField.field[yLocate + 1, xLocate] = 0;
                    gameField.field[yLocate, xLocate - 1] = 0;

                    if (SearchY_Status_2() == 1)
                    {
                        gameField.field[yLocate - 3, xLocate] = 2;
                        gameField.field[yLocate - 2, xLocate] = 2;
                        gameField.field[yLocate - 1, xLocate] = 2;
                        gameField.field[yLocate - 2, xLocate - 1] = 2;
                    }
                    else
                    {
                        gameField.field[yLocate - 2, xLocate] = 2;
                        gameField.field[yLocate - 1, xLocate] = 2;
                        gameField.field[yLocate, xLocate] = 2;
                        gameField.field[yLocate - 1, xLocate - 1] = 2;
                    }
                    break;
                #endregion
                #region case 3
                case 3:
                    gameField.field[yLocate, xLocate] = 0;
                    gameField.field[yLocate, xLocate + 1] = 0;
                    gameField.field[yLocate + 1, xLocate] = 0;
                    gameField.field[yLocate, xLocate - 1] = 0;

                    if (SearchY_Status_3() == 1)
                    {
                        gameField.field[yLocate - 1, xLocate] = 2;
                        gameField.field[yLocate - 2, xLocate] = 2;
                        gameField.field[yLocate - 2, xLocate + 1] = 2;
                        gameField.field[yLocate - 2, xLocate - 1] = 2;
                    }
                    else
                    {
                        gameField.field[yLocate, xLocate] = 2;
                        gameField.field[yLocate - 1, xLocate] = 2;
                        gameField.field[yLocate - 1, xLocate + 1] = 2;
                        gameField.field[yLocate - 1, xLocate - 1] = 2;
                    }
                    break;
                #endregion
                #region case 4
                case 4:
                    gameField.field[yLocate - 1, xLocate] = 0;
                    gameField.field[yLocate, xLocate] = 0;
                    gameField.field[yLocate + 1, xLocate] = 0;
                    gameField.field[yLocate, xLocate + 1] = 0;

                    if (SearchY_Status_4() == 1)
                    {
                        gameField.field[yLocate - 3, xLocate] = 2;
                        gameField.field[yLocate - 2, xLocate] = 2;
                        gameField.field[yLocate - 1, xLocate] = 2;
                        gameField.field[yLocate - 2, xLocate + 1] = 2;
                    }
                    else
                    {
                        gameField.field[yLocate - 2, xLocate] = 2;
                        gameField.field[yLocate - 1, xLocate] = 2;
                        gameField.field[yLocate, xLocate] = 2;
                        gameField.field[yLocate - 1, xLocate + 1] = 2;
                    }
                    break;
                    #endregion
            }
        }
        private void SearchY_Status_1()
        {
            bool found = false;
            int i = yLocate;
            while ((i < gameField.YSize) && (!found))
            {
                if ((gameField.field[i, xLocate + 1] == 2) ||
                    (gameField.field[i, xLocate - 1] == 2) ||
                    (gameField.field[i, xLocate] == 2))
                {
                    yLocate = i;
                    found = true;
                }
                i++;
            }
            if (!found)
                yLocate = gameField.YSize;
        }
        private int SearchY_Status_2()
        {
            int i = yLocate;
            while (i < gameField.YSize)
            {
                if ((gameField.field[i, xLocate] == 2) &&
                    (gameField.field[i - 2, xLocate - 1] != 2))
                {
                    yLocate = i;
                    return 1;
                }
                if ((gameField.field[i, xLocate - 1] == 2) &&
                    (gameField.field[i, xLocate] != 2))
                {
                    yLocate = i;
                    return 2;
                }
                i++;
            }
            yLocate = gameField.YSize;
            return 1;
        }
        private int SearchY_Status_3()
        {
            int i = yLocate;
            while (i < gameField.YSize)
            {
                if ((gameField.field[i, xLocate] == 2) &&
                    (gameField.field[i - 2, xLocate - 1] != 2) &&
                    (gameField.field[i - 2, xLocate + 1] != 2))
                {
                    yLocate = i;
                    return 1;
                }
                if (((gameField.field[i, xLocate - 1] == 2) && (gameField.field[i - 1, xLocate + 1] != 2) && (gameField.field[i, xLocate] != 2)) ||
                    ((gameField.field[i, xLocate + 1] == 2) && (gameField.field[i - 1, xLocate - 1] != 2) && (gameField.field[i, xLocate] != 2)))
                {
                    yLocate = i;
                    return 2;
                }
                i++;
            }
            yLocate = gameField.YSize;
            return 1;
        }
        private int SearchY_Status_4()
        {
            int i = yLocate;
            while (i < gameField.YSize)
            {
                if ((gameField.field[i, xLocate] == 2) &&
                    (gameField.field[i - 2, xLocate + 1] != 2))
                {
                    yLocate = i;
                    return 1;
                }
                if ((gameField.field[i, xLocate + 1] == 2) &&
                    (gameField.field[i, xLocate] != 2))
                {
                    yLocate = i;
                    return 2;
                }
                i++;
            }
            yLocate = gameField.YSize;
            return 1;
        }
        public override void ShiftLeft()
        {
            switch (status)
            {
                #region case 1
                case 1:
                    if ((xLocate - 1 != 0) &&
                        (gameField.field[yLocate, xLocate - 2] != 2) &&
                        (gameField.field[yLocate - 1, xLocate - 1] != 2))
                    {
                        gameField.field[yLocate - 1, xLocate] = 0;
                        gameField.field[yLocate, xLocate + 1] = 0;

                        gameField.field[yLocate - 1, xLocate - 1] = 1;
                        gameField.field[yLocate, xLocate - 2] = 1;
                        xLocate -= 1;
                    }
                    break;
                #endregion
                #region case 2
                case 2:
                    if ((xLocate - 1 != 0) &&
                        (gameField.field[yLocate - 1, xLocate - 1] != 2) &&
                        (gameField.field[yLocate, xLocate - 2] != 2) &&
                        (gameField.field[yLocate + 1, xLocate - 1] != 2))
                    {
                        gameField.field[yLocate - 1, xLocate] = 0;
                        gameField.field[yLocate, xLocate] = 0;
                        gameField.field[yLocate + 1, xLocate] = 0;

                        gameField.field[yLocate - 1, xLocate - 1] = 1;
                        gameField.field[yLocate, xLocate - 2] = 1;
                        gameField.field[yLocate + 1, xLocate - 1] = 1;
                        xLocate -= 1;
                    }
                    break;
                #endregion
                #region case 3
                case 3:
                    if ((xLocate - 1 != 0) &&
                        (gameField.field[yLocate, xLocate - 2] != 2) &&
                        (gameField.field[yLocate + 1, xLocate - 1] != 2))
                    {
                        gameField.field[yLocate + 1, xLocate] = 0;
                        gameField.field[yLocate, xLocate + 1] = 0;

                        gameField.field[yLocate + 1, xLocate - 1] = 1;
                        gameField.field[yLocate, xLocate - 2] = 1;
                        xLocate -= 1;
                    }
                    break;
                #endregion
                #region case 4
                case 4:
                    if ((xLocate != 0) &&
                        (gameField.field[yLocate - 1, xLocate - 1] != 2) &&
                        (gameField.field[yLocate, xLocate - 1] != 2) &&
                        (gameField.field[yLocate + 1, xLocate - 1] != 2))
                    {
                        gameField.field[yLocate, xLocate + 1] = 0;
                        gameField.field[yLocate - 1, xLocate] = 0;
                        gameField.field[yLocate + 1, xLocate] = 0;

                        gameField.field[yLocate - 1, xLocate - 1] = 1;
                        gameField.field[yLocate, xLocate - 1] = 1;
                        gameField.field[yLocate + 1, xLocate - 1] = 1;
                        xLocate -= 1;
                    }
                    break;
                    #endregion
            }
        }
        public override void ShiftRight()
        {
            switch (status)
            {
                #region case 1
                case 1:
                    if ((xLocate + 1 != gameField.XSize - 1) &&
                        (gameField.field[yLocate - 1, xLocate + 1] != 2) &&
                        (gameField.field[yLocate, xLocate + 2] != 2))
                    {
                        gameField.field[yLocate, xLocate - 1] = 0;
                        gameField.field[yLocate - 1, xLocate] = 0;

                        gameField.field[yLocate - 1, xLocate + 1] = 1;
                        gameField.field[yLocate, xLocate + 2] = 1;
                        xLocate += 1;
                    }
                    break;
                #endregion
                #region case 2
                case 2:
                    if ((xLocate != gameField.XSize - 1) &&
                        (gameField.field[yLocate - 1, xLocate + 1] != 2) &&
                        (gameField.field[yLocate, xLocate + 1] != 2) &&
                        (gameField.field[yLocate + 1, xLocate + 1] != 2))
                    {
                        gameField.field[yLocate, xLocate - 1] = 0;
                        gameField.field[yLocate - 1, xLocate] = 0;
                        gameField.field[yLocate + 1, xLocate] = 0;

                        gameField.field[yLocate, xLocate + 1] = 1;
                        gameField.field[yLocate - 1, xLocate + 1] = 1;
                        gameField.field[yLocate + 1, xLocate + 1] = 1;
                        xLocate += 1;
                    }
                    break;
                #endregion
                #region case 3
                case 3:
                    if ((xLocate + 1 != gameField.XSize - 1) &&
                        (gameField.field[yLocate, xLocate + 2] != 2) &&
                        (gameField.field[yLocate + 1, xLocate + 1] != 2))
                    {
                        gameField.field[yLocate, xLocate - 1] = 0;
                        gameField.field[yLocate + 1, xLocate] = 0;

                        gameField.field[yLocate + 1, xLocate + 1] = 1;
                        gameField.field[yLocate, xLocate + 2] = 1;
                        xLocate += 1;
                    }
                    break;
                #endregion
                #region case 4
                case 4:
                    if ((xLocate + 1 != gameField.XSize - 1) &&
                        (gameField.field[yLocate - 1, xLocate + 1] != 2) &&
                        (gameField.field[yLocate, xLocate + 2] != 2) &&
                        (gameField.field[yLocate + 1, xLocate + 1] != 2))
                    {
                        gameField.field[yLocate, xLocate] = 0;
                        gameField.field[yLocate - 1, xLocate] = 0;
                        gameField.field[yLocate + 1, xLocate] = 0;

                        gameField.field[yLocate, xLocate + 2] = 1;
                        gameField.field[yLocate - 1, xLocate + 1] = 1;
                        gameField.field[yLocate + 1, xLocate + 1] = 1;
                        xLocate += 1;
                    }
                    break;
                    #endregion
            }
        }
        public override void Turn()
        {
            switch (status)
            {
                #region case 1
                case 1:
                    if ((yLocate + 1 != gameField.YSize) &&
                        (gameField.field[yLocate + 1, xLocate] != 2))
                    {
                        gameField.field[yLocate, xLocate + 1] = 0;

                        gameField.field[yLocate + 1, xLocate] = 1;
                        status = 2;
                    }
                    break;
                #endregion
                #region case 2
                case 2:
                    if ((xLocate + 1 != gameField.XSize) &&
                        (gameField.field[yLocate, xLocate + 1] != 2))
                    {
                        gameField.field[yLocate - 1, xLocate] = 0;

                        gameField.field[yLocate, xLocate + 1] = 1;
                        status = 3;
                    }
                    break;
                #endregion
                #region case 3
                case 3:
                    if ((yLocate != 0) &&
                        (gameField.field[yLocate - 1, xLocate] != 2))
                    {
                        gameField.field[yLocate, xLocate - 1] = 0;

                        gameField.field[yLocate - 1, xLocate] = 1;
                        status = 4;
                    }
                    break;
                #endregion
                #region case 4
                case 4:
                    if ((xLocate != 0) &&
                        (gameField.field[yLocate, xLocate - 1] != 2))
                    {
                        gameField.field[yLocate + 1, xLocate] = 0;

                        gameField.field[yLocate, xLocate - 1] = 1;
                        status = 1;
                    }
                    break;
                    #endregion
            }
        }

        public override bool HasDrawingPlace()
        {
            throw new NotImplementedException();
        }
    }
}
