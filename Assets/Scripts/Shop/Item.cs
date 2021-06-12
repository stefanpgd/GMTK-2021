using UnityEngine;

[CreateAssetMenu(fileName = "Item")]
public class Item : ScriptableObject
{
    public ItemType Type;
    public string ItemTitle;
    public string ItemDescription;
    public int ItemCost;
    public Sprite ItemImage;
}
