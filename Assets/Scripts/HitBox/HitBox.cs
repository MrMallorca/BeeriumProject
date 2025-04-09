using UnityEngine;

public class HitBox : MonoBehaviour
{
    private BaseFighter enemyFighter;

    private float basicAttack = 5f;
    private float chargeAttack = 10f;
    private void Start()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        enemyFighter = other.gameObject.GetComponentInParent<BaseFighter>();

        if (gameObject.tag != enemyFighter.tag)
        {
            enemyFighter.NotifyDamageReceivedBasic(basicAttack);

        }
    }
 
}
