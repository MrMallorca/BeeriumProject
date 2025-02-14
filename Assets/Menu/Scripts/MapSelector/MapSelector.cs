using System;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;

public class MapSelector : MonoBehaviour
{
    public List<Kingdom> kingdoms;

    private GameObject kingdomPointPrefab;
    private Transform modelTransform;

    private void Start()
    {
        foreach(Kingdom k in kingdoms)
        {
            SpawnKingdomPoint(k);
        }
    }

    private void SpawnKingdomPoint(Kingdom k)
    {
        GameObject kingdom = Instantiate(kingdomPointPrefab, modelTransform);
        kingdom.transform.localEulerAngles = new Vector3(k.x, k.y, 0);
    }

    public void LookAtKingdom(Kingdom k)
    {
        Transform cameraParent = Camera.main.transform.parent;
        Transform cameraPivot = cameraParent.parent;

        cameraParent.localEulerAngles = new Vector3(k.x, 0, 0);
        cameraPivot.localEulerAngles = new Vector3(cameraPivot.localEulerAngles.x, k.y,0);
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.E))
        {
            LookAtKingdom(kingdoms[0]);
        }
        if(Input.GetKeyDown(KeyCode.R))
        {
            LookAtKingdom(kingdoms[1]);
        }
    }
}

[System.Serializable]
public class Kingdom
{
    public string name;
    public float x, y;
}
