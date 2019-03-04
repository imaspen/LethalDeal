using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Deck
{
    

    public class DeckController : MonoBehaviour
    {
        private static System.Random rng = new System.Random();

        public Queue<string> Deck { get; private set; }
        // Use this for initialization
        void Start()
        {
            var deckList = new List<string>();

            var shuffledDeck = new Queue<string>();

            deckList.Add("Big Robot");
            deckList.Add("Medium Robot");
            deckList.Add("Small Robot");
            deckList.Add("Gun One");
            deckList.Add("Gun Two");
            deckList.Add("Gun Three");

            while (deckList.Count > 0)
            {
                int placeholder = rng.Next(deckList.Count);
                addCardToDeck(deckList[placeholder]);
                deckList.RemoveAt(placeholder);
            }
           
        }     

        public void addCardToDeck(string card)
        {
            Deck.Enqueue(card);
        }

        public string getNextCardFromDeck()
        {
            return Deck.Dequeue();
        }
    }
}