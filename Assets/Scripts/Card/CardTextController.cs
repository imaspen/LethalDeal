using UnityEngine;

namespace Card
{
    public class CardTextController : MonoBehaviour
    {
        private CardData _cardData;
        private TextMesh _cardDescription;
        private TextMesh _cardTitle;

        private void Start()
        {
            _cardData = transform.parent.GetComponent<CardData>();
            var cardTextParts = GetComponentsInChildren<TextMesh>();
            foreach (var cardTextPart in cardTextParts)
                if (cardTextPart.name == "Title")
                    _cardTitle = cardTextPart;
                else
                    _cardDescription = cardTextPart;
            OnCardTextChanged();
        }

        private void OnCardTextChanged()
        {
            _cardTitle.text = _cardData.Title;
            _cardDescription.text = _cardData.Description;
        }
    }
}
