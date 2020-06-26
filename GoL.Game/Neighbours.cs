using System.Collections.Generic;

namespace GoL.Game
{
    public static class Neighbours
    {
        public const short TOP_BORDER = short.MaxValue - 1;
        public const short BOTTOM_BORDER = short.MaxValue - 2;
        public const short RIGHT_BORDER = short.MaxValue - 3;
        public const short LEFT_BORDER = short.MaxValue - 4;
        public const short TOP_RIGHT_CORNER = short.MaxValue - 5;
        public const short TOP_LEFT_CORNER = short.MaxValue - 6;
        public const short BOTTOM_RIGHT_CORNER = short.MaxValue - 7;
        public const short BOTTOM_LEFT_CORNER = short.MaxValue - 8;

        public static List<PointOffset[]> Offsets = new List<PointOffset[]>(9)
        {
            new PointOffset[]   // Middle
            {
                PointOffset.Create(-1, -1), PointOffset.Create(0, -1),  PointOffset.Create(1, -1),
                PointOffset.Create(-1, 0),                              PointOffset.Create(1, 0),
                PointOffset.Create(-1, 1), PointOffset.Create(0, 1),    PointOffset.Create(1, 1)
            },

            new PointOffset[]   //Top
            {
                PointOffset.Create(-1, TOP_BORDER), PointOffset.Create(0, TOP_BORDER),      PointOffset.Create(1, TOP_BORDER),
                PointOffset.Create(-1, 0),                                                  PointOffset.Create(1, 0),
                PointOffset.Create(1, 1),           PointOffset.Create(0, 1),               PointOffset.Create(1, 1)
            },

            new PointOffset[]   //Bottom
            {
                PointOffset.Create(-1, -1),             PointOffset.Create(0, -1),              PointOffset.Create(1, -1),
                PointOffset.Create(-1, 0),                                                      PointOffset.Create(1, 0),
                PointOffset.Create(-1, BOTTOM_BORDER),   PointOffset.Create(0, BOTTOM_BORDER),  PointOffset.Create(1, BOTTOM_BORDER)
            },

            new PointOffset[]   // Right
            {
                PointOffset.Create(-1, -1),     PointOffset.Create(0, -1),  PointOffset.Create(RIGHT_BORDER, -1),
                PointOffset.Create(-1, 0),                                  PointOffset.Create(RIGHT_BORDER, 0),
                PointOffset.Create(-1, 1),      PointOffset.Create(0, 1),   PointOffset.Create(RIGHT_BORDER, 1)
            },

            new PointOffset[]   // Left
            {
                PointOffset.Create(LEFT_BORDER, -1),    PointOffset.Create(0, -1),      PointOffset.Create(1, -1),
                PointOffset.Create(LEFT_BORDER, 0),                                     PointOffset.Create(1, 0),
                PointOffset.Create(LEFT_BORDER, 1),     PointOffset.Create(0, 1),       PointOffset.Create(1, 1)
            },

            new PointOffset[]   // Top right
            {
                PointOffset.Create(-1, TOP_BORDER),             PointOffset.Create(0, TOP_BORDER),      PointOffset.Create(TOP_RIGHT_CORNER, TOP_RIGHT_CORNER),
                PointOffset.Create(-1, 0),                                                              PointOffset.Create(RIGHT_BORDER, 0),
                PointOffset.Create(-1, 1),                      PointOffset.Create(0, 1),               PointOffset.Create(RIGHT_BORDER, 1)
            },

            new PointOffset[]   // Top left
            {
                PointOffset.Create(TOP_LEFT_CORNER, TOP_LEFT_CORNER),   PointOffset.Create(0, TOP_BORDER),  PointOffset.Create(TOP_BORDER, TOP_BORDER),
                PointOffset.Create(LEFT_BORDER, 0),                                                         PointOffset.Create(1, 0),
                PointOffset.Create(LEFT_BORDER, 1),                     PointOffset.Create(0, 1),           PointOffset.Create(1, 1)
            },

            new PointOffset[]   // Bottom right
            {
                PointOffset.Create(-1, -1),                 PointOffset.Create(0, -1),              PointOffset.Create(RIGHT_BORDER, -1),
                PointOffset.Create(-1, 0),                                                          PointOffset.Create(RIGHT_BORDER, 0),
                PointOffset.Create(BOTTOM_BORDER, BOTTOM_BORDER),      PointOffset.Create(0, BOTTOM_BORDER),   PointOffset.Create(BOTTOM_RIGHT_CORNER, BOTTOM_RIGHT_CORNER)
            },

            new PointOffset[]   // Bottom left
            {
                PointOffset.Create(LEFT_BORDER, -1),                   PointOffset.Create(0, -1),                           PointOffset.Create(1, -1),
                PointOffset.Create(LEFT_BORDER, 0),                                                                                 PointOffset.Create(1, 0),
                PointOffset.Create(BOTTOM_LEFT_CORNER, BOTTOM_LEFT_CORNER),     PointOffset.Create(0, BOTTOM_BORDER),   PointOffset.Create(BOTTOM_BORDER, BOTTOM_BORDER)
            }
        };
    }
}
