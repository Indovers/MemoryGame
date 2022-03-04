using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class RestartButton : MonoBehaviour
{
   private Button _button;

   private void Awake()
   {
      _button = GetComponent<Button>();
   }

   private void Start()
   {
      _button.onClick.AddListener(RestartGame);
   }

   private void RestartGame()
   {
      GameState.OnGameRestarted?.Invoke();
   }
}
