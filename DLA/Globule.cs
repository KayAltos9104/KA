using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DLA
{
    class Globule : Particle
    {
        public Globule(int[,] field)
        {
            _field = field;
            _x = rnd.Next(0, field.GetLength(0));
            _y = rnd.Next(0, field.GetLength(1));
            _view_in_console = 2;
            _field[_x, _y] = _view_in_console;
        }
    }
}
