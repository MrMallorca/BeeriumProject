using System;
using UnityEngine;

public class Player_Health : MonoBehaviour
{
    public float currentHealth;
    public float startingHealth = 60f;

    HealthBar healthBar;


    // La vida depende del personaje 
    //Se ha de instanciar la vida a traves de su script



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
        //HealthManage.instance.NotifyLifeChanged(this, currentHealth);
    }

    internal void SetHealthBar(HealthBar healthBar)
    {
        this.healthBar = healthBar;
    }
}
