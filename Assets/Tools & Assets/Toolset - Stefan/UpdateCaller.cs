using System;
using UnityEngine;

namespace SilverRogue.Tools
{
    /// <summary>
    /// With this, non-Monobehaviour scripts can subscribe to
    /// Unity's update method.
    /// </summary>
    public class UpdateCaller : MonoBehaviour
    {
        private static UpdateCaller instance;

        private Action updateCallback;

        #region Singleton
        private void Awake()
        {
            if(instance == null)
            {
                instance = this;
            }
        }
        #endregion

        public static void AddUpdateCallback(Action updateMethod)
        {
            instance.updateCallback += updateMethod;
        }

        public static void RemoveUpdateCallback(Action updateMethod)
        {
            instance.updateCallback -= updateMethod;
        }

        private void Update()
        {
            if(updateCallback != null)
            {
                updateCallback.Invoke();
            }
        }
    }
}