using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DLA
{
    class Cluster : Particle
    {
        static int _view_in_console = 1;//Ну, статической иконку делать - спорное решение, но в данном случае можно
        //Просто вы тем самым обрубаете возможность кластерам разные метки ставить)

        public Cluster(int[,] field)
        {
            _field = field;
            _x = 4; _y = 4;//А если поле будет не 9х9? Можно было бы хотя бы к размеру поля привязать - оно все равно аргументом идет))
            _field[_x, _y] = _view_in_console;
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