using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using Random = System.Random;

public class Task3Script : MonoBehaviour
{
    List<Card> deck = new List<Card>();
    Stack<Card> shuffledDeck = new Stack<Card>();
    List<Card> hand = new List<Card>();

    // Start is called before the first frame update
    void Start()
    {
        bool win = false;

        for (int i = 1; i < 5; i++)
        {
            deck.Add(new Card(i, 1));
            deck.Add(new Card(i, 2));
            deck.Add(new Card(i, 3));
            deck.Add(new Card(i, 4));
        }

        Random random = new Random();
        int num;

        for (int i = 16; i > 0; i--)
        {
            num = random.Next(0, i);
            shuffledDeck.Push(deck[num]);
            deck.RemoveAt(num);
        }

        for (int i = 0; i < 4; i++)
        {
            hand.Add(shuffledDeck.Pop());
        }

        Debug.Log("I made the initial deck and draw.");

        while (win == false)
        {
            Debug.Log("My hand is: " + hand[0].face +" of " + hand[0].suit + ", "
            + hand[1].face +" of " + hand[1].suit + ", " 
            + hand[2].face +" of " + hand[2].suit + ", "
            + hand[3].face +" of " + hand[3].suit + ", ");

            win = CheckSuits(hand);

            if(win == true)
            {
                Debug.Log("The game is WON.");
                break;
            }

            else
            {
                Debug.Log("This is not a winning hand.");
                num = random.Next(0, 4);
                Card discarded = hand[num];
                hand.RemoveAt(num);
                shuffledDeck.TryPeek(out Card nextCard);

                if(nextCard == null)
                {
                    Debug.Log("The game is LOST.");
                    break;
                }

                hand.Add(shuffledDeck.Pop());
                Debug.Log("I discarded the " + discarded.face + " of " + discarded.suit + " and draw the " + nextCard.face + " of " + nextCard.suit + ".");
            }
        }
    }

    public bool CheckSuits(List<Card> hand)
    {
        if ((hand[0].suit == hand[1].suit && hand[0].suit == hand[2].suit) || (hand[0].suit == hand[1].suit && hand[0].suit == hand[3].suit) || (hand[0].suit == hand[2].suit && hand[0].suit == hand[3].suit))
        {
            return true;
        }

        else if(hand[1].suit == hand[2].suit && hand[1].suit == hand[3].suit)
        {
            return true;
        }

        else
        {
            return false;
        }
    }
}

public class Card
{
    public char face {get; set;}
    public string suit {get; set;}

    public Card(int faceNum, int suitNum)
    {
        switch (faceNum)
        {
            case 1:
                this.face = 'J';
                break;

            case 2:
                this.face = 'Q';
                break;

            case 3:
                this.face = 'K';
                break;

            default:
                this.face = 'A';
                break; 
        }

        switch (suitNum)
        {
            case 1:
                this.suit = "Clubs";
                break;

            case 2:
                this.suit = "Diamonds";
                break;

            case 3:
                this.suit = "Hearts";
                break;

            default:
                this.suit = "Spades";
                break; 
        }
    }
}