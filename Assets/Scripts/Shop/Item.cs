using UnityEngine;

[CreateAssetMenu(fileName = "Item")]
public class Item : ScriptableObject
{
    public ItemType Type;
    public int ItemCost;
    public string ItemTitle;
    public Sprite ItemImage;
}
