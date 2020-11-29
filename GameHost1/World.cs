using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameHost1
{
    public class World
    {
        private int height;
        private int width;

        private Cell[,] member;

        public World(bool[,] matrix)
        {
            height = matrix.GetLength(0);
            width = matrix.GetLength(1);

            member = new Cell[height, width];
            
            for(int i = 0; i < height; i++)
            {
                for(int j = 0; j < width; j++)
                {
                    member[i, j] = new Cell(matrix[i,j]); 
                    
                    if(i-1 >= 0)
                    {
                        if(j-1 >= 0)
                        {
                            member[i, j].SetNeighbors(member[i-1, j-1]);
                        }

                        member[i, j].SetNeighbors(member[i - 1, j]);

                        if( j + 1 < width)
                        {
                            member[i, j].SetNeighbors(member[i - 1, j + 1]);
                        } 
                    }

                    if ( j - 1 >= 0)
                    {
                        member[i, j].SetNeighbors(member[i, j - 1]);
                    }

                }
            }
            
            Check();
    
        }    

        private void Check()
        {
            foreach(Cell cell in member)
            {
                cell.Check();
            }
        }

        private bool[,] GetMap()
        {
            bool[,] map = new bool[height, width];

            for(int i = 0; i < height; i++)
            {
                for(int j = 0; j < width; j++)
                {
                    map[i,j] = member[i,j].IsAlive();
                }
            }
            
            return map;  
        }

        public bool[,] TimePass()
        {
            foreach (Cell cell in member)
            {
                cell.TimePass();
            }

            Check();

            return GetMap();

        }

        






    }
}
