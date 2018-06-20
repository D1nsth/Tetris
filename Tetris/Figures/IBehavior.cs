using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tetris.Figures
{
    interface IBehavior
    {
        void FallDown();
        void JerkDown();
        void ShiftLeft();
        void ShiftRight();
        void Turn();
    }
}
