using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameHost1
{
    public class Cell
    {
        public Cell(bool _alive)
        {
            alive = _alive;
            neighbors = new List<Cell>();
        }

        private bool alive { get; set; }  

        private List<Cell> neighbors { get; set; }

        public void SetNeighbors(Cell newNeighbor)
        {
            AddNeighbor(newNeighbor);
            newNeighbor.AddNeighbor(this);
        }

        public void AddNeighbor(Cell newNeighbor)
        {
            neighbors.Add(newNeighbor);
        }

        private int count { get; set; } 

        public void Check()
        {
            count = neighbors.Count(c => c.IsAlive());    
        }

        public bool IsAlive()
        {
            return alive;
        }

        public void TimePass()
        {
            alive = (count == 3) || (alive && count == 2);            
        }

    }
}
