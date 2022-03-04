using DG.Tweening;
using UnityEngine;

public class WinScreen : MonoBehaviour
{
    [SerializeField] private float winScreenFadeTime;
    
    private CanvasGroup _winCanvasGroup;

    private void Awake()
    {
        _winCanvasGroup = GetComponent<CanvasGroup>();
    }

    private void OnEnable()
    {
        GameState.OnGameSucceed += ShowWinScreen;
        GameState.OnGameStarted += HideWinScreen;
    }

    private void OnDisable()
    {
        GameState.OnGameSucceed -= ShowWinScreen;
        GameState.OnGameStarted -= HideWinScreen;
    }

    private void ShowWinScreen()
    {
        _winCanvasGroup.blocksRaycasts = true;
        _winCanvasGroup.DOFade(1, winScreenFadeTime);
    }
    
    private void HideWinScreen(GameSettings gameSettings)
    {
        _winCanvasGroup.blocksRaycasts = false;
        _winCanvasGroup.alpha = 0;
    }
}
