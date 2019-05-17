using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dictionaries
{
    class Dictionary_1
    {
        Dictionary<string, int> dictionary;
        List<string> weapons;

        private string currentWeapon;

        public Dictionary_1()
        {
            dictionary = new Dictionary<string, int>
            {
                { "Scar-H", 20 },
                { "M16", 30 },
                { "Spas-12", 8 },
                { "Ump-45", 25 }
            };

            weapons = new List<string>();
            weapons.AddRange(dictionary.Keys);

            currentWeapon = "Scar-H";

            HandleShoot();
        }

        private void HandleShoot()
        {
            while (true)
            {
                ConsoleKey key = Console.ReadKey().Key;
                Console.Clear();

                Console.WriteLine(key.ToString());

                if (key.Equals(ConsoleKey.Escape)) return;

                if (((int)key > 48 && (int) key <= 52))
                {
                    string name = key.ToString().Substring(1);
                    int value = int.Parse(name) - 1;

                    currentWeapon = weapons[value];

                    Console.WriteLine("Switched weapon to: " + currentWeapon);
                }

                if (key.Equals(ConsoleKey.Spacebar))
                {
                    Console.WriteLine("Current weapon: " + currentWeapon);

                    int ammo = dictionary[currentWeapon]--;

                    if (ammo <= 0)
                    {
                        ammo = 0;
                        dictionary[currentWeapon] = ammo;
                        Console.WriteLine("Empty clip!");
                    } else

                    Console.WriteLine("Ammo: " + dictionary[currentWeapon]);
                }
            }
        }
        
    }
}
