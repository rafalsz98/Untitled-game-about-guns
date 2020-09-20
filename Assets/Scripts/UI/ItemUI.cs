using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ItemUI : MonoBehaviour
{
    [SerializeField]
    private Image selection = null;
    [SerializeField]
    private Image itemImage = null;
    [SerializeField]
    private Image itemEquipped = null;
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

    public static ItemUI CreateItemUIElement(string itemName, Sprite itemImage, int itemQuantity, Transform parent)
    {
        GameObject newItem = Instantiate(GameManager.instance.itemUIPrefab, parent);
        ItemUI itemUI = newItem.GetComponent<ItemUI>();
        itemUI.ChangeItemImage(itemImage);
        itemUI.ChangeItemName(itemName);
        itemUI.ChangeItemQuantity(itemQuantity.ToString());
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

    // Toggle image informing if item is currently equipped
    // If state == 0, then hide image
    // If state == 1, then show image
    public void ToggleEquip(bool state)
    {
        itemEquipped.enabled = state;
    }
}
