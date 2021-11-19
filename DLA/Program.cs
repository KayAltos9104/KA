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

            int cluster_V = 1;
            List<Cluster> cluster_parts = new List<Cluster>(cluster_V);
            cluster_parts.Add(new Cluster(field));

            int numb_of_globules = 0;
            List<Globule> globules = new List<Globule>(numb_of_globules);
            globules.Add(new Globule(field));

            while (true)
            {
                Update();
                Console.ReadKey();
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
