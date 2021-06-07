using UnityEngine;

public class GameTime : MonoBehaviour
{
    /// <summary>
    /// Replacement for deltaTime. Used to manually control the speed of time
    /// without having to touch timescale for things like UI.
    /// </summary>
    public static float deltaTime;

    private static float timeMultiplier = 1.0f;

    private void Update()
    {
        deltaTime = Time.deltaTime * timeMultiplier;
    }

    public static void SetTimeScale(float scale) => timeMultiplier = scale;
}
