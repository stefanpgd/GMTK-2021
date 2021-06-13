using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIRestartButton : MonoBehaviour
{
    [SerializeField] private Button button;

    private void Start()
    {
        button.onClick.AddListener(RestartScene);
    }

    private void OnDestroy()
    {
        button.onClick.RemoveListener(RestartScene);
    }

    private void RestartScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
