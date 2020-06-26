namespace GoL.Game
{
    public struct PointOffset
    {
        public static PointOffset Create(short x, short y)
        {
            return new PointOffset { OffsetX = x, OffsetY = y };
        }

        public short OffsetX { get; set; }
        public short OffsetY { get; set; }
    }
}
