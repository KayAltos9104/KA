using System;
using System.Collections.Generic;
using System.Threading;

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

            int numb_of_globules = 1;
            int globules_i = 0;
            List<Globule> globules = new List<Globule>(numb_of_globules); // Список глобул

            Console.WriteLine("Введите количество новых частиц (глобул):"); // Интерфейс
            int num_of_particles = Int32.Parse(Console.ReadLine());

            while (cluster_parts.Count <= num_of_particles + 1)
            {
                if (i > 1 && globules_i == 0)
                {
                    globules.Add(new Globule(field));
                    globules_i = 1;
                }
                if (i > 1)
                {
                    globules[numb_of_globules - 1].GetCoord(out int g_x, out int g_y);
                    if (globules_i == 1)
                    {
                        if ((g_x + 1 < field.GetLength(0) && g_y + 1 < field.GetLength(1) && field[g_x + 1, g_y + 1] == Cluster.Pic) ||
                            (g_x - 1 > 0 && g_y - 1 > 0 && field[g_x - 1, g_y - 1] == Cluster.Pic) ||
                            (g_x + 1 < field.GetLength(0) && field[g_x + 1, g_y] == Cluster.Pic) ||
                            (g_y + 1 < field.GetLength(1) && field[g_x, g_y + 1] == Cluster.Pic) ||
                            (g_x - 1 > 0 && field[g_x - 1, g_y] == Cluster.Pic) ||
                            (g_y - 1 > 0 && field[g_x, g_y - 1] == Cluster.Pic) ||
                            (g_x - 1 > 0 && g_y + 1 < field.GetLength(1) && field[g_x - 1, g_y + 1] == Cluster.Pic) ||
                            (g_x + 1 < field.GetLength(0) && g_y - 1 > 0 && field[g_x + 1, g_y - 1] == Cluster.Pic))
                        {
                            Globule_IntoPartOfCluster(globules, numb_of_globules, g_x, g_y, globules_i, cluster_V, cluster_parts, out int n_globules_i);
                            globules_i = n_globules_i;
                        }
                        else
                        {
                            Globule_Move(g_x, g_y, globules, numb_of_globules);
                        }
                    }
                    else
                    {
                        Globule_Move(g_x, g_y, globules, numb_of_globules);
                    }
                }
                Update();
                Thread.Sleep(500);
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

                    if (field[i, j] == Cluster.Pic)
                        Console.ForegroundColor = ConsoleColor.Cyan;
                    if (field[i, j] == Globule.Pic)
                        Console.ForegroundColor = ConsoleColor.Red;

                    Console.Write(field[i, j]);
                    Console.ResetColor();
                }
                Console.WriteLine();
            }
        }

        static void Update()
        {
            Draw();
        }

        static void Globule_IntoPartOfCluster(List<Globule> globules, int numb_of_globules, int g_x, int g_y, int globules_i, int cluster_V, List<Cluster> cluster_parts, out int n_globules_i)
        {
            globules.RemoveAt(numb_of_globules - 1);
            field[g_x, g_y] = 0;
            globules_i = 0;
            n_globules_i = globules_i;
            cluster_V++;
            cluster_parts.Add(new Cluster(field));
            cluster_parts[cluster_V - 1].GetCoord(out int c_x, out int c_y);
            c_x = g_x; c_y = g_y;
            field[c_x, c_y] = Cluster.Pic;
        }

        static void Globule_Move(int g_x, int g_y, List<Globule> globules, int numb_of_globules)
        {
            field[g_x, g_y] = 0;
            globules[numb_of_globules - 1].Move(field);
            globules[numb_of_globules - 1].GetCoord(out g_x, out g_y);
            field[g_x, g_y] = Globule.Pic;
        }
    }
}