using System;

namespace GoL.Game
{
    public struct Point<T> where T : struct
    {
        public Point(T x, T y)
        {
            X = x;
            Y = y;
        }

        public T X { get; set; }
        public T Y { get; set; }

        public (T x, T y) Coordinates => (x: X, y: Y);
    }
}
