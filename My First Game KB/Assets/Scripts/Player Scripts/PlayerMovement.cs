using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Statistics stats;
    //public Statistics basestats;
    private Rigidbody2D myRigidbody;
    private BoxCollider2D boxCollider;
    private Vector3 moveDelta;
    public Animator animator;
    public GameObject lookingDir;
    public GameObject ContexClue;
    //public Camera cam;
    //private Vector2 mousePosition;
    // Start is called before the first frame update
    private void Start()
    {
        //StatReset();
        animator = GetComponent<Animator>();
        boxCollider = GetComponent<BoxCollider2D>();
    }
    private void Update()
    {
        FaceDirection();
    }
    // Update is called once per frame
    private void FixedUpdate()
    {
        
        moveDelta = Vector3.zero;
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical"); 
        moveDelta = new Vector3(x, y, 0);
        
        
        if (moveDelta.x>0 )
        {    
            transform.localScale = Vector3.one;
            lookingDir.transform.localScale = Vector3.one;
            ContexClue.transform.localScale = Vector3.one;
        }       
        else if(moveDelta.x<0 )
        {
            transform.localScale = new Vector3(-1, 1, 1);
            lookingDir.transform.localScale = new Vector3(-1, 1, 1);
            ContexClue.transform.localScale = new Vector3(-1, 1, 1);
        }       
        if(moveDelta!=Vector3.zero)
        {
            animator.SetBool("moving",true);
            myRigidbody.MovePosition(transform.position+=stats.speed * moveDelta * Time.deltaTime);
         
        }else
        {
            animator.SetBool("moving",false);
        }
        
       


    }

    void FaceDirection()
    {
        Vector3 mousePosition = Input.mousePosition;
        mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);

        Vector2 direction = new Vector2(mousePosition.x - transform.position.x, mousePosition.y - transform.position.y);
        lookingDir.transform.up = direction;
    }
    /*
    void StatReset()
    {
        stats.speed = basestats.speed;
        stats.HP = basestats.HP;
        stats.dmg = basestats.dmg;
        stats.attackspeed = basestats.attackspeed;
        stats.knockback = basestats.knockback;
        
    }
    */
}
