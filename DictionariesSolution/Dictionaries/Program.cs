using Dictionaries.Opdrachten.Inventory;

namespace Dictionaries
{
    class Program
    {
        static void Main(string[] args)
        {
            new InputHandler();

            new Inventory();

            Level newLevel = new Level();

            newLevel.LevelBoot(20, 20);

            newLevel.LevelShow();

            //new Dictionary_2();
        }
    }
}
