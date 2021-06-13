using UnityEngine;
using UnityEngine.UI;

public class ShopManager : MonoBehaviour
{
    [SerializeField] private Button exitShopButton;

    private UserMetricsService userMetricsService;
    private LevelSwitchManager levelSwitchManager;

    #region Singleton
    public static ShopManager Instance;
    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
    }
    #endregion

    private void Start()
    {
        userMetricsService = UserMetricsService.Instance;
        levelSwitchManager = LevelSwitchManager.Instance;

        exitShopButton.onClick.AddListener(levelSwitchManager.LoadNextLevel);
    }

    private void OnDestroy()
    {
        exitShopButton.onClick.RemoveListener(levelSwitchManager.LoadNextLevel);
    }

    public bool PurchaseItem(Item item)
    {
        int currentScore = userMetricsService.GetMetric(MetricType.Score);

        if(item.ItemCost >= currentScore)
        {
            switch(item.Type)
            {
                case ItemType.HealthUpgrade:
                    PlayerHealth.Instance.UpdateMaxHealth(100);
                    PlayerHealth.Instance.UpdateHealth(200);
                    break;
            }

            return true;
        }
        else
        {
            return false;
        }
    }
}
