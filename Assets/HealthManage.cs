using UnityEngine;

public class HealthManage : MonoBehaviour, IDamageable
{
    [SerializeField] private float maxHealth = 100f;

    public HealthBar healthBar;

    private float currentHealth;

    public bool HasTakenDamage { get; set; }

    private void Start()
    {
        currentHealth = maxHealth;
        healthBar.maxHealth(maxHealth);
    }
    public void Damage(float damageAmount)
    {
        HasTakenDamage = true;
        currentHealth -= damageAmount;
        healthBar.SetHealth(currentHealth);

        if(currentHealth <= 0)
        {
            Die();
        }
    }
    private void Die()
    { 
        Destroy(gameObject);
        Debug.Log("Ha muerto");
    }
}
