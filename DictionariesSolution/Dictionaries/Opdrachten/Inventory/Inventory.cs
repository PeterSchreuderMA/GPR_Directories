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
        private Dictionary<Slot, List<Item>> inv;

        private Dictionary<Position, Item> levelItems;

        private Position currentPosition;

        private Item pickedUp;

        public Inventory()
        {
            currentPosition = new Position();
            inv = new Dictionary<Slot, List<Item>>();
            levelItems = new Dictionary<Position, Item>();

            // Creates a new list for every slot
            foreach (Slot slot in Enum.GetValues(typeof(Slot)))
            {
                inv.Add(slot, new List<Item>());
            }

            SpawnItems();

            InputHandler.inputAction += ReceiveInput;
        }

        Item GetLevelItem(Position position)
        {

            foreach (Position pos in levelItems.Keys)
            {
                if (pos.x == position.x && pos.y == position.y) return levelItems[pos];
            }

            return null;

        }

        void RemoveLevelItem(Position position)
        {

            foreach (Position pos in levelItems.Keys)
            {
                if (pos.x == position.x && pos.y == position.y) { levelItems.Remove(pos); return; }
            }

        }


        void SpawnItems()
        {
            int length = 10;

            while (length > 0)
            {
                int x = RandomNumber(-10, 10);

                int y = RandomNumber(-10, 10);

                Position pos = new Position(x, y);

                if (GetLevelItem(pos) != null) continue;

                Item item = RandomItem();

                levelItems.Add(pos, item);

                Console.WriteLine("Position: (" + pos.x + ", " + pos.y + ") Item: " + item.name);
                length--;
            }
        }

        Item RandomItem()
        {
            Array sizeValues = Enum.GetValues(typeof(Size));
            Random random = new Random();
            Size randomSize = (Size)sizeValues.GetValue(random.Next(sizeValues.Length));

            Array typeValues = Enum.GetValues(typeof(ItemType));
            Random random1 = new Random();
            ItemType randomType = (ItemType) typeValues.GetValue(random1.Next(typeValues.Length));

            return new Item(randomType, randomSize);
        }

        private int RandomNumber(int min, int max)
        {
            Random random = new Random();
            return random.Next(min, max);
        }

        void Move(Direction direction)
        {

            switch (direction)
            {
                case Direction.UP:
                    currentPosition.Add(0, 1);
                    break;
                case Direction.DOWN:
                    currentPosition.Add(0, -1);
                    break;
                case Direction.LEFT:
                    currentPosition.Add(-1, 0);
                    break;
                case Direction.RIGHT:
                    currentPosition.Add(1, 0);
                    break;
            }
        }

        private void PickUp()
        {
            if (GetLevelItem(currentPosition) == null)
            {
                // TODO Write warning
                return;
            }

            Item item = GetItemStandingOn();

            //Adds picked up item to inventory
            AddItemToInventory(item);

            //Removes position with picked up item;
            RemoveLevelItem(currentPosition);

            //TODO Write item picked up!
        }

        private void AddItemToInventory(Item item)
        {
            pickedUp = item;
            foreach (Slot slot in inv.Keys)
            {
                List<Item> itemList = inv[slot];

                if (itemList.Count == 0)
                {
                    itemList.Add(item);
                    return;
                }

                if (itemList[0].itemType == item.itemType)
                {
                    itemList.Add(item);
                    return;
                }
            }
        }

        private string ItemsToString(Slot slot)
        {
            List<Item> items = inv[slot];

            string line = "";

            for (int i = 0; i < items.Count; i++)
            {
                Item item = items[i];

                if (i == 0)
                    line += item.name;
                else
                    line += ", " + item.name;
            }

            if (line.Length == 0)
            {
                line = "[empty]";
            }

            return line;
        }

        private List<string> InventoryToString()
        {
            List<string> list = new List<string>();

            foreach (Slot slot in inv.Keys)
            {
                list.Add(slot.ToString() + ": " + ItemsToString(slot));
            }

            return list;
        }

        private Item GetItemStandingOn()
        {
            return GetLevelItem(currentPosition);
        }

        void ReceiveInput(ConsoleKey key)
        {
            pickedUp = null;
            switch (key)
            {
                    case ConsoleKey.W: case ConsoleKey.UpArrow:
                    Move(Direction.UP);
                    break;

                case ConsoleKey.A: case ConsoleKey.LeftArrow:
                    Move(Direction.LEFT);
                    break;

                case ConsoleKey.D: case ConsoleKey.RightArrow:
                    Move(Direction.RIGHT);
                    break;

                case ConsoleKey.S: case ConsoleKey.DownArrow:
                    Move(Direction.DOWN);
                    break;

                case ConsoleKey.E: case ConsoleKey.F:
                    PickUp();
                    break;
            }

            Console.WriteLine("CurrentPosition: " + "(" + currentPosition.x + ", " + currentPosition.y + ")");

            foreach (string line in InventoryToString())
            {
                Console.WriteLine(line);
            }


            Item currentItem = GetItemStandingOn();
            if (currentItem == null)
                Console.WriteLine("Current item: NONE");
            else
                Console.WriteLine("Current item: " + currentItem.name);

            if (pickedUp == null)
                Console.WriteLine("Picked up item: NONE");
            else
                Console.WriteLine("Picked up item: " + pickedUp.name);
        }
    }
}
