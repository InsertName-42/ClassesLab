using CardClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardTests
{
    internal class BlackjackTests
    {
        static void Main(string[] args)
        {
            Console.WriteLine("--- Starting BlackJackHand Class Tests ---");

            //Test Default Constructor and IsEmpty property
            Console.WriteLine("\n--- Test 1: Default Constructor and IsEmpty ---");
            BlackJackHand emptyHand = new BlackJackHand();
            Console.WriteLine($"Is newly created hand empty? Expected: True, Actual: {emptyHand.IsEmpty}");
            Console.WriteLine($"Number of cards in empty hand: Expected: 0, Actual: {emptyHand.NumCards}");
            Console.WriteLine($"ToString() of empty hand:\n{emptyHand.ToString()}");

            //Test Constructor with Deck and numCards
            Console.WriteLine("\n--- Test 2: Constructor with Deck and numCards ---");
            //Create a new deck
            Deck testDeck = new Deck();
            //Shuffle the deck for randomness
            testDeck.Shuffle();
            BlackJackHand initialHand = new BlackJackHand(testDeck, 2);
            Console.WriteLine($"Number of cards in initial hand after dealing 2: Expected: 2, Actual: {initialHand.NumCards}");
            Console.WriteLine($"Initial hand details:\n{initialHand.ToString()}");

            //Test HasAce() method
            Console.WriteLine("\n--- Test 3: HasAce() ---");
            BlackJackHand handWithAce = new BlackJackHand();
            handWithAce.Add(new Card(1, 1));
            handWithAce.Add(new Card(5, 2));
            Console.WriteLine($"Hand details:\n{handWithAce.ToString()}");
            Console.WriteLine($"Does handWithAce have an Ace? Expected: True, Actual: {handWithAce.HasAce()}");

            BlackJackHand handWithoutAce = new BlackJackHand();
            handWithoutAce.Add(new Card(10, 1));
            handWithoutAce.Add(new Card(7, 2));
            Console.WriteLine($"Hand details:\n{handWithoutAce.ToString()}");
            Console.WriteLine($"Does handWithoutAce have an Ace? Expected: False, Actual: {handWithoutAce.HasAce()}");

            // Test GetScore() method
            Console.WriteLine("\n--- Test 4: GetScore() ---");

            //Hand with no aces
            BlackJackHand scoreTestHand1 = new BlackJackHand();
            scoreTestHand1.Add(new Card(10, 1));
            scoreTestHand1.Add(new Card(2, 2));
            Console.WriteLine($"Hand details:\n{scoreTestHand1.ToString()}");
            Console.WriteLine($"Score for (Ten + Two): Expected: 12, Actual: {scoreTestHand1.GetScore()}");

            //Hand with one Ace and a face card
            BlackJackHand scoreTestHand2 = new BlackJackHand();
            scoreTestHand2.Add(new Card(1, 1));
            scoreTestHand2.Add(new Card(11, 2));
            Console.WriteLine($"Hand details:\n{scoreTestHand2.ToString()}");
            Console.WriteLine($"Score for (Ace + Jack, Ace as 11): Expected: 21, Actual: {scoreTestHand2.GetScore()}");

            //Test IsBusted() method
            Console.WriteLine("\n--- Test 5: IsBusted() ---");

            //Hand that is busted
            BlackJackHand bustedHand = new BlackJackHand();
            bustedHand.Add(new Card(10, 1));
            bustedHand.Add(new Card(5, 2));
            bustedHand.Add(new Card(8, 3));
            Console.WriteLine($"Hand details:\n{bustedHand.ToString()}");
            Console.WriteLine($"Is hand busted (10 + 5 + 8 = 23)? Expected: True, Actual: {bustedHand.IsBusted()}");

            //Hand that is not busted
            BlackJackHand notBustedHand = new BlackJackHand();
            notBustedHand.Add(new Card(7, 1));
            notBustedHand.Add(new Card(8, 2));
            Console.WriteLine($"Hand details:\n{notBustedHand.ToString()}");
            Console.WriteLine($"Is hand busted (7 + 8 = 15)? Expected: False, Actual: {notBustedHand.IsBusted()}");
            
            Console.WriteLine("\nAll BlackJackHand Class Tests Completed");
        }
    }
}