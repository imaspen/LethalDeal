using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Dealer
{
    public class DeckController : MonoBehaviour
    {
        public Queue<string> Deck { get; private set; }

        private void Start()
        {
            var rng = new System.Random();
            var deckList = new List<string>();
            Deck = new Queue<string>();
            for (var i = 0; i < 3; i++) deckList.Add("Circler");
            for (var i = 0; i < 3; i++) deckList.Add("Shotgunner");
            for (var i = 0; i < 3; i++) deckList.Add("Liner");

            while (deckList.Count > 0)
            {
                var placeholder = rng.Next(deckList.Count);
                AddCard(deckList[placeholder]);
                deckList.RemoveAt(placeholder);
            }
        }

        public void AddCard(string card)
        {
            Deck.Enqueue(card);
        }

        public string GetNextCard()
        {
            return Deck.Dequeue();
        }
    }
}
