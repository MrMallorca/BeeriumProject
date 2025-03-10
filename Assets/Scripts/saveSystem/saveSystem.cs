using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class saveSystem : MonoBehaviour
{
    PlayerMovement2 playerMove;
    HealthBar healthBar;

    private void Awake()
    {
        healthBar = FindObjectOfType<HealthBar>();
    }
}
