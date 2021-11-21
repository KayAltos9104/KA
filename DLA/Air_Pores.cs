using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DLA
{
    class Air_Pores : Particle
    {
        public Air_Pores(int[,] field)
        {
            _field = field;
            _view_in_console = 0;
            _field[_x, _y] = _view_in_console;
        }
    }
}