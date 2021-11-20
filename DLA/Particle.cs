using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DLA
{
    abstract class Particle
    {
        private protected Random rnd = new Random();
        private protected static int _view_in_console;

        private protected int _x, _y;
        private protected int[,] _field;

        public void GetCoord(out int x, out int y)
        {
            x = _x;
            y = _y;
        }

        public void Move(int[,] field)
        {
            int direction = rnd.Next(0, 4);
            switch (direction)
            {
                case 0:
                    {
                        if (_x + 1 < field.GetLength(0))
                            _x = _x + 1;
                        break;
                    }
                case 1:
                    {
                        if (_y - 1 > 0)
                            _y = _y - 1;
                        break;
                    }
                case 2:
                    {
                        if (_x - 1 > 0)
                            _x = _x - 1;
                        break;
                    }
                case 3:
                    {
                        if (_y + 1 < field.GetLength(1))
                            _y = _y + 1;
                        break;
                    }
            }
        }

        public int Pic
        {
            get
            {
                return _view_in_console;
            }
        }
    }
}
