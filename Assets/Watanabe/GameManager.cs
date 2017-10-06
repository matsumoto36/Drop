using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

    public float limitTime;		//制限時間

    public float playerpos;
    public float stagelength;
    public Slider stageprogress;

    float _hp = 0;

    float time;//時間を記録する小数も入る変数
    Text text;

    public int limitBaseScore;
    public int lifeBaseScore;
    public int tensuu;

    public float stageProgress; //進行度の割合

    [SerializeField]
    private Text _textGameManager;

    [SerializeField]
    private Image _imageMask;

    //追加
    public Text Score_Text;            // uGUI/Text
	public RectTransform resultPanel;
	public Image rankImage;
	public Sprite[] rankSprList;

	Player player;
	int score = 0;
    bool isPlayGame = false;

    void Start()
    {
		player = FindObjectOfType<Player>();
		time = limitTime;
        //自分のインスペクター内からTextコンポーネントを取得。
        text = GetComponent<Text>();

        stagelength = FloorMove.GoalPos;

		AudioManager.FadeIn(2, BGMType.Game);

		StartCoroutine(CountDownGameManager());
	}
    void Update () {
        
        if (!isPlayGame) return;

		//Debug
		if(Input.GetKeyDown(KeyCode.B)) GameClear();


        //ここに時間の制御
        time -= Time.deltaTime;

        //タイムアップ
        if(time < 0)
        {
            time = 0;
            GameOver();
        }

        _textGameManager.text = "";

         stageprogress.value = FloorMove.player.position.y / stagelength;


    }

    /// <summary>
    /// ゲームクリアしたときに実行される
    /// </summary>
    public void GameClear() {

		Debug.Log("GameClear");

		//アニメーションを再生
		StartCoroutine(ResultAnim());
	}

	/// <summary>
	/// ゲームオーバーになったとき実行される
	/// </summary>
	public void GameOver() {
        Debug.Log("GameOver");

        isPlayGame = false;

		StartCoroutine(ResultAnim());
	}

	public void BackButton() {

		AudioManager.Play(SEType.Button);
		AudioManager.FadeOut(1);

		SceneFader.MoveToScene("MenuScene", SceneMoveType.Short);
	}

	public void RetryButton() {

		AudioManager.Play(SEType.Button);
		AudioManager.FadeOut(1);

		SceneFader.MoveToScene("Game", SceneMoveType.Short);
	}

	/// <summary>
	/// スコアを計算して返す
	/// </summary>
	/// <returns></returns>
	int CalcScore() {

		//計算式
		//内部で予め制限時間を設けてゴールした時間を差し引いた数値×点数)
		// + 残りライフ×点数
		// * ゴール位置による倍率加算

		var timeScore = time * limitBaseScore;
		var lifeScore = player.HP * lifeBaseScore;

		return (int)((timeScore + lifeScore) * FindObjectOfType<GoalScore>().mag);
	}

	/// <summary>
	/// スタートの時間のカウントダウンを行う
	/// </summary>
	/// <returns></returns>
	IEnumerator CountDownGameManager() {
        _textGameManager.gameObject.SetActive(true);

        _textGameManager.text = "3";
        yield return new WaitForSeconds(1.0f);

        _textGameManager.text = "2";
        yield return new WaitForSeconds(1.0f);

        _textGameManager.text = "1";
        yield return new WaitForSeconds(1.0f);

        _textGameManager.text = "すたーと！";
        yield return new WaitForSeconds(1.0f);

        isPlayGame = true;
        _textGameManager.text = "";
        _textGameManager.gameObject.SetActive(false);

		AudioManager.Play(SEType.Start);

		player.Initialize();

		//ひとまずタイムアタック
		FindObjectOfType<SceanManegement>().TimeAttack();
    }

	IEnumerator ResultAnim() {

		isPlayGame = false;
		player.canInput = false;

		//スコアの計算
		score = CalcScore();

		yield return new WaitForSeconds(2);

		//リザルトを表示
		resultPanel.gameObject.SetActive(true);

		if(player.isDeath) {
			AudioManager.Play(SEType.Game_Over);
		}
		else {
			AudioManager.Play(SEType.Clear_Goal);
		}



		//順位発表
		RankingManager.LoadRanking();
		RankingManager.SetRankData(score);
		RankingManager.SaveRanking();

		//スコアをアニメーション
		yield return StartCoroutine("ScoreCount", 5f);//早さ

		var rank = RankingManager.GetRank(score);
		if(rank < 3) {
			rankImage.enabled = true;
			rankImage.sprite = rankSprList[rank];
		}
	}

	/// <summary>
	/// スコアをどぅるどぅるする
	/// </summary>
	/// <param name="second">どのくらいの時間で完了するのか</param>
	/// <returns></returns>
	public IEnumerator ScoreCount(float second)
    {
        float t = 0;//経過時間

        while (t <  1.0f )
        {
			if(Input.GetMouseButtonDown(0)) break;

            t += Time.deltaTime / second;//経過時間の計算
            float startScore = 0;//スタートの値：最小値
            float Score = Mathf.Lerp(startScore, score, t);//どぅるどぅるする
            Score_Text.text = string.Format("{0}", (int)(Score));//テキストとして表示
            yield return null;
        }

		Score_Text.text = string.Format("{0}", score);
	}
}
