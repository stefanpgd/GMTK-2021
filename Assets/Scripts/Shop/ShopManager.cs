using UnityEngine;

public class ShopManager : MonoBehaviour
{
    private UserMetricsService userMetricsService;

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
    }

    public bool PurchaseItem(Item item)
    {
        int currentScore = userMetricsService.GetMetric(MetricType.Score);
        bool purchaseSuccesful = false;

        switch(item.Type)
        {
            case ItemType.HealthUpgrade:
                break;
        }

        return purchaseSuccesful;
    }
}
