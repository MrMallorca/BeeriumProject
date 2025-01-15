using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform[] targets; // Los objetivos a seguir
    public float smoothSpeed = 0.125f; // Velocidad de suavizado
    public Vector3 offset; // Desplazamiento de la cámara

    void LateUpdate()
    {
        if (targets == null || targets.Length == 0)
        {
            return;
        }

        Vector3 desiredPosition = CalculateCenterPoint() + offset;
        desiredPosition.y = transform.position.y; // Mantener la altura actual de la cámara

        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        transform.position = smoothedPosition;
    }

    Vector3 CalculateCenterPoint()
    {
        Vector3 centerPoint = Vector3.zero;
        int activeCount = 0;

        foreach (Transform t in targets)
        {
            if (t.gameObject.activeInHierarchy) // Solo considerar los objetivos activos
            {
                centerPoint += t.position;
                activeCount++;
            }
        }

        if (activeCount > 0)
        {
            centerPoint /= activeCount; // Calcular el promedio
        }

        return centerPoint;
    }
}