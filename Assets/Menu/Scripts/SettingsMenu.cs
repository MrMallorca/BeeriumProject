using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections.Generic;
using UnityEngine.SceneManagement;


public class OptionsMenu : MonoBehaviour
{

    
    

    void Start()
    {
        

    }
    private void Update()
    {

    }
    public void SetQuality(int quality)
    {
        QualitySettings.SetQualityLevel(quality);
    }

    public void SetFullScreen(bool isFullScreen)
    {
        Screen.fullScreen = isFullScreen;
    }

    public void BackButton(string level)
    {
        SceneManager.LoadScene(level);
    }
}
