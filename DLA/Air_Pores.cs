using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DLA
{
    class Air_Pores : Particle
    {
        public Air_Pores(int[,] field)//Я так понимаю, это была заготовка под массив из particle, а не int?)
        {
            _field = field;
        }
    }
}