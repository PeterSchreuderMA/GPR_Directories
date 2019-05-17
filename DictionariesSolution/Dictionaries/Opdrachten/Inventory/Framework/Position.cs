using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dictionaries.Opdrachten.Inventory.Framework
{
    class Position
    {
        public int x, y;

        public Position(int _x, int _y)
        {
            x = _x;
            y = _y;
        }

        public Position() : this(0, 0)
        {
        }

        public void Add(int _x, int _y)
        {
            x += _x;
            y += _y;

            if (x < 1)
                x = 1;
            else if (x > 19 - 1)
                x = 19 - 1;

            if (y < 1)
                y = 1;
            else if (y > 19 - 1)
                y = 19 - 1;





        }

        public void Add(Position position)
        {
            Add(position.x, position.y);
        }

        public void Remove(int _x, int _y)
        {
            x -= _x;
            y -= _y;
        }

        public void Remove(Position position)
        {
            Remove(position.x, position.y);
        }
    }
}
