using UnityEngine;
using UnityEngine.UI;  

public class AnimationController : MonoBehaviour
{
     Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }
    public void PlayCameraAnimation()
    {
        animator.SetTrigger("PlayCameraAnimation");
    }

    public void PlaySoundAnimation()
    {
        animator.SetTrigger("PlaySoundAnimation");
    }

    public void PlayGraphicsAnimation()
    {
        animator.SetTrigger("PlayGraphicsAnimation");
    }

    public void PlayHowToAnimation()
    {
        animator.SetTrigger("PlayHowToAnimation");
    }

    public void GoBackAnimation()
    {
        animator.SetTrigger("GoBack");
    }

}
