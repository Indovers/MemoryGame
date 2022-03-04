using UnityEngine;
using UnityEngine.UI;
using Zenject;

[RequireComponent(typeof(GridLayoutGroup))]
public class CardGrid : MonoBehaviour
{
    [SerializeField] private float gridOffset;
    [SerializeField] private Sprite[] cardSprites;
    [SerializeField] private Card cardPrefab;

    private RectTransform _rectTransform;
    private GridLayoutGroup _gridLayoutGroup;

    private CardMatchChecker _cardMatchChecker;
    
    private int _height;
    private int _width;
    private int _totalCells;
    
    private void Awake()
    {
        _rectTransform = GetComponent<RectTransform>();
        _gridLayoutGroup = GetComponent<GridLayoutGroup>();
    }

    [Inject] private void Construct(CardMatchChecker cardMatchChecker)
    {
        _cardMatchChecker = cardMatchChecker;
    }

    private void OnEnable()
    {
        GameState.OnGameStarted += Init;
    }

    private void OnDisable()
    {
        GameState.OnGameStarted -= Init;
    }

    private void Init(GameSettings gameSettings)
    {
        ClearGrid();
        ShuffleCardSprites();
        CalculateGridSize(gameSettings.difficultyLevel * 2);
        SpawnGridCards();
        ShuffleCards();
    }

    private void CalculateGridSize(int cardsAmount)
    {
        _totalCells = cardsAmount;
        _width = Mathf.FloorToInt(Mathf.Sqrt(cardsAmount));
        _height = cardsAmount / _width;
        _width += _totalCells - _width * _height;
    }

    private void SpawnGridCards()
    {
        var gridSize = (_rectTransform.sizeDelta.x - (Mathf.Max(_width,_height) - 1) * gridOffset) / Mathf.Max(_width,_height);

        for (var i = 0; i < _totalCells; i++)
        {
            var card = Instantiate(cardPrefab, transform).GetComponent<Card>();
            card.Init(cardSprites[i/2], i/2, _cardMatchChecker);

            _gridLayoutGroup.cellSize = new Vector2(gridSize, gridSize);
            _gridLayoutGroup.spacing = new Vector2(gridOffset, gridOffset);
        }
    }

    private void ClearGrid()
    {
        foreach (Transform child in transform)
        {
            Destroy(child.gameObject);
        }
    }

    private void ShuffleCardSprites()
    {
        ShuffleUtils.ShuffleArray(ref cardSprites);
    }

    private void ShuffleCards()
    {
        ShuffleUtils.ShuffleTransforms(transform);
    }
}
