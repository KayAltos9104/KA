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
            cluster_parts[cluster_V - 1].GetCoord(out int c_x, out int c_y);

            int numb_of_globules = 0;
            int globules_i = 0;
            List<Globule> globules = new List<Globule>(numb_of_globules); // Список глобул

            while (true)
            {
                if (i > 1 && globules_i == 0)
                {
                    numb_of_globules++;
                    globules.Add(new Globule(field));
                    globules_i = 1;
                }
                if (i > 1)
                {
                    globules[numb_of_globules - 1].GetCoord(out int g_x, out int g_y);
                    if (globules_i == 1 &&
                        (g_x == c_x + 1 && g_y == c_y + 1) |
                        (g_x == c_x - 1 && g_y == c_y - 1) |
                        (g_x == c_x + 1 && g_y == c_y) |
                        (g_x == c_x && g_y == c_y + 1) |
                        (g_x == c_x - 1 && g_y == c_y) |
                        (g_x == c_x && g_y == c_y - 1) |
                        (g_x == c_x - 1 && g_y == c_y + 1) |
                        (g_x == c_x + 1 && g_y == c_y - 1))
                    {
                        globules.RemoveAt(numb_of_globules - 1);
                        field[g_x, g_y] = 0;
                        globules_i = 0;
                        cluster_V++;
                        cluster_parts.Add(new Cluster(field));
                        cluster_parts[cluster_V - 1].GetCoord(out int n_c_x, out int n_c_y);
                        n_c_x = g_x; n_c_y = g_y;
                        field[n_c_x, n_c_y] = 1;
                    }
                    else
                    {
                        field[g_x, g_y] = 0;
                        globules[numb_of_globules - 1].Move(field);
                        globules[numb_of_globules - 1].GetCoord(out g_x, out g_y);
                        field[g_x, g_y] = 2;
                    }
                }
                Update();
                //Console.ReadKey();
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
