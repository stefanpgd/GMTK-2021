using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UiGoToGame : MonoBehaviour
{
    [SerializeField] private Button button;

    private void Start()
    {
        button.onClick.AddListener(LoadGame);
    }

    private void OnDestroy()
    {
        button.onClick.RemoveListener(LoadGame);
    }

    private void LoadGame()
    {
        SceneManager.LoadScene("LekkerKlooien");
    }
}