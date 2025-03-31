using UnityEngine;
using UnityEngine.SceneManagement;

public class changeScene : MonoBehaviour
{
    public void ChangeScene(string name)
    { SceneManager.LoadScene(name); }
}
