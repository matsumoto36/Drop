using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

    public float limitTime;		//制限時間
    public Text timetext;

    public float playerpos;
    public float stagelength;
    public Slider stageprogress;
    //↓追加
    float _hp = 0;

    float time;//時間を記録する小数も入る変数
    Text text;
    //private bool    m_isVisibleTimer    = false;

    public int limitBaseScore;
    public int lifeBaseScore;
    public int tensuu;

    public float stageProgress; //進行度の割合

    [SerializeField]
    private Text _textGameManager;

    [SerializeField]
    private Image _imageMask;

    bool isPlayGame = false;

    void Start()
    {
        time = limitTime;
        //自分のインスペクター内からTextコンポーネントを取得。
        text = GetComponent<Text>();

        stagelength = FloorMove.GoalPos;
    }
    void Update () {

        if (!isPlayGame) return;

        //ここに時間の制御
        time -= Time.deltaTime;
        timetext.text = time.ToString("00.00");

        //タイムアップ
        if(time < 0)
        {
            time = 0;
            GameOver();
        }

        _textGameManager.text = "";

        ////HP上昇
        //_hp += 1;
        //if (_hp > stageprogress.maxValue)
        //{
        //    // 最大を超えたら0に戻す
        //    _hp = stageprogress.minValue;
        //}
        // HPゲージに値を設定
        stageprogress.value = FloorMove.player.position.y / stagelength;
    }
    /// <summary>
    /// ゲームを開始するときに
    /// ボタンで押すと実行される
    /// </summary>

    public void OnClickButtonStart()//ボタン
    {
        StartCoroutine(CountDownGameManager());
    }
    /// <summary>
    /// ゲームクリアしたときに実行される
    /// </summary>
    public void GameClear() {
        Debug.Log("GameClear");

        //スコアの計算
        int score = CalcScore();

        //リザルトを表示

	}

	/// <summary>
	/// ゲームオーバーになったとき実行される
	/// </summary>
	public void GameOver() {
        Debug.Log("GameOver");

        timetext.text = time.ToString("00.00");

        isPlayGame = false;

	}

	/// <summary>
	/// スコアを計算して返す
	/// </summary>
	/// <returns></returns>
	int CalcScore() {
        int x = limitBaseScore;
        int y = lifeBaseScore;
        int k;
        int h = tensuu;
        k=(x*h)+(y*h)*2;

        return k;
	}

	/// <summary>
	/// スタートの時間のカウントダウンを行う
	/// </summary>
	/// <returns></returns>
	IEnumerator CountDownGameManager() {
        _imageMask.gameObject.SetActive(true);
        _textGameManager.gameObject.SetActive(true);

        _textGameManager.text = "3";
        yield return new WaitForSeconds(1.0f);

        _textGameManager.text = "2";
        yield return new WaitForSeconds(1.0f);

        _textGameManager.text = "1";
        yield return new WaitForSeconds(1.0f);

        _textGameManager.text = "スタート！";
        yield return new WaitForSeconds(1.0f);

        isPlayGame = true;
        _textGameManager.text = "";
        _textGameManager.gameObject.SetActive(false);
        _imageMask.gameObject.SetActive(false);

        yield return null;

        //if (m_isVisibleTimer)
        //{
        //    //毎フレームの時間を加算。
        //    time += Time.deltaTime;
        //    //分.timeを60で割った値.
        //    int minute = (int)time / 60;
        //    //秒.timeを60で割った余り.
        //    int second = (int)time % 60;
        //    //テキスト形式の分・秒を用意.
        //    string minText, secText;

        //    if (minute < 10)
        //        //ToStringでint→Stringに変換.
        //        minText = "0" + minute.ToString();
        //    else
        //        minText = minute.ToString();
        //    if (second < 10)
        //        //上に同じく
        //        secText = "0" + second.ToString();
        //    else
        //        secText = second.ToString();

        //    text.text = "Time:" + minText + ":" + secText;
        //}
    }
}
