using System;
using UnityEngine;

public class Player_Health : MonoBehaviour
{
    public float currentHealth;
    public float startingHealth = 60f;

    HealthBar healthBar;

    private void Start()
    {
        currentHealth = startingHealth;
        Debug.Log(currentHealth);
    }

    public void TakeDamage(int amount)
    {
        currentHealth -= amount;
        if(currentHealth <= 0)
        {
            Destroy(gameObject);
        }

        healthBar.NotifyLifeChanged(currentHealth, startingHealth);
    }

    public void aaaaaaaaaaa()
    {
        healthBar.NotifyLifeChanged(currentHealth, startingHealth);
    }
    //private void Update()
    //{
    //    healthBar.NotifyLifeChanged(currentHealth, startingHealth);
    //}
    internal void SetHealthBar(HealthBar healthBar)
    {
        this.healthBar = healthBar;
    }
}
