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
        }
    }
}