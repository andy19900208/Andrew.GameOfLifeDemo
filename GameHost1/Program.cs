using System;
using System.Collections.Generic;
using System.Threading;

namespace GameHost1
{
    public class Program
    {
        static void Main(string[] args)
        {
            RunGameOfLife();
        }

        private static void RunGameOfLife()
        {
            bool[,] matrix = new bool[50, 20];

            Init(matrix, 20);
            World world = new World(matrix);
            God god = new God(world);

            for (int count = 0; count < 5000; count++)
            {
                Thread.Sleep(200);

                god.PrintWorld();

                world.TimePass();

                Console.WriteLine($"round: {count} / 5000...");
            }
        }

        private static void Init(bool[,] matrix, int rate = 20)
        {
            Random rnd = new Random();

            for (int y = 0; y < matrix.GetLength(1); y++)
            {
                for (int x = 0; x < matrix.GetLength(0); x++)
                {
                    matrix[x, y] = (rnd.Next(100) < rate);
                }
            }
        }

        public static bool[,] GetNextGenMatrix(bool[,] matrix_current)
        {
            World world = new World(matrix_current);

            world.TimePass();

            return world.GetMap();
        }


    }
}
