using System;
//Where card definitions are found
using CardClasses;

namespace CardTests
{
    class Program
    {
        static void Main(string[] args)
        {
            //Tests for cards  Entry
            Console.WriteLine("--- Testing Card Class ---");

            TestCardConstructors();
            TestCardPropertyGetters();
            TestCardPropertySetters();
            TestCardPropertySettersWithExceptions();
            TestCardToString();
            TestCardColorAndSuitChecks();
            TestCardRankChecks();
            TestCardComparison();

            Console.WriteLine("--- Card Class Tests Completed ---");
        }

        static void TestCardConstructors()
        {
            //Test constructors
            Console.WriteLine("\n--- Testing Constructors ---");
            Card defaultCard = new Card();
            Console.WriteLine($"Default constructor: Expected Ace of Clubs, Actual: {defaultCard}");

            Card customCard = new Card(10, 3);
            Console.WriteLine($"Custom constructor (10, 3): Expected Ten of Hearts, Actual: {customCard}");

            //Tests invalid values
            try
            {
                Card invalidCardValue = new Card(0, 1);
            }
            catch (ArgumentOutOfRangeException ex)
            {
                Console.WriteLine($"Creating card with invalid value (0) threw exception: {ex.Message}");
            }

            try
            {
                Card invalidCardSuit = new Card(1, 5);
            }
            catch (ArgumentOutOfRangeException ex)
            {
                Console.WriteLine($"Creating card with invalid suit (5) threw exception: {ex.Message}");
            }
        }

        static void TestCardPropertyGetters()
        {
            //Test getters
            Console.WriteLine("\n--- Testing Property Getters ---");
            Card card = new Card(12, 4);
            Console.WriteLine($"Card: {card}");
            Console.WriteLine($"Value: Expected 12, Actual: {card.Value}");
            Console.WriteLine($"Suit: Expected 4, Actual: {card.Suit}");
        }

        static void TestCardPropertySetters()
        {
            //Test setters
            Console.WriteLine("\n--- Testing Property Setters ---");
            Card card = new Card();
            card.Value = 7;
            card.Suit = 2;
            Console.WriteLine($"After setting Value to 7 and Suit to 2: Expected 7 of Diamonds, Actual: {card}");
        }

        static void TestCardPropertySettersWithExceptions()
        {
            //Test setter errors
            Console.WriteLine("\n--- Testing Property Setters with Exceptions ---");
            Card card = new Card(5, 1);

            //Invalid values
            try
            {
                card.Value = 0;
            }
            catch (ArgumentOutOfRangeException ex)
            {
                Console.WriteLine($"Setting invalid Value (0) threw exception: {ex.Message}");
                Console.WriteLine($"Value should still be 5: {card.Value}");
            }

            try
            {
                card.Value = 14;
            }
            catch (ArgumentOutOfRangeException ex)
            {
                Console.WriteLine($"Setting invalid Value (14) threw exception: {ex.Message}");
                Console.WriteLine($"Value should still be 5: {card.Value}");
            }

            //Invalid suits
            try
            {
                card.Suit = 0;
            }
            catch (ArgumentOutOfRangeException ex)
            {
                Console.WriteLine($"Setting invalid Suit (0) threw exception: {ex.Message}");
                Console.WriteLine($"Suit should still be 1: {card.Suit}");
            }

            try
            {
                card.Suit = 5;
            }
            catch (ArgumentOutOfRangeException ex)
            {
                Console.WriteLine($"Setting invalid Suit (5) threw exception: {ex.Message}");
                Console.WriteLine($"Suit should still be 1: {card.Suit}");
            }
        }

        static void TestCardToString()
        {
            //Test to string
            Console.WriteLine("\n--- Testing ToString ---");
            Card aceOfSpades = new Card(1, 4);
            Card queenOfHearts = new Card(12, 3);
            Console.WriteLine($"Ace of Spades: Expected Ace of Spades, Actual: {aceOfSpades}");
            Console.WriteLine($"Queen of Hearts: Expected Queen of Hearts, Actual: {queenOfHearts}");
        }

        //Tests card checks
        static void TestCardColorAndSuitChecks()
        {
            //Test color or suit
            Console.WriteLine("\n--- Testing Color and Suit Checks ---");
            Card club = new Card(2, 1);
            Card diamond = new Card(3, 2);
            Card heart = new Card(4, 3);
            Card spade = new Card(5, 4);

            //Multitesting
            Console.WriteLine($"{club}: IsRed: {club.IsRed()}, IsBlack: {club.IsBlack()}, IsClub: {club.IsClub()}, IsDiamond: {club.IsDiamond()}, IsHeart: {club.IsHeart()}, IsSpade: {club.IsSpade()}");
            Console.WriteLine($"{diamond}: IsRed: {diamond.IsRed()}, IsBlack: {diamond.IsBlack()}, IsClub: {diamond.IsClub()}, IsDiamond: {diamond.IsDiamond()}, IsHeart: {diamond.IsHeart()}, IsSpade: {diamond.IsSpade()}");
            Console.WriteLine($"{heart}: IsRed: {heart.IsRed()}, IsBlack: {heart.IsBlack()}, IsClub: {heart.IsClub()}, IsDiamond: {heart.IsDiamond()}, IsHeart: {heart.IsHeart()}, IsSpade: {heart.IsSpade()}");
            Console.WriteLine($"{spade}: IsRed: {spade.IsRed()}, IsBlack: {spade.IsBlack()}, IsClub: {spade.IsClub()}, IsDiamond: {spade.IsDiamond()}, IsHeart: {spade.IsHeart()}, IsSpade: {spade.IsSpade()}");
        }

        static void TestCardRankChecks()
        {
            //Test type
            Console.WriteLine("\n--- Testing Rank Checks ---");
            Card ace = new Card(1, 1);
            Card jack = new Card(11, 2);
            Card queen = new Card(12, 3);
            Card king = new Card(13, 4);
            Card two = new Card(2, 1);

            //Multitesting
            Console.WriteLine($"{ace}: IsAce: {ace.IsAce()}, IsFaceCard: {ace.IsFaceCard()}");
            Console.WriteLine($"{jack}: IsAce: {jack.IsAce()}, IsFaceCard: {jack.IsFaceCard()}");
            Console.WriteLine($"{queen}: IsAce: {queen.IsAce()}, IsFaceCard: {queen.IsFaceCard()}");
            Console.WriteLine($"{king}: IsAce: {king.IsAce()}, IsFaceCard: {king.IsFaceCard()}");
            Console.WriteLine($"{two}: IsAce: {two.IsAce()}, IsFaceCard: {two.IsFaceCard()}");
        }

        static void TestCardComparison()
            //Test comparisons
        {
            Console.WriteLine("\n--- Testing Card Comparison ---");
            Card card1 = new Card(7, 3);
            Card card2 = new Card(7, 1);
            Card card3 = new Card(10, 3);

            Console.WriteLine($"{card1} SuitMatches {card2}: Expected False, Actual: {card1.SuitMatches(card2)}");
            Console.WriteLine($"{card1} ValueMatches {card2}: Expected True, Actual: {card1.ValueMatches(card2)}");
            Console.WriteLine($"{card1} SuitMatches {card3}: Expected True, Actual: {card1.SuitMatches(card3)}");
            Console.WriteLine($"{card1} ValueMatches {card3}: Expected False, Actual: {card1.ValueMatches(card3)}");
        }
    }
}