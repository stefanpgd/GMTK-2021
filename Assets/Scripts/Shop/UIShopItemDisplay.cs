using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIShopItemDisplay : MonoBehaviour
{
    [SerializeField] private Item item;
    [SerializeField] private Button purchaseButton;
    [SerializeField] private SpriteRenderer itemImageDisplay;
    [SerializeField] private TextMeshProUGUI itemTitleDisplay;
    [SerializeField] private TextMeshProUGUI itemCostDisplay;
    [SerializeField] private GameObject purchasedLayer;

    private ShopManager shopManager;

    private void Start()
    {
        shopManager = ShopManager.Instance;

        itemImageDisplay.sprite = item.ItemImage;
        itemTitleDisplay.text = item.ItemTitle;
        itemCostDisplay.text = item.ItemCost.ToString();

        purchasedLayer.SetActive(false);

        purchaseButton.onClick.AddListener(TryPurchaseItem);
    }

    private void OnDestroy()
    {
        purchaseButton.onClick.RemoveListener(TryPurchaseItem);
    }

    private void TryPurchaseItem()
    {
        bool hasPurchasedItem = shopManager.PurchaseItem(item);

        if(hasPurchasedItem)
        {
            purchasedLayer.SetActive(true);
            purchaseButton.onClick.RemoveListener(TryPurchaseItem);
        }
    }
}
