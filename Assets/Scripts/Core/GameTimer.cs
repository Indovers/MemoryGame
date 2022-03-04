using System;
using System.Collections;
using UnityEngine;

public class GameTimer : MonoBehaviour
{
    public static Action<int> OnTimerUpdated;

    private int _timeLeft;

    private void OnEnable()
    {
        GameState.OnGameStarted += StartGameTimer;
        GameState.OnGameSucceed += StopGameTimer;
    }

    private void OnDisable()
    {
        GameState.OnGameStarted -= StartGameTimer;
        GameState.OnGameSucceed -= StopGameTimer;
    }

    private void StartGameTimer(GameSettings gameSettings)
    {
        StopGameTimer();
        
        _timeLeft = gameSettings.difficultyLevel * 5;

        OnTimerUpdated?.Invoke(_timeLeft);

        StartCoroutine(nameof(TimerCoroutine));
    }

    private void StopGameTimer()
    {
        StopCoroutine(nameof(TimerCoroutine));
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
