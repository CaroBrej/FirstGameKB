using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Equipment : Interactable
{
    public EQstats stats;
    public GameObject PickUpBox;
    public Text PickUpTextName;
    public Text PickUpTextStats;
    public Text PickUpTextType;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Interact") && playerInRange)
        {
            if (PickUpBox.activeInHierarchy)
            {
                PickUpBox.SetActive(false);
                contextOn.Raise();
            }
            else
            {
                PickUpBox.SetActive(true);
                PickUpBox.GetComponent<PickUp>().Item =this.gameObject;
                PickUpTextName.text = stats.EqName;
                PickUpTextType.text = stats.EqType.ToString();
                PickUpTextStats.text = statsstring();
                contextOff.Raise();
            }
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = false;
            PickUpBox.SetActive(false);
            contextOff.Raise();
        }
    }

    private string statsstring()
    {
        string StatsString = "";
        if(stats.speed!=0)
        {
            StatsString = StatsString + "spd: " + stats.speed.ToString()+" ";
        }
        if (stats.HP != 0)
        {
            StatsString = StatsString + "HP: " + stats.HP.ToString() + " ";
        }
        if (stats.dmg != 0)
        {
            StatsString = StatsString + "dmg: " + stats.dmg.ToString() + " ";
        }
        if (stats.attackspeed != 0)
        {
            StatsString = StatsString + "att spd: " + stats.attackspeed.ToString();
        }

        return StatsString;
    }
}
