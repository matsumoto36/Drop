using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{

   public void Loadscene(string SceneName)
    {
        Debug.Log(SceneName);
        SceneManager.LoadScene(SceneName); 
    }
    public void GameEnd()
    {
        Application.Quit();
    }
}
