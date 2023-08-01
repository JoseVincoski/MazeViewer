using MazePrinter.PrinterRelatedClasses;

namespace MazePrinter
{
    public class ConsoleInterface
    {
        private MazeAPIInterface mazeApi;
        public ConsoleInterface(MazeAPIInterface apiInterface)
        {
            mazeApi = apiInterface;
        }

        public async Task Start()
        {
            var continueLoop = true;
            while (continueLoop)
            {
                Console.Write("Maze Height: ");
                int.TryParse(Console.ReadLine(), out int mazeHeight);

                Console.Write("Maze Width: ");
                int.TryParse(Console.ReadLine(), out int mazeWidth);

                var maze = await mazeApi.GetMaze(mazeHeight, mazeWidth);
                Printer printer = new Printer(maze);
                printer.PrintMazeTiles();

                Console.Write("To exit type n: ");
                continueLoop = Console.ReadLine()?.ToLower() != "n";
            }
        }
    }
}