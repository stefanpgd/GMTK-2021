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

        if(item.ItemCost >= currentScore)
        {
            switch(item.Type)
            {
                case ItemType.HealthUpgrade:
                    //wajow upgrade de player's health, wie had dat verwacht
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
