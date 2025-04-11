using UnityEngine;

public class HitBox : MonoBehaviour
{
    private BaseFighter enemyFighter;


    private void OnTriggerEnter(Collider other)
    {
        enemyFighter = other.gameObject.GetComponentInParent<BaseFighter>();

        if (gameObject.tag != enemyFighter.tag)
        {
           
           enemyFighter.NotifyDamageReceived(5f);
            
            
        }
    }
 
}
