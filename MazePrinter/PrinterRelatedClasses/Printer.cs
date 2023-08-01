
using Domain.MazeGenerator;
using Domain.MazeGenerator.Enums;

namespace MazePrinter.PrinterRelatedClasses
{
    public class Printer
    {
        private readonly Maze _maze;
        public Printer(Maze maze)
        {
            _maze = maze;
        }

        public void PrintMazeAsInts()
        {
            for (int row = 0; row < _maze.Height; row++)
            {
                for (int column = 0; column < _maze.Width; column++)
                {
                    Console.Write(_maze.Tiles[row, column]);
                }
                Console.WriteLine();
            }
        }

        public void PrintMazeTiles()
        {
            for (int row = 0; row < _maze.Height; row++)
            {
                for (int column = 0; column < _maze.Width; column++)
                {
                    Console.Write(GetTileType(row, column));
                }
                Console.WriteLine();
            }
        }

        private string GetTileType(int y, int x)
        {
            var currentTile = _maze.GetTileTypeInPosition(y, x);
            if (TileTypeChecker.IsPath(currentTile)) return CharactersPrinter.GetTile(MazeTiles.Path);
            else if (currentTile == TileType.Start) return CharactersPrinter.GetTile(MazeTiles.Start);
            else if (currentTile == TileType.Target) return CharactersPrinter.GetTile(MazeTiles.Target);

            var tilesInfo = _maze.GetTilesTypeAroundPosition(y, x);

            if (TileTypeChecker.IsAnyOutsideMaze(tilesInfo))
            {
                var frame = CheckOutsideFrame(tilesInfo);
                if (frame != null) return frame;
            }

            var intersection = CheckIntersections(tilesInfo);
            if (intersection != null) return intersection;

            var corners = CheckCorners(tilesInfo);
            if (corners != null) return corners;

            var straightLines = CheckStraightLines(tilesInfo);
            if (straightLines != null) return straightLines;

            return CharactersPrinter.GetTile(MazeTiles.Path);
        }

        private string? CheckIntersections(TilesAround tiles)
        {
            if (TileTypeChecker.AllAreWalls(tiles.NTile, tiles.ETile, tiles.STile, tiles.WTile)) return CharactersPrinter.GetTile(MazeTiles.IntesectionAll);
            else if (TileTypeChecker.AllAreWalls(tiles.NTile, tiles.ETile, tiles.STile)) return CharactersPrinter.GetTile(MazeTiles.IntersectionE);
            else if (TileTypeChecker.AllAreWalls(tiles.ETile, tiles.STile, tiles.WTile)) return CharactersPrinter.GetTile(MazeTiles.IntersectionS);
            else if (TileTypeChecker.AllAreWalls(tiles.STile, tiles.WTile, tiles.NTile)) return CharactersPrinter.GetTile(MazeTiles.IntersectionW);
            else if (TileTypeChecker.AllAreWalls(tiles.WTile, tiles.NTile, tiles.ETile)) return CharactersPrinter.GetTile(MazeTiles.IntersectionN);

            return null;
        }

        private string? CheckCorners(TilesAround tiles)
        {
            if (TileTypeChecker.AllAreWalls(tiles.NTile, tiles.ETile)) return CharactersPrinter.GetTile(MazeTiles.NE);
            else if (TileTypeChecker.AllAreWalls(tiles.ETile, tiles.STile)) return CharactersPrinter.GetTile(MazeTiles.SE);
            else if (TileTypeChecker.AllAreWalls(tiles.STile, tiles.WTile)) return CharactersPrinter.GetTile(MazeTiles.SW);
            else if (TileTypeChecker.AllAreWalls(tiles.WTile, tiles.NTile)) return CharactersPrinter.GetTile(MazeTiles.NW);

            return null;
        }

        private string? CheckStraightLines(TilesAround tiles)
        {
            if (TileTypeChecker.AnyIsWall(tiles.WTile, tiles.ETile)) return CharactersPrinter.GetTile(MazeTiles.Horizontal);
            else if (TileTypeChecker.AnyIsWall(tiles.NTile, tiles.STile)) return CharactersPrinter.GetTile(MazeTiles.Vertical);

            return null;
        }

        private string? CheckOutsideFrame(TilesAround tiles)
        {
            //Print frame vertices
            if (TileTypeChecker.AllAreWalls(tiles.NTile, tiles.ETile, tiles.STile)) return CharactersPrinter.GetTile(MazeTiles.IntersectionE);
            else if (TileTypeChecker.AllAreWalls(tiles.ETile, tiles.STile, tiles.WTile)) return CharactersPrinter.GetTile(MazeTiles.IntersectionS);
            else if (TileTypeChecker.AllAreWalls(tiles.STile, tiles.WTile, tiles.NTile)) return CharactersPrinter.GetTile(MazeTiles.IntersectionW);
            else if (TileTypeChecker.AllAreWalls(tiles.WTile, tiles.NTile, tiles.ETile)) return CharactersPrinter.GetTile(MazeTiles.IntersectionN);

            else if (TileTypeChecker.AllAreWalls(tiles.NTile, tiles.ETile)) return CharactersPrinter.GetTile(MazeTiles.NE);
            else if (TileTypeChecker.AllAreWalls(tiles.ETile, tiles.STile)) return CharactersPrinter.GetTile(MazeTiles.SE);
            else if (TileTypeChecker.AllAreWalls(tiles.STile, tiles.WTile)) return CharactersPrinter.GetTile(MazeTiles.SW);
            else if (TileTypeChecker.AllAreWalls(tiles.WTile, tiles.NTile)) return CharactersPrinter.GetTile(MazeTiles.NW);

            //Print frame intersections
            //Print frame straight walls
            else if (TileTypeChecker.AnyIsWall(tiles.WTile, tiles.ETile)) return CharactersPrinter.GetTile(MazeTiles.Horizontal);
            else if (TileTypeChecker.AnyIsWall(tiles.NTile, tiles.STile)) return CharactersPrinter.GetTile(MazeTiles.Vertical);

            return null;
        }
    }
}
