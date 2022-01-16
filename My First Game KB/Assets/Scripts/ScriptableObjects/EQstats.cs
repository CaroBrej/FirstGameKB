using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "EQstats", menuName = "EQstats")]
public class EQstats : ScriptableObject
{
    public string EqName;
    public EQtype EqType;
    public float speed;
    public int HP;
    public int dmg;
    public float attackspeed;

    public enum EQtype
    {
        weapon,
        head,
        body,
        arms,
        legs,
        boots,
        necklace,
        ring
    }
}
