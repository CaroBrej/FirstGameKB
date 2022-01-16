using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealingZone : Sign
{
    public GameObject healingObject;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetButtonDown("Interact") && playerInRange)
        {
            if (dialogBox.activeInHierarchy)
            {
                dialogBox.SetActive(false);
                contextOn.Raise();
            }
            else
            {
                dialogBox.SetActive(true);
                dialogText.text = dialog;
                contextOff.Raise();
                healingObject.GetComponent<PlayerStats>().FullHeal();
            }
        }
    }

    
}
