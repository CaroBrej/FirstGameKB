using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    public Transform attackingPoint;
    public GameObject attackPrefab;
    //public Statistics stats;
    public Enemy stats;
    public float attackRadius;
    private float elapsedTime = 0;
    public Transform target;

    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindWithTag("Player").transform;
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Vector3.Distance(target.position, transform.position) <= attackRadius)
        {
            if (Time.time >= elapsedTime)
            {
                elapsedTime = Time.time + (1 / stats.AttackSpeed);
                StartCoroutine(AttackCo());
            }
        }

    }
    void Attack()
    {
        Vector3 rotation = attackingPoint.rotation.eulerAngles;
        rotation = new Vector3(rotation.x, rotation.y, rotation.z + 90);
        GameObject clone = Instantiate(attackPrefab, attackingPoint.position, Quaternion.Euler(rotation));
        Destroy(clone, 0.25f);
    }

    IEnumerator AttackCo()
    {

        yield return new WaitForSeconds((1 / stats.AttackSpeed));
        if (Vector3.Distance(target.position, transform.position) <= attackRadius)
        {
            Attack();
        }
            
    }
}