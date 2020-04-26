using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class AmmoBar : MonoBehaviour
{
    public TextMeshProUGUI text;

    private void Start()
    {
        ChangeAmmo(0, 0);
    }

    public void ChangeAmmo(int curr, int max)
    {
        string s = curr.ToString() + "/" + max.ToString();
        text.SetText(s);
    }

    public void ChangeDurability(int dur)
    {
        text.SetText(dur.ToString());
    }
}
