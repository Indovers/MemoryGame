using System;
using TMPro;
using UnityEngine;

[RequireComponent(typeof(TMP_InputField))]
public class PlayerNameInputField : MonoBehaviour
{
    public static Action<string> OnPlayerNameChanged;

    private TMP_InputField _playerNameInputField;
    
    private void Awake()
    {
        _playerNameInputField = GetComponent<TMP_InputField>();
    }

    private void Start()
    {
        _playerNameInputField.onValueChanged.AddListener(UpdatePlayerName);
    }

    private void UpdatePlayerName(string playerName)
    {
        OnPlayerNameChanged?.Invoke(playerName);
    }
}
