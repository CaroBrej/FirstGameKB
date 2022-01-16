using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerStats : MonoBehaviour
{
    public Statistics stats;
    public Statistics basestats;
    public UserInterfaceBar healthBar;
    public VectorValue PlayerSpwan;
    public PLayerEq Inventory;
    public EquippedItems equippedItems;
    public EquippedItems baseEquippedItems;
    // Start is called before the first frame update
    void Start()
    {
        if(PlayerSpwan.LoadBaseStats)
        {
            StatReset();
        }
        LoadHealthBar();
        SceneSpawn();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StatReset()
    {
        stats.speed = basestats.speed;
        stats.HP = basestats.HP;
        stats.dmg = basestats.dmg;
        stats.attackspeed = basestats.attackspeed;
        stats.knockback = basestats.knockback;
        stats.maxHP = basestats.maxHP;
        stats.knocbackdef = basestats.knocbackdef;

        for (int i = 0; i < baseEquippedItems.items.Length; i++)
        {
            equippedItems.items[i] = baseEquippedItems.items[i];
        }

        Inventory.Items.Clear();
    }

    public void Hurt(int value)
    {
        stats.HP = stats.HP - value;
        if (stats.HP < 0) stats.HP = 0;
        healthBar.SetValue(stats.HP);
        if (stats.HP == 0)
        {
            Die();
        }
    }

    public void FullHeal()
    {
        stats.HP = stats.maxHP;
        healthBar.SetValue(stats.HP);
    }

    public void Heal(int value)
    {
        stats.HP = stats.HP + value;
        if (stats.HP > stats.maxHP) stats.HP = stats.maxHP;
        healthBar.SetValue(stats.HP);
    }

    public void Die()
    {
        Destroy(this.gameObject);
        SceneManager.LoadScene("MainMenu");
    }

    public void SceneSpawn()
    {
        transform.position = PlayerSpwan.initialValue;
    }

    public void LoadHealthBar()
    {
        healthBar.SetMaxValue(stats.maxHP);
        healthBar.SetValue(stats.HP);
    }

    public void EquipItem(EQstats item)
    {
        stats.maxHP = stats.maxHP+item.HP;
        stats.speed = stats.speed + item.speed;
        stats.dmg = stats.dmg + item.dmg;
        stats.attackspeed = stats.attackspeed + item.attackspeed;

        for (int i = 0; i < equippedItems.items.Length; i++)
        {
            if (item.EqType== equippedItems.items[i].EqType)
            {
                stats.maxHP = stats.maxHP - equippedItems.items[i].HP;
                stats.speed = stats.speed - equippedItems.items[i].speed;
                stats.dmg = stats.dmg - equippedItems.items[i].dmg;
                stats.attackspeed = stats.attackspeed - equippedItems.items[i].attackspeed;
                if(equippedItems.items[i].EqName!="None")
                {
                    Inventory.Items.Add(equippedItems.items[i]);
                }
                Inventory.Items.Remove(item);
                equippedItems.items[i] = item;
                break;
            }
        }
        
        healthBar.SetMaxValue(stats.maxHP);
    }
    public void DestroyItem(EQstats item)
    {
        Inventory.Items.Remove(item);
    }

    
    
}
