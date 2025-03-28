using System;
using UnityEngine;

public class HealthManage : MonoBehaviour, IDamageable
{
    public static HealthManage instance;


    private float maxHealth_Player1;
    private float maxHealth_Player2;

    [SerializeField] GameObject Player1;
    [SerializeField] GameObject Player2;

     public HealthBar healthBar;

    private float currentHealth_Player1;
    private float currentHealth_Player2;

    public bool HasTakenDamage { get; set; }

    public void StartComponents()
    {
        ////currentHealth_Player1 = Player1.GetComponent<Diana>().health;
        ////currentHealth_Player2 = Player2.GetComponent<Diana>().health;

        //Debug.Log(currentHealth_Player1);
        //Debug.Log(currentHealth_Player2);

        //healthBar.maxHealth(maxHealth_Player1, maxHealth_Player2);
    }

    public void NotifyDamageReceived(float damageAmount)
    {
        //HasTakenDamage = true;
        //currentHealth_Player1 -= damageAmount;
        //healthBar.SetHealth(currentHealth_Player1, currentHealth_Player2);

        //if(healthBar.slider_Player1.value <= 0)
        //{
        //    Die_Player1();
        //}
    }    
    public void Damage_Player2(float damageAmount)
    {
        //HasTakenDamage = true;
        //currentHealth_Player2 -= damageAmount;
        //healthBar.SetHealth(currentHealth_Player1, currentHealth_Player2);

        //if(healthBar.slider_Player2.value <= 0)
        //{
        //    Die_Player2();
        //}
    }

    private void Die_Player1()
    {
        //Debug.Log("Ha muerto player1");
        //Player1.transform.GetChild(0).gameObject.SetActive(false);
    }
    private void Die_Player2()
    { 
        //Debug.Log("Ha muerto player2");
        //Player2.transform.GetChild(0).gameObject.SetActive(false);
    }

    private void RestartPlayers()
    {
        //Player1.transform.GetChild(0).gameObject.SetActive(true);
        //Player2.transform.GetChild(0).gameObject.SetActive(true);
    }


    private void Update()
    {
        //if (healthBar.slider_Player1.value <= 0)
        //{
        //    Die_Player1();

        //}
        
        //if (healthBar.slider_Player2.value <= 0)
        //{
        //    Die_Player2();
        //}
    }
}
