﻿using System.Collections.Generic;
using System.Linq;

namespace GoL.Game.Rules
{
    internal class UnderpopulationRule : IRule
    {
        public CellState? Run(Cell currentCell, List<Cell> neighbours)
        {
            if(currentCell.State == CellState.Alive && neighbours.Where(x => x.State == CellState.Alive).Count() < 2)
            {
                return CellState.Dead;
            }

            return null;
        }
    }
}
