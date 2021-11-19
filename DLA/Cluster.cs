using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DLA
{
    class Cluster : Particle
    {
        public Cluster(int[,] field)
        {
            _field = field;
            _x = 4; _y = 4;
            _view_in_console = 1;
            _field[_x, _y] = _view_in_console;
        }
    }
}
