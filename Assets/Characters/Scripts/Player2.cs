using UnityEngine;

public class Player2 : MonoBehaviour
{
    [SerializeField] Transform enemyPlayer;

    private SpriteRenderer spriteRenderer;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        Vector3 direction = enemyPlayer.position - transform.position;

        if (direction.x < 0) 
        {
            spriteRenderer.flipX = true; 
        }
        else 
        {
            spriteRenderer.flipX = false; 
        }
    }
}
