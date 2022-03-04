using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class Card : MonoBehaviour
{
    [SerializeField] private float flipDuration;
    [SerializeField] private float hideDelay;
    
    private Sprite _cardSprite;
    private Sprite _defaultCardSprite;
    private Image _cardImage;

    private CardMatchChecker _cardMatchChecker;

    private bool _isMatched;

    public int CardID { get; private set; }

    private void Awake()
    {
        _cardImage = GetComponent<Image>();
        _defaultCardSprite = _cardImage.sprite;
    }

    public void Init(Sprite cardSprite, int cardID, CardMatchChecker cardMatchChecker)
    {
        _cardSprite = cardSprite;
        CardID = cardID;

        _cardMatchChecker = cardMatchChecker;
    }

    public void ShowCard()
    {
        if(_cardMatchChecker.FlippedCardsCount >= 2 || _isMatched) return;
        
        CardMatchChecker.OnCardStartFlipping?.Invoke();

        var mySequence = DOTween.Sequence();
        mySequence
            .Append(transform.DOLocalRotate(new Vector3(0, -90, 0), flipDuration/2)
            .OnComplete(()=>
                _cardImage.sprite = _cardSprite));
        mySequence
            .Append(transform.DOLocalRotate(new Vector3(0, -180, 0), flipDuration/2))
            .OnComplete(()=>
                CardMatchChecker.OnCardFlipped?.Invoke(this));
    }

    public void HideCard()
    {
        var mySequence = DOTween.Sequence();
        mySequence.SetDelay(hideDelay);
        mySequence
            .Append(transform.DOLocalRotate(new Vector3(0, -90, 0), flipDuration/2)
                .OnComplete(()=>
                    _cardImage.sprite = _defaultCardSprite));
        mySequence
            .Append(transform.DOLocalRotate(new Vector3(0, 0, 0), flipDuration/2))
            .OnComplete(()=>
                CardMatchChecker.OnCardsHidden?.Invoke());
    }

    public void MarkAsMatched()
    {
        _isMatched = true;
    }
}
