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

        public Globule(int[,] field)//Лочить генерацию в конструктор можно, конечно, но не очень хорошо
            //Я тоже люблю в конструктор сложную логику пихать, но это не рекомендуется - обычно конструкторы
            //используют по большей части для инициализации полей
            //Здесь в любом случае у глобулы всегда рандомное расположение. А если ей конкретное место нужно будет задать?
            //В рамках задачи это работает, и слава богу, но про такие вещи надо думать))
        {
            _field = field;
            Random(field);
            if (field[_x, _y] == 1)//А если еще раз на кластер наткнемся после второго генерации? Тут do-while больше в тему
                Random(field);
            _field[_x, _y] = _view_in_console;
        }

        void Random(int[,] field)//Название не очень в том плане, что есть системный класс Random. Чтобы не путаться, лучше что-то другое дать
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