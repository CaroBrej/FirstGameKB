using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attacking : MonoBehaviour
{
    public Transform attackingPoint;
    public GameObject slash_prefab;
    public GameObject arrow_prefab;
    public Statistics stats;
    public float bulletForce = 20f;
    private float elapsedTime = 0;
    public int weapon = 1;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Alpha2))
        {
            weapon = 2;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            weapon = 1;
        }
        if(Input.GetButton("Fire1"))
        {
            if(Time.time>=elapsedTime)
            {
                elapsedTime = Time.time + (1 / stats.attackspeed);
                if(weapon==1)
                {
                    Slash();
                }
                else
                {
                    Shoot();
                }
                    
            }

           
        }

        void Slash()
        {
            Vector3 rotation = attackingPoint.rotation.eulerAngles;
            rotation = new Vector3(rotation.x,rotation.y,rotation.z+90);
            GameObject clone=Instantiate(slash_prefab,attackingPoint.position,Quaternion.Euler(rotation));
            Destroy(clone,0.25f);
        }

        void Shoot()
        {
            GameObject arrow = Instantiate(arrow_prefab, attackingPoint.position,attackingPoint.rotation);
            Rigidbody2D clonerb=arrow.GetComponent<Rigidbody2D>();
            clonerb.AddForce(attackingPoint.up * bulletForce, ForceMode2D.Impulse);
            Destroy(arrow, 2f);
        }
    }
}
