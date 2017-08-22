using System;
using System.Collections.Generic;
using System.Linq;


namespace linq_frontier
{
    class Program
    {
        public static int sumOfEarthShips(List<Spaceship> ships)
        {
            var spaceShipsWithoutWarp = ships.Where(w => w.HasWarpDrive == false).Select(s => s.Name).Count();
            Console.WriteLine(spaceShipsWithoutWarp);
            return spaceShipsWithoutWarp;
        }

        public static void sendShipsToFightMonsters(List<Spaceship> ships)
        {
            var fighterShips = ships.Where(w => w.HasWarpDrive).ToList();
            foreach (Spaceship item in fighterShips)
            {
                item.fightSpaceMonster();

            }


        }

        public static Spaceship findMostGunsWithSize(List<Spaceship> ships, int size)
        {
            var biggestStick = ships.Where(s => s.Size == size).OrderByDescending(laser => laser.NumLasers).First();
            return biggestStick;
        }

        public static IEnumerable<Spaceship> ExplorationFleet(List<Spaceship> ships)
        {
            var wimpyShips = ships.Where(h => h.HasWarpDrive).OrderBy(x => x.NumLasers).Take(5).ToList();
            return wimpyShips;
        }

        static void Main(string[] args)
        {
            var testShips = new List<Spaceship>();
            testShips.Add(new Spaceship());
            testShips.Add(new Spaceship());
            testShips.Add(new Spaceship());
            testShips.Add(new Spaceship());
            testShips.Add(new Spaceship());
            testShips.Add(new Spaceship());
            testShips.Add(new Spaceship());
            testShips.Add(new Spaceship());
            testShips.Add(new Spaceship());
            testShips.Add(new Spaceship());

            Console.WriteLine($"Number of ships protecting earth: {sumOfEarthShips(testShips)}");
            sendShipsToFightMonsters(testShips);
            Console.WriteLine($"{findMostGunsWithSize(testShips, 5).Name}");
            foreach (var item in ExplorationFleet(testShips))
            {
                Console.WriteLine($"{item.Name} - Exploration.");
            }


        }
    }
}

