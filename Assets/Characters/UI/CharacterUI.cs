using UnityEngine;

[System.Serializable]
[CreateAssetMenu(fileName = "New Character", menuName = "Character")]
public class CharacterUI : ScriptableObject
{
    [SerializeField] string characterName;
    [SerializeField] Sprite characterSprite;
    

}
