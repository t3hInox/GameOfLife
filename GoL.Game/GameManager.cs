using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GoL.Game
{
    public class GameManager
    {
        private List<Cell> _gameField;
        private readonly GameContext _gameContext;
        private readonly GenerationManager _generationManager;

        public GameManager(uint width, uint height)
        {
            _gameContext = new GameContext
            {
                BoardWidth = width,
                BoardHeight = height
            };
            var totalCells = (int)(_gameContext.BoardWidth * _gameContext.BoardHeight);
            _gameField = new List<Cell>(totalCells);
            _generationManager = new GenerationManager(totalCells);

            InitializeField(totalCells);
        }

        private void InitializeField(int totalCells)
        {
            for(uint i = 0; i < totalCells; i++)
            {
                _gameField.Add(new Cell(i, _gameContext));
            }

            var aliveCellPositions = new[] { 44, 59, 73, 72, 71 };

            foreach(var aliveCell in aliveCellPositions)
            {
                _gameField[aliveCell].State = CellState.Alive;
            }
        }

        public string PrintGeneration()
        {
            var nextGeneration = _generationManager.Generate(_gameField);
            var sb = new StringBuilder();

            foreach(var cell in nextGeneration)
            {
                sb.Append(cell.State == CellState.Alive ? "O" : "_");
            }

            _gameField = nextGeneration.ToList();
            return sb.ToString();
        }
    }
}
