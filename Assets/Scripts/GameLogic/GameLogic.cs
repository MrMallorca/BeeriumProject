using UnityEngine;

public class GameLogic : MonoBehaviour
{
    //Aqui se intanciaran los personajes y se les asignaran las barras de vida.

    [SerializeField] GameObject[] personajes;
    [SerializeField] GameObject player1;
    [SerializeField] GameObject player2;

    private void Start()
    {
        string personaje1 = CharacterSelectorManager.confirmedCharacter1;


        foreach (GameObject personaje in personajes)
        {
            if (personaje.name == personaje1)
            {
                Instantiate(personaje, transform.position = new Vector3(-6.3f,-3.55f,0), Quaternion.identity, player1.transform);
                break;
            }
        }

        string personaje2 = CharacterSelectorManager.confirmedCharacter2;


        foreach (GameObject personaje in personajes)
        {
            if (personaje.name == personaje2)
            {
                Instantiate(personaje, transform.position = new Vector3(4.94f, -3.55f, 0), Quaternion.identity, player1.transform);
                break;
            }
        }
    }

}