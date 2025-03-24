using UnityEngine;

public class Player_Health : MonoBehaviour
{
    public float health;
    private float maxHealth;

    // La vida depende del personaje 
    //Se ha de instanciar la vida a traves de su script



    private void Start()
    {
        health = maxHealth;
        Debug.Log(health);
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
