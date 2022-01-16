using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Statistics basestats;
    //protected Statistics stats = new Statistics();
    
    protected float speed;
    protected int maxHP;
    protected int HP;
    protected int dmg;
    protected float attackspeed;
    protected float knockback;
    protected bool knockbackdef;
    protected bool attacked = false;



    // Start is called before the first frame update
    void Start()
    {
        //Stats();
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    protected void Stats()
    {
        //stats = new Statistics(basestats.speed, basestats.HP, basestats.dmg, basestats.attackspeed,basestats.knockback);  
        speed = basestats.speed;
        HP = basestats.HP;
        dmg = basestats.dmg;
        attackspeed = basestats.attackspeed;
        knockback = basestats.knockback;
        maxHP = basestats.maxHP;
        knockbackdef = basestats.knocbackdef;
    }

    public void Hurt(int dmg)
    {
        HP = HP - dmg;
        if(HP<=0)
        {
            HP = 0;
            Die();
        }
        attacked = true;
    }

    public void Die()
    {
        Destroy(this.gameObject);
    }

    public float AttackSpeed 
    { 
        get
        {
            return attackspeed;
        } 
        
    }

}
