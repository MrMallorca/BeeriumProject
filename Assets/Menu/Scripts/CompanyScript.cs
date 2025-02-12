using System;
using System.Collections;
using DG.Tweening;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class CompanyScript : MonoBehaviour
{
    [SerializeField] string name;
    
    void Start()
    {
        Wait();
        ChangeScene();
    }
    IEnumerator Wait()
    {
        yield return new WaitForSecondsRealtime(100f);
    }
    public void ChangeScene()
    {
        SceneManager.LoadScene(name);
    }
}
