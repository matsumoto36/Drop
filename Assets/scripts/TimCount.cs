using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimCount : MonoBehaviour {

    float time;//時間を記録する小数も入る変数
    Text text;

	void Start () {

        time = 0;
        //自分のインスペクター内からTextコンポーネントを取得。
        text = GetComponent<Text>();
        	
	}
    
	void Update () {

        //毎フレームの時間を加算。
        time += Time.deltaTime;
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
