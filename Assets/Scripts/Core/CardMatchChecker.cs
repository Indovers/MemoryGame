using System;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class CardMatchChecker : MonoBehaviour
{
    public static Action OnCardStartFlipping;
    public static Action<Card> OnCardFlipped;
    public static Action OnCardsHidden;

    private List<Card> _selectedCards = new List<Card>();
    private GameState _gameState;
    public int FlippedCardsCount { get; private set; }

    [Inject] private void Construct(GameState gameState)
    {
        _gameState = gameState;
    }

    private void OnEnable()
    {
        OnCardStartFlipping += CardStartedFlipping;
        OnCardFlipped += CardFlipped;
        OnCardsHidden += ClearSelectedCards;
    }

    private void OnDisable()
    {
        OnCardStartFlipping -= CardStartedFlipping;
        OnCardFlipped -= CardFlipped;
        OnCardsHidden -= ClearSelectedCards;
    }

    private void CardStartedFlipping()
    {
        FlippedCardsCount++;
    }

    private void CardFlipped(Card card)
    {
        if (_selectedCards.Count == 0)
        {
            _selectedCards.Add(card);
            return;
        }

        _selectedCards.Add(card);
        CheckCardsIdentity();
    }

    private void CheckCardsIdentity()
    {
        for (int i = 0; i < _selectedCards.Count-1; i++)
        {
            if (_selectedCards[i].CardID != _selectedCards[i + 1].CardID)
            {
                CardsNotMatched();
                return;
            }
        }
        
        CardsMatched();
    }

    private void CardsMatched()
    {
        foreach (var card in _selectedCards)
        {
            card.MarkAsMatched();
        }
        
        _gameState.PairMatched();
        
        ClearSelectedCards();
    }

    private void CardsNotMatched()
    {
        foreach (var card in _selectedCards)
        {
            card.HideCard();
        }
    }

    private void ClearSelectedCards()
    {
        FlippedCardsCount = 0;
        _selectedCards.Clear();
    }
}
