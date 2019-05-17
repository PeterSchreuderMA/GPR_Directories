using Dictionaries.Opdrachten.Inventory;

namespace Dictionaries
{
    class Program
    {
        public static Level newLevel = new Level();
        public static InputHandler inputHandler;
        public static Inventory inventory;

        static void Main(string[] args)
        {
            inputHandler = new InputHandler();

            inventory = new Inventory();

            

            newLevel.LevelBoot(20, 20);

            

            //new Dictionary_2();
        }
    }
}
