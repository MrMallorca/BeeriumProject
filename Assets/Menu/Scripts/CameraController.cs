using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
     GameObject leftTarget;
     GameObject rightTarget;

    public float minDistance;
   
    public float maxSize = 10f; 
    public float minSize = 5f; 
    public float sizeSmoothSpeed = 0.1f; 

    private Camera cam;

    private void Start()
    {
        cam = GetComponent<Camera>();

      

    }

    private void Update()
    {
        leftTarget = GameObject.FindGameObjectWithTag("Player1");
        rightTarget = GameObject.FindGameObjectWithTag("Player2");

        Debug.Log(leftTarget);
        Debug.Log(rightTarget);


        float distanceBetweenTargets = Mathf.Abs(leftTarget.transform.position.x - rightTarget.transform.position.x);

        float centerPosition = (leftTarget.transform.position.x + rightTarget.transform.position.x) / 2;

        transform.position = new Vector3(centerPosition, transform.position.y,
            distanceBetweenTargets > minDistance ? -distanceBetweenTargets : -minDistance);

        AdjustCameraSize(distanceBetweenTargets);
    }

    void AdjustCameraSize(float distance)
    {
        
        float targetSize = Mathf.Lerp(minSize, maxSize, distance / 20f);

        cam.orthographicSize = Mathf.Lerp(cam.orthographicSize, targetSize, sizeSmoothSpeed);
    }
   
}