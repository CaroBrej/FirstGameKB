using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryButtons : MonoBehaviour
{
    public GameObject Player;
    //public EquippedItems equippedItems;
    public EquippedItems baseEquippedItems;
    public GameObject EqCanvas;
    public PLayerEq Inventory;

    public Text ItemHpText;
    public Text ItemDmgText;
    public Text ItemSpeedText;
    public Text ItemAttSpdText;

    public EQstats itemToInspect;
    public EQstats itemToEquip;
    public EQstats itemToRemove;
    public EQstats itemToDestroy;
      
    

    public void EquipButton()
    {
        if(itemToEquip.EqName!="None")
        {
            Player.GetComponent<PlayerStats>().EquipItem(itemToEquip);
            EqCanvas.GetComponent<UIInventory>().InventoryClear();
            EqCanvas.GetComponent<UIInventory>().InventoryUpdate();
        }
        itemToEquip = baseEquippedItems.items[0];
        
    }
    public void InspectButton()
    {
        ItemHpText.text = itemToInspect.HP.ToString();
        ItemDmgText.text = itemToInspect.dmg.ToString();
        ItemSpeedText.text = itemToInspect.speed.ToString();
        ItemAttSpdText.text = itemToInspect.attackspeed.ToString();
        itemToInspect = baseEquippedItems.items[0];
    }
    public void RemoveButton()
    {
        Player.GetComponent<PlayerStats>().EquipItem(itemToRemove);
        EqCanvas.GetComponent<UIInventory>().InventoryClear();
        EqCanvas.GetComponent<UIInventory>().InventoryUpdate();
        itemToRemove = baseEquippedItems.items[0];
    }
    public void DestroyButton()
    {
        if (itemToDestroy.EqName != "None")
        {
            Player.GetComponent<PlayerStats>().DestroyItem(itemToDestroy);
            EqCanvas.GetComponent<UIInventory>().InventoryClear();
            EqCanvas.GetComponent<UIInventory>().InventoryUpdate();
        }
        itemToDestroy = baseEquippedItems.items[0];
    }
}
