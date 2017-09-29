using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

	public float limitTime;		//制限時間
	public float stageProgress;	//進行度の割合
	
	void Update () {
		//ここに時間の制御
	}

	/// <summary>
	/// ゲームを開始するときに
	/// ボタンで押すと実行される
	/// </summary>
	public void GameStart() {

	}

	/// <summary>
	/// ゲームクリアしたときに実行される
	/// </summary>
	public void GameClear() {

	}

	/// <summary>
	/// ゲームオーバーになったとき実行される
	/// </summary>
	public void GameOver() {

	}

	/// <summary>
	/// スコアを計算して返す
	/// </summary>
	/// <returns></returns>
	int CalcScore() {
		return 0;
	}

	/// <summary>
	/// スタートの時間のカウントダウンを行う
	/// </summary>
	/// <returns></returns>
	IEnumerator CountDown() {
		yield return null;
	}
}
