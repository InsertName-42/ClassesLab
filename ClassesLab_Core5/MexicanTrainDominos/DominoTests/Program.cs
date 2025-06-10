using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DominoClasses;

namespace DominoTests
{
    internal class TrainTests
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Starting Train Class Tests");

            TestTrainConstructors();
            TestTrainProperties();
            TestTrainAddAndToString();
            TestMexicanTrainPlayable();
            TestPlayerTrainPlayableAndOpenClose();
            TestPlayMethodExceptions();
            TestDominoSorting();
            TestTrainIteration();

            Console.WriteLine("\n All Train Class Tests Completed ");
            Console.ReadLine();
        }

        static void TestTrainConstructors()
        {
            Console.WriteLine("\n Test 1: Train Constructors ");

            //Test default constructor
            Train train1 = new MexicanTrain();
            Console.WriteLine($"Default constructor: Is train empty? Expected: True, Actual: {train1.IsEmpty}");
            Console.WriteLine($"Default constructor: Engine value? Expected: 1, Actual: {train1.EngineValue}");
            Console.WriteLine($"Default constructor: Playable value? Expected: 1, Actual: {train1.PlayableValue}");
            Console.WriteLine($"Default constructor: Count? Expected: 0, Actual: {train1.Count}");
            Console.WriteLine($"Default constructor: ToString? Expected: Engine: [1] - Empty Train, Actual: {train1.ToString()}");


            //Test constructor with value
            Train train2 = new MexicanTrain(6);
            Console.WriteLine($"Constructor with engine value (6): Is train empty? Expected: True, Actual: {train2.IsEmpty}");
            Console.WriteLine($"Constructor with engine value (6): Engine value? Expected: 6, Actual: {train2.EngineValue}");
            Console.WriteLine($"Constructor with engine value (6): Playable value? Expected: 6, Actual: {train2.PlayableValue}");
            Console.WriteLine($"Constructor with engine value (6): Count? Expected: 0, Actual: {train2.Count}");
            Console.WriteLine($"Constructor with engine value (6): ToString? Expected: Engine: [6] - Empty Train, Actual: {train2.ToString()}");
        }

        static void TestTrainProperties()
            //Tests of properties
        {
            Console.WriteLine("\n Test 2: Train Properties ");
            Train train = new MexicanTrain(12);

            Console.WriteLine($"Initial Count: Expected 0, Actual: {train.Count}");
            Console.WriteLine($"Initial IsEmpty: Expected True, Actual: {train.IsEmpty}");
            Console.WriteLine($"Initial EngineValue: Expected 12, Actual: {train.EngineValue}");
            Console.WriteLine($"Initial PlayableValue: Expected 12, Actual: {train.PlayableValue}");
            Console.WriteLine($"Initial LastDomino: Expected null, Actual: {train.LastDomino}");

            Domino d1 = new Domino(12, 5);
            Domino d2 = new Domino(5, 3);
            train.Add(d1);

            Console.WriteLine($"\nAfter adding [12|5]:");
            Console.WriteLine($"Count: Expected 1, Actual: {train.Count}");
            Console.WriteLine($"IsEmpty: Expected False, Actual: {train.IsEmpty}");
            Console.WriteLine($"LastDomino: Expected [12|5], Actual: {train.LastDomino}");
            Console.WriteLine($"PlayableValue: Expected 5, Actual: {train.PlayableValue}");

            train.Add(d2);

            Console.WriteLine($"\nAfter adding [5|3]:");
            Console.WriteLine($"Count: Expected 2, Actual: {train.Count}");
            Console.WriteLine($"LastDomino: Expected [5|3], Actual: {train.LastDomino}");
            Console.WriteLine($"PlayableValue: Expected 3, Actual: {train.PlayableValue}");

            //Test indexer
            Console.WriteLine($"Domino at index 0: Expected [12|5], Actual: {train[0]}");
            Console.WriteLine($"Domino at index 1: Expected [5|3], Actual: {train[1]}");

            try
            {
                Console.WriteLine($"Attempting to access index 2: {train[2]} (Expected ArgumentOutOfRangeException)");
            }
            catch (ArgumentOutOfRangeException ex)
            {
                Console.WriteLine($"Caught expected exception for invalid index: {ex.Message}");
            }
        }

        static void TestTrainAddAndToString()
        {
            Console.WriteLine("\n Test 3: Train Add and ToString ");
            Train train = new MexicanTrain(10);
            Console.WriteLine($"Initial train ToString: {train.ToString()}");

            train.Add(new Domino(10, 10));
            Console.WriteLine($"After adding [10|10]: {train.ToString()}");

            train.Add(new Domino(10, 7));
            Console.WriteLine($"After adding [10|7]: {train.ToString()}");

            train.Add(new Domino(7, 2));
            Console.WriteLine($"After adding [7|2]: {train.ToString()}");
        }

        static void TestMexicanTrainPlayable()
        {
            Console.WriteLine("\n Test 4: MexicanTrain IsPlayable and Play ");
            MexicanTrain mexicanTrain = new MexicanTrain(12);
            Hand hand = new Hand();

            //Test 1: Empty train, first domino must match engine
            //Playable no flip
            Domino d1 = new Domino(12, 5);
            //Playable must flip
            Domino d2 = new Domino(5, 12);
            //Not playable
            Domino d3 = new Domino(10, 8);

            bool mustFlip;

            Console.WriteLine($"Is [12|5] playable on empty MexicanTrain (engine 12)? Expected: True, Actual: {mexicanTrain.IsPlayable(hand, d1, out mustFlip)}, MustFlip: {mustFlip}");
            Console.WriteLine($"Is [5|12] playable on empty MexicanTrain (engine 12)? Expected: True, Actual: {mexicanTrain.IsPlayable(hand, d2, out mustFlip)}, MustFlip: {mustFlip}");
            Console.WriteLine($"Is [10|8] playable on empty MexicanTrain (engine 12)? Expected: False, Actual: {mexicanTrain.IsPlayable(hand, d3, out mustFlip)}, MustFlip: {mustFlip}");

            //Play the first domino
            hand.Add(d1);
            mexicanTrain.Play(hand, d1);
            Console.WriteLine($"\nPlayed [12|5]. Train: {mexicanTrain.ToString()} (PlayableValue: {mexicanTrain.PlayableValue})");
            Console.WriteLine($"Hand after play: {hand.ToString()}");

            //Test 2: Train not empty, domino must match PlayableValue
            // Playable, no flip
            Domino d4 = new Domino(5, 1);
            //Playable, must flip
            Domino d5 = new Domino(0, 5);
            //Not playable
            Domino d6 = new Domino(1, 2);

            hand.Add(d4);
            hand.Add(d5);
            hand.Add(d6);

            Console.WriteLine($"\nHand before next plays: {hand.ToString()}");

            Console.WriteLine($"Is [5|1] playable on MexicanTrain (playable value 5)? Expected: True, Actual: {mexicanTrain.IsPlayable(hand, d4, out mustFlip)}, MustFlip: {mustFlip}");
            mexicanTrain.Play(hand, d4);
            Console.WriteLine($"Played [5|1]. Train: {mexicanTrain.ToString()} (PlayableValue: {mexicanTrain.PlayableValue})");
            Console.WriteLine($"Hand after play: {hand.ToString()}");

            Console.WriteLine($"Is [0|5] playable on MexicanTrain (playable value 1)? Expected: False, Actual: {mexicanTrain.IsPlayable(hand, d5, out mustFlip)}, MustFlip: {mustFlip}"); // Playable value is now 1
            //Flipped for the current playable value
            //Playable must flip
            Domino d7 = new Domino(8, 1);
            hand.Add(d7);
            Console.WriteLine($"Is [8|1] playable on MexicanTrain (playable value 1)? Expected: True, Actual: {mexicanTrain.IsPlayable(hand, d7, out mustFlip)}, MustFlip: {mustFlip}");
            mexicanTrain.Play(hand, d7);
            Console.WriteLine($"Played [8|1] (flipped). Train: {mexicanTrain.ToString()} (PlayableValue: {mexicanTrain.PlayableValue})");
            Console.WriteLine($"Hand after play: {hand.ToString()}");
        }

        static void TestPlayerTrainPlayableAndOpenClose()
        {
            Console.WriteLine("\n Test 5: PlayerTrain IsPlayable, Open, Close ");
            Hand playerHand = new Hand();
            Hand otherHand = new Hand();
            PlayerTrain playerTrain = new PlayerTrain(playerHand, 12);

            //Playable on empty train
            Domino d1 = new Domino(12, 6);
            //Playable on 6
            Domino d2 = new Domino(6, 1);
            //Not playable
            Domino d3 = new Domino(5, 5);
            playerHand.Add(d1);
            playerHand.Add(d2);
            playerHand.Add(d3);

            Domino d_other = new Domino(12, 3);
            otherHand.Add(d_other);

            bool mustFlip;

            Console.WriteLine($"PlayerTrain initial state: IsOpen={playerTrain.IsOpen}, Train: {playerTrain.ToString()}");
            Console.WriteLine($"Player Hand: {playerHand.ToString()}");
            Console.WriteLine($"Other Hand: {otherHand.ToString()}");

            //Empty train, player's hand
            Console.WriteLine($"\n--- Empty train, player's own hand ---");
            Console.WriteLine($"Is [12|6] from playerHand playable? Expected: True, Actual: {playerTrain.IsPlayable(playerHand, d1, out mustFlip)}, MustFlip: {mustFlip}");
            playerTrain.Play(playerHand, d1);
            Console.WriteLine($"Played [12|6]. Train: {playerTrain.ToString()} (PlayableValue: {playerTrain.PlayableValue})");
            Console.WriteLine($"Player Hand: {playerHand.ToString()}");

            //Train not empty, player's hand, train is closed
            Console.WriteLine($"\n--- Train not empty, player's own hand, train closed ---");
            Console.WriteLine($"Is [6|1] from playerHand playable? Expected: True, Actual: {playerTrain.IsPlayable(playerHand, d2, out mustFlip)}, MustFlip: {mustFlip}");
            playerTrain.Play(playerHand, d2);
            Console.WriteLine($"Played [6|1]. Train: {playerTrain.ToString()} (PlayableValue: {playerTrain.PlayableValue})");
            Console.WriteLine($"Player Hand: {playerHand.ToString()}");

            //Other hand, train is closed
            Console.WriteLine($"\n--- Other hand, train closed ---");
            Console.WriteLine($"Is [12|3] from otherHand playable? Expected: False, Actual: {playerTrain.IsPlayable(otherHand, d_other, out mustFlip)}, MustFlip: {mustFlip}");

            //Other hand, train is open
            Console.WriteLine($"\n--- Other hand, train open ---");
            playerTrain.Open();
            Console.WriteLine($"PlayerTrain state after Open(): IsOpen={playerTrain.IsOpen}");
            Domino d_other_playable = new Domino(1, 9);
            otherHand.Add(d_other_playable);
            Console.WriteLine($"Other Hand (with new playable): {otherHand.ToString()}");
            Console.WriteLine($"Is [1|9] from otherHand playable? Expected: True, Actual: {playerTrain.IsPlayable(otherHand, d_other_playable, out mustFlip)}, MustFlip: {mustFlip}");
            playerTrain.Play(otherHand, d_other_playable);
            Console.WriteLine($"Played [1|9] by otherHand. Train: {playerTrain.ToString()} (PlayableValue: {playerTrain.PlayableValue})");
            Console.WriteLine($"Other Hand after play: {otherHand.ToString()}");

            //Reclose train
            Console.WriteLine($"\n--- Close train ---");
            playerTrain.Close();
            Console.WriteLine($"PlayerTrain state after Close(): IsOpen={playerTrain.IsOpen}");
            Domino d_other_unplayable = new Domino(9, 0);
            otherHand.Add(d_other_unplayable);
            Console.WriteLine($"Other Hand (with new unplayable): {otherHand.ToString()}");
            Console.WriteLine($"Is [9|0] from otherHand playable? Expected: False, Actual: {playerTrain.IsPlayable(otherHand, d_other_unplayable, out mustFlip)}, MustFlip: {mustFlip}");
        }

        static void TestPlayMethodExceptions()
        {
            Console.WriteLine("\n Test 6: Play Method Exception Handling ");
            MexicanTrain mexicanTrain = new MexicanTrain(7);
            Hand hand = new Hand();

            Domino d1 = new Domino(1, 2);
            hand.Add(d1);

            Console.WriteLine($"Train: {mexicanTrain.ToString()}");
            Console.WriteLine($"Hand: {hand.ToString()}");

            try
            {
                Console.WriteLine($"Attempting to play [1|2] (not playable)...\n");
                mexicanTrain.Play(hand, d1);
                Console.WriteLine("Error: Play method did not throw an exception for unplayable domino.\n");
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine($"Caught expected exception: {ex.Message}\n");
                Console.WriteLine($"Train after failed play (should be unchanged): {mexicanTrain.ToString()}\n");
                Console.WriteLine($"Hand after failed play (should be unchanged): {hand.ToString()}\n");
            }

            Domino d2 = new Domino(7, 7);
            hand.Add(d2);
            Console.WriteLine($"\nHand with playable domino: {hand.ToString()}\n");
            try
            {
                Console.WriteLine($"Attempting to play [7|7] (playable)...\n");
                mexicanTrain.Play(hand, d2);
                Console.WriteLine($"Successfully played [7|7]. Train: {mexicanTrain.ToString()}\n");
                Console.WriteLine($"Hand after successful play: {hand.ToString()}\n");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: Play method threw unexpected exception for playable domino: {ex.Message}\n");
            }
        }

        static void TestDominoSorting()
        {
            Console.WriteLine("\n Test 7: Domino Sorting (IComparable<Domino>) ");

            List<Domino> dominos = new List<Domino>
            {
                new Domino(1, 2),
                new Domino(6, 6),
                new Domino(0, 0),
                new Domino(3, 4),
                new Domino(1, 1)
            };

            Console.WriteLine("Original list of dominos:");
            foreach (var d in dominos)
            {
                Console.Write($"{d.ToString()} (Score: {d.Score}) ");
            }
            Console.WriteLine();

            //CompareTo method
            dominos.Sort();

            Console.WriteLine("\nSorted list of dominos (by Score):");
            foreach (var d in dominos)
            {
                Console.Write($"{d.ToString()} (Score: {d.Score}) ");
            }
            Console.WriteLine();

            //Expected order: [0|0] (0), [1|1] (2), [1|2] (3), [3|4] (7), [6|6] (12)
        }

        static void TestTrainIteration()
        {
            Console.WriteLine("\n Test 8: Train Iteration (IEnumerable<Domino>) ");

            MexicanTrain mexicanTrain = new MexicanTrain(12);
            Hand hand = new Hand();
            Domino d1 = new Domino(12, 5);
            Domino d2 = new Domino(5, 3);
            Domino d3 = new Domino(3, 3);

            hand.Add(d1);
            hand.Add(d2);
            hand.Add(d3);

            //[12|5]
            mexicanTrain.Play(hand, d1);
            //[12|5] [5|3]
            mexicanTrain.Play(hand, d2);
            //[12|5] [5|3] [3|3]
            mexicanTrain.Play(hand, d3);

            Console.WriteLine($"\nIterating through MexicanTrain: {mexicanTrain.ToString()}");
            Console.Write("Dominos in train using foreach: ");
            foreach (Domino d in mexicanTrain)
            {
                Console.Write($"{d.ToString()} ");
            }
            Console.WriteLine();

            PlayerTrain playerTrain = new PlayerTrain(new Hand(), 10);
            Domino p1 = new Domino(10, 0);
            Domino p2 = new Domino(0, 10);
            playerTrain.Add(p1);
            playerTrain.Add(p2);

            Console.WriteLine($"\nIterating through PlayerTrain: {playerTrain.ToString()}");
            Console.Write("Dominos in train using foreach: ");
            foreach (Domino d in playerTrain)
            {
                Console.Write($"{d.ToString()} ");
            }
            Console.WriteLine();
        }
    }
}