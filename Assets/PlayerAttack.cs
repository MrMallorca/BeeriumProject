using UnityEngine;
using System.Collections.Generic;
using System.Collections;
using System;



public class PlayerAttack : MonoBehaviour
{
   
    [SerializeField] private Transform attackTransform;
    [SerializeField] private float attackRange = 1.5f;
    [SerializeField] private LayerMask attacableLayer;

    [SerializeField] private float damageAmount = 1f;


    //CD
    [SerializeField] private float timeBtwAttacks = 0.15f;
    private float attackTimeCounter;


    public bool ShouldBeDamaging { get; private set; } = false;

    private List<IDamageable> iDamageables = new List<IDamageable>();


    private Animator animator;

    private RaycastHit2D[] hits;

    private void Start()
    {
        animator = GetComponent<Animator>();

        attackTimeCounter = timeBtwAttacks;
    }

    private void Update()
    {
        if (UserInput.instance.controls.Attack.Attack.WasPerformedThisFrame() && attackTimeCounter>= timeBtwAttacks)
        {
            //Resert counter
            attackTimeCounter = 0f;

            Debug.Log("Attack");
            Attack();
            //DamageWhileSlashIsActive();

            animator.SetTrigger("attack");
        }
        attackTimeCounter += Time.deltaTime;
    }

    private void Attack()
    {
        hits = Physics2D.CircleCastAll(attackTransform.position, attackRange, transform.right,0f, attacableLayer);

        for (int i = 0; i < hits.Length; i++) 
        {
           IDamageable iDamageable = hits[i].collider.gameObject.GetComponent<IDamageable>();

            if (iDamageable != null) 
            {
                //apply damage
                iDamageable.Damage(damageAmount);
            }
        }
    }

    public IEnumerator DamageWhileSlashIsActive()
    {
        Debug.Log("aaaaa");
        ShouldBeDamaging = true;
        while(ShouldBeDamaging)
        {
            Debug.Log("wwwww");
            hits = Physics2D.CircleCastAll(attackTransform.position, attackRange, transform.right, 0f, attacableLayer);

            for (int i = 0; i < hits.Length; i++)
            {
                IDamageable iDamageable = hits[i].collider.gameObject.GetComponent<IDamageable>();

                if (iDamageable != null && !iDamageable.HasTakenDamage)
                {
                    //apply damage
                    iDamageable.Damage(damageAmount);
                    iDamageables.Add(iDamageable);
                }
            }

            yield return null;
        }

        ReturnAttackableToDamageable();
       
    }

    private void ReturnAttackableToDamageable()
    {
        foreach(IDamageable thingsThatWasDamage in iDamageables)
        {
            thingsThatWasDamage.HasTakenDamage = false;
        }
        iDamageables.Clear();
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(attackTransform.position, attackRange);
    }

    #region

    public void ShouldBeDamagingToTrue()
    {
        ShouldBeDamaging = true;
    }

    public void ShouldBeDamagingToFalse()
    {
        ShouldBeDamaging = false;
    }


    #endregion
}
