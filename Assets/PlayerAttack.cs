using UnityEngine;
using System.Collections.Generic;
using System.Collections;
using System;



public class PlayerAttack : MonoBehaviour
{
   
    [SerializeField] private Transform attackTransform;
    [SerializeField] private float attackRange = 1.5f;
    [SerializeField] private LayerMask attacableLayer;


    private RaycastHit2D[] hits;
    private void Update()
    {
        if(UserInput.instance.controls.Attack.Attack.WasPerformedThisFrame())
        {
            //ATTACK
            Debug.Log("Attack");
        }
    }

    private void Attack()
    {
        hits = Physics2D.CircleCastAll(attackTransform.position, attackRange, transform.right,0f, attacableLayer);

        for (int i = 0; i < hits.Length; i++) 
        {
            enemyHealth enemyHealth = hits[i].collider.gameObject.GetComponent<enemyHealth>();

            //Damage
            Debug.Log("Damage");
        }
    }
}
