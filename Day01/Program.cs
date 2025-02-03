using System;
using System.IO;

// Day 1: Not Quite Lisp.
namespace Day01
{
    class Program
    {
        static void Main(string[] args)
        {
            var directions = File.ReadAllText("Day01Input.txt");

            // Part 1.
            var floor = 0;
            foreach (var direction in directions)            
                floor += direction == '(' ? 1 : -1;            
            Console.WriteLine($"Part 1 answer: {floor}");

            // Part 2.
            floor = 0;
            var position = 0;
            while (floor > -1)
            {                
                floor += directions[position] == '(' ? 1 : -1;
                position++;
            }
            Console.WriteLine($"Part 2 answer: {position}");
        }
    }
}
