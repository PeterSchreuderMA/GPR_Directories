using Dictionaries.Opdrachten.Inventory.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dictionaries.Opdrachten.Inventory;

namespace Dictionaries.Opdrachten.Inventory
{
    class Level
    {
        private string[,] level = new string[20, 20];
        /*{
            { "#", "#", "#", "#", "#", "#", "#", "#", "#", "#", "#", "#", "#", "#", "#", "#", "#", "#", "#", "#" },
            { "#", "#", "#", "#", "#", "#", "#", "#", "#", "#", "#", "#", "#", "#", "#", "#", "#", "#", "#", "#" },
            { "#", "#", "#", "#", "#", "#", "#", "#", "#", "#", "#", "#", "#", "#", "#", "#", "#", "#", "#", "#" },
            { "#", "#", "#", "#", "#", "#", "#", "#", "#", "#", "#", "#", "#", "#", "#", "#", "#", "#", "#", "#" },
            { "#", "#", "#", "#", "#", "#", "#", "#", "#", "#", "#", "#", "#", "#", "#", "#", "#", "#", "#", "#" },
            { "#", "#", "#", "#", "#", "#", "#", "#", "#", "#", "#", "#", "#", "#", "#", "#", "#", "#", "#", "#" },
            { "#", "#", "#", "#", "#", "#", "#", "#", "#", "#", "#", "#", "#", "#", "#", "#", "#", "#", "#", "#" },
            { "#", "#", "#", "#", "#", "#", "#", "#", "#", "#", "#", "#", "#", "#", "#", "#", "#", "#", "#", "#" },
            { "#", "#", "#", "#", "#", "#", "#", "#", "#", "#", "#", "#", "#", "#", "#", "#", "#", "#", "#", "#" },
            { "#", "#", "#", "#", "#", "#", "#", "#", "#", "#", "#", "#", "#", "#", "#", "#", "#", "#", "#", "#" },
            { "#", "#", "#", "#", "#", "#", "#", "#", "#", "#", "#", "#", "#", "#", "#", "#", "#", "#", "#", "#" },
            { "#", "#", "#", "#", "#", "#", "#", "#", "#", "#", "#", "#", "#", "#", "#", "#", "#", "#", "#", "#" },
            { "#", "#", "#", "#", "#", "#", "#", "#", "#", "#", "#", "#", "#", "#", "#", "#", "#", "#", "#", "#" },
            { "#", "#", "#", "#", "#", "#", "#", "#", "#", "#", "#", "#", "#", "#", "#", "#", "#", "#", "#", "#" },
            { "#", "#", "#", "#", "#", "#", "#", "#", "#", "#", "#", "#", "#", "#", "#", "#", "#", "#", "#", "#" },
            { "#", "#", "#", "#", "#", "#", "#", "#", "#", "#", "#", "#", "#", "#", "#", "#", "#", "#", "#", "#" },
            { "#", "#", "#", "#", "#", "#", "#", "#", "#", "#", "#", "#", "#", "#", "#", "#", "#", "#", "#", "#" },
            { "#", "#", "#", "#", "#", "#", "#", "#", "#", "#", "#", "#", "#", "#", "#", "#", "#", "#", "#", "#" },
            { "#", "#", "#", "#", "#", "#", "#", "#", "#", "#", "#", "#", "#", "#", "#", "#", "#", "#", "#", "#" },
            { "#", "#", "#", "#", "#", "#", "#", "#", "#", "#", "#", "#", "#", "#", "#", "#", "#", "#", "#", "#" }
        };*/

        private Dictionary<Position, Item> levelItems;

        private Position currentPosition = new Position(1, 1);

        /// <summary>
        /// Builds the level
        /// </summary>
        /// <param name="_sizeX"></param>
        /// <param name="_sizeY"></param>
        public void LevelBoot(int _sizeX, int _sizeY)
        {
            currentPosition = new Position(2, 2);

            for (int _x = 0; _x < _sizeX; _x++)
            {
                for (int _y = 0; _y < _sizeY; _y++)
                {
                    if (_y == 0 || _x == 0 || _y == _sizeY -1 || _x == _sizeX -1)
                        level[_y, _x] = "# ";
                    else
                        level[_y, _x] = "  ";

                }
            }
        }

        /// <summary>
        /// Shows the level as a string
        /// </summary>
        /// <param name="_playerPos"></param>
        /// <returns></returns>
        public string LevelShow(Position _playerPos)
        {
            string _return = "";

            int _sizeX = level.GetLength(0);
            int _sizeY = level.GetLength(1);

            for (int _x = 0; _x < _sizeX; _x++)
            {
                for (int _y = 0; _y < _sizeY; _y++)
                {
                    string _arrayVal = level[_x, _y];

                    if (_playerPos.x == _y && _playerPos.y == _x)
                    {
                        _return += "8 ";
                    }
                    else if (Program.inventory.ItemLevelIsAtPosition(new Position(_x, _y)))
                    {
                        _return += "+ ";
                    }
                    else
                    {
                        _return += _arrayVal;
                    }
                }

                Console.WriteLine(_return);
                _return = "";
            }


            return _return;
        }
    }
}
