using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DLA
{
    class Globule : Particle
    {
        static int _view_in_console = 2;

        public Globule(int[,] field)
        {
            _field = field;
            Random(field);
            if (field[_x, _y] == 1)
                Random(field);
            _field[_x, _y] = _view_in_console;
        }

        void Random(int[,] field)
        {
            _x = rnd.Next(0, field.GetLength(0));
            _y = rnd.Next(0, field.GetLength(1));
        }

        public static int Pic
        {
            get
            {
                return _view_in_console;
            }
        }
    }
}