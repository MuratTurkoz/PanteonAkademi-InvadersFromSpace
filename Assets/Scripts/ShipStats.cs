using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ShipStats
{
    [Range(1, 6)]
    public int maxHealth;
    [HideInInspector]
    public int currentHealth;
    [HideInInspector]
    public int maxLifes = 3;
    [HideInInspector]
    public int currentLifes = 3;
    public float shipSpeed;
    public float fireRate;
     ShipStats()
    {
        currentLifes = maxLifes;
        currentHealth = maxHealth;
       
    }
}
