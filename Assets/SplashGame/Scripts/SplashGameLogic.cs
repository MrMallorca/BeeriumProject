using System.Collections;
using EasyTransition;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Video;

public class SplashGameLogic : MonoBehaviour
{
    [SerializeField] InputActionReference start;

    [SerializeField] string nextSceneName;
    [SerializeField] TransitionSettings transitionSettings;
    public float startDelay;

    private bool transitionIsFinish = false;

    [SerializeField] CanvasGroup[] images;
    [SerializeField] TextMeshProUGUI title;
    [SerializeField] TextMeshProUGUI pressKeyText;

    private void OnEnable()
    {
        start.action.Enable();

        start.action.performed += onStartGame;
    }
    private void Start()
    {
        StartCoroutine(FadeImagesSequentially());


    }

   

    public void onStartGame(InputAction.CallbackContext ctx)
    {
        if (transitionIsFinish)
        {
            TransitionManager.Instance().Transition(nextSceneName, transitionSettings, startDelay);
        }
    }

    private IEnumerator BlinkText()
    {
        title.text = "The Last Stars";

        while (true)
        {
            pressKeyText.text = " ";
            yield return new WaitForSeconds(0.5f);
            pressKeyText.text = "Press any key";
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

    private void OnDisable()
    {
        start.action.Disable();

        start.action.performed -= onStartGame;
    }
}