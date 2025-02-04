using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

// Day 3: Perfectly Spherical Houses in a Vacuum.
namespace Day03
{
    class Program
    {
        static void Main(string[] args)
        {
            var directions = File.ReadAllText("Day03Input.txt");

            // Part 1.
            var position = (0, 0);
            var visitedPositions = new Dictionary<(int, int), int>();
            visitedPositions.Add(position, 1);
            for (var i = 0; i < directions.Length; i++)
            {
                var direction = directions[i];
                position = Move(direction, position);
                AddVisitedPosition(position, visitedPositions);            
            }
            Console.WriteLine($"Part 1 answer: {visitedPositions.Count()}");

            // Part 2.
            var santaPosition = (0, 0);
            var roboSantaPosition = (0, 0);
            visitedPositions.Clear();
            visitedPositions.Add(santaPosition, 2);
            for (var i = 0; i < directions.Length; i += 2)
            {
                var (santaDirection, roboSantaDirection) = (directions[i], directions[i + 1]);
                santaPosition = Move(santaDirection, santaPosition);
                AddVisitedPosition(santaPosition, visitedPositions);
                roboSantaPosition = Move(roboSantaDirection, roboSantaPosition);                
                AddVisitedPosition(roboSantaPosition, visitedPositions);                
            }
            Console.WriteLine($"Part 2 answer: {visitedPositions.Count()}");
        }

        // Add position to visited dictionary.
        static void AddVisitedPosition((int, int) position, Dictionary<(int,int), int> visitedPositions)
        {
            if (!visitedPositions.ContainsKey(position))
                visitedPositions.Add(position, 0);
            visitedPositions[position]++;
        }

        // Move elf in a given direction relative to current position.
        static (int, int) Move(char direction, (int, int) position)
        {            
            switch (direction)
            {
                case '>':
                    position = (position.Item1 + 1, position.Item2);
                    break;
                case '<':
                    position = (position.Item1 - 1, position.Item2);
                    break;
                case '^':
                    position = (position.Item1, position.Item2 - 1);
                    break;
                case 'v':
                    position = (position.Item1, position.Item2 + 1);
                    break;
            }
            return position;
        }
    }
}