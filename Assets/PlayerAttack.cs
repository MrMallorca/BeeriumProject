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


    //CoolDown
    [SerializeField] private float timeBtwAttacks = 0.15f;
    private float attackTimeCounter;


    //private Animator animator; DESCOMENTAR CUANDO SE TENGA LA ANIMACION

    private RaycastHit2D[] hits;

    private void Start()
    {
        //animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (UserInput.instance.controls.Attack.Attack.WasPerformedThisFrame() && attackTimeCounter>= timeBtwAttacks)
        {
            //Resert counter
            attackTimeCounter = 0f;

            Debug.Log("Attack");
            Attack();
            //animator.SetTrigger("attack");
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
    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(attackTransform.position, attackRange);
    }
}
