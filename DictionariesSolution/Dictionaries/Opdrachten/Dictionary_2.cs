using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dictionaries
{
    enum Weapon
    {
        SCAR_H, M16, SPAS_12, UMP_45, 
    }

    class Dictionary_2
    {
        Dictionary<Weapon, int> dictionary;
        List<Weapon> weapons;

        private Weapon currentWeapon;

        public Dictionary_2()
        {
            dictionary = new Dictionary<Weapon, int>
            {
                { Weapon.SCAR_H, 20 },
                { Weapon.M16, 30 },
                { Weapon.SPAS_12, 8 },
                { Weapon.UMP_45, 25 }
            };

            weapons = new List<Weapon>();
            weapons.AddRange(dictionary.Keys);

            currentWeapon = Weapon.SCAR_H;

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
