using UnityEngine;

public interface IDamageable
{
    public void NotifyDamageReceivedBasic(float damageAmount);

    public void NotifyDamageReceivedStrong(float damageAmount);

    public bool HasTakenDamage { get; set;}



}
