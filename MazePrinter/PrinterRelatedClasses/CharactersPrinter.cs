using Domain.MazeGenerator.Enums;

namespace MazePrinter.PrinterRelatedClasses
{
    public static class CharactersPrinter
    {
        public static readonly string Horizontal = "─";
        public static readonly string Vertical = "│";
        public static readonly string NE = "└";
        public static readonly string SE = "┌";
        public static readonly string SW = "┐";
        public static readonly string NW = "┘";
        public static readonly string IntersectionN = "┴";
        public static readonly string IntersectionE = "├";
        public static readonly string IntersectionS = "┬";
        public static readonly string IntersectionW = "┤";
        public static readonly string Start = "S";
        public static readonly string IntesectionAll = "┼";
        public static readonly string Target = "X";

        public static readonly string Path = " ";
        public static readonly string VerifiedPath = " ";

        public static string GetTile(MazeTiles tileType)
        {
            var tileName = Enum.GetName(typeof(MazeTiles), tileType);
            var tileInfo = typeof(CharactersPrinter).GetField(tileName);

            string? fieldValue = (string?)tileInfo.GetValue(null);
            if (fieldValue == null) return null;

            return fieldValue;
        }
    }
}
