using UnityEngine;

public class enemyHealth : MonoBehaviour, IDamageable
{
    [SerializeField] private float maxHealth;

    private float currentHealth;



    private void Start()
    {
        currentHealth = maxHealth;
    }
    public void Damage(float damageAmount)
    {
        currentHealth -= damageAmount;

        if(currentHealth <= 0)
        {
            Die();
        }
    }
    private void Die()
    { 
        Destroy(gameObject);
    }
}
