using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObjects/Weapons")]
public class WeaponStats : ScriptableObject
{
    public float Range = 5f;
    public float FireRate = 10f;
    public int Damage = 10;
    public Vector3 Spread = new Vector3(0.1f, 0.1f, 0.1f);
    

}
