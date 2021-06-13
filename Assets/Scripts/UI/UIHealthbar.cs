using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIHealthbar : MonoBehaviour
{
    [SerializeField] private Image healthBarFill;
    [SerializeField] private TextMeshProUGUI healthbarText;

    private PlayerHealth playerHealth;

    private void Start()
    {
        playerHealth = PlayerHealth.Instance;

        playerHealth.playerHealthUpdatedEvent += UpdateHealthbar;
        UpdateHealthbar();
    }

    private void UpdateHealthbar()
    {
        float currentHealth = playerHealth.Health;
        float maxHealth = playerHealth.MaxHealth;

        float fill = currentHealth / maxHealth;

        healthBarFill.fillAmount = fill;
        healthbarText.text = currentHealth.ToString() + "/" + maxHealth.ToString();
    }
}
