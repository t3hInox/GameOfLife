using System.Collections.Generic;
using System.Linq;

namespace GoL.Game.Rules
{
    internal class RemainAliveRule : IRule
    {
        public CellState? Run(Cell currentCell, List<Cell> neighbours)
        {
            var aliveNeighbours = neighbours.Where(x => x.State == CellState.Alive).Count();
            var validAliveNeighbourCount = new[] { 2, 3 };

            if (currentCell.State == CellState.Alive && validAliveNeighbourCount.Contains(aliveNeighbours))
            {
                return CellState.Alive;
            }

            return null;
        }
    }
}
