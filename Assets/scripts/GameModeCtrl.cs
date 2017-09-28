using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameModeCtrl : MonoBehaviour
{

    //ゲームモードのid,0がタイムアタック,1がスコアアタック
    int id;

    //タイムの加減算決定
    int addSub;

    float time;//時間を記録する小数も入る変数
    Text text;

    // Use this for initialization
    void Start ()
    {
        id = SceneController.publicId;

        time = 0;
        //自分のインスペクター内からTextコンポーネントを取得。
        text = GetComponent<Text>();

        switch (id)
        {
            case 0:
                addSub = 1;
                break;
            case 1:
                addSub = -1;
                break;
        }
    }
	
	// Update is called once per frame
	void Update ()
    {
        //毎フレームの時間を加算。
        time += Time.deltaTime * addSub;
        //分.timeを60で割った値.
        int minute = (int)time / 60;
        //秒.timeを60で割った余り.
        int second = (int)time % 60;
        //テキスト形式の分・秒を用意.
        string minText, secText;

        if (minute < 10)
            //ToStringでint→Stringに変換.
            minText = "0" + minute.ToString();
        else
            minText = minute.ToString();
        if (second < 10)
            //上に同じく
            secText = "0" + second.ToString();
        else
            secText = second.ToString();

        text.text = "Time:" + minText + ":" + secText;
    }
}
