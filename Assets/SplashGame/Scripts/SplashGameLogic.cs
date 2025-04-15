using System.Collections;
using EasyTransition;
using TMPro;
using UnityEngine;
using UnityEngine.Video;

public class SplashGameLogic : MonoBehaviour
{
    [SerializeField] string nextSceneName;
    [SerializeField] TransitionSettings transitionSettings;
    public float startDelay;

    private bool transitionIsFinish = false;

    [SerializeField] CanvasGroup[] images;
    [SerializeField] TextMeshProUGUI title;


    private void Start()
    {
        StartCoroutine(FadeImagesSequentially());


    }

    private void Update()
    {
        if(Input.anyKeyDown && transitionIsFinish)
        {
            TransitionManager.Instance().Transition(nextSceneName, transitionSettings, startDelay);
        }
    }

    private IEnumerator BlinkText()
    {
        while (true)
        {
            title.text = " ";
            yield return new WaitForSeconds(0.5f);
            title.text = "The Last Stars";
            yield return new WaitForSeconds(0.5f);
        }
    }

    private IEnumerator FadeImagesSequentially()
    {
        yield return new WaitForSeconds(startDelay);

        foreach (CanvasGroup image in images)
        {
            float t = 0f;
            image.alpha = 0f;

            while (t < 1f)
            {
                t += Time.deltaTime;
                image.alpha = Mathf.Clamp01(t); 
                yield return null;
            }

            image.alpha = 1f; 

            yield return new WaitForSeconds(0.3f);
        }
        transitionIsFinish = true;

        StartCoroutine(BlinkText());


    }
}