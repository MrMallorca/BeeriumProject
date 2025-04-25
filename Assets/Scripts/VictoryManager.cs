using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class VictoryManager : MonoBehaviour
{
    private Animator transitionAnimator;
    [SerializeField] float transitionTime = 5f;
    [SerializeField] Canvas canvas;

    void Update()
    {
        bool playerMuerto = false;

        foreach (BaseFighter bf in BaseFighter.fighterList)
        {
            playerMuerto |= bf.currentHealth < 0f;

            if(bf.currentHealth < 0f)
            {
                playerMuerto = true;
                StartCoroutine(SceneLoad());

                ChargeScene();
            }


        }

        //if (playerMuerto)
        //{
        //    StartCoroutine(SceneLoad());
        //}

        //Debug.Log(baseFighter.currentHealth);
        //if (baseFighter.currentHealth <= 0)
        //{
        //    Debug.Log("player1 victory");
        //}
    }

    public IEnumerator SceneLoad()
    {
        //if (baseFighter.currentHealth <= 0)
        //{
        canvas.gameObject.SetActive(true);
        transitionAnimator.SetTrigger("StartTransition");
        yield return new WaitForSeconds(transitionTime);
        //}

    }

    public static void ChargeScene()
    {
        Debug.Log("Siguiente escena");
        SceneManager.LoadScene("Options");
    }
}
