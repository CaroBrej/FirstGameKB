using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{
    public GameObject Item;
    public GameObject Player;
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PickUpButton()
    {
        Player.GetComponent<PlayerStats>().Inventory.Items.Add(Item.GetComponent<Equipment>().stats);
        Destroy(Item);
        this.gameObject.SetActive(false);

    }


}
