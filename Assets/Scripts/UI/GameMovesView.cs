using TMPro;
using UnityEngine;

[RequireComponent(typeof(TextMeshProUGUI))]
public class GameMovesView : MonoBehaviour
{
    private TextMeshProUGUI _textView;

    private void Awake()
    {
        _textView = GetComponent<TextMeshProUGUI>();
    }

    private void OnEnable()
    {
        GameMoves.OnMovesUpdated += UpdateMovesView;
    }

    private void OnDisable()
    {
        GameMoves.OnMovesUpdated -= UpdateMovesView;
    }

    private void UpdateMovesView(int moves)
    {
        _textView.text = moves.ToString();
    }
}
