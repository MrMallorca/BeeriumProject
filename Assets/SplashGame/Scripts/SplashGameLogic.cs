using System.Collections;
using EasyTransition;
using UnityEngine;
using UnityEngine.Video;

public class SplashGameLogic : MonoBehaviour
{
    [SerializeField] string nextSceneName;
    [SerializeField] TransitionSettings transitionSettings;
    public float startDelay;

    private bool isTransitioning = false;


    

    
    private void Update()
    {
        if (isTransitioning)
        {
            return;
        }

        isTransitioning = true;
        TransitionManager.Instance().Transition(nextSceneName, transitionSettings, startDelay);


    }


}
