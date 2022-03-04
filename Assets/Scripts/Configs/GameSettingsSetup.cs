using UnityEngine;
using Zenject;

public class GameSettingsSetup : MonoBehaviour
{
    private GameSettings _gameSettings;
    
    [Inject] public void Construct(GameSettings gameSettings)
    {
        _gameSettings = gameSettings;
    }
    
    private void OnEnable()
    {
        DifficultySlider.OnDifficultyChanged += UpdateDifficulty;
        PlayerNameInputField.OnPlayerNameChanged += UpdatePlayerName;
    }

    private void OnDisable()
    {
        DifficultySlider.OnDifficultyChanged -= UpdateDifficulty;
        PlayerNameInputField.OnPlayerNameChanged -= UpdatePlayerName;
    }

    private void UpdateDifficulty(int difficulty)
    {
        _gameSettings.difficultyLevel = difficulty;
    }

    private void UpdatePlayerName(string playerName)
    {
        _gameSettings.playerName = playerName;
    }
}
