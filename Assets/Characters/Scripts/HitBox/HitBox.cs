using System.Collections;
using UnityEngine;
using static UnityEngine.Rendering.DebugUI;

public class HitBox : MonoBehaviour
{
    private BaseFighter enemyFighter;

    [SerializeField] public int hitCount;
    float knockbackForce = 600f;


    Rigidbody otherRb;
    Vector3 direction;


    private void Start()
    {
        hitCount = 0;
    }
    private void OnTriggerEnter(Collider other)
    {
        enemyFighter = other.gameObject.GetComponentInParent<BaseFighter>();

        if (gameObject.tag != enemyFighter.tag)
        {
        
           hitCount += 1;
           enemyFighter.NotifyDamageReceived(5f);

            otherRb = enemyFighter.GetComponentInParent<Rigidbody>();

            print(enemyFighter.name);

            Vector3 flatDirection = otherRb.position - transform.parent.position;
            flatDirection.y = 0f;
            flatDirection.Normalize();
            flatDirection.y = 0.2f; // Salto hacia atrás

            otherRb.mass = 0.5f;

            otherRb.AddForce(flatDirection * knockbackForce * Time.deltaTime, ForceMode.Impulse);
            
           
        }
    }


    public IEnumerator ResetHitCount()
    {
        yield return new WaitForSeconds(1.5f);
        hitCount = 0;
    }



}
