using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour {
    
    //Text用変数
    public Text ScoreText;

    //Score計算用変数
    private int score = 0;


	void Start () {

        //初期Scoreを代入して表示
        ScoreText.text = "Score: 0";
	}
	
    //アイテムを取った時加算
    void OnTriggerEnter2D(Collider2D collison)
    {
        //振れたよ
        Debug.Log("ふれたよ");
        string yourTag = collison.gameObject.tag;

        if (yourTag=="Item")
        {
            //加算
            Debug.Log("加算");
            score += 100;
        }
        SetScore();
    }

    void SetScore()
    {
        //表示
        Debug.Log("表示");
        ScoreText.text = string.Format("Score:{0}", score);
    }
}
