using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour {
    [SerializeField]
    private Text _textGameController;

    [SerializeField]
    private Image _imageMask;

    void Start()
    {
        _textGameController.text = "";
    }

    public void OnClickButtonStart()
    {
        StartCoroutine(CountdownCoroutine());
    }

    IEnumerator CountdownCoroutine()//カウントダウン
    {
        _imageMask.gameObject.SetActive(true);
        _textGameController.gameObject.SetActive(true);

        _textGameController.text = "3";
        yield return new WaitForSeconds(1.0f);

        _textGameController.text = "2";
        yield return new WaitForSeconds(1.0f);

        _textGameController.text = "1";
        yield return new WaitForSeconds(1.0f);

        _textGameController.text = "GO!";
        yield return new WaitForSeconds(1.0f);

        _textGameController.text = "";
        _textGameController.gameObject.SetActive(false);
        _imageMask.gameObject.SetActive(false);
    }
}
