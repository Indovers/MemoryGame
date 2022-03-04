using TMPro;
using UnityEngine;

[RequireComponent(typeof(TextMeshProUGUI))]
public class GameTimerView : MonoBehaviour
{
    private TextMeshProUGUI _textView;

    private void Awake()
    {
        _textView = GetComponent<TextMeshProUGUI>();
    }

    private void OnEnable()
    {
        GameTimer.OnTimerUpdated += UpdateTimerView;
    }

    private void OnDisable()
    {
        GameTimer.OnTimerUpdated -= UpdateTimerView;
    }

    private void UpdateTimerView(int newTime)
    {
        _textView.text = newTime.ToString();
    }
}
