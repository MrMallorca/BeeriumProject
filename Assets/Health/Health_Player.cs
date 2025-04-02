using System;
using UnityEngine;

public class Health_Player : MonoBehaviour
{
    public float health;
    public float maxHealth;


    private void Awake()
    {
        health = maxHealth;
    }
    private void Update()
    {
        TakeDamage();
    }

    private void TakeDamage()
    {
        
    }
}
