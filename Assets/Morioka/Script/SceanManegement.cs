using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SceanManegement : MonoBehaviour
{
    //InvisibleStatのインスタンス
    GameObject InvStart;
    //ステージセレクトボタンのインスタンス
    GameObject[] SelectBt = new GameObject[2];
    //ゲームスクリプトのインスタンス
    StageGenerator Sgene;
    SimpleMove main;

    int id;

    private void Start()
    {
        //インスタンスを生成
        InvStart = GameObject.Find("InvisibleStart");
        SelectBt[0] = GameObject.Find("Time");
        SelectBt[1] = GameObject.Find("Score");
        Sgene = GetComponent<StageGenerator>();
        main = FindObjectOfType<SimpleMove>();
        main.enabled = false;

        //selectを非表示
        SelectBt[0].SetActive(false);
        SelectBt[1].SetActive(false);
    }


    /// <summary>
    /// モードセレクトへの遷移
    /// </summary>
    public void Select()
    {
        //InvisibleStartを非アクティブ
        InvStart.SetActive(false);

        //selectを表示
        SelectBt[0].SetActive(true);
        SelectBt[1].SetActive(true);
    }

    /// <summary>
    /// タイムアタックへの遷移
    /// </summary>
    public void TimeAttack()
    {
        id = 1;
        //Sgene.Generat(id);
        main.enabled = true;
        SelectBt[0].SetActive(false);
        SelectBt[1].SetActive(false);
    }

    /// <summary>
    /// スコアアタックへの遷移
    /// </summary>
    public void ScoreAttack()
    {
        id = -1;
        //Sgene.Generat(id);
        main.enabled = true;
        SelectBt[0].SetActive(false);
        SelectBt[1].SetActive(false);
    }
}
