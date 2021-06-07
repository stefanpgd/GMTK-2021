using UnityEngine;
#pragma warning disable 649

namespace SilverRogue.Tools
{
    public class DontDestroyThisObject : MonoBehaviour
    {
        private void Awake() => DontDestroyOnLoad(this.gameObject);
    }
}