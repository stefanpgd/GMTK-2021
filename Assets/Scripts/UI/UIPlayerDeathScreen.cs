using UnityEngine;

public class UIPlayerDeathScreen : MonoBehaviour
{
    [SerializeField] private Animator endScreenAnimator;

    private PlayerHealth playerHealth;
    [SerializeField] private GameObject player;

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
        player.SetActive(false);
    }
}
