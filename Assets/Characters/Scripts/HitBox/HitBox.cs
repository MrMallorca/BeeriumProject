using System.Collections;
using UnityEngine;
using static UnityEngine.Rendering.DebugUI;

public class HitBox : MonoBehaviour
{
    private BaseFighter enemyFighter;

    [SerializeField] public int hitCount;
    float knockbackForce = 30f;


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


            if (hitCount >= 3)
            {
                ApplyKnockback(enemyFighter);
                StartCoroutine(ResetHitCount());
            }
        }
    }

    private void ApplyKnockback(BaseFighter target)
    {
        Rigidbody rb = target.GetComponent<Rigidbody>();
        if (rb != null)
        {
            // Dirección de empuje contraria al atacante
            Vector3 direction = (target.transform.position - transform.position).normalized;
            direction.y = 0; // Evita empuje vertical
            direction.Normalize(); // Vuelve a normalizar el vector sin la Y
            rb.AddForce(direction * knockbackForce, ForceMode.Impulse);

        
        }
    }

    public IEnumerator ResetHitCount()
    {
        yield return new WaitForSeconds(1.5f);
        hitCount = 0;
    }



}
