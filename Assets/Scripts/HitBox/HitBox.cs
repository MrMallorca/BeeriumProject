using UnityEngine;

public class HitBox : MonoBehaviour
{
    private void OnTriggerEnter(Collider collision) 
    {
        Collider[] hitbox = Physics.OverlapBox(collision.bounds.center, collision.bounds.extents, collision.transform.rotation);
        Debug.Log("Pega");
    }
}
