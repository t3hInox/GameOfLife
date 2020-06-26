using GoL.Game.Rules;
using System.Collections.Generic;
using System.Linq;

namespace GoL.Game
{
    internal class GenerationManager
    {
        private readonly List<IRule> _rules;
        private readonly int _totalCells;

        public GenerationManager(int totalCells)
        {
            _totalCells = totalCells;
            _rules = new List<IRule>
            { 
                new OverpopulationRule(),
                new RemainAliveRule(),
                new ResurrectRule(),
                new UnderpopulationRule()
            };
        }

        public IEnumerable<Cell> Generate(List<Cell> currentGeneration)
        {
            var original = currentGeneration.ConvertAll(x => new Cell(x));
            var nextGeneration = new List<Cell>(_totalCells);

            for (var i = 0; i < currentGeneration.Count; i++)
            {
                var cell = currentGeneration[i];
                var neighbours = new List<Cell>(8);

                foreach(var neighbour in cell.NeighbourCoordinates)
                {
                    neighbours.Add(original.Where(x => x.Coordinates.X == neighbour.X && x.Coordinates.Y == neighbour.Y).Single());
                }

                CellState? newState = null;

                foreach(var rule in _rules)
                {
                    newState = rule.Run(cell, neighbours);
                    if (newState != null)
                    {
                        break;
                    }
                }

                if(newState != null)
                {
                    cell.State = newState.Value;
                }

                nextGeneration.Add(cell);
            }

            return nextGeneration;
        }
    }
}
