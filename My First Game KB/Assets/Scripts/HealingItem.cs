using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealingItem : MonoBehaviour
{
    public int healValue;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            if(other.GetComponent<PlayerStats>().stats.HP!= other.GetComponent<PlayerStats>().stats.maxHP)
            {
                other.GetComponent<PlayerStats>().Heal(healValue);
                Destroy(this.gameObject);
            }
            
        }
    }
}
