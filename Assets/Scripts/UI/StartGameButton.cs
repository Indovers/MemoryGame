using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class StartGameButton : MonoBehaviour
{
    private const string GameSceneName = "GameScene";
    
    private Button _startGameButton;

    private void Awake()
    {
        _startGameButton = GetComponent<Button>();
    }

    private void OnEnable()
    {
        PlayerNameInputField.OnPlayerNameChanged += ValidateButton;
    }

    private void OnDisable()
    {
        PlayerNameInputField.OnPlayerNameChanged -= ValidateButton;
    }

    private void ValidateButton(string playerName)
    {
        _startGameButton.interactable = !string.IsNullOrEmpty(playerName);
    }

    public void StartGame()
    {
        SceneManager.LoadScene(GameSceneName);
    }
}
