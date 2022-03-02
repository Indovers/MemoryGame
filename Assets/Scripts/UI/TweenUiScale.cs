using DG.Tweening;
using UnityEngine;

public class TweenUiScale : MonoBehaviour
{
    [SerializeField] private Ease easeType;
    [SerializeField] private float easeInDuration;
    [SerializeField] private float easeOutDuration;
    [SerializeField] private float easeScaleFactor;

    public void EaseIn()
    {
        transform.DOScale(Vector3.one * easeScaleFactor, easeInDuration).SetEase(easeType);
    }
    
    public void EaseOut()
    {
        transform.DOScale(Vector3.one, easeOutDuration).SetEase(easeType);
    }
}
