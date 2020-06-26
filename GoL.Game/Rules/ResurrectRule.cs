using System.Collections.Generic;
using System.Linq;

namespace GoL.Game.Rules
{
    internal class ResurrectRule : IRule
    {
        public CellState? Run(Cell currentCell, List<Cell> neighbours)
        {
            if(currentCell.State == CellState.Dead && neighbours.Where(x => x.State == CellState.Alive).Count() == 3)
            {
                return CellState.Alive;
            }

            return null;
        }
    }
}
