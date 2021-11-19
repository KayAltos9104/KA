using System;
using System.Collections.Generic;

namespace DLA
{
    class Program
    {
        static int[,] field;
        static void Main()
        {
            field = new int[9, 9];
            int i = 1;

            int cluster_V = 1;
            List<Cluster> cluster_parts = new List<Cluster>(cluster_V);
            cluster_parts.Add(new Cluster(field)); // Первый кластер посередине

            int numb_of_globules = 0;
            int globules_i = 0;
            List<Globule> globules = new List<Globule>(numb_of_globules); // Список глобул

            while (true)
            {
                if (i > 1 & globules_i == 0)
                {
                    numb_of_globules++;
                    globules.Add(new Globule(field));
                    globules_i = 1;
                }
                if (globules_i == 1)
                {
                    globules[numb_of_globules - 1].GetCoord(out int x, out int y);
                    field[x, y] = 0;
                    globules[numb_of_globules - 1].Move(field);
                    globules[numb_of_globules - 1].GetCoord(out x, out y);
                    field[x, y] = 2;
                }
                Update();
                Console.ReadKey();
                if (i == 1)
                    i++;
            }
        }

        static void Draw()
        {
            Console.Clear();
            for (int i = 0; i < field.GetLength(0); i++)
            {
                for (int j = 0; j < field.GetLength(1); j++)
                {
                    Console.Write(field[i, j]);
                }
                Console.WriteLine();
            }
        }

        static void Update()
        {
            Draw();
        }
    }
}
