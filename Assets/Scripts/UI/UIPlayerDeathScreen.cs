using UnityEngine;

public class UIPlayerDeathScreen : MonoBehaviour
{
    [SerializeField] private Animator endScreenAnimator;

    private PlayerHealth playerHealth;

    private void Start()
    {
        playerHealth = PlayerHealth.Instance;

        playerHealth.playerDiedEvent += MoveInEndScreen;
    }

    private void OnDestroy()
    {
        playerHealth.playerDiedEvent -= MoveInEndScreen;
    }

    private void MoveInEndScreen()
    {
        endScreenAnimator.SetTrigger("SlideIn");
    }
}
