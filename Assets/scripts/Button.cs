using UnityEngine;
using UnityEngine.SceneManagement;

public class Button : MonoBehaviour {

    public void OnClick()
    {
        Debug.Log("Close click!");
        // 非表示にする
        gameObject.SetActive(false);
    }
    public void Open()
    { 
    // Canvasを表示する
    OptionController.SetActive("Option_Canvas", true);
    }
    //読み込み
    public void Return(string name)
    {
        Debug.Log("再読み込み");
        SceneManager.LoadScene(name);
           

    }
}
