using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Fight_Btn : MonoBehaviour
{
    [SerializeField] public Button fight_btn;
    [SerializeField] public Button BackButton;
    public void ChangeScene(string scene)
    { SceneManager.LoadScene(scene);
        Debug.Log("PUTAAAAAAA");
    }
}
