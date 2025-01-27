using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class MenuInGame : MonoBehaviour
{
    [SerializeField] GameObject menuInGame;
    private void Awake()
    {
        menuInGame.SetActive(false);
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            PauseGame();
        }
    }

    public void ReturnGame()
    {
        Time.timeScale = 1.0f;
        menuInGame.SetActive(false);
    }
    public void PauseGame()
    {
        Time.timeScale = 0f;
        menuInGame.SetActive(true);
    }
}
