using System;
using System.Collections;
using UnityEngine;

public class GameTimer : MonoBehaviour
{
    public static Action<int> OnTimerUpdated;
    
    private int _timeLeft;
    private void OnEnable()
    {
        GameState.OnGameStarted += StartNewGameTimer;
    }

    private void OnDisable()
    {
        GameState.OnGameStarted -= StartNewGameTimer;
    }

    private void StartNewGameTimer(GameSettings gameSettings)
    {
        _timeLeft = gameSettings.difficultyLevel * 5;
        
        OnTimerUpdated?.Invoke(_timeLeft);

        StartCoroutine(nameof(TimerCoroutine));
    }

    private IEnumerator TimerCoroutine()
    {
        while (_timeLeft > 0)
        {
            yield return new WaitForSeconds(1);

            _timeLeft--;
            
            OnTimerUpdated?.Invoke(_timeLeft);
        }
        
        GameState.OnGameLost?.Invoke();
    }
}
