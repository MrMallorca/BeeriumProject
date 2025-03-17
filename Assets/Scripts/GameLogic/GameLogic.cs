using UnityEngine;

public class GameLogic : MonoBehaviour
{
    //Aqui se intanciaran los personajes y se les asignaran las barras de vida.

    [SerializeField] GameObject[] personajes;

    private void Start()
    {
        string personaje1 = CharacterSelectorManager.confirmedCharacter1;


        foreach (GameObject personaje in personajes)
        {
            if (personaje.name == personaje1)
            {
                Instantiate(personaje, transform.position = new Vector3(-6.3f,-3.55f,0), Quaternion.identity);
                personaje.tag = "Player1";
                Debug.Log(personaje.tag);
                break;
            }
        }

        string personaje2 = CharacterSelectorManager.confirmedCharacter2;


        foreach (GameObject personaje in personajes)
        {
            if (personaje.name == personaje2)
            {
                Instantiate(personaje, transform.position = new Vector3(4.94f, -3.55f, 0), Quaternion.identity);
                personaje.tag = "Player2";
                Debug.Log(personaje.tag);
                break;
            }
        }
    }

}
