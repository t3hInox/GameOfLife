using System;
using System.Collections.Generic;

namespace GoL.Game
{
    internal class Cell
    {
        public Cell(Cell source)
        {
            _gameContext = source._gameContext;
            State = source.State;
            Position = source.Position;
        }

        public Cell(uint position, GameContext gameContext)
        {
            _gameContext = gameContext;
            State = CellState.Dead;
            Position = position;
        }

        public readonly GameContext _gameContext;

        public CellState State { get; set; }
        public uint Position { get; set; }

        public IEnumerable<Point<uint>> NeighbourCoordinates 
        {
            get 
            {
                var neighbourOffsets = Neighbours.Offsets[(int)Location];

                foreach (var offset in neighbourOffsets)
                {
                    var coordinates = NormalizeCoordinates((offset.OffsetX, offset.OffsetY));
                    yield return new Point<uint>(coordinates.x, coordinates.y);
                }
            }
        }

        public Point<uint> Coordinates {
            get
            {
                return new Point<uint>
                {
                    X = Position % _gameContext.BoardWidth,
                    Y = Position < _gameContext.BoardWidth ? 0 : (uint)Math.Floor((decimal)Position / _gameContext.BoardWidth)
                };
            }
        }
        public Location Location {
            get
            {
                if (Coordinates.Coordinates == (0, 0))
                {
                    return Location.TopLeft;
                }
                else if (Coordinates.Coordinates == (_gameContext.BoardWidth - 1, 0))
                {
                    return Location.TopRight;
                }
                else if (Coordinates.Coordinates == (0, _gameContext.BoardHeight - 1))
                {
                    return Location.BottomLeft;
                }
                else if (Coordinates.Coordinates == (_gameContext.BoardWidth - 1, _gameContext.BoardHeight - 1))
                {
                    return Location.BottomRight;
                }
                else if (Coordinates.X == 0 && Coordinates.Y > 0 && Coordinates.Y < _gameContext.BoardHeight - 1)
                {
                    return Location.Left;
                }
                else if (Coordinates.Y == 0 && Coordinates.X > 0 && Coordinates.X <= _gameContext.BoardWidth - 2)
                {
                    return Location.Top;
                }
                else if (Coordinates.X > 0 && Coordinates.X < _gameContext.BoardWidth - 1 && Coordinates.Y == _gameContext.BoardHeight - 1)
                {
                    return Location.Bottom;
                }
                else if (Coordinates.X == _gameContext.BoardWidth - 1 && Coordinates.Y > 0 && Coordinates.Y < _gameContext.BoardHeight - 1)
                {
                    return Location.Right;
                }
                else
                {
                    return Location.Middle;
                }
            }
        }

        private (uint x, uint y) NormalizeCoordinates((short x, short y) offset)
        {
            uint normalizedX;
            uint normalizedY;

            switch (offset.x)
            {
                case Neighbours.TOP_BORDER:             normalizedX = Coordinates.X; break;
                case Neighbours.BOTTOM_BORDER:          normalizedX = Coordinates.X; break;
                case Neighbours.RIGHT_BORDER:           normalizedX = 0; break;
                case Neighbours.LEFT_BORDER:            normalizedX = _gameContext.BoardWidth - 1; break;

                case Neighbours.TOP_RIGHT_CORNER:       normalizedX = 0; break;
                case Neighbours.TOP_LEFT_CORNER:        normalizedX = _gameContext.BoardWidth - 1; break;
                case Neighbours.BOTTOM_RIGHT_CORNER:    normalizedX = 0; break;
                case Neighbours.BOTTOM_LEFT_CORNER:     normalizedX = _gameContext.BoardWidth - 1; break;

                default: normalizedX = Coordinates.X + (uint)offset.x; break;
            }

            switch (offset.y)
            {
                case Neighbours.TOP_BORDER:             normalizedY = _gameContext.BoardHeight - 1; break;
                case Neighbours.BOTTOM_BORDER:          normalizedY = 0; break;
                case Neighbours.RIGHT_BORDER:           normalizedY = Coordinates.Y; break;
                case Neighbours.LEFT_BORDER:            normalizedY = Coordinates.Y; break;
                                                                  
                case Neighbours.TOP_RIGHT_CORNER:       normalizedY = _gameContext.BoardHeight - 1; break;
                case Neighbours.TOP_LEFT_CORNER:        normalizedY = _gameContext.BoardHeight - 1; break;
                case Neighbours.BOTTOM_RIGHT_CORNER:    normalizedY = 0; break;
                case Neighbours.BOTTOM_LEFT_CORNER:     normalizedY = 0; break;

                default: normalizedY = Coordinates.Y + (uint)offset.y; break;
            }

            return (normalizedX, normalizedY);
        }
    }
}
