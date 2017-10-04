using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test_CheckRank : MonoBehaviour {

	// Use this for initialization
	void Start () {
		RankingManager.SetRankData(1001);
		RankingManager.SetRankData(10);
		RankingManager.SetRankData(100);
		RankingManager.SetRankData(5000);

		Debug.Log(RankingManager.GetScore(0));
		Debug.Log(RankingManager.GetScore(1));
		Debug.Log(RankingManager.GetScore(2));
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
