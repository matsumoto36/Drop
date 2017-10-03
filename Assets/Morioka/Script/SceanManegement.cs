using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SceanManegement : MonoBehaviour
{
    //InvisibleStatのインスタンス
    GameObject InvStart;
    //ゲームスクリプトのインスタンス
    StageGenerator Sgene;

    int id;

    private void Start()
    {
        //インスタンスを生成
        InvStart = GameObject.Find("Invisible");
        Sgene = GetComponent<StageGenerator>();
    }


    /// <summary>
    /// モードセレクトへの遷移
    /// </summary>
    public void Select()
    {
        //InvisibleStartを非アクティブ
        InvStart.SetActive(false);
    }

    /// <summary>
    /// タイムアタックへの遷移
    /// </summary>
    public void TimeAttack()
    {
        id = 1;
        //Sgene.Generat(id);

    }

    /// <summary>
    /// スコアアタックへの遷移
    /// </summary>
    public void ScoreAttack()
    {
        id = -1;
        //Sgene.Generat(id);
    }
}
