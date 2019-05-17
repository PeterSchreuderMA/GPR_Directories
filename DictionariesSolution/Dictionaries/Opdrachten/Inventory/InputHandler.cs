using System;
using System.Threading;

namespace Dictionaries.Opdrachten.Inventory
{
    class InputHandler
    {
        public static Action<ConsoleKey> inputAction;

        public InputHandler()
        {
            Thread thread = new Thread(ReadInput);
            thread.Start();
        }

        void ReadInput()
        {
            while (true)
            {
                ConsoleKey key = Console.ReadKey().Key;

                Console.Clear();

                inputAction(key);
            }
        }
    }
}
