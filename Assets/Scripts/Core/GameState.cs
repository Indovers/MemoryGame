using System;
using UnityEngine;
using Zenject;

public class GameState : MonoBehaviour
{
    public static Action<GameSettings> OnGameStarted;
    public static Action OnGameRestarted;
    public static Action OnGameSucceed;
    public static Action OnGameLost;

    private GameSettings _gameSettings;

    private int _totalPairsMatched;

    [Inject] private void Construct(GameSettings gameSettings)
    {
        _gameSettings = gameSettings;
    }

    private void OnEnable()
    {
        OnGameStarted += PrepareNewGame;
        OnGameRestarted += RestartGame;
    }

    private void OnDisable()
    {
        OnGameStarted -= PrepareNewGame;
        OnGameRestarted -= RestartGame;
    }
    
    private void Start()
    {
        OnGameStarted?.Invoke(_gameSettings);
    }

    private void RestartGame()
    {
        OnGameStarted?.Invoke(_gameSettings);
    }

    private void PrepareNewGame(GameSettings gameSettings)
    {
        _totalPairsMatched = 0;
    }

    public void PairMatched()
    {
        _totalPairsMatched++;
        
        if(_totalPairsMatched >= _gameSettings.difficultyLevel)
           GameSucceed();
    }

    private void GameSucceed()
    {
        OnGameSucceed?.Invoke();
    }
}
