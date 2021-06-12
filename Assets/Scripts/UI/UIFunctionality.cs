using UnityEngine;

namespace Rink
{
    public class UIFunctionality : MonoBehaviour
    {
        // Variables
        [SerializeField] private UnityEngine.Events.UnityEvent onStartEvent;

        private void Start() => onStartEvent.Invoke();

        /// <summary>Load Scene by index.</summary>
        /// <param name="index">Scene Index</param>
        public void LoadScene(int index) => UnityEngine.SceneManagement.SceneManager.LoadScene(index);
        /// <summary>Load Scene by name.</summary>
        /// <param name="index">Scene Name</param>
        public void LoadScene(string name) => UnityEngine.SceneManagement.SceneManager.LoadScene(name);

        public void QuitGame()
        {
#if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
#else
            Application.Quit();
#endif
        }
    }
}