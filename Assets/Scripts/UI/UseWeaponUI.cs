using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UseWeaponUI : MonoBehaviour
{
    public Image[] WeaponTiles = new Image[weaponsCount];
    public TextMeshProUGUI[] WeaponNames = new TextMeshProUGUI[weaponsCount];
    public TextMeshProUGUI[] Numbers = new TextMeshProUGUI[weaponsCount];
    public Image Weapon1Image;
    public Image Weapon2Image;
    [HideInInspector]
    public int currentlySelected = -1;

    private const int weaponsCount = 2;
    private GameManager gameManager;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameManager.instance;
        gameManager.inputMaster.UseWeaponGUI.Move.performed +=
            (UnityEngine.InputSystem.InputAction.CallbackContext ctx) => Navigate((int)ctx.ReadValue<float>());
        gameManager.inputMaster.UseWeaponGUI.Exit.performed += (_) => HideGUI();
        gameObject.SetActive(false);
    }

    public void ShowGUI(Weapon weapon1, Weapon weapon2)
    {
        gameManager.inputMaster.UseWeaponGUI.Enable();
        gameManager.inputMaster.EquipmentGUI.Disable();
        Weapon1Image.sprite = weapon1.image;
        Weapon2Image.sprite = weapon2.image;

        WeaponNames[0].text = weapon1.name;
        WeaponNames[1].text = weapon2.name;

        gameObject.SetActive(true);
    }

    public void HideGUI()
    {
        gameManager.inputMaster.UseWeaponGUI.Disable();
        gameManager.inputMaster.EquipmentGUI.Enable();

        gameObject.SetActive(false);
        toggleWeapon(currentlySelected);
    }

    public void Navigate(int dir)
    {
        int id = currentlySelected + dir;
        if (id >= weaponsCount)
            id = 0;
        else if (id < 0)
            id = weaponsCount - 1;

        toggleWeapon(id);
    }

    private void toggleWeapon(int id)
    {
        if (id < 0 || id >= weaponsCount)
            return;
        if (currentlySelected == id)
        {
            WeaponTiles[id].enabled = false;
            currentlySelected = -1;
        }
        else
        {
            if (currentlySelected != -1)
                toggleWeapon(currentlySelected);
            WeaponTiles[id].enabled = true;
            currentlySelected = id;
        }
    }
}
