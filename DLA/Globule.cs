﻿using System;
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
            Random(field);
            if (_x == 4 && _y == 4)
                Random(field);
            _view_in_console = 2;
            _field[_x, _y] = _view_in_console;
        }

        void Random(int[,] field)
        {
            _x = rnd.Next(0, field.GetLength(0));
            _y = rnd.Next(0, field.GetLength(1));
        }
    }
}
