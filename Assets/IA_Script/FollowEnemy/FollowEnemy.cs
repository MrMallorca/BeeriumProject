using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class FollowEnemy : MonoBehaviour
{
    public float speed;
    [SerializeField] Transform enemy;
    public float minDistance;

    private bool doingCombo;

    private void Update()
    {
        //AI DISTANCE TO PLAYER
        if(Vector2.Distance(transform.position,enemy.position)> minDistance)
        {
            transform.position = 
                Vector2.MoveTowards(transform.position, enemy.position, speed * Time.deltaTime);
        }
        else if(!doingCombo) //ATACK CODE
        {
            Debug.Log("COMBOS");
            doingCombo = true;
        }
    }
}
