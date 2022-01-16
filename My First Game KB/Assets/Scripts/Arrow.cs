using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    public Statistics stats;
    private int dmgdealay = 0;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            if(dmgdealay==0)
            {
                dmgdealay = 1;
                other.GetComponent<Enemy>().Hurt(stats.dmg);
                Destroy(this.gameObject);

            }
        }
    }

}
