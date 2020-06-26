using System.Collections.Generic;

namespace GoL.Game.Rules
{
    internal interface IRule
    {
        public CellState? Run(Cell currentCell, List<Cell> neighbours);
    }
}
