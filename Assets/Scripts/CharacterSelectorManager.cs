using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CharacterSelectorManager : MonoBehaviour
{

    [SerializeField] GameObject[] personajes;

    [SerializeField] TheLastStarsCS grid;

    [SerializeField] public Button fight_btn;
    [SerializeField] public Button BackButton;

    string currentScene;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        currentScene = SceneManager.GetActiveScene().name;


    }

    // Update is called once per frame
    void Update()
    {

    }

    public void StartGame()
    {
        

            PlayerPrefs.SetString("selectedCharacter1",grid.confirmedCharacter1.name);
            PlayerPrefs.SetString("selectedCharacter2", grid.confirmedCharacter2.name);

            Debug.Log(grid.confirmedCharacter1.name);
            Debug.Log(grid.confirmedCharacter2.name);

            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        
    }

    
 
}
