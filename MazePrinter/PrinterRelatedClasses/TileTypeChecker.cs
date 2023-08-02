using Domain.MazeGenerator;
using Domain.MazeGenerator.Enums;

namespace MazePrinter.PrinterRelatedClasses
{
    public static class TileTypeChecker
    {
        public static bool IsAnyOutsideMaze(TilesAround tiles)
        {
            return tiles.NTile == TileType.SolidWall || tiles.ETile == TileType.SolidWall || tiles.STile == TileType.SolidWall || tiles.WTile == TileType.SolidWall;
        }

        public static bool IsWall(TileType tile1)
        {
            return tile1 == TileType.MovableWall || tile1 == TileType.SolidWall || tile1 == TileType.BaseWall;
        }
        public static bool AllAreWalls(TileType tile1, TileType tile2)
        {
            return IsWall(tile1) && IsWall(tile2);
        }
        public static bool AllAreWalls(TileType tile1, TileType tile2, TileType tile3)
        {
            return IsWall(tile1) && IsWall(tile2) && IsWall(tile3);
        }
        public static bool AllAreWalls(TileType tile1, TileType tile2, TileType tile3, TileType tile4)
        {
            return IsWall(tile1) && IsWall(tile2) && IsWall(tile3) && IsWall(tile4);
        }

        public static bool AnyIsWall(TileType tile1, TileType tile2)
        {
            return IsWall(tile1) || IsWall(tile2);
        }

        public static bool IsPath(TileType tile1)
        {
            return tile1 == TileType.BasePath || tile1 == TileType.VerifiedPath;
        }
    }
}
