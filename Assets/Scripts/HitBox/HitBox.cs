using UnityEngine;

public class HitBox : MonoBehaviour
{
    private void OnTriggerEnter(Collider collision)
    {
        Debug.Log("Pega");

    }
}
