using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewGun", menuName = "Items/New Gun")]
public class Gun : Item
{
    [Header("Specs")]
    public float damage;
    public float stoppingPower;
    public float condition;
    public float fireRate;

    public int magazineSize;

    public GameObject prefab;

    public enum GunTypes
    {
        Handgun,
        Shotgun,
        Rifle,
        Bolt_Rifle,
        Assault_Rifle
    }

    public GunTypes type;
}
