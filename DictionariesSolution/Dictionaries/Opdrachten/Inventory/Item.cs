using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dictionaries.Opdrachten.Inventory
{
    enum ItemType
    {
        STONE, STICK, APPLE
    }

    enum Size
    {
        SMALL, MEDIUM, BIG
    }

    class Item
    {
        public ItemType itemType;
        public Size size;
        public string name
        {
            get { return "" + size.ToString() + " " + itemType.ToString(); }
        }


        public Item(ItemType _itemType, Size _size)
        {
            itemType = _itemType;
            size = _size;
        }
    }
}
