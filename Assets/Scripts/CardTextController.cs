﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardTextController : MonoBehaviour
{
    private CardData _cardData;
    private TextMesh _cardName;
    private TextMesh _cardDescription;

    private void Start()
    {
        _cardData = GetComponent<CardData>();
        var cardTextParts = GetComponentsInChildren<TextMesh>();
        foreach (var cardTextPart in cardTextParts)
        {
            if (cardTextPart.name == "Title")
            {
                _cardName = cardTextPart;
            }
            else
            {
                _cardDescription = cardTextPart;
            }
        }
        OnCardTextChanged();
    }

    private void OnCardTextChanged()
    {
        _cardName.text = _cardData.Name;
        _cardDescription.text = _cardData.Description;
    }
}