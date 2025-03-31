using System;
using UnityEngine;

public class Player_Health : HealthBar
{
    public float currentHealth;
    [HideInInspector]  public float startingHealth = 70f;

    protected override void DoAwake()
    {
        Debug.Log("Player_Health DoAwake");
        currentHealth = startingHealth;
        Debug.Log(currentHealth);
        //Destroy(this);
    }


    public void TakeDamage(int amount)
    {
        currentHealth -= amount;
        if(currentHealth <= 0)
        {
            Destroy(gameObject);
        }

        NotifyLifeChanged(currentHealth, startingHealth);
    }

    //public void aaaaaaaaaaa()
    //{
    //    healthBar.NotifyLifeChanged(currentHealth, startingHealth);
    //}

    private void Update()
    {
        if (slider.value <= 0) 
        {
            Debug.Log("Muerto");
        }
    }

    //internal void SetHealthBar(HealthBar healthBar)
    //{
    //    this.healthBar = healthBar;
    //}
}
