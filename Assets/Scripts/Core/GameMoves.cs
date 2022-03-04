using System;
using UnityEngine;

public class GameMoves : MonoBehaviour
{
    public static Action<int> OnMovesUpdated;

    private int _totalMoves = 0;

    private void OnEnable()
    {
        CardMatchChecker.OnCardStartFlipping += UpdateTotalMoves;
    }

    private void OnDisable()
    {
        CardMatchChecker.OnCardStartFlipping -= UpdateTotalMoves;
    }

    private void UpdateTotalMoves()
    {
        _totalMoves++;

        OnMovesUpdated?.Invoke(_totalMoves);
    }
}
