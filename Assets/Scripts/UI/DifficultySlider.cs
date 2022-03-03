using System;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Slider))]
public class DifficultySlider : MonoBehaviour
{
    public static Action<int> OnDifficultyChanged;

    private Slider _difficultySlider;

    private void Awake()
    {
        _difficultySlider = GetComponent<Slider>();
    }

    private void Start()
    {
        _difficultySlider.onValueChanged.AddListener(DifficultyChanged);
        
        DifficultyChanged(_difficultySlider.value);
    }

    private void DifficultyChanged(float difficulty)
    {
        OnDifficultyChanged?.Invoke(Mathf.RoundToInt(difficulty));
    }
}
