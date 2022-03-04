using System;
using UnityEngine;
using Zenject;

public class GameState : MonoBehaviour
{
    public static Action<GameSettings> OnGameStarted;
    public static Action OnGameSucceed;
    public static Action OnGameLost;

    private GameSettings _gameSettings;

    [Inject] private void Construct(GameSettings gameSettings)
    {
        _gameSettings = gameSettings;
    }

    private void Start()
    {
        OnGameStarted?.Invoke(_gameSettings);
    }
}
