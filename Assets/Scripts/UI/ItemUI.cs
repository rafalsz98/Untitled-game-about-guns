using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ItemUI : MonoBehaviour
{
    public int ID
    { get; set; }

    [SerializeField]
    private Image selection = null;
    [SerializeField]
    private Image itemImage = null;
    [SerializeField]
    private TextMeshProUGUI itemName = null;
    [SerializeField]
    private TextMeshProUGUI quantity = null;


    public void ChangeItemImage(Sprite image)
    {
        itemImage.sprite = image;
    }

    public void ChangeItemName(string name)
    {
        itemName.text = name;
    }

    public void ChangeItemQuantity(string q)
    {
        quantity.text = q;
    }

    public static ItemUI CreateItemUIElement(Item item, Transform parent)
    {
        GameObject newItem = Instantiate(GameManager.instance.itemUIPrefab, parent);
        ItemUI itemUI = newItem.GetComponent<ItemUI>();
        itemUI.ChangeItemImage(item.image);
        itemUI.ChangeItemName(item.itemName);
        itemUI.ChangeItemQuantity(item.quantity.ToString());
        itemUI.ID = item.ID;
        return itemUI;
    }

    public void ToggleSelection()
    {
        if (!selection.enabled)
        {
            selection.enabled = true;
            Color32 c = new Color32(28, 28, 28, 255);
            itemName.color = c;
            quantity.color = c;
        }
        else
        {
            selection.enabled = false;
            Color32 c = new Color32(168, 168, 168, 255);
            itemName.color = c;
            quantity.color = c;
        }
    }
}
