using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CharacterSelectorManager : MonoBehaviour
{


    [SerializeField] TheLastStarsCS grid;

    [SerializeField] public Button fight_btn;
    [SerializeField] public Button BackButton;

    public static string confirmedCharacter1;
    public static string confirmedCharacter2;

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


            confirmedCharacter1 = grid.confirmedCharacter1.name;
            confirmedCharacter2 = grid.confirmedCharacter2.name;


            Debug.Log(confirmedCharacter1);
            Debug.Log(confirmedCharacter2);

            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        
    }

    
 
}
