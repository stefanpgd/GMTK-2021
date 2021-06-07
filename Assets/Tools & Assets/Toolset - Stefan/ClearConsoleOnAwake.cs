using System.Reflection;
using UnityEditor;
using UnityEngine;

namespace SilverRogue.Tools
{
#if UNITY_EDITOR
    public class ClearConsoleOnAwake : MonoBehaviour
    {
        [SerializeField] private bool Clear;

        private void Awake()
        {
            if(Clear)
            {
                var assembly = Assembly.GetAssembly(typeof(SceneView));
                var type = assembly.GetType("UnityEditor.LogEntries");
                var method = type.GetMethod("Clear");
                method.Invoke(new object(), null);
            }
        }
    }
#endif
}