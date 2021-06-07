using UnityEngine;

namespace SilverRogue.Tools
{
    public class DisableLogsOnRelease : MonoBehaviour
    {
        private void Awake()
        {
#if UNITY_EDITOR
            Debug.unityLogger.logEnabled = true;
#else
            Debug.unityLogger.logEnabled = false;
#endif
        }
    }
}