using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleAttack : MonoBehaviour
{
    public Statistics stats;
    private float knockbackdealay=0;
    private float dmgdealay = 0;
    public string attackTargetTag;
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
        if (other.gameObject.CompareTag(attackTargetTag))
        {
            if (Time.time >= dmgdealay)
            {
                if(attackTargetTag=="Enemy")
                {
                    other.GetComponent<Enemy>().Hurt(stats.dmg);
                }
                else if(attackTargetTag=="Player")
                {
                    other.GetComponent<PlayerStats>().Hurt(stats.dmg);
                }
                
                dmgdealay = Time.time + (1 / stats.attackspeed)+0.001f;
            }
                
            Rigidbody2D enemy = other.GetComponent<Rigidbody2D>();
            
            if(enemy != null)
            {
                Vector3 difference = enemy.transform.position - transform.position;
                difference = difference.normalized * stats.knockback;
                if(Time.time>=knockbackdealay)
                {
                    bool knockbackdef = false;
                    if(attackTargetTag == "Enemy")
                    {
                        knockbackdef = other.GetComponent<Enemy>().basestats.knocbackdef;
                    }
                    if(!knockbackdef)
                    {
                        enemy.MovePosition(other.transform.position += stats.knockback * Time.deltaTime * difference);
                        knockbackdealay = Time.time + 1f;
                    }
                    
                    
                }
                
            }
        }
    }
}
