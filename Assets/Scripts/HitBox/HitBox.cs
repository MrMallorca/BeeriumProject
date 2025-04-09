using UnityEngine;

public class HitBox : MonoBehaviour
{
    private BaseFighter fighter;

    private void Start()
    {
        fighter = GetComponentInParent<BaseFighter>();
    }
    private void OnTriggerEnter(Collider collision)
    {
        fighter.NotifyDamageReceived(10f);

    }
}
