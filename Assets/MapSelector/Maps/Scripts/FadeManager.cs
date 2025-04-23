using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FadeManager : MonoBehaviour
{
    BaseFighter baseFighter;


    private Animator transitionAnimator;
    [SerializeField] float transitionTime = 1f;
    [SerializeField] Canvas canvas;

   // public GameObject objectToFind;
    string tagName = "VictoryTag";

    private void Start()
    {
        //objectToFind = GameObject.FindGameObjectWithTag(tagName);
        transitionAnimator = /*objectToFind.*/GetComponentInChildren<Animator>();
        
    }

    //private void Update()
    //{
    //    if (Input.GetKey(KeyCode.Space)) 
    //    {
    //        SceneLoad();
    //    }
    //}

    //public void LoadScene()
    //{
    //    transitionAnimator.SetTrigger("StartTransition");
    //    yield return new WaitForSeconds(transitionTime);
    //    SceneManager.LoadScene("Options");
    //}

    public IEnumerator SceneLoad()
    {
        if (baseFighter.currentHealth <= 0)
        {

            transitionAnimator.SetTrigger("StartTransition");
            yield return new WaitForSeconds(transitionTime);
            SceneManager.LoadScene("Options");
        }
    }
}
