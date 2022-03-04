using System;
using DG.Tweening;
using UnityEngine;

[RequireComponent(typeof(CanvasGroup))]
public class LoseScreen : MonoBehaviour
{
    [SerializeField] private float loseScreenFadeTime;
    
    private CanvasGroup _loseCanvasGroup;

    private void Awake()
    {
        _loseCanvasGroup = GetComponent<CanvasGroup>();
    }

    private void OnEnable()
    {
        GameState.OnGameLost += ShowLoseScreen;
        GameState.OnGameStarted += HideLoseScreen;
    }

    private void OnDisable()
    {
        GameState.OnGameLost -= ShowLoseScreen;
        GameState.OnGameStarted -= HideLoseScreen;
    }

    private void ShowLoseScreen()
    {
        _loseCanvasGroup.blocksRaycasts = true;
        _loseCanvasGroup.DOFade(1, loseScreenFadeTime);
    }
    
    private void HideLoseScreen(GameSettings gameSettings)
    {
        _loseCanvasGroup.blocksRaycasts = false;
        _loseCanvasGroup.alpha = 0;
    }
}
