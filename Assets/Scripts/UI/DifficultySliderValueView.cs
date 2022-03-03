using TMPro;
using UnityEngine;

[RequireComponent(typeof(TextMeshProUGUI))]
public class DifficultySliderValueView : MonoBehaviour
{
    private TextMeshProUGUI _text;

    private void Awake()
    {
        _text = GetComponent<TextMeshProUGUI>();
    }

    private void OnEnable()
    {
        DifficultySlider.OnDifficultyChanged += UpdateDifficultyView;
    }

    private void OnDisable()
    {
        DifficultySlider.OnDifficultyChanged -= UpdateDifficultyView;
    }

    private void UpdateDifficultyView(int difficulty)
    {
        _text.text = difficulty.ToString();
    }
}
