using System;
using System.IO;
using System.Linq;

// Day 2: I Was Told There Would Be No Math.
namespace Day02
{
    class Program
    {
        static void Main(string[] args)
        {
            // Parse input.
            var dimensionsLines = File.ReadAllLines("Day02Input.txt");
            var dimensionsList =
                dimensionsLines.
                Select(d => d.Split("x").Select(d2 => int.Parse(d2)).ToArray()).
                ToList();

            // Part 1.
            var totalPaperRequired =
                dimensionsList.
                Select(d => GetPaperRequired(d)).
                Sum();
            Console.WriteLine($"Part 1 answer: {totalPaperRequired}");

            // Part 2.
            var totalRibbonRequired =
                dimensionsList.
                Select(d => GetRibbonRequired(d)).
                Sum();
            Console.WriteLine($"Part 2 answer: {totalRibbonRequired}");
        }

        // Get total wrapping paper needed for a parcel with passed dimensions.
        static int GetPaperRequired(int[] dimensions)
        {
            var (l,w,h) = (dimensions[0], dimensions[1], dimensions[2]);
            var (face1, face2, face3) = (l * w, w * h, h * l);
            var minFaceArea = Math.Min(Math.Min(face1, face2), face3);
            var totalPaper = 2 * face1 + 2 * face2 + 2 * face3 + minFaceArea;
            return totalPaper;
        }

        // Get total ribbon needed for a parcel with passed dimensions.
        static int GetRibbonRequired(int[] dimensions)
        {
            var (l, w, h) = (dimensions[0], dimensions[1], dimensions[2]);
            var (perimeter1, perimeter2, perimiter3) = (2 * (l + w), 2 * (w + h), 2 * (h + l));
            var minPerimeter = Math.Min(Math.Min(perimeter1, perimeter2), perimiter3);
            var totalRibbon = l * w * h + minPerimeter;
            return totalRibbon;
        }
    }
}