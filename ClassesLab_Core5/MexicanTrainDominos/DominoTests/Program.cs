using System;
using DominoClasses;

namespace DominoTests
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("--- Testing Domino Class ---");
            TestDominoConstructors();
            TestDominoPropertyGetters();
            TestDominoPropertySetters();
            TestDominoFlip();
            TestDominoScore();
            TestDominoIsDouble();
            TestDominoPropertySettersWithExceptions();
            TestDominoComparison();
            Console.WriteLine("--- Domino Class Tests Completed ---");

            Console.WriteLine("\n--- Testing Boneyard Class ---");
            TestBoneyardConstructor();
            TestBoneyardShuffle();
            TestBoneyardDeal();
            TestBoneyardIndexer();
            Console.WriteLine("--- Boneyard Class Tests Completed ---");

            Console.ReadLine();
        }

        static void TestDominoConstructors()
        {
            Console.WriteLine("\n--- Testing Domino Constructors ---");
            Domino defaultDomino = new Domino();
            Console.WriteLine($"Default constructor: Expected [0|0], Actual: {defaultDomino}");

            Domino customDomino = new Domino(3, 5);
            Console.WriteLine($"Custom constructor (3, 5): Expected [3|5], Actual: {customDomino}");
        }

        static void TestDominoPropertyGetters()
        {
            Console.WriteLine("\n--- Testing Domino Property Getters ---");
            Domino d = new Domino(4, 6);
            Console.WriteLine($"Domino: {d}");
            Console.WriteLine($"Side1: Expected 4, Actual: {d.Side1}");
            Console.WriteLine($"Side2: Expected 6, Actual: {d.Side2}");
        }

        static void TestDominoPropertySetters()
        {
            Console.WriteLine("\n--- Testing Domino Property Setters ---");
            Domino d = new Domino();
            d.Side1 = 7;
            d.Side2 = 9;
            Console.WriteLine($"After setting Side1 to 7 and Side2 to 9: Expected [7|9], Actual: {d}");
        }

        static void TestDominoFlip()
        {
            Console.WriteLine("\n--- Testing Domino Flip ---");
            Domino d = new Domino(1, 6);
            Console.WriteLine($"Before flip: {d}");
            d.Flip();
            Console.WriteLine($"After flip: Expected [6|1], Actual: {d}");
        }

        static void TestDominoScore()
        {
            Console.WriteLine("\n--- Testing Domino Score ---");
            Domino d1 = new Domino(12, 6);
            Console.WriteLine($"Domino: {d1}, Score: Expected 18, Actual: {d1.Score}");
        }

        static void TestDominoIsDouble()
        {
            Console.WriteLine("\n--- Testing Domino IsDouble ---");
            Domino d1 = new Domino(5, 5);
            Domino d2 = new Domino(2, 4);
            Console.WriteLine($"Domino: {d1}, IsDouble: Expected True, Actual: {d1.IsDouble()}");
            Console.WriteLine($"Domino: {d2}, IsDouble: Expected False, Actual: {d2.IsDouble()}");
        }

        static void TestDominoPropertySettersWithExceptions()
        {
            Console.WriteLine("\n--- Testing Domino Property Setters with Exceptions ---");
            Domino d1 = new Domino(10, 10);
            try
            {
                d1.Side1 = 13;
            }
            catch (ArgumentOutOfRangeException ex)
            {
                Console.WriteLine($"Setting Side1 to 13 threw exception: {ex.Message}");
            }
            try
            {
                d1.Side2 = -1;
            }
            catch (ArgumentOutOfRangeException ex)
            {
                Console.WriteLine($"Setting Side2 to -1 threw exception: {ex.Message}");
            }
        }

        static void TestDominoComparison()
        {
            Console.WriteLine("\n--- Testing Domino Comparison ---");
            Domino d1 = new Domino(1, 2);
            Domino d2 = new Domino(2, 1);
            Domino d3 = new Domino(3, 3);
            Domino d4 = new Domino(1, 1);

            Console.WriteLine($"{d1} == {d2}: Expected True, Actual: {d1 == d2}");
            Console.WriteLine($"{d1} != {d3}: Expected True, Actual: {d1 != d3}");
            Console.WriteLine($"{d1} == {d4}: Expected False, Actual: {d1 == d4}");
        }

        static void TestBoneyardConstructor()
        {
            Console.WriteLine("\n--- Testing Boneyard Constructor ---");
            Boneyard b6 = new Boneyard(6);
            Console.WriteLine($"NumDominos (maxDots=6): Expected 28, Actual: {b6.NumDominos}");
            Console.WriteLine($"IsEmpty (maxDots=6): Expected False, Actual: {b6.IsEmpty}");
            Console.WriteLine("ToString (first few dominoes for maxDots=6):\n" + b6.ToString().Substring(0, 100) + "..."); // Print a snippet

            Console.WriteLine("\n--- Testing Boneyard Constructor (maxDots = 0) ---");
            Boneyard b0 = new Boneyard(0);
            Console.WriteLine($"NumDominos (maxDots=0): Expected 1, Actual: {b0.NumDominos}");
            Console.WriteLine($"IsEmpty (maxDots=0): Expected False, Actual: {b0.IsEmpty}");
            Console.WriteLine("ToString (maxDots=0):\n" + b0.ToString());
        }

        static void TestBoneyardShuffle()
        {
            Console.WriteLine("\n--- Testing Boneyard Shuffle ---");
            Boneyard b = new Boneyard(6);
            Console.WriteLine("Before shuffle (first domino): " + b[0]);
            b.Shuffle();
            Console.WriteLine("After shuffle (first domino - should be different): " + b[0]);
        }

        static void TestBoneyardDeal()
        {
            Console.WriteLine("\n--- Testing Boneyard Deal ---");
            Boneyard b = new Boneyard(6);
            int initialCount = b.NumDominos;
            Domino dealtDomino = b.Deal();

            Console.WriteLine($"Dealt Domino: {dealtDomino}");
            Console.WriteLine($"NumDominos after deal: Expected {initialCount - 1}, Actual: {b.NumDominos}");
            Console.WriteLine($"IsEmpty after deal: Expected False, Actual: {b.IsEmpty}");

            while (!b.IsEmpty)
            {
                b.Deal();
            }
            Console.WriteLine($"\nDealt all dominos.");
            Console.WriteLine($"NumDominos: Expected 0, Actual: {b.NumDominos}");
            Console.WriteLine($"IsEmpty: Expected True, Actual: {b.IsEmpty}");
            Console.WriteLine($"Attempt to deal from empty boneyard: Expected null, Actual: {b.Deal() == null}");
        }

        static void TestBoneyardIndexer()
        {
            Console.WriteLine("\n--- Testing Boneyard Indexer ---");
            Boneyard b = new Boneyard(6);
            Console.WriteLine($"Domino at index 0: {b[0]} (Expected [0|0])");
            Console.WriteLine($"Domino at index 5: {b[5]} (Expected [0|5])");

            Domino newDomino = new Domino(10, 10);
            b[0] = newDomino;
            Console.WriteLine($"Domino at index 0 after setting: {b[0]} (Expected [10|10])");

            try
            {
                Domino outOfRange = b[b.NumDominos];
            }
            catch (ArgumentOutOfRangeException ex)
            {
                Console.WriteLine($"Accessing out-of-range index threw exception (get): {ex.Message}");
            }

            try
            {
                b[b.NumDominos] = new Domino(1, 1);
            }
            catch (ArgumentOutOfRangeException ex)
            {
                Console.WriteLine($"Setting out-of-range index threw exception (set): {ex.Message}");
            }
        }
    }
}