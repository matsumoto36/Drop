using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class RankingManager : MonoBehaviour {

	const string SAVEKEY = "Rank";
	const int SAVECOUNT = 3;

	static RankingManager myManager;

	int[] rankingScore = new int[SAVECOUNT];

	static RankingManager() {
		new GameObject("[RankingManager]").AddComponent<RankingManager>();
	}

	void Awake() {

		if(!myManager) {
			myManager = this;
			DontDestroyOnLoad(gameObject);
		}
		else {
			Destroy(gameObject);
		}
	}

	/// <summary>
	/// 保存しているランキングデータをロードする
	/// </summary>
	public static void LoadRanking() {

		for(int i = 0;i < SAVECOUNT;i++) {
			myManager.rankingScore[i] =
				PlayerPrefs.GetInt(SAVEKEY + i, 0);
		}
	}

	/// <summary>
	/// 現在のランキングデータを保存する
	/// </summary>
	public static void SaveRanking() {

		for(int i = 0;i < SAVECOUNT;i++) {
			PlayerPrefs.SetInt(SAVEKEY + i, myManager.rankingScore[i]);
		}
	}

	/// <summary>
	/// 特定の順位のデータを取得する
	/// </summary>
	/// <param name="rank"></param>
	/// <returns></returns>
	public static int GetScore(int rank) {
		return myManager.rankingScore[rank];
	}

	/// <summary>
	/// スコアの順位を取得する
	/// </summary>
	/// <param name="score"></param>
	/// <returns></returns>
	public static int GetRank(int score) {
		for(int i = 0;i < SAVECOUNT;i++) {
			if(myManager.rankingScore[i] <= score) return i;
		}

		return SAVECOUNT;
	}

	/// <summary>
	/// ランキングにデータを入れる(ソート込)
	/// </summary>
	/// <param name="score"></param>
	public static void SetRankData(int score) {

		var rankData = myManager.rankingScore.ToList();
		rankData.Add(score);

		rankData.Sort((int x, int y) => {
			return y.CompareTo(x);
		});

		rankData.RemoveAt(SAVECOUNT);

		myManager.rankingScore = rankData.ToArray();
	}
}
