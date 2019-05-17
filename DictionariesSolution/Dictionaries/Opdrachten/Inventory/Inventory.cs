using System;
using System.Collections.Generic;
using System.Windows;
using Dictionaries.Opdrachten.Inventory.Framework;

namespace Dictionaries.Opdrachten.Inventory
{
    enum Slot
    {
        H1, H2, H3, B1, B2, B3
    }

    enum Direction
    {
        UP, DOWN, LEFT, RIGHT
    }

    class Inventory
    {
        Dictionary<Slot, List<Item>> inv;

        Position position;

        public Inventory()
        {
            inv = new Dictionary<Slot, List<Item>>();

            // Creates a new list for every slot
            foreach (Slot slot in Enum.GetValues(typeof(Slot)))
            {
                inv.Add(slot, new List<Item>());
            }

            InputHandler.inputAction += ReceiveInput;
        }

        void PrintStatus()
        {

        }

        void Move(Direction direction)
        {
            switch (direction)
            {
                case Direction.UP:
                    break;
                case Direction.DOWN:
                    break;
                case Direction.LEFT:
                    break;
                case Direction.RIGHT:
                    break;
            }
        }


        void ReceiveInput(ConsoleKey key)
        {
            PrintStatus();

            Console.WriteLine("Key: " + key);
        }
    }
}
