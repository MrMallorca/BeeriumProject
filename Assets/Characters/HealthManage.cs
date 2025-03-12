using UnityEngine;

public class HealthManage : MonoBehaviour, IDamageable
{
    public static HealthManage instance;


    [SerializeField] private float maxHealth_Player1 = 100f;
    [SerializeField] private float maxHealth_Player2 = 100f;

    public HealthBar healthBar;

    private float currentHealth_Player1;
    private float currentHealth_Player2;

    public bool HasTakenDamage { get; set; }

    private void Start()
    {
        currentHealth_Player1 = maxHealth_Player1;
        currentHealth_Player2 = maxHealth_Player2;
        healthBar.maxHealth(maxHealth_Player1, maxHealth_Player2);
    }
    public void Damage_Player1(float damageAmount)
    {
        HasTakenDamage = true;
        currentHealth_Player1 -= damageAmount;
        healthBar.SetHealth(currentHealth_Player1, currentHealth_Player2);

        if(healthBar.slider_Player1.value <= 0)
        {
            Die_Player1();
        }
    }    
    public void Damage_Player2(float damageAmount)
    {
        HasTakenDamage = true;
        currentHealth_Player2 -= damageAmount;
        healthBar.SetHealth(currentHealth_Player1, currentHealth_Player2);

        if(healthBar.slider_Player2.value <= 0)
        {
            Die_Player2();
        }
    }

    private void Die_Player1()
    {  
        Debug.Log("Ha muerto player1");
    } 
    private void Die_Player2()
    { 
        Debug.Log("Ha muerto player2");
    }


    private void Update()
    {
        if (healthBar.slider_Player1.value <= 0)
        {
            Debug.Log("11111111111111111111111111");
        }
        
        if (healthBar.slider_Player2.value <= 0)
        {
            Debug.Log("2222222222222222222222222");
        }
    }
}
