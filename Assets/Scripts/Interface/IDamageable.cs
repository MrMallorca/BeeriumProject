using UnityEngine;

public interface IDamageable
{
    public void Damage_Player1(float damageAmount);
    public void Damage_Player2(float damageAmount);

    public bool HasTakenDamage { get; set;}
}
