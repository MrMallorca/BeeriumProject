using UnityEngine;
using Unity.Cinemachine;
using UnityEngine.UI;
using UnityEngine.Rendering;
using UnityEngine.SceneManagement;

public class MapSelectorCameraController : MonoBehaviour
{
    [SerializeField] CinemachineCamera Yellowcamera;
    [SerializeField] CinemachineCamera Pinkcamera;
    [SerializeField] CinemachineCamera Greencamera;
    [SerializeField] CinemachineCamera Startcamera;

    [SerializeField] Button YellowBtn;
    [SerializeField] Button PinkBtn;
    [SerializeField] Button GreenwBtn;


    private void Start()
    {
        Yellowcamera.enabled = false;
        Pinkcamera.enabled = false;
        Greencamera.enabled = false;
        Startcamera.enabled = true;
    }
    public void OnClickYellow()
    {
        Debug.Log("Yellow camera enable");

        Yellowcamera.enabled = true;
        Pinkcamera.enabled = false;
        Greencamera.enabled = false;
        Startcamera.enabled = false;
    }

    public void OnClickGreen()
    {
        Debug.Log("Green camera enable");

        Yellowcamera.enabled = false;
        Pinkcamera.enabled = false;
        Startcamera.enabled = false;
        Greencamera.enabled = true;
    }
    public void OnClickPink()
    {
        Debug.Log("Pink camera enable");

        Yellowcamera.enabled = false;
        Pinkcamera.enabled = true;
        Greencamera.enabled = false;
        Startcamera.enabled = false;
    }

    public void SelectScene(string scene)
    { SceneManager.LoadScene(scene); }

}
