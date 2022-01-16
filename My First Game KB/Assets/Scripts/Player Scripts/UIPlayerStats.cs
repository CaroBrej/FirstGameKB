using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIPlayerStats : MonoBehaviour
{
    public Statistics PlayerStats;
    public GameObject InventoryBox;

    public Text HpValueText;
    public Text dmgValueText;
    public Text speedValueText;
    public Text attspdValueText;
    

    // Update is called once per frame
    void Update()
    {
        if (InventoryBox.activeInHierarchy)
        {
            RefreshStats();
        }
    }

    public void RefreshStats()
    {
        HpValueText.text = PlayerStats.maxHP.ToString();
        dmgValueText.text = PlayerStats.dmg.ToString();
        speedValueText.text = PlayerStats.speed.ToString();
        attspdValueText.text = PlayerStats.attackspeed.ToString();

    }
}
