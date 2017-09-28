using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    //ゲームモードのID
    public static int publicId; 

   public void Loadscene(int id)
    {
        publicId = id;
        SceneManager.LoadScene("Game"); 
    }
    public void GameEnd()
    {
        Application.Quit();
    }
}
