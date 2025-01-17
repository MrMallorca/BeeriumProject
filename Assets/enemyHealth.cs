using UnityEngine;

public class enemyHealth : MonoBehaviour
{
    [SerializeField] private float maxHealth;

    private float currentHealth;
    private void Start()
    {
        currentHealth = maxHealth;
    }
}
