using System;
using UnityEngine;

public class GameMoves : MonoBehaviour
{
    public static Action<int> OnMovesUpdated;

    private int _totalMoves = 0;

    private void OnEnable()
    {
        CardMatchChecker.OnCardStartFlipping += UpdateTotalMoves;
        GameState.OnGameStarted += ClearGameMoves;
    }

    private void OnDisable()
    {
        CardMatchChecker.OnCardStartFlipping -= UpdateTotalMoves;
        GameState.OnGameStarted -= ClearGameMoves;
    }

    private void ClearGameMoves(GameSettings gameSettings)
    {
        _totalMoves = 0;
        
        OnMovesUpdated?.Invoke(_totalMoves);
    }

    private void UpdateTotalMoves()
    {
        _totalMoves++;

        OnMovesUpdated?.Invoke(_totalMoves);
    }
}
