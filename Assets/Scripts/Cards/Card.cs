using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class Card : MonoBehaviour
{
    [SerializeField] private float flipDuration;
    
    private Sprite _cardSprite;
    private Image _cardImage;

    private void Awake()
    {
        _cardImage = GetComponent<Image>();
    }

    public void Init(Sprite cardSprite)
    {
        _cardSprite = cardSprite;
    }

    public void FlipCard()
    {
        var mySequence = DOTween.Sequence();
        mySequence
            .Append(transform.DOLocalRotate(new Vector3(0, -90, 0), flipDuration/2)
            .OnComplete(()=>_cardImage.sprite = _cardSprite));
        mySequence
            .Append(transform.DOLocalRotate(new Vector3(0, -180, 0), flipDuration/2));
    }
}
