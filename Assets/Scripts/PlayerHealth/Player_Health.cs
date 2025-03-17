using UnityEngine;

public class Player_Health : MonoBehaviour
{
    public float health;
    public float maxHealth = 100f;

    private void Start()
    {
        health = maxHealth;
    }
    public void TakeDamage(int amount)
    {
        health -= amount;
        if(health <= 0)
        {
            Destroy(gameObject);
        }
    }
}
