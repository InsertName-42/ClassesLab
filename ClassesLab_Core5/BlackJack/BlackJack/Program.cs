using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CardClasses;

namespace BlackJack
{
    class Program
    {
        //Global win variables
        static int playerWins = 0;
        static int dealerWins = 0;

        static void Main(string[] args)
        {
            Console.WriteLine("Play Blackjack!");
            //Round logic
            bool playAgain = true;
            while (playAgain)
            {
                PlayHand();
                Console.WriteLine($"Current Score: Player Wins: {playerWins} | Dealer Wins: {dealerWins}");

                Console.Write("\nDo you want to play another hand? (yes/no): ");
                string response = Console.ReadLine().ToLower().Trim();
                playAgain = (response == "yes" || response == "y");
                //Reset
                Console.Clear();
            }

            Console.WriteLine($"Final Score: Player Wins: {playerWins} | Dealer Wins: {dealerWins}");
            Console.ReadLine();
        }

        static void PlayHand()
        {
            Console.WriteLine("\n Starting New Hand");

            //Create objects
            Deck gameDeck = new Deck();
            BlackJackHand playerHand = new BlackJackHand();
            BlackJackHand dealerHand = new BlackJackHand();

            //Shuffle the deck
            gameDeck.Shuffle();
            Console.WriteLine("Deck shuffled.");

            //Deal initial cards
            //Player gets 2 cards
            playerHand.Add(gameDeck.Deal());
            playerHand.Add(gameDeck.Deal());

            //Dealer gets 2 cards
            dealerHand.Add(gameDeck.Deal());
            dealerHand.Add(gameDeck.Deal());

            Console.WriteLine("\nInitial Deal");
            DisplayHands(playerHand, dealerHand, hideDealerFirstCard: true);

            //Immediate Blackjacks
            if (playerHand.GetScore() == 21 && dealerHand.GetScore() == 21)
            {
                Console.WriteLine("Both player and dealer have Blackjack!");
                DisplayHands(playerHand, dealerHand, hideDealerFirstCard: false);
                return;
            }
            else if (playerHand.GetScore() == 21)
            {
                Console.WriteLine("You have a Blackjack! You win!");
                playerWins++;
                DisplayHands(playerHand, dealerHand, hideDealerFirstCard: false);
                return;
            }
            else if (dealerHand.GetScore() == 21)
            {
                Console.WriteLine("Dealer has a Blackjack! Dealer wins!");
                dealerWins++;
                DisplayHands(playerHand, dealerHand, hideDealerFirstCard: false);
                return;
            }

            //Player's turn
            PlayerTurn(playerHand, gameDeck);
            if (playerHand.IsBusted())
            {
                Console.WriteLine("\nBusted! Dealer wins!");
                dealerWins++;
                DisplayHands(playerHand, dealerHand, hideDealerFirstCard: false);
                return;
            }

            //Dealer's turn
            DealerTurn(dealerHand, gameDeck);
            if (dealerHand.IsBusted())
            {
                Console.WriteLine("\nDealer Busted! Player wins!");
                playerWins++;
                DisplayHands(playerHand, dealerHand, hideDealerFirstCard: false); // Reveal dealer's hand
                return;
            }

            //Determine winner if no one busted
            DetermineWinner(playerHand, dealerHand);
        }


        static void PlayerTurn(BlackJackHand playerHand, Deck gameDeck)
        {
            Console.WriteLine("\nPlayer's Turn");
            bool playerContinues = true;
            while (playerContinues && !playerHand.IsBusted())
            {
                Console.WriteLine("\nYour hand:");
                Console.WriteLine(playerHand.ToString());
                Console.WriteLine($"Your current score: {playerHand.GetScore()}");

                Console.Write("Do you want to HIT or STAND? (H/S): ");
                string choice = Console.ReadLine().ToLower().Trim();

                if (choice == "h" || choice == "hit")
                {
                    Card newCard = gameDeck.Deal();
                    if (newCard != null)
                    {
                        playerHand.Add(newCard);
                        Console.WriteLine($"You got: {newCard.ToString()}");
                        //Checks for a bust
                        if (playerHand.IsBusted())
                        {
                            Console.WriteLine($"Your hand is now: {playerHand.ToString()}");
                            Console.WriteLine($"Your score: {playerHand.GetScore()}");
                            Console.WriteLine("You busted!");
                            playerContinues = false;
                        }
                    }
                    else
                    {
                        Console.WriteLine("The deck is empty! Cannot draw more cards.");
                        playerContinues = false;
                    }
                }
                else if (choice == "s" || choice == "stand")
                {
                    Console.WriteLine("Good luck.");
                    playerContinues = false;
                }
                else
                {
                    Console.WriteLine("Invalid input. Please type 'H' for HIT or 'S' for STAND.");
                }
            }
        }


        static void DealerTurn(BlackJackHand dealerHand, Deck gameDeck)
        {
            Console.WriteLine("\nDealer's Turn");
            Console.WriteLine("Dealer's hidden card is revealed!");
            //Reveal dealer's hand
            DisplayHands(null, dealerHand, hideDealerFirstCard: false);
            //Hit/Stand logic checks if score is 16
            while (dealerHand.GetScore() < 17 && !dealerHand.IsBusted())
            {
                Console.WriteLine("Dealer hits.");
                Card newCard = gameDeck.Deal();
                if (newCard != null)
                {
                    dealerHand.Add(newCard);
                    Console.WriteLine($"Dealer hit and got: {newCard.ToString()}");
                    //Update hand
                    DisplayHands(null, dealerHand, hideDealerFirstCard: false);
                }
                else
                {
                    Console.WriteLine("The deck is empty! Dealer cannot draw more cards.");
                    break;
                }
            }

            if (dealerHand.IsBusted())
            {
                Console.WriteLine("Dealer busted!");
            }
            else
            {
                Console.WriteLine($"Dealer stands with a score of {dealerHand.GetScore()}.");
            }
        }


        static void DetermineWinner(BlackJackHand playerHand, BlackJackHand dealerHand)
        {
            Console.WriteLine("\n--- Final Results ---");
            DisplayHands(playerHand, dealerHand, hideDealerFirstCard: false);
            //Get scores
            int playerScore = playerHand.GetScore();
            int dealerScore = dealerHand.GetScore();
            //Display scores
            Console.WriteLine($"Player's Final Score: {playerScore}");
            Console.WriteLine($"Dealer's Final Score: {dealerScore}");
            //Determines winner
            if (playerScore > dealerScore)
            {
                Console.WriteLine("Player wins this hand!");
                playerWins++;
            }
            else if (dealerScore > playerScore)
            {
                Console.WriteLine("Dealer wins this hand!");
                dealerWins++;
            }
            else
            {
                Console.WriteLine("It's a Tie!");
            }
        }

       
        static void DisplayHands(BlackJackHand playerHand, BlackJackHand dealerHand, bool hideDealerFirstCard)
        {
            if (playerHand != null)
            {
                Console.WriteLine("\nYour Hand");
                Console.WriteLine(playerHand.ToString());
                Console.WriteLine($"Your Score: {playerHand.GetScore()}");
            }

            Console.WriteLine("\nDealer's Hand");
            if (hideDealerFirstCard && dealerHand.NumCards > 0)
            {
                //Displays the first card as hidden
                Console.WriteLine("Cards in Hand:");
                Console.WriteLine("[Hidden Card]");
                for (int i = 1; i < dealerHand.NumCards; i++)
                {
                    Console.WriteLine(dealerHand[i].ToString());
                }
                //Doesn't show the dealer's score if a card is hidden
                Console.WriteLine("Dealer's score: ??");
            }
            else
            {
                Console.WriteLine(dealerHand.ToString());
                Console.WriteLine($"Dealer's Score: {dealerHand.GetScore()}");
            }
        }
    }
}
