using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class CompanyScript : MonoBehaviour
{
    public void ChangeScene(string name)
    {
        SceneManager.LoadScene(name);
    }
}
