using UnityEngine;
using UnityEngine.SceneManagement;

public class OptionController : MonoBehaviour {

    //Option_canvasのインスタンス
    static Canvas _canvas;
    void Start()
    {
        // Canvasコンポーネントを保持
        _canvas = GetComponent<Canvas>();
        gameObject.SetActive(false);
    }

    /// 表示・非表示を設定する
    public static void SetActive(string name, bool b)
    {
            // 子の要素をたどる
            if (_canvas.name == name)
            {
                // 指定した名前と一致
                // 表示フラグを設定
                _canvas.gameObject.SetActive(b);
                Debug.Log(_canvas.name);
                // おしまい
                return;
            }
        // 指定したオブジェクト名が見つからなかった
        Debug.LogWarning("Not found objname:" + name);
    }
   
}
