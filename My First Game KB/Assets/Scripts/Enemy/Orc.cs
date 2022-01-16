using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Orc : Enemy
{
    public Transform target;
    public float chaseRadius;
    public float attackRadius;
    public Animator animator;
    public GameObject lookingDirection;
    

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        Stats();
        target = GameObject.FindWithTag("Player").transform;
        
    }
    
    // Update is called once per frame
    void Update()
    {
        CheckDistance();

        
        if (target.position.x<transform.position.x)
        {
            transform.localScale = new Vector3(-1, 1, 1);
            lookingDirection.transform.localScale = new Vector3(-1, 1, 1);
        }
        else if(target.position.x > transform.position.x)
        {
            transform.localScale = Vector3.one;
            lookingDirection.transform.localScale = Vector3.one;
        }
        
        
    }
    void CheckDistance()
    {
        Vector3 targetDir = target.position - transform.position;
        Vector2 direction = new Vector2(targetDir.x, targetDir.y);
        lookingDirection.transform.up = direction;
        float distance = Vector3.Distance(target.position, transform.position);
        if (((distance<= chaseRadius || attacked) && distance>attackRadius-0.05f))
        {
            animator.SetBool("moving", true);
            transform.position = Vector3.MoveTowards(transform.position,target.position,speed * Time.deltaTime);           
        }
        else
        {
            animator.SetBool("moving", false);            
        }
        
    }

}
