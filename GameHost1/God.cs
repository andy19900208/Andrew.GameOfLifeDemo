using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameHost1
{
    public class God
    {
        private World world;
        public God(World _world)
        {
            world = _world;
        }  

        public void PrintWorld()
        {
            bool[,] matrix = world.GetMap();

            int live_count = 0;

            Console.SetCursorPosition(0, 0);

            for (int y = 0; y < matrix.GetLength(1); y++)
            {
                for (int x = 0; x < matrix.GetLength(0); x++)
                {
                    var c = matrix[x, y];
                    live_count += (c ? 1 : 0);
                    Console.Write(c ? '★' : '☆');
                }
                Console.WriteLine();
            }

            Console.WriteLine($"total lives: {live_count}");
        }

    }
}