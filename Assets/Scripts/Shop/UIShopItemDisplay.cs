using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIShopItemDisplay : MonoBehaviour
{
    [SerializeField] private Item item;
    [SerializeField] private Button purchaseButton;
    [SerializeField] private Image itemImageDisplay;
    [SerializeField] private TextMeshProUGUI itemTitleDisplay;
    [SerializeField] private TextMeshProUGUI itemDescription;
    [SerializeField] private TextMeshProUGUI itemCost;
    [SerializeField] private GameObject purchaseLayer;
    [SerializeField] private GameObject purchasedLayer;

    private ShopManager shopManager;

    private void Start()
    {
        shopManager = ShopManager.Instance;

        itemImageDisplay.sprite = item.ItemImage;
        itemTitleDisplay.text = item.ItemTitle;
        itemDescription.text = item.ItemDescription.ToString();
        itemCost.text = "Price: " + item.ItemCost.ToString();

        purchaseLayer.SetActive(true);
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
            purchaseLayer.SetActive(false);
            purchasedLayer.SetActive(true);
            purchaseButton.onClick.RemoveListener(TryPurchaseItem);
        }
    }
}
