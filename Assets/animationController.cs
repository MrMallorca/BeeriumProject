using UnityEngine;
using UnityEngine.UI;  

public class AnimationController : MonoBehaviour
{
    public Animator animator;

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

    public void GoBackAnimation()
    {
        animator.SetTrigger("GoBack");
    }

}
